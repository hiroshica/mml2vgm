﻿using Core;
using mml2vgmIDE;
using System;
using System.Windows.Forms;

namespace SoundManager
{
    public delegate bool Enq(outDatum od, long Counter, Chip Chip, EnmDataType Type, int Address, int Data, object ExData);
    public delegate bool Deq(ref outDatum od, ref long Counter, ref Chip Chip, ref EnmDataType Type, ref int Address, ref int Data, ref object ExData);
    public delegate void Snd(outDatum od, long Counter, Chip Chip, EnmDataType Type, int Address, int Data, object ExData);

    public class SoundManager : IDisposable
    {

        public const int DATA_SEQUENCE_FREQUENCE = 44100;
        public Setting setting = null;

        /// <summary>
        /// ミュージックデータ解析
        ///     処理周期 : 無し
        ///     データ受取時 : DataSenderへ即送信
        ///                  DataSenderが受け取ることができない状態の場合は、待ち合わせする
        /// </summary>
        private DataMaker dataMaker;

        /// <summary>
        /// データ送信
        ///     処理周期 : 44100Hz(Default)
        ///     SeqCounter値に合わせて各ChipSenderへデータを振り分けながら送信。
        ///     ChipSenderが受け取ることができない状態の場合は、待ち合わせする
        /// </summary>
        private DataSender dataSender;

        /// <summary>
        /// エミュチップ専門データ送信
        ///     処理周期 : 無し
        ///     データが来たら、エミュレーションむけリングバッファにEnqueue
        ///     Enqueueできない場合は、待ち合わせする
        /// </summary>
        private EmuChipSender emuChipSender;

        /// <summary>
        /// 実チップ専門データ送信
        ///     処理周期 : 無し
        ///     データが来たら、実チップ向けコールバックを実施
        ///     待ち合わせ無し
        /// </summary>
        private RealChipSender realChipSender;

        /// <summary>
        /// 割り込み処理カウンタ
        /// 割り込みが発生している(1以上の)間、DataSenderは各チップへデータを送信しない
        /// </summary>
        private int interruptCounter = 0;

        private bool fadeOut = false;
        private int loopCounter = 0;


        private volatile object lockObj = new object();


        /// <summary>
        /// セットアップ
        /// </summary>
        /// <param name="DriverAction">ミュージックドライバーの1フレームあたりの処理を指定してください</param>
        /// <param name="RealChipAction">実チップ向けデータ送信処理を指定してください</param>
        /// <param name="startData">DataSenderが初期化を行うときに出力するデータを指定してください</param>
        public void Setup(
            DriverAction DriverAction
            , Snd RealChipAction
            , Deq ProcessingData
            , Deq SetMMLParameter
            , DataSeqFrqEventHandler DataSeqFrqCallBack
            , Action WaitSync
            , PackData[] startData
            , long EmuDelay
            , long RealDelay
)
        {
            dataMaker = new DataMaker(DriverAction);
            emuChipSender = new EmuChipSender(DATA_SEQUENCE_FREQUENCE);
            realChipSender = new RealChipSender(RealChipAction, DATA_SEQUENCE_FREQUENCE);
            dataSender = new DataSender(
                emuChipSender.Enq
                , realChipSender.Enq
                , ProcessingData
                , SetMMLParameter
                , startData
                , null
                , DataSeqFrqCallBack
                , WaitSync
                , EmuDelay
                , RealDelay
                );

            dataMaker.parent = this;
            emuChipSender.parent = this;
            realChipSender.parent = this;
            dataSender.parent = this;

            dataMaker.Mount();
            dataSender.Mount();
            emuChipSender.Mount();
            realChipSender.Mount();
        }

        public void SetMusicInterruptTimer(MusicInterruptTimer m)
        {
            if (dataSender == null) return;
            dataSender.SetMusicInterruptTimer(m);
        }
        public MusicInterruptTimer GetMusicInterruptTimer()
        {
            return dataSender.GetMusicInterruptTimer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stopData">DataSenderが演奏停止を行うときに出力するデータを指定してください</param>
        public void SetStopData(PackData[] stopData)
        {
            dataSender.SetStopData(stopData);
        }

        public void Release()
        {
            if (dataMaker != null) dataMaker.Unmount();
            if (dataSender != null) dataSender.Unmount();
            if (emuChipSender != null) emuChipSender.Unmount();
            if (realChipSender != null) realChipSender.Unmount();
        }

        public void RequestStart(SendMode mode, bool useEmu, bool useReal)
        {
            SetInterrupt();
            fadeOut = false;
            loopCounter = 0;

            Mode = mode;//orではない

            dataSender.Init();

            if ((mode & SendMode.MML) == SendMode.MML)
            {
                if(dataMaker.unmount) dataMaker.Mount();
                dataMaker.RequestStart();
                while (!dataMaker.IsRunning())
                {
                    //Application.DoEvents();
                }
            }

            dataSender.RequestStart();
            while (!dataSender.IsRunning())
            {
                Application.DoEvents();
            }

            if (useEmu)
                emuChipSender.RequestStart();
            if (useReal)
                realChipSender.RequestStart();

            ResetInterrupt();

            isVirtualOnlySend = false;
            if (setting.other.PlayDeviceCB)
            {
                if (useEmu && !useReal)
                {
                    isVirtualOnlySend = true;
                    //Audio.stopDataVirtulaOnlySend = dataSender.stopData;
                }
            }
        }

        public void RequestStop()
        {
            if (dataMaker != null)
            {
                while (dataMaker.IsRunning())
                {
                    dataMaker.RequestStop();
                    Application.DoEvents();//Waveデバイス対策
                }
            }
            if (dataSender != null)
            {
                while (dataSender.IsRunning())
                {
                    dataSender.RequestStop();
                    Application.DoEvents();//Waveデバイス対策
                }
            }
            if (emuChipSender != null)
            {
                while (emuChipSender.IsRunning())
                {
                    emuChipSender.RequestStop();
                    Application.DoEvents();//Waveデバイス対策
                    emuChipSender.recvBuffer.Init(DATA_SEQUENCE_FREQUENCE);
                }
            }
            if (realChipSender != null)
            {
                while (realChipSender.IsRunning())
                {
                    realChipSender.RequestStop();
                    Application.DoEvents();//Waveデバイス対策
                }
            }

            //if (isVirtualOnlySend)
            {
                Audio.stopDataVirtulaOnlySend = dataSender.stopData;

            }
        }

        public void RequestStopAsync()
        {
            if (dataMaker != null)
            {
                dataMaker.RequestStop();
            }
            if (dataSender != null)
            {
                dataSender.RequestStop();
            }
            if (emuChipSender != null)
            {
                emuChipSender.RequestStop();
            }
            if (realChipSender != null)
            {
                realChipSender.RequestStop();
            }
        }

        public void RequestStopAtDataMaker()
        {
            dataMaker.RequestStop();
        }

        public void RequestStopAtEmuChipSender()
        {
            if (emuChipSender == null) return;
            emuChipSender.RequestStop();
        }

        public void RequestStopAtRealChipSender()
        {
            realChipSender.RequestStop();
        }

        public bool IsRunningAtDataMaker()
        {
            if (dataMaker == null) return false;
            return dataMaker.IsRunning();
        }

        public bool IsRunningAtDataSender()
        {
            if (dataSender == null) return false;
            return dataSender.IsRunning();
        }

        public bool IsRunningAtRealChipSender()
        {
            if (realChipSender == null) return false;
            return realChipSender.IsRunning();
        }

        public long GetDriverSeqCounterDelay()
        {
            return (long)(DATA_SEQUENCE_FREQUENCE * 0.5);
        }

        public void SetFadeOut()
        {
            lock (lockObj)
            {
                fadeOut = true;
            }
        }

        public bool GetFadeOut()
        {
            lock (lockObj)
            {
                return fadeOut;
            }
        }

        public void CountUpLoopCounter()
        {
            lock (lockObj)
            {
                loopCounter++;
            }
        }

        public int GetLoopCounter()
        {
            lock (lockObj)
            {
                return loopCounter;
            }
        }

        public void SetSpeed(double sp)
        {
            if (dataSender != null) dataSender.SetSpeed(sp);
        }

        public double GetSpeed()
        {
            if (dataSender == null) return 1.0;
            return dataSender.GetSpeed();
        }

        public bool IsRunningAtEmuChipSender()
        {
            if (emuChipSender == null) return false;
            return emuChipSender.IsRunning();
        }

        /// <summary>
        /// DriverのデータをEnqueueするメソッドを取得する
        /// </summary>
        /// <returns></returns>
        public Enq GetDriverDataEnqueue()
        {
            return dataSender.Enq;
        }

        /// <summary>
        /// EmuのデータをDequeueするメソッドを取得する
        /// </summary>
        /// <returns></returns>
        public Deq GetEmuDataDequeue()
        {
            return emuChipSender.Deq;
        }

        /// <summary>
        /// RealのデータをDequeueするメソッドを取得する
        /// </summary>
        /// <returns></returns>
        public Deq GetRealDataDequeue()
        {
            return realChipSender.Deq;
        }

        public RingBuffer GetEmuRecvBuffer()
        {
            return emuChipSender.recvBuffer;
        }

        public bool IsRunningAsync()
        {
            if (dataMaker != null) if (dataMaker.IsRunning())
                    return true;
            if (dataSender != null) if (dataSender.IsRunning())
                    return true;
            if (emuChipSender != null) if (emuChipSender.IsRunning())
                    return true;
            if (realChipSender != null) if (realChipSender.IsRunning())
                    return true;

            return false;
        }

        public void SetInterrupt()
        {
            lock (lockObj)
            {
                interruptCounter++;
            }
        }

        public void ResetInterrupt()
        {
            lock (lockObj)
            {
                if (interruptCounter > 0) interruptCounter--;
            }
        }

        public bool GetInterrupt()
        {
            lock (lockObj)
            {
                return (interruptCounter > 0);
            }
        }

        public long GetSeqCounter()
        {
            if (dataSender == null) return 0;
            return dataSender.GetSeqCounter();
        }

        public long GetDataSenderBufferCounter()
        {
            if (dataSender == null) return 0;
            return dataSender.GetRingBufferCounter();
        }

        public long GetDataSenderBufferSize()
        {
            if (dataSender == null) return 0;
            return dataSender.GetRingBufferSize();
        }

        public long GetEmuChipSenderBufferSize()
        {
            if (emuChipSender == null) return 0;
            return emuChipSender.GetRingBufferSize();
        }

        public long GetRealChipSenderBufferSize()
        {
            if (realChipSender == null) return 0;
            return realChipSender.GetRingBufferSize();
        }

        public long GetProcessOverFlowCounter()
        {
            if (dataSender == null) return 0;
            return dataSender.GetProcessOverFlowCounter();
        }

        public double GetProcess1Lap()
        {
            if (dataSender == null) return 0;
            return dataSender.GetProcess1Lap();
        }

        public double GetProcess2Lap()
        {
            if (dataSender == null) return 0;
            return dataSender.GetProcess2Lap();
        }
        public int GetSkipFrame()
        {
            if (dataSender == null) return 0;
            return dataSender.GetSkipFrame();
        }

        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        public SendMode Mode { get; set; }

        private int _CurrentTempo = 120;
        public int CurrentTempo
        { get => _CurrentTempo; set => _CurrentTempo = value; }

        private int _CurrentClockCount = 192;
        public int CurrentClockCount
        { get => _CurrentClockCount; set => _CurrentClockCount = value; }

        private int _CurrentNoteLength = 0;
        public int CurrentNoteLength
        { get => _CurrentNoteLength; set => _CurrentNoteLength = value; }

        private string _CurrentChip = "";
        public string CurrentChip
        { get => _CurrentChip; set => _CurrentChip = value; }
        private int _CurrentCh = 0;
        public int CurrentCh
        { get => _CurrentCh; set => _CurrentCh = value; }
        public bool isVirtualOnlySend { get; internal set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dataMaker.Dispose();
                    dataSender.Dispose();
                    emuChipSender.Dispose();
                    realChipSender.Dispose();
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
                // TODO: 大きなフィールドを null に設定します。

                disposedValue = true;
            }
        }

        // TODO: 上の Dispose(bool disposing) にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
        // ~Player() {
        //   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
        //   Dispose(false);
        // }

        // このコードは、破棄可能なパターンを正しく実装できるように追加されました。
        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
            Dispose(true);
            // TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
            // GC.SuppressFinalize(this);
        }

        public void ClearData()
        {
            dataSender.ClearBuffer();
        }

        public void SetMode(SendMode mode)
        {
            Mode |= mode;
        }

        public void ResetMode(SendMode mode)
        {
            Mode &= (~mode) & SendMode.Both;
        }

        public void AddDataSeqFrqEvent(DataSeqFrqEventHandler h)
        {
            dataSender.OnDataSeqFrq += h;
        }

        public void RemoveDataSeqFrqEvent(DataSeqFrqEventHandler h)
        {
            dataSender.OnDataSeqFrq -= h;
        }

        internal void ForcedProc()
        {
            dataSender.ForcedStepUpSeqCounterProc();
        }

        #endregion
    }

}
