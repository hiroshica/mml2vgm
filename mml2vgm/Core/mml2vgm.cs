﻿using musicDriverInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;

namespace Core
{
    /// <summary>
    /// コンパイラ
    /// </summary>
    public class Mml2vgm
    {

        public ClsVgm desVGM = null;
        public outDatum[] desBuf = null;
        public bool outVgmFile = true;
        public bool outTraceInfoFile = false;
        public string desTiFn = "";

        private object document;
        private string srcFn;
        private string desFn;
        private string stPath;
        private Action<string> Disp = null;
        private string wrkPath;
        private string[] srcTxt;

        private int pcmDataSeqNum = 0;
        private bool bufferMode = false;
        private bool writeFileMode;

        public bool doSkip = false;
        public bool doSkipStop = false;
        public Point caretPoint = Point.Empty;
        public bool usePCMCacheFromGUI = false;
        public bool isIDE = false;
        private bool doJumping=false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="srcFn">ソースファイル</param>
        /// <param name="desFn">出力ファイル</param>
        /// <param name="stPath">アプリケーションパス</param>
        /// <param name="disp">メッセージ表示メソッド</param>
        public Mml2vgm(object document, string srcFn, string desFn, string stPath, Action<string> disp)
        {
            this.document = document;
            this.srcFn = srcFn;
            this.desFn = desFn;
            this.stPath = stPath;
            this.Disp = disp;
            this.wrkPath = Path.GetDirectoryName(Path.GetFullPath(srcFn));
            this.srcTxt = null;
            bufferMode = false;
            this.writeFileMode = true;
            this.doJumping = false;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="srcFn">ソースファイル</param>
        /// <param name="desFn">出力ファイル</param>
        /// <param name="stPath">アプリケーションパス</param>
        /// <param name="disp">メッセージ表示メソッド</param>
        /// <param name="wrkPath">取り込みファイルが存在するパス(通常はソースファイルと同じパス)</param>
        public Mml2vgm(object document, string srcFn, string desFn, string stPath, Action<string> disp, string wrkPath)
        {
            this.document = document;
            this.srcFn = srcFn;
            this.desFn = desFn;
            this.stPath = stPath;
            this.Disp = disp;
            this.wrkPath = wrkPath;
            this.srcTxt = null;
            bufferMode = false;
            this.writeFileMode = true;
            this.doJumping = false;
        }

        public Mml2vgm(object document, string[] srcTxt, string srcFn, string desFn, string stPath, Action<string> disp, string wrkPath, bool writeFileMode)
        {
            this.document = document;
            this.srcFn = srcFn;
            this.desFn = desFn;
            this.stPath = stPath;
            this.Disp = disp;
            this.wrkPath = wrkPath;
            this.srcTxt = srcTxt;
            this.bufferMode = true;
            this.writeFileMode = writeFileMode;
            this.doJumping = false;
        }

        /// <summary>
        /// コンパイル開始
        /// </summary>
        /// <returns></returns>
        public int Start()
        {
            try
            {
                Disp(string.Format(msg.get("I04000"), "mml2vgm"));
                Disp("");

                int ret = Start_Analyze();
                if (ret != 0) return ret;

                Disp(msg.get("I04004"));
                //wrkPath PCMファイル取り込み対象パス
                if (desVGM.instPCMDatSeq.Count > 0) GetPCMData(wrkPath);

                Disp(msg.get("I04005"));

                MMLAnalyze mmlAnalyze = new MMLAnalyze(desVGM);
                mmlAnalyze.doSkip = doSkip;
                mmlAnalyze.caretPoint = caretPoint;

                if (mmlAnalyze.Start() != 0)
                {
                    msgBox.setErrMsg(string.Format(
                        msg.get("E04003")
                        , mmlAnalyze.linePos.row), mmlAnalyze.linePos);
                    return -1;
                }


                if(!isIDE && mmlAnalyze.useJumpPoint)
                {
                    doJumping = true;
                    desVGM.doJumping = true;
                }


                if (desVGM.info.format != enmFormat.ZGM)
                {
                    switch (desVGM.info.format)
                    {
                        case enmFormat.VGM:
                            Disp(msg.get("I04006"));
                            desBuf = desVGM.Vgm_getByteData(mmlAnalyze.mmlData);
                            Disp(msg.get("I04007"));
                            break;
                        case enmFormat.XGM:
                            Disp(msg.get("I04008"));
                            desBuf = desVGM.Xgm_getByteData(mmlAnalyze.mmlData);
                            Disp(msg.get("I04009"));
                            break;
                        default:
                            break;
                    }

                    if (desBuf == null)
                    {
                        if (desVGM.linePos != null)
                        {
                            msgBox.setErrMsg(string.Format(
                                msg.get("E04004")
                                , desVGM.linePos.row), desVGM.linePos);
                        }
                        return -1;
                    }

                    if (outVgmFile && writeFileMode)
                    {
                        Disp(msg.get("I04021"));
                        if (desVGM.info.format == enmFormat.VGM)
                            OutVgmFile(desBuf);
                        else
                            OutXgmFile(desBuf);
                    }

                }
                else
                {

                    Disp(msg.get("I04023"));
                    ZGMmaker zmake = new ZGMmaker();
                    desVGM.jumpPointClock = -1;
                    desVGM.jumpChannels = new List<Tuple<enmChipType, int>>();
                    desBuf = zmake.Build(desVGM);
                    Disp(msg.get("I04024"));

                    if (desBuf == null)
                    {
                        msgBox.setErrMsg(string.Format(
                            msg.get("E04004")
                            , desVGM.linePos.row), desVGM.linePos);
                        return -1;
                    }

                    if (outVgmFile && writeFileMode)
                    {
                        Disp(msg.get("I04025"));
                        zmake.OutFile(desBuf, desFn);
                    }

                }

#if !DEBUG
                if (outTraceInfoFile && writeFileMode)
                {
#endif
                    Disp(msg.get("I04022"));
                    OutTraceInfoFile(desBuf);
#if !DEBUG
                }
#endif

                Result();

                FileInformation.loopCounter = desVGM.loopClock;
                FileInformation.totalCounter = desVGM.lClock;
                FileInformation.format = desVGM.info.format;

                return 0;
            }
            catch (Exception ex)
            {
                Disp(ex.Message);
                msgBox.setErrMsg(string.Format(msg.get("E04005")
                    , (desVGM.linePos == null ? "-" : desVGM.linePos.row.ToString())
                    , ex.Message
                    , ex.StackTrace), desVGM.linePos);
                return -1;
            }
            finally
            {
                Disp(msg.get("I04011"));
                Disp("");
            }
        }

        public int Start_Analyze()
        {
            List<Line> src = null;

            //.gwiファイルの読み込み
            if (!bufferMode)
            {
                Disp(msg.get("I04001"));
                srcFn = srcFn.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar);
                if (!File.Exists(srcFn))
                {
                    msgBox.setErrMsg(msg.get("E04000"), new LinePos(document,srcFn));
                    return -1;
                }

                Disp(msg.get("I04002"));
                //string path = Path.GetDirectoryName(Path.GetFullPath(srcFn));
                //wrkPath インクルードファイル取り込み対象パス
                srcTxt = File.ReadAllLines(srcFn);
            }

            //インクルードファイルのマージ
            src = GetSrc(srcTxt, wrkPath);

            if (src == null)
            {
                msgBox.setErrMsg(msg.get("E04001"), new LinePos(document, srcFn));
                return -1;
            }

            Disp(msg.get("I04003"));
            //ざっくりくわけ
            SourceParser sp = new SourceParser();
            sp.Parse(src);

            desVGM = new ClsVgm(stPath, sp);
            desVGM.doJumping = doJumping;
            desVGM.doSkip = doSkip;
            desVGM.doSkipStop = doSkipStop;
            desVGM.caretPoint = caretPoint;
            desVGM.wrkPath = wrkPath;
            if (desVGM.Analyze(src) != 0)
            {
                msgBox.setErrMsg(string.Format(
                    msg.get("E04002")
                    , desVGM.linePos.row), desVGM.linePos);
                return -1;
            }

            return 0;
        }

        private void OutVgmFile(outDatum[] desBuf)
        {
            List<byte> lstBuf = new List<byte>();
            int dmySkipCount = 0;
            int nrmSkipCount = 0;
            int vgmDataOffset
                = desBuf[0x34].val
                + desBuf[0x35].val * 0x100
                + desBuf[0x36].val * 0x100_00
                + desBuf[0x37].val * 0x100_00_00 + 0x34;
            int skip = 0;
            bool dataEndFlg = false;
            //Console.WriteLine("--------");

            for (int adr = 0; adr < desBuf.Length; adr++)
            {
                outDatum od = desBuf[adr];
                if (adr < vgmDataOffset)
                {
                    lstBuf.Add(od.val);
                    continue;
                }
                if (dataEndFlg)
                {
                    lstBuf.Add(od.val);
                    continue;
                }

                //ダミーコマンドをスキップする
                if (dmySkipCount > 0)
                {
                    dmySkipCount--;
                    continue;
                }
                if (nrmSkipCount > 0)
                {
                    nrmSkipCount--;
                    lstBuf.Add(od.val);
                    continue;
                }
                //TODO: Dummy Command
                if (od.val == 0x2f //dummyChipコマンド　(第2引数：chipID 第３引数:chipNumber)
                    && Common.CheckDummyCommand(od.type))//ここで指定できるmmlコマンドは元々はChipに送信することのないコマンドのみ(さもないと、通常のコマンドのデータと見分けがつかなくなる可能性がある)
                {
                    //Console.WriteLine("SkipAddress:{0:x06} skip:{1:x06}", adr, skip);
                    dmySkipCount = 2;
                    skip += 3;
                    continue;
                }
                else
                {
                    if (od.val == 0x62 || od.val == 0x63 || (od.val >= 0x70 && od.val <= 0x8f))
                    {
                        nrmSkipCount = 0;
                    }
                    else if (od.val == 0x90 || od.val == 0x91 || od.val == 0x95)
                    {
                        nrmSkipCount = 4;
                    }
                    else if (od.val == 0x92)
                    {
                        nrmSkipCount = 5;
                    }
                    else if (od.val == 0x93)
                    {
                        nrmSkipCount = 10;
                    }
                    else if (od.val == 0x94)
                    {
                        nrmSkipCount = 1;
                    }
                    else if (od.val == 0x66)
                    {
                        nrmSkipCount = 0;
                        dataEndFlg = true;
                    }
                    else if (od.val == 0x67)
                    {
                        nrmSkipCount =
                            desBuf[adr + 3].val
                            + desBuf[adr + 4].val * 0x100
                            + desBuf[adr + 5].val * 0x100_00
                            + desBuf[adr + 6].val * 0x100_00_00 + 0x7 - 1;
                    }
                    else if (od.val == 0x68)
                    {
                        nrmSkipCount = 11;
                    }
                    else if ((od.val >= 0x30 && od.val <= 0x3f) || od.val == 0x4f || od.val == 0x50)
                    {
                        nrmSkipCount = 1;
                    }
                    else if ((od.val >= 0x40 && od.val <= 0x4e) || (od.val >= 0x51 && od.val <= 0x5f) || od.val == 0x61)
                    {
                        nrmSkipCount = 2;
                    }
                    else if (od.val >= 0xa0 && od.val <= 0xbf)
                    {
                        nrmSkipCount = 2;
                    }
                    else if ((od.val >= 0xc0 && od.val <= 0xdf) || od.val == 0x64)
                    {
                        nrmSkipCount = 3;
                    }
                    else if (od.val >= 0xe0 && od.val <= 0xff)
                    {
                        nrmSkipCount = 4;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("Unknown command {0:x02}", od.val));
                    }
                }

                lstBuf.Add(od.val);
            }
            byte[] bufs = lstBuf.ToArray();
            OutFile(bufs);
        }

        private void OutXgmFile(outDatum[] desBuf)
        {
            List<byte> lstBuf = new List<byte>();

            int adr;
            int sampleDataBlockSize = desBuf[0x100].val + desBuf[0x101].val * 0x100;
            int sampleDataBlockAddr = 0x104;
            adr = sampleDataBlockAddr + sampleDataBlockSize * 256;
            int musicDataBlockSize = desBuf[adr].val + desBuf[adr + 1].val * 0x100 + desBuf[adr + 2].val * 0x100_00 + desBuf[adr + 3].val * 0x100_00_00;
            int musicDataBlockAddr = sampleDataBlockAddr + sampleDataBlockSize * 256 + 4;
            int gd3InfoStartAddr = musicDataBlockAddr + musicDataBlockSize;
            int dumcnt = 0;

            for (int i = 0; i < desBuf.Length;)
            {

                outDatum od = desBuf[i];
                if (i < musicDataBlockAddr || i >= gd3InfoStartAddr)
                {
                    if (i == gd3InfoStartAddr)
                    {
                        int newGd3InfoStartAddr = lstBuf.Count;
                        int newMusicDataBlockSize = newGd3InfoStartAddr - musicDataBlockAddr;
                        lstBuf[adr] = (byte)newMusicDataBlockSize;
                        lstBuf[adr + 1] = (byte)(newMusicDataBlockSize >> 8);
                        lstBuf[adr + 2] = (byte)(newMusicDataBlockSize >> 16);
                        lstBuf[adr + 3] = (byte)(newMusicDataBlockSize >> 24);
                    }

                    i++;
                    lstBuf.Add(od.val);
                    continue;
                }

                byte L = (byte)(od.val & 0xf);
                byte H = (byte)(od.val & 0xf0);

                //dummyコマンド以外は書き込む
                if (H != 0x60) lstBuf.Add(od.val);

                i++;
                switch (H)
                {
                    case 0x00://waitコマンド
                        //Console.WriteLine("Wait command {0:x} adr:{1:x}", H | L, i - 1);
                        break;
                    case 0x10://DCSGコマンド
                        //Console.WriteLine("DCSG command {0:x} adr:{1:x}", H | L, i - 1);
                        for (int x = 0; x < L + 1; x++) lstBuf.Add(desBuf[i++].val);
                        break;
                    case 0x20://OPN2 port0
                    case 0x30://OPN2 port1
                        //Console.WriteLine("OPN2 p01 command {0:x} adr:{1:x}", H | L, i - 1);
                        for (int x = 0; x < L + 1; x++)
                        {
                            lstBuf.Add(desBuf[i++].val);
                            lstBuf.Add(desBuf[i++].val);
                        }
                        break;
                    case 0x40://OPN2 KeyONコマンド
                        //Console.WriteLine("OPN2 keyon command {0:x} adr:{1:x}", H | L, i - 1);
                        for (int x = 0; x < L + 1; x++) lstBuf.Add(desBuf[i++].val);
                        break;
                    case 0x50://OPN2 PCMコマンド
                        //Console.WriteLine("OPN2 pcm command {0:x} adr:{1:x}", H | L, i - 1);
                        lstBuf.Add(desBuf[i++].val);
                        break;
                    case 0x60://dummyChipコマンド　(第2引数：chipID 第３引数:chipNumber)
                        //TODO: Dummy Command
                        //Console.WriteLine("dummy command {0:x} adr:{1:x}", H | L, i - 1);
                        if (Common.CheckDummyCommand(od.type))//ここで指定できるmmlコマンドは元々はChipに送信することのないコマンドのみ(さもないと、通常のコマンドのデータと見分けがつかなくなる可能性がある)
                        {
                            //lstBuf.Add(desBuf[i++].val);
                            //lstBuf.Add(desBuf[i++].val);
                            i += 2;
                            dumcnt += 3;
                        }
                        break;
                    case 0x70:
                        if (L == 0xe)//loop
                        {
                            //Console.WriteLine("loop command {0:x} adr:{1:x}", H | L, i - 1);
                            lstBuf.Add((byte)desVGM.loopOffset);
                            lstBuf.Add((byte)(desVGM.loopOffset >> 8));
                            lstBuf.Add((byte)(desVGM.loopOffset >> 16));
                            i += 3;
                        }
                        else if (L == 0xf)//end
                        {
                            //Console.WriteLine("end command {0:x} adr:{1:x}", H | L, i - 1);
                        }
                        break;
                    default:
                        Console.WriteLine("Warning Unkown command {0:x} adr:{1:x}", H | L, i - 1);
                        break;
                }
            }

            byte[] bufs = lstBuf.ToArray();
            OutFile(bufs);
        }

        private void OutFile(byte[] bufs)
        {
            if (Path.GetExtension(desFn).ToLower() != ".vgz")
            {
                if (desVGM.info.format == enmFormat.VGM)
                {
                    log.Write("VGMファイル出力");
                    File.WriteAllBytes(
                        Path.Combine(
                            Path.GetDirectoryName(desFn)
                            , Path.GetFileNameWithoutExtension(desFn) + ".vgm"
                            )
                        , bufs);
                }
                else
                {
                    log.Write("XGMファイル出力");
                    File.WriteAllBytes(
                        Path.Combine(
                            Path.GetDirectoryName(desFn)
                            , Path.GetFileNameWithoutExtension(desFn) + ".xgm"
                            )
                        , bufs);
                }
                return;
            }

            log.Write(msg.get("I04021"));

            int num;
            byte[] buf = new byte[1024];

            MemoryStream inStream = new MemoryStream(bufs);
            FileStream outStream = new FileStream(desFn, FileMode.Create, FileAccess.Write);
            GZipStream compStream = new GZipStream(outStream, CompressionMode.Compress);

            try
            {
                while ((num = inStream.Read(buf, 0, buf.Length)) > 0)
                {
                    compStream.Write(buf, 0, num);
                }
            }
            catch { }
            finally
            {
                if (compStream != null) compStream.Dispose();
                if (outStream != null) outStream.Dispose();
                if (inStream != null) inStream.Dispose();
            }
        }

        private void OutTraceInfoFile(outDatum[] desBuf)
        {
            List<string> buf = new List<string>();
            foreach (outDatum od in desBuf)
            {
                if (od.linePos != null)
                {
                    buf.Add(string.Format(
                        "File:[{0}] Row:[{1}] Col:[{2}] Len:[{3}] Chip:[{4}] Secondary:[{5}] Part:[{6}] Ch:[{7}] MMLType:[{8}] Val:[{9:X2}]"
                        , od.linePos.srcMMLID
                        , od.linePos.row
                        , od.linePos.col
                        , od.linePos.length
                        , od.linePos.chip
                        , od.linePos.chipNumber
                        , od.linePos.part
                        , od.linePos.ch
                        , od.type
                        , od.val));
                }
                else
                {
                    buf.Add(string.Format(
                        "File:[{0}] Row:[{1}] Col:[{2}] Len:[{3}] Chip:[{4}] Secondary:[{5}] Part:[{6}] Ch:[{7}] MMLType:[{8}] Val:[{9:X2}]"
                        , ""
                        , ""
                        , ""
                        , ""
                        , ""
                        , ""
                        , ""
                        , ""
                        , od.type
                        , od.val));
                }
            }

            log.Write(msg.get("I04022"));
#if DEBUG
            desTiFn = "DEBUG_vgmData.txt";
#endif
            File.WriteAllLines(desTiFn, buf, System.Text.Encoding.UTF8);
        }

        private List<Line> GetSrc(string[] srcBuf, string path)
        {
            try
            {
                List<Line> des = new List<Line>();
                return GetSrcRec(srcBuf, des, path, srcFn, 0);
            }
            catch
            {
                msgBox.setErrMsg(string.Format(
                                msg.get("E04008")
                                , srcFn), new LinePos(document, srcFn));
                return null;
            }
        }

        private List<Line> GetSrcRec(string[] srcBuf, List<Line> des, string path, string sourceFileName, int sourceLineNumber)
        {
            foreach (string s in srcBuf)
            {
                Line line = new Line(new LinePos(document,sourceFileName, sourceLineNumber), s);
                des.Add(line);
                sourceLineNumber++;

                if (!string.IsNullOrEmpty(s)
                    && s.TrimStart().Length > 2
                    && s.TrimStart().Substring(0, 2) == "'+")
                {
                    string includeFn = s.Substring(2).Trim().Trim('"');
                    includeFn = includeFn.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar);
                    if (!File.Exists(includeFn))
                    {
                        includeFn = Path.Combine(path, includeFn);
                        includeFn = includeFn.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar);
                        if (!File.Exists(includeFn))
                        {
                            msgBox.setErrMsg(string.Format(
                                msg.get("E04006")
                                , includeFn), new LinePos(null,sourceFileName, sourceLineNumber, 0, s.Length));
                            return null;
                        }
                    }
                    string[] incBuf = File.ReadAllLines(includeFn);
                    des = GetSrcRec(incBuf, des, path, includeFn, 0);
                }
            }

            return des;
        }

        private void GetPCMData(string path)
        {

            //キャッシュ処理:キャッシュファイルの存在をチェックする。あるなら読み込む
            desVGM.pcmCache = null;
            desVGM.fnPcmCache = null;

            //mml2vgmGUIからキャッシュを使う指示有りの場合は強制的に有効にする
            if (usePCMCacheFromGUI) desVGM.info.usePcmCache = true;

            if (desVGM.info.usePcmCache && desVGM.info.format == enmFormat.XGM)
            {
                try
                {
                    desVGM.fnPcmCache = srcFn + ".pcmCache.bin";
                    if (File.Exists(desVGM.fnPcmCache)) desVGM.pcmCache = File.ReadAllBytes(desVGM.fnPcmCache);
                }
                catch
                {
                    desVGM.pcmCache = null;
                }
            }

            Dictionary<int, Tuple<string, clsPcm>> newDic = new Dictionary<int, Tuple<string, clsPcm>>();
            foreach (clsPcmDatSeq pds in desVGM.instPCMDatSeq)
            {
                byte[] buf;
                clsPcm v;
                bool isRaw;
                bool is16bit;
                int samplerate;

                if (pds.chip == enmChipType.None) continue;

                switch (pds.type)
                {
                    case enmPcmDefineType.Easy:
                        if (desVGM.instPCM.ContainsKey(pds.No))
                        {
                            desVGM.instPCM.Remove(pds.No);
                        }
                        v = new clsPcm(
                            pds.No
                            , pcmDataSeqNum++
                            , pds.chip
                            , pds.chipNumber
                            , pds.FileName
                            , pds.BaseFreq
                            , pds.Volume
                            , 0
                            , 0
                            , 0
                            , pds.DatLoopAdr
                            , false
                            , 8000);
                        desVGM.instPCM.Add(pds.No, new Tuple<string, clsPcm>("", v));

                        if ((desVGM.info.format == enmFormat.XGM && desVGM.pcmCache == null)
                            || desVGM.info.format != enmFormat.XGM)
                        {
                            //ファイルの読み込み
                            buf = Common.GetPCMDataFromFile(path, v, out isRaw, out is16bit, out samplerate);
                            if (buf == null)
                            {
                                msgBox.setErrMsg(string.Format(
                                    msg.get("E04007")
                                    , v.fileName), new LinePos(null,pds.FileName));
                                continue;
                            }

                            //pitch変換
                            if (desVGM.info.format == enmFormat.XGM)
                            {
                                int fFreq = (int)pds.DatLoopAdr;
                                //SOXで変換する
                                ConvertFreq(path, ref buf, pds.BaseFreq, ref fFreq);
                                pds.BaseFreq = fFreq;
                                v.freq = fFreq;
                            }

                            if (desVGM.info.format == enmFormat.XGM && v.chipNumber != 0)
                            {
                                msgBox.setErrMsg(string.Format(
                                    msg.get("E01017")
                                    , v.fileName), new LinePos(null,pds.FileName));
                                continue;
                            }

                            if (desVGM.chips.ContainsKey(v.chip))
                            {
                                desVGM.chips[v.chip][v.chipNumber]
                                    .StorePcm(
                                    newDic
                                    , new KeyValuePair<int, clsPcm>(pds.No, v)
                                    , buf
                                    , is16bit
                                    , samplerate);
                            }
                        }
                        else
                        {
                            //キャッシュを使う場合は
                            //dummy情報を登録する
                            desVGM.chips[v.chip][v.chipNumber]
                                .StorePcm(
                                newDic
                                , new KeyValuePair<int, clsPcm>(pds.No, v)
                                , new byte[0]
                                , false
                                , 14000);
                        }

                        if (v.chip == enmChipType.YM2609)
                        {
                            if (pds.DatLoopAdr == 0)
                            {
                                //ADPCM-A
                                if (desVGM.chips != null && desVGM.chips.ContainsKey(v.chip) && desVGM.chips[v.chip] != null)
                                {
                                    pds.DatEndAdr = (int)((YM2609)desVGM.chips[v.chip][v.chipNumber]).pcmDataEasyA.Length - 16;
                                }
                            }
                            else if (pds.DatLoopAdr == 1)
                            {
                                //ADPCM-B
                                if (desVGM.chips != null && desVGM.chips.ContainsKey(v.chip) && desVGM.chips[v.chip] != null)
                                {
                                    pds.DatEndAdr = (int)((YM2609)desVGM.chips[v.chip][v.chipNumber]).pcmDataEasyB.Length - 16;
                                }
                            }
                            else
                            {
                                //ADPCM-C
                                if (desVGM.chips != null && desVGM.chips.ContainsKey(v.chip) && desVGM.chips[v.chip] != null)
                                {
                                    pds.DatEndAdr = (int)((YM2609)desVGM.chips[v.chip][v.chipNumber]).pcmDataEasyC.Length - 16;
                                }
                            }

                        }
                        else if (v.chip == enmChipType.YM2610B)
                        {
                            if (pds.DatLoopAdr == 0)
                            {
                                //ADPCM-A
                                if (desVGM.chips != null && desVGM.chips.ContainsKey(v.chip) && desVGM.chips[v.chip] != null)
                                {
                                    pds.DatEndAdr = (int)((YM2610B)desVGM.chips[v.chip][v.chipNumber]).pcmDataEasyA.Length - 16;
                                }
                            }
                            else
                            {
                                //ADPCM-B
                                if (desVGM.chips != null && desVGM.chips.ContainsKey(v.chip) && desVGM.chips[v.chip] != null)
                                {
                                    pds.DatEndAdr = (int)((YM2610B)desVGM.chips[v.chip][v.chipNumber]).pcmDataEasyB.Length - 16;
                                }
                            }

                        }
                        else
                        {
                            if (desVGM.chips != null && desVGM.chips.ContainsKey(v.chip) && desVGM.chips[v.chip] != null)
                            {
                                pds.DatEndAdr = (int)desVGM.chips[v.chip][v.chipNumber].pcmDataEasy.Length - 16;
                            }
                        }
                        break;
                    case enmPcmDefineType.Mucom88:
                        if (desVGM.instPCM.ContainsKey(pds.No))
                        {
                            desVGM.instPCM.Remove(pds.No);
                        }
                        v = new clsPcm(
                            pds.No
                            , pcmDataSeqNum++
                            , pds.chip
                            , pds.chipNumber
                            , pds.FileName
                            , pds.BaseFreq
                            , pds.Volume
                            , 0
                            , 0
                            , 0
                            , pds.DatLoopAdr
                            , false
                            , 8000);
                        desVGM.instPCM.Add(pds.No, new Tuple<string, clsPcm>("", v));

                        mucomADPCM2PCM.mucomPCMInfo info = null;
                        for (int i = 0; i < mucomADPCM2PCM.lstMucomPCMInfo.Count; i++)
                        {
                            mucomADPCM2PCM.mucomPCMInfo inf = mucomADPCM2PCM.lstMucomPCMInfo[i];
                            if (pds.No == inf.no)
                            {
                                info = inf;
                                break;
                            }
                        }
                        if (info == null) return;

                        //ファイルの読み込み
                        buf = mucomADPCM2PCM.GetPcmData(info);
                        if (buf == null)
                        {
                            msgBox.setErrMsg(string.Format(
                                msg.get("E04007")
                                , v.fileName), new LinePos(null,pds.FileName));
                            continue;
                        }

                        if (desVGM.info.format == enmFormat.XGM && v.chipNumber != 0)
                        {
                            msgBox.setErrMsg(string.Format(
                                msg.get("E01017")
                                , v.fileName), new LinePos(null,pds.FileName));
                            continue;
                        }

                        desVGM.chips[v.chip][v.chipNumber]
                            .StorePcm(
                            newDic
                            , new KeyValuePair<int, clsPcm>(pds.No, v)
                            , buf
                            , false
                            , 8000);

                        break;
                    case enmPcmDefineType.RawData:
                        //ファイルの読み込み
                        buf = Common.GetPCMDataFromFile(path, pds.FileName, 100, out isRaw, out is16bit, out samplerate);
                        if (buf == null)
                        {
                            msgBox.setErrMsg(string.Format(
                                msg.get("E04007")
                                , pds.FileName), new LinePos(null,pds.FileName));
                            continue;
                        }
                        desVGM.chips[pds.chip][pds.chipNumber]
                            .StorePcmRawData(
                            pds
                            , buf
                            , isRaw
                            , is16bit
                            , samplerate);
                        break;
                    case enmPcmDefineType.Set:
                        //if(!desVGM.chips[pds.chip][pds.chipNumber ? 1 : 0].StorePcmCheck())
                        //{
                        //    return;
                        //}
                        if (desVGM.instPCM.ContainsKey(pds.No))
                        {
                            desVGM.instPCM.Remove(pds.No);
                        }
                        v = new clsPcm(
                            pds.No
                            , pcmDataSeqNum++
                            , pds.chip
                            , pds.chipNumber
                            , ""
                            , pds.BaseFreq
                            , 100
                            , pds.DatStartAdr
                            , pds.DatEndAdr
                            , pds.chip != enmChipType.RF5C164
                                ? (pds.DatEndAdr - pds.DatStartAdr + 1)
                                : (pds.DatLoopAdr - pds.DatStartAdr + 1)
                            , pds.DatLoopAdr
                            , false
                            , 8000
                            , pds.Option);
                        newDic.Add(pds.No, new Tuple<string, clsPcm>("", v));

                        break;
                }
            }

            desVGM.instPCM = newDic;

        }

        private void ConvertFreq(string srcPath, ref byte[] buf, int srcFreq, ref int dstFreq)
        {
            if (dstFreq < 73)
            {
                dstFreq = GetNoteNumToFreq(srcFreq, dstFreq);
            }

            if (srcFreq == dstFreq) return;

            try
            {
                string path = Common.SearchSoxPath(stPath, "sox", "sox.exe", "sox");
                if (!File.Exists(path))
                {
                    msgBox.setErrMsg(string.Format("SoXが見つかりませんでした.(検索場所:{0})", path), null);
                    return;
                }

                //元ファイルの作成と出力先ファイルの削除
                string tempPath = Path.Combine(srcPath, "soxTemp.raw");
                File.Delete(tempPath);
                File.WriteAllBytes(tempPath, buf);
                string destPath = Path.Combine(srcPath, "soxTempDest.raw");
                File.Delete(destPath);

                Disp(string.Format("SoXを使用し、ピッチの変換を行います。{0}Hz", dstFreq));

                //SoXの起動
                System.Diagnostics.ProcessStartInfo psi =
                    new System.Diagnostics.ProcessStartInfo();
                psi.FileName = string.Format("\"{0}\"", path);
                psi.Arguments = string.Format("-D -e unsigned -b 8 -c 1 -r {2} \"{1}\" -r {0} \"{3}\"", srcFreq, tempPath, dstFreq, destPath);
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
#if DEBUG
                Disp(string.Format("{0} {1}", psi.FileName, psi.Arguments));
#endif
                System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
                p.WaitForExit();
                buf = File.ReadAllBytes(destPath);

                //元ファイルと出力先ファイルの削除
                File.Delete(tempPath);
                File.Delete(destPath);
            }
            catch (Exception e)
            {
                msgBox.setErrMsg(string.Format(
                    "SoXを使用した周波数変換処理で例外が発生しました.\r\nMessage:\r\n{0}\r\nStackTrace:\r\n{1}\r\n"
                    , e.Message
                    , e.StackTrace), null);
            }
        }


        private int GetNoteNumToFreq(int srcFreq, int dstFreq)
        {
            if (dstFreq == 36) return srcFreq;

            int oct = dstFreq / 12 - 3;
            int n = dstFreq % 12;
            double f = srcFreq * Const.pcmMTbl[n] * Math.Pow(2, oct);

            return (int)f;
        }

        private void Result()
        {
            Disp("");

            string res = "";
            foreach (ClsChip[] chips in desVGM.chips.Values)
            {
                foreach (ClsChip chip in chips)
                {
                    res += DispPCMRegion(chip);
                }
            }

            if (res != "")
            {
                Disp(msg.get("I04012"));
                //Disp(" YM2608:  None");
                //Disp(" YM2610B: 0=A 1=B");
                //Disp(" RF5C164: None");
                Disp("");
                Disp(msg.get("I04013"));
                Disp("");
                Disp("");
                if (desVGM.c140 != null)
                {
                    if (desVGM.c140[0] != null && desVGM.c140[0].pcmDataEasy != null)
                        Disp(string.Format(msg.get("I04014")
                            , ((C140)desVGM.c140[0]).isSystem2 ? "" : "1"));
                    if (desVGM.c140.Length > 1)
                    {
                        if (desVGM.c140[1] != null && desVGM.c140[1].pcmDataEasy != null)
                            Disp(string.Format(msg.get("I04015")
                                , ((C140)desVGM.c140[1]).isSystem2 ? "" : "1"));
                    }
                }
                Disp("");

                Disp(msg.get("I04016"));
                Disp(msg.get("I04017"));
                Disp(res);
            }



            res = "";
            foreach (ClsChip[] chips in desVGM.chips.Values)
            {
                foreach (ClsChip chip in chips)
                {
                    res += DispPCMRegionDataBlock(chip);
                }
            }

            if (res != "")
            {
                Disp(msg.get("I04019"));
                Disp(msg.get("I04020"));
                Disp(res);
            }
        }

        private string DispPCMRegion(ClsChip c)
        {
            if (c == null) return "";

            if (c.chipType == enmChipType.YM2609)
            {
                YM2609 opna2 = (YM2609)c;
                if (opna2.pcmDataEasyA == null
                    && opna2.pcmDataEasyB == null
                    && opna2.pcmDataEasyC == null
                    && opna2.pcmDataEasyD == null
                    && opna2.pcmDataDirectA.Count == 0
                    && opna2.pcmDataDirectB.Count == 0
                    && opna2.pcmDataDirectC.Count == 0
                    && opna2.pcmDataDirect.Count == 0
                    ) return "";
            }
            else if (c.chipType == enmChipType.YM2610B)
            {
                YM2610B opnb = (YM2610B)c;
                if (opnb.pcmDataEasyA == null
                    && opnb.pcmDataEasyB == null
                    && opnb.pcmDataDirectA.Count == 0
                    && opnb.pcmDataDirectB.Count == 0
                    ) return "";
            }
            else
            {
                if (c.pcmDataEasy == null && c.pcmDataDirect.Count == 0) return "";
            }

            string region = "";

            for (int i = 0; i < 256; i++)
            {
                if (!desVGM.instPCM.ContainsKey(i)) continue;
                if (desVGM.instPCM[i].Item2.chip != c.chipType) continue;
                if (desVGM.instPCM[i].Item2.chipNumber != c.ChipNumber) continue;

                region += c.DispRegion(desVGM.instPCM[i]);

            }

            long tl = 0;
            foreach (int i in desVGM.instPCM.Keys)
            {
                tl += desVGM.instPCM[i].Item2.size;
            }
            region += (string.Format(msg.get("I04018"), tl));
            region += "\r\n";

            return region;
        }

        private string DispPCMRegionDataBlock(ClsChip c)
        {
            YM2609 opna2;
            YM2610B opnb;
            string region = "";
            long tl = 0;

            if (c == null) return "";

            if (c.chipType == enmChipType.YM2609)
            {
                opna2 = (YM2609)c;
                if (opna2.pcmDataEasyA == null
                    && opna2.pcmDataEasyB == null
                    && opna2.pcmDataEasyC == null
                    && opna2.pcmDataEasyD == null
                    && opna2.pcmDataDirectA.Count == 0
                    && opna2.pcmDataDirectB.Count == 0
                    && opna2.pcmDataDirectC.Count == 0
                    && opna2.pcmDataDirect.Count == 0
                    ) return "";

                if (opna2.pcmDataEasyA != null)
                {
                    region += string.Format("{0,-10} {1,-7} ${2,-7:X6} ${3,-7:X6} ${4,-7:X6}  {5}\r\n"
                        , opna2.Name + "_A"
                        , opna2.ChipNumber != 0 ? "SEC" : "PRI"
                        , 0
                        , opna2.pcmDataEasyA.Length - 1
                        , opna2.pcmDataEasyA.Length
                        , "AUTO"
                        );
                    tl += opna2.pcmDataEasyA.Length;
                }
                if (opna2.pcmDataEasyB != null)
                {
                    region += string.Format("{0,-10} {1,-7} ${2,-7:X6} ${3,-7:X6} ${4,-7:X6}  {5}\r\n"
                        , opna2.Name + "_B"
                        , opna2.ChipNumber != 0 ? "SEC" : "PRI"
                        , 0
                        , opna2.pcmDataEasyB.Length - 1
                        , opna2.pcmDataEasyB.Length
                        , "AUTO"
                        );
                    tl += opna2.pcmDataEasyB.Length;
                }
                if (opna2.pcmDataEasyC != null)
                {
                    region += string.Format("{0,-10} {1,-7} ${2,-7:X6} ${3,-7:X6} ${4,-7:X6}  {5}\r\n"
                        , opna2.Name + "_C"
                        , opna2.ChipNumber != 0 ? "SEC" : "PRI"
                        , 0
                        , opna2.pcmDataEasyC.Length - 1
                        , opna2.pcmDataEasyC.Length
                        , "AUTO"
                        );
                    tl += opna2.pcmDataEasyC.Length;
                }
                if (opna2.pcmDataEasyD != null)
                {
                    region += string.Format("{0,-10} {1,-7} ${2,-7:X6} ${3,-7:X6} ${4,-7:X6}  {5}\r\n"
                        , opna2.Name + "_D"
                        , opna2.ChipNumber != 0 ? "SEC" : "PRI"
                        , 0
                        , opna2.pcmDataEasyD.Length - 1
                        , opna2.pcmDataEasyD.Length
                        , "AUTO"
                        );
                    tl += opna2.pcmDataEasyD.Length;
                }

            }
            else if (c.chipType == enmChipType.YM2610B)
            {
                opnb = (YM2610B)c;
                if (opnb.pcmDataEasyA == null
                    && opnb.pcmDataEasyB == null
                    && opnb.pcmDataDirectA.Count == 0
                    && opnb.pcmDataDirectB.Count == 0
                    ) return "";

                if (opnb.pcmDataEasyA != null)
                {
                    region += string.Format("{0,-10} {1,-7} ${2,-7:X6} ${3,-7:X6} ${4,-7:X6}  {5}\r\n"
                        , opnb.Name + "_A"
                        , opnb.ChipNumber != 0 ? "SEC" : "PRI"
                        , 0
                        , opnb.pcmDataEasyA.Length - 1
                        , opnb.pcmDataEasyA.Length
                        , "AUTO"
                        );
                    tl += opnb.pcmDataEasyA.Length;
                }
                if (opnb.pcmDataEasyB != null)
                {
                    region += string.Format("{0,-10} {1,-7} ${2,-7:X6} ${3,-7:X6} ${4,-7:X6}  {5}\r\n"
                        , opnb.Name + "_B"
                        , opnb.ChipNumber != 0 ? "SEC" : "PRI"
                        , 0
                        , opnb.pcmDataEasyB.Length - 1
                        , opnb.pcmDataEasyB.Length
                        , "AUTO"
                        );
                    tl += opnb.pcmDataEasyB.Length;
                }

            }
            else
            {
                if (c.pcmDataEasy == null && c.pcmDataDirect.Count == 0) return "";

                if (c.pcmDataEasy != null)
                {
                    region += string.Format("{0,-10} {1,-7} ${2,-7:X6} ${3,-7:X6} ${4,-7:X6}  {5}\r\n"
                        , c.Name
                        , c.ChipNumber != 0 ? "SEC" : "PRI"
                        , 0
                        , c.pcmDataEasy.Length - 1
                        , c.pcmDataEasy.Length
                        , "AUTO"
                        );
                    tl += c.pcmDataEasy.Length;
                }
            }


            if (c.pcmDataDirect.Count > 0)
            {
                foreach (clsPcmDatSeq pds in desVGM.instPCMDatSeq)
                {
                    if (pds.type == enmPcmDefineType.Set) continue;
                    if (pds.type == enmPcmDefineType.Easy) continue;
                    if (pds.chip != c.chipType) continue;
                    if (pds.chipNumber != c.ChipNumber) continue;
                    if (desVGM.chips[pds.chip] == null) continue;
                    if (desVGM.chips[pds.chip][0] == null) continue;
                    if (!desVGM.chips[pds.chip][0].CanUsePICommand()) continue;

                    region += string.Format("{0,-10} {1,-7} ${2,-7:X6} ${3,-7:X6} ${4,-7:X6}  {5}\r\n"
                        , c.Name
                        , pds.chipNumber != 0 ? "SEC" : "PRI"
                        , pds.DatStartAdr
                        , pds.DatEndAdr
                        , pds.DatEndAdr - pds.DatStartAdr + 1
                        , pds.type == enmPcmDefineType.Easy ? "AUTO" : "MANUAL"
                        );
                    tl += pds.DatEndAdr - pds.DatStartAdr + 1;
                }
            }

            if (region != "")
            {
                region += (string.Format(msg.get("I04018"), tl));
                region += "\r\n";
            }

            return region;
        }



    }
}