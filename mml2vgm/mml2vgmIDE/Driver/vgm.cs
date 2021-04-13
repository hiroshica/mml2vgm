﻿using Core;
using SoundManager;
using System;
using System.Collections.Generic;

namespace mml2vgmIDE
{
    public class vgm : baseDriver
    {

        public const int FCC_VGM = 0x206D6756;	// "Vgm "
        public const int FCC_GD3 = 0x20336447;  // "Gd3 "

        public const uint defaultSN76489ClockValue = 3579545;
        public const uint defaultYM2612ClockValue = 7670454;
        public const uint defaultRF5C164ClockValue = 12500000;
        public const uint defaultPWMClockValue = 23011361;
        public const uint defaultC140ClockValue = 21390;
        public const MDSound.c140.C140_TYPE defaultC140Type = MDSound.c140.C140_TYPE.ASIC219;
        public const uint defaultOKIM6258ClockValue = 4000000;
        public const uint defaultOKIM6295ClockValue = 4000000;
        public const uint defaultSEGAPCMClockValue = 4000000;
        public const uint defaultAY8910ClockValue = 1789750;


        public uint SN76489ClockValue = 3579545;
        public uint YM2612ClockValue = 7670454;
        public uint RF5C68ClockValue = 12500000;
        public uint RF5C164ClockValue = 12500000;
        public uint PWMClockValue = 23011361;
        public uint C140ClockValue = 21390;
        public MDSound.c140.C140_TYPE C140Type = MDSound.c140.C140_TYPE.ASIC219;
        public uint OKIM6258ClockValue = 4000000;
        public byte OKIM6258Type = 0;
        public uint OKIM6295ClockValue = 4000000;
        public uint SEGAPCMClockValue = 4000000;
        public int SEGAPCMInterface = 0;
        public uint YM2151ClockValue;
        public uint YM2608ClockValue;
        public uint YM2203ClockValue;
        public uint YM2610ClockValue;
        public uint YM3812ClockValue;
        public uint YM3526ClockValue;
        public uint Y8950ClockValue;
        public uint YMF262ClockValue;
        public uint YMF271ClockValue;
        public uint YMF278BClockValue;
        public uint YMZ280BClockValue;
        public uint AY8910ClockValue;
        public uint YM2413ClockValue;
        public uint HuC6280ClockValue;
        public uint QSoundClockValue;
        public uint C352ClockValue;
        public byte C352ClockDivider;
        public uint GA20ClockValue;
        public uint K053260ClockValue;
        public uint K054539ClockValue;
        public byte K054539Flags;
        public uint K051649ClockValue;
        public uint DMGClockValue;
        public uint NESClockValue;
        public uint MultiPCMClockValue;

        public bool YM2612DualChipFlag;
        public bool YM2151DualChipFlag;
        public bool YM2203DualChipFlag;
        public bool YM2608DualChipFlag;
        public bool YM2610DualChipFlag;
        public bool YM3812DualChipFlag;
        public bool YM3526DualChipFlag;
        public bool Y8950DualChipFlag;
        public bool YMF262DualChipFlag;
        public bool YMF271DualChipFlag;
        public bool YMF278BDualChipFlag;
        public bool YMZ280BDualChipFlag;
        public bool OKIM6295DualChipFlag;
        public bool SN76489DualChipFlag;
        public bool SEGAPCMDualChipFlag;
        public bool RF5C68DualChipFlag;
        public bool RF5C164DualChipFlag;
        public bool AY8910DualChipFlag;
        public bool YM2413DualChipFlag;
        public bool HuC6280DualChipFlag;
        public bool C140DualChipFlag;
        public bool C352DualChipFlag;
        public bool GA20DualChipFlag;
        public bool K053260DualChipFlag;
        public bool K054539DualChipFlag;
        public bool K051649DualChipFlag;
        public bool DMGDualChipFlag;
        public bool NESDualChipFlag;
        public bool MultiPCMDualChipFlag;

        public dacControl dacControl = new dacControl();
        public bool isPcmRAMWrite = false;
        public bool useChipYM2612Ch6 = false;
        //public Setting setting = null;


        private Action<outDatum>[] vgmCmdTbl = new Action<outDatum>[0x100];

        private List<string> chips = null;

        private uint vgmAdr;
        //private int vgmWait;
        private long vgmLoopOffset = 0;
        private uint vgmEof;
        private bool vgmAnalyze;

        private long vgmDataOffset = 0;

        private const int PCM_BANK_COUNT = 0x40;
        private VGM_PCM_BANK[] PCMBank = new VGM_PCM_BANK[PCM_BANK_COUNT];
        private PCMBANK_TBL PCMTbl = new PCMBANK_TBL();
        private byte DacCtrlUsed;
        private byte[] DacCtrlUsg = new byte[0xFF];
        private DACCTRL_DATA[] DacCtrl = new DACCTRL_DATA[0xFF];

        private byte[][] ym2610AdpcmA = new byte[2][] { null, null };
        private byte[][] ym2610AdpcmB = new byte[2][] { null, null };

        private List<byte> pcmDat = new List<byte>();



        public override bool init(outDatum[] vgmBuf, ChipRegister chipRegister, EnmChip[] useChip, uint latency, uint waitTime, long jumpPointClock)
        {
            this.vgmBuf = vgmBuf;
            this.chipRegister = chipRegister;
            this.useChip = useChip;
            this.latency = latency;
            this.waitTime = waitTime;
            this.jumpPointClock = jumpPointClock;
            //dumpCounter = 0;

            ym2610AdpcmA = new byte[2][] { null, null };
            ym2610AdpcmB = new byte[2][] { null, null };

            if (!getInformationHeader()) return false;

            vgmAdr = (uint)vgmDataOffset;
            //vgmWait = 0;
            vgmAnalyze = true;
            Counter = 0;
            vgmFrameCounter = -latency - waitTime;
            vgmCurLoop = 0;
            vgmSpeed = 1;
            vgmSpeedCounter = 0;

            for (int i = 0; i < PCM_BANK_COUNT; i++) PCMBank[i] = new VGM_PCM_BANK();
            dacControl.refresh();
            DacCtrlUsed = 0x00;
            for (byte CurChip = 0x00; CurChip < 0xFF; CurChip++)
            {
                DacCtrl[CurChip] = new DACCTRL_DATA();
                DacCtrl[CurChip].Enable = false;
            }

            setCommands();

            Stopped = false;
            useChipYM2612Ch6 = false;
            foreach (EnmChip uc in useChip)
            {
                if (uc == EnmChip.YM2612Ch6)
                {
                    useChipYM2612Ch6 = true;
                    break;
                }
            }
            return true;
        }

        public override void oneFrameProc()
        {
            try
            {
                vgmSpeedCounter += vgmSpeed;
                while (vgmSpeedCounter >= 1.0)
                {
                    vgmSpeedCounter -= 1.0;
                    if (vgmFrameCounter > -1)
                    {
                        oneFrameVGMMain();
                    }
                    else
                    {
                        vgmFrameCounter++;
                    }
                }
            }
            catch (Exception ex)
            {
                log.ForcedWrite(ex);

            }
        }

        private void oneFrameVGMMain()
        {
            //if (vgmWait > 0)
            //{
            //    //if (model == enmModel.VirtualModel)
            //        oneFrameVGMStream();
            //    vgmWait--;
            //    Counter++;
            //    vgmFrameCounter++;
            //    return;
            //}

            Counter = Audio.DriverSeqCounter;

            if (!vgmAnalyze)
            {
                //if (model == enmModel.VirtualModel)
                //    oneFrameVGMStream();
                Stopped = true;
                return;
            }

            int countNum = 0;
            //while (vgmWait <= 0)
            {
                if (vgmAdr >= vgmBuf.Length || vgmAdr >= vgmEof)
                {
                    if (LoopCounter != 0)
                    {
                        vgmAdr = (uint)(vgmLoopOffset + 0x1c);
                        chipRegister.LoopCountUp(Audio.DriverSeqCounter);
                        vgmCurLoop++;
                    }
                    else
                    {
                        vgmAnalyze = false;
                        return;
                    }
                }

                outDatum cmd = vgmBuf[vgmAdr].Copy();
                //Console.WriteLine("[{0}]: Adr:{1:X} Dat:{2:X}",model, vgmAdr , vgmBuf[vgmAdr]);
                if (vgmCmdTbl[cmd.val] != null)
                {
                    //if (model == enmModel.VirtualModel) Console.WriteLine("{0:X05} : {1:X02} ", vgmAdr, vgmBuf[vgmAdr]);
                    vgmCmdTbl[cmd.val](cmd);
                }
                else
                {
                    //わからんコマンド
                    Console.WriteLine("unknown command: Adr:{0:X} Dat:{1:X}", vgmAdr, vgmBuf[vgmAdr].val);
                    vgmAdr++;
                }
                countNum++;
                if (countNum > 100)
                {
                    //if (model == EnmModel.RealModel && countNum%100==0)
                    //{
                    //    isDataBlock = true;
                    //    chipRegister.sendDataYM2608(0,model);
                    //    chipRegister.setYM2608SyncWait(0,1);
                    //    chipRegister.sendDataYM2151(0,model);
                    //    chipRegister.setYM2151SyncWait(0,1);

                    //    chipRegister.sendDataYM2608(1, model);
                    //    chipRegister.setYM2608SyncWait(1, 1);
                    //    chipRegister.sendDataYM2151(1, model);
                    //    chipRegister.setYM2151SyncWait(1, 1);
                    //}
                }
            }

            //if (model == EnmModel.RealModel && isDataBlock)
            //{
            //    isDataBlock = false;
            //    //Console.WriteLine("{0} countnum:{1}", model, countNum);
            //    countNum = 0;
            //}

            //Send wait
            //if (model == EnmModel.RealModel)
            //{
            //    if (vgmSpeed == 1) //等速の場合のみウェイトをかける
            //    {
            //        if (useChipYM2612Ch6)
            //            chipRegister.setYM2612SyncWait(0, vgmWait);
            //        //if ((useChip & enmUseChip.SN76489) == enmUseChip.SN76489)
            //        //    chipRegister.setSN76489SyncWait(vgmWait);
            //        //chipRegister.setYM2608SyncWait(vgmWait);
            //        //chipRegister.setYM2151SyncWait(vgmWait);
            //    }
            //}

            //if (model == enmModel.VirtualModel)

            for (long i = Counter; i < Audio.DriverSeqCounter; i++)
            {
                oneFrameVGMStream(i);
            }

            //vgmWait--;
            vgmFrameCounter++;

        }

        private void oneFrameVGMStream(long Counter)
        {
            for (int CurChip = 0x00; CurChip < DacCtrlUsed; CurChip++)
            {
                dacControl.update(Counter, DacCtrlUsg[CurChip], 1);
            }
        }

        private void setCommands()
        {

            for (int i = 0; i < vgmCmdTbl.Length; i++) vgmCmdTbl[i] = null;

            vgmCmdTbl[0x2f] = vcDummyChip;
            vgmCmdTbl[0x30] = vcPSG;
            vgmCmdTbl[0x31] = vcDummy1Ope;
            vgmCmdTbl[0x32] = vcDummy1Ope;
            vgmCmdTbl[0x33] = vcDummy1Ope;
            vgmCmdTbl[0x34] = vcDummy1Ope;
            vgmCmdTbl[0x35] = vcDummy1Ope;
            vgmCmdTbl[0x36] = vcDummy1Ope;
            vgmCmdTbl[0x37] = vcDummy1Ope;

            vgmCmdTbl[0x38] = vcDummy1Ope;
            vgmCmdTbl[0x39] = vcDummy1Ope;
            vgmCmdTbl[0x3a] = vcDummy1Ope;
            vgmCmdTbl[0x3b] = vcDummy1Ope;
            vgmCmdTbl[0x3c] = vcDummy1Ope;
            vgmCmdTbl[0x3d] = vcDummy1Ope;
            vgmCmdTbl[0x3e] = vcDummy1Ope;
            vgmCmdTbl[0x3f] = vcGGPSGPort06;

            vgmCmdTbl[0x40] = vcDummy2Ope;
            vgmCmdTbl[0x41] = vcDummy2Ope;
            vgmCmdTbl[0x42] = vcDummy2Ope;
            vgmCmdTbl[0x43] = vcDummy2Ope;
            vgmCmdTbl[0x44] = vcDummy2Ope;
            vgmCmdTbl[0x45] = vcDummy2Ope;
            vgmCmdTbl[0x46] = vcDummy2Ope;
            vgmCmdTbl[0x47] = vcDummy2Ope;

            vgmCmdTbl[0x48] = vcDummy2Ope;
            vgmCmdTbl[0x49] = vcDummy2Ope;
            vgmCmdTbl[0x4a] = vcDummy2Ope;
            vgmCmdTbl[0x4b] = vcDummy2Ope;
            vgmCmdTbl[0x4c] = vcDummy2Ope;
            vgmCmdTbl[0x4d] = vcDummy2Ope;
            vgmCmdTbl[0x4e] = vcDummy2Ope;

            vgmCmdTbl[0x4f] = vcGGPSGPort06;
            vgmCmdTbl[0x50] = vcPSG;

            vgmCmdTbl[0x51] = vcYM2413;
            vgmCmdTbl[0x52] = vcYM2612Port0;
            vgmCmdTbl[0x53] = vcYM2612Port1;

            vgmCmdTbl[0x54] = vcYM2151;
            vgmCmdTbl[0x55] = vcYM2203;
            vgmCmdTbl[0x56] = vcYM2608Port0;
            vgmCmdTbl[0x57] = vcYM2608Port1;

            vgmCmdTbl[0x58] = vcYM2610Port0;
            vgmCmdTbl[0x59] = vcYM2610Port1;
            vgmCmdTbl[0x5a] = vcYM3812;
            vgmCmdTbl[0x5b] = vcYM3526;
            vgmCmdTbl[0x5c] = vcY8950;
            vgmCmdTbl[0x5d] = vcYMZ280B;
            vgmCmdTbl[0x5e] = vcYMF262Port0;
            vgmCmdTbl[0x5f] = vcYMF262Port1;

            vgmCmdTbl[0x61] = vcWaitNSamples;
            vgmCmdTbl[0x62] = vcWait735Samples;
            vgmCmdTbl[0x63] = vcWait882Samples;
            vgmCmdTbl[0x64] = vcOverrideLength;

            vgmCmdTbl[0x66] = vcEndOfSoundData;
            vgmCmdTbl[0x67] = vcDataBlock;
            vgmCmdTbl[0x68] = vcPCMRamWrite;

            vgmCmdTbl[0x70] = vcWaitN1Samples;
            vgmCmdTbl[0x71] = vcWaitN1Samples;
            vgmCmdTbl[0x72] = vcWaitN1Samples;
            vgmCmdTbl[0x73] = vcWaitN1Samples;
            vgmCmdTbl[0x74] = vcWaitN1Samples;
            vgmCmdTbl[0x75] = vcWaitN1Samples;
            vgmCmdTbl[0x76] = vcWaitN1Samples;
            vgmCmdTbl[0x77] = vcWaitN1Samples;

            vgmCmdTbl[0x78] = vcWaitN1Samples;
            vgmCmdTbl[0x79] = vcWaitN1Samples;
            vgmCmdTbl[0x7a] = vcWaitN1Samples;
            vgmCmdTbl[0x7b] = vcWaitN1Samples;
            vgmCmdTbl[0x7c] = vcWaitN1Samples;
            vgmCmdTbl[0x7d] = vcWaitN1Samples;
            vgmCmdTbl[0x7e] = vcWaitN1Samples;
            vgmCmdTbl[0x7f] = vcWaitN1Samples;

            vgmCmdTbl[0x80] = vcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x81] = vcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x82] = vcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x83] = vcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x84] = vcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x85] = vcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x86] = vcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x87] = vcWaitNSamplesAndSendYM26120x2a;

            vgmCmdTbl[0x88] = vcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x89] = vcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x8a] = vcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x8b] = vcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x8c] = vcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x8d] = vcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x8e] = vcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x8f] = vcWaitNSamplesAndSendYM26120x2a;

            vgmCmdTbl[0x90] = vcSetupStreamControl;
            vgmCmdTbl[0x91] = vcSetStreamData;
            vgmCmdTbl[0x92] = vcSetStreamFrequency;
            vgmCmdTbl[0x93] = vcStartStream;
            vgmCmdTbl[0x94] = vcStopStream;
            vgmCmdTbl[0x95] = vcStartStreamFastCall;

            vgmCmdTbl[0xa0] = vcAY8910;
            vgmCmdTbl[0xa1] = vcYM2413;
            vgmCmdTbl[0xa2] = vcYM2612Port0;
            vgmCmdTbl[0xa3] = vcYM2612Port1;
            vgmCmdTbl[0xa4] = vcYM2151;
            vgmCmdTbl[0xa5] = vcYM2203;
            vgmCmdTbl[0xa6] = vcYM2608Port0;
            vgmCmdTbl[0xa7] = vcYM2608Port1;

            vgmCmdTbl[0xa8] = vcYM2610Port0;
            vgmCmdTbl[0xa9] = vcYM2610Port1;
            vgmCmdTbl[0xaa] = vcYM3812;
            vgmCmdTbl[0xab] = vcDummy2Ope;
            vgmCmdTbl[0xac] = vcY8950;
            vgmCmdTbl[0xad] = vcYMZ280B;
            vgmCmdTbl[0xae] = vcYMF262Port0;
            vgmCmdTbl[0xaf] = vcYMF262Port1;

            //if ((useChip & enmUseChip.RF5C164) == enmUseChip.RF5C164)
            //{
            vgmCmdTbl[0xb0] = vcRf5c68;
            vgmCmdTbl[0xc1] = vcRf5c68MemoryWrite;
            vgmCmdTbl[0xb1] = vcRf5c164;
            vgmCmdTbl[0xc2] = vcRf5c164MemoryWrite;
            //}
            //else
            //{
            //    vgmCmdTbl[0xb1] = vcDummy2Ope;
            //    vgmCmdTbl[0xc2] = vcDummy3Ope;
            //}

            //if ((useChip & enmUseChip.PWM) == enmUseChip.PWM)
            //{
            vgmCmdTbl[0xb2] = vcPWM;
            //}
            //else
            //{
            //vgmCmdTbl[0xb2] = vcDummy2Ope;
            //}
            vgmCmdTbl[0xb3] = vcDMG;
            vgmCmdTbl[0xb4] = vcNES;
            vgmCmdTbl[0xb5] = vcMultiPCM;
            vgmCmdTbl[0xb6] = vcDummy2Ope;
            vgmCmdTbl[0xb7] = vcOKIM6258;

            vgmCmdTbl[0xb8] = vcOKIM6295;
            vgmCmdTbl[0xb9] = vcHuC6280;
            vgmCmdTbl[0xba] = vcK053260;
            vgmCmdTbl[0xbb] = vcDummy2Ope;
            vgmCmdTbl[0xbc] = vcDummy2Ope;
            vgmCmdTbl[0xbd] = vcDummy2Ope;
            vgmCmdTbl[0xbe] = vcDummy2Ope;
            vgmCmdTbl[0xbf] = vcGA20;

            vgmCmdTbl[0xc0] = vcSEGAPCM;
            vgmCmdTbl[0xc3] = vcMultiPCMSetBank;
            vgmCmdTbl[0xc4] = vcQSound;
            vgmCmdTbl[0xc5] = vcDummy3Ope;
            vgmCmdTbl[0xc6] = vcDummy3Ope;
            vgmCmdTbl[0xc7] = vcDummy3Ope;

            vgmCmdTbl[0xc8] = vcDummy3Ope;
            vgmCmdTbl[0xc9] = vcDummy3Ope;
            vgmCmdTbl[0xca] = vcDummy3Ope;
            vgmCmdTbl[0xcb] = vcDummy3Ope;
            vgmCmdTbl[0xcc] = vcDummy3Ope;
            vgmCmdTbl[0xcd] = vcDummy3Ope;
            vgmCmdTbl[0xce] = vcDummy3Ope;
            vgmCmdTbl[0xcf] = vcDummy3Ope;

            vgmCmdTbl[0xd0] = vcYMF278B;
            vgmCmdTbl[0xd1] = vcYMF271;
            vgmCmdTbl[0xd2] = vcK051649;
            vgmCmdTbl[0xd3] = vcK054539;
            vgmCmdTbl[0xd4] = vcC140;
            vgmCmdTbl[0xd5] = vcDummy3Ope;
            vgmCmdTbl[0xd6] = vcDummy3Ope;
            vgmCmdTbl[0xd7] = vcDummy3Ope;

            vgmCmdTbl[0xd8] = vcDummy3Ope;
            vgmCmdTbl[0xd9] = vcDummy3Ope;
            vgmCmdTbl[0xda] = vcDummy3Ope;
            vgmCmdTbl[0xdb] = vcDummy3Ope;
            vgmCmdTbl[0xdc] = vcDummy3Ope;
            vgmCmdTbl[0xdd] = vcDummy3Ope;
            vgmCmdTbl[0xde] = vcDummy3Ope;
            vgmCmdTbl[0xdf] = vcDummy3Ope;

            vgmCmdTbl[0xe0] = vcSeekToOffsetInPCMDataBank;
            vgmCmdTbl[0xe1] = vcC352;
            vgmCmdTbl[0xe2] = vcDummy4Ope;
            vgmCmdTbl[0xe3] = vcDummy4Ope;
            vgmCmdTbl[0xe4] = vcDummy4Ope;
            vgmCmdTbl[0xe5] = vcDummy4Ope;
            vgmCmdTbl[0xe6] = vcDummy4Ope;
            vgmCmdTbl[0xe7] = vcDummy4Ope;

            vgmCmdTbl[0xe8] = vcDummy4Ope;
            vgmCmdTbl[0xe9] = vcDummy4Ope;
            vgmCmdTbl[0xea] = vcDummy4Ope;
            vgmCmdTbl[0xeb] = vcDummy4Ope;
            vgmCmdTbl[0xec] = vcDummy4Ope;
            vgmCmdTbl[0xed] = vcDummy4Ope;
            vgmCmdTbl[0xee] = vcDummy4Ope;
            vgmCmdTbl[0xef] = vcDummy4Ope;

            vgmCmdTbl[0xf0] = vcDummy4Ope;
            vgmCmdTbl[0xf1] = vcDummy4Ope;
            vgmCmdTbl[0xf2] = vcDummy4Ope;
            vgmCmdTbl[0xf3] = vcDummy4Ope;
            vgmCmdTbl[0xf4] = vcDummy4Ope;
            vgmCmdTbl[0xf5] = vcDummy4Ope;
            vgmCmdTbl[0xf6] = vcDummy4Ope;
            vgmCmdTbl[0xf7] = vcDummy4Ope;

            vgmCmdTbl[0xf8] = vcDummy4Ope;
            vgmCmdTbl[0xf9] = vcDummy4Ope;
            vgmCmdTbl[0xfa] = vcDummy4Ope;
            vgmCmdTbl[0xfb] = vcDummy4Ope;
            vgmCmdTbl[0xfc] = vcDummy4Ope;
            vgmCmdTbl[0xfd] = vcDummy4Ope;
            vgmCmdTbl[0xfe] = vcDummy4Ope;
            vgmCmdTbl[0xff] = vcDummy4Ope;

        }

        private void vcDummyChip(outDatum od)
        {
            chipRegister.writeDummyChip(od, Audio.DriverSeqCounter, vgmBuf[vgmAdr + 1].val, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcDummy1Ope(outDatum od)
        {
            //Console.Write("({0:X02}:{1:X02})", vgmBuf[vgmAdr], vgmBuf[vgmAdr + 1]);
            vgmAdr += 2;
        }

        private void vcDummy2Ope(outDatum od)
        {
            //Console.Write("({0:X02}:{1:X02}:{2:X02})", vgmBuf[vgmAdr], vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2]);
            vgmAdr += 3;
        }

        private void vcDummy3Ope(outDatum od)
        {
            //Console.Write("({0:X02}:{1:X02}:{2:X02}:{3:X02})", vgmBuf[vgmAdr], vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], vgmBuf[vgmAdr + 3]);
            vgmAdr += 4;
        }

        private void vcDummy4Ope(outDatum od)
        {
            //Console.WriteLine("unknown command:Adr:{0:X}({1:X02}:{2:X02}:{3:X02}:{4:X02}:{5:X02})",vgmAdr, vgmBuf[vgmAdr], vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], vgmBuf[vgmAdr + 3], vgmBuf[vgmAdr + 4]);
            vgmAdr += 5;
        }

        private void vcGGPSGPort06(outDatum od)
        {
            chipRegister.SN76489SetRegisterGGpanning(od, Audio.DriverSeqCounter, vgmBuf[vgmAdr].val == 0x4f ? 0 : 1, vgmBuf[vgmAdr + 1].val);
            vgmAdr += 2;
        }

        private void vcPSG(outDatum od)
        {
            chipRegister.SN76489SetRegister(od, Audio.DriverSeqCounter, vgmBuf[vgmAdr].val == 0x50 ? 0 : 1, vgmBuf[vgmAdr + 1].val);
            vgmAdr += 2;
        }

        private void vcAY8910(outDatum od)
        {
            chipRegister.AY8910SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr + 1].val & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1].val & 0x7f, vgmBuf[vgmAdr + 2].val);
            //chipRegister.setAY8910Register(0, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void vcDMG(outDatum od)
        {
            chipRegister.setDMGRegister((vgmBuf[vgmAdr + 1].val & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1].val & 0x7f, vgmBuf[vgmAdr + 2].val);
            //chipRegister.setAY8910Register(0, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void vcNES(outDatum od)
        {
            chipRegister.setNESRegister((vgmBuf[vgmAdr + 1].val & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1].val & 0x7f, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcMultiPCM(outDatum od)
        {
            chipRegister.setMultiPCMRegister((vgmBuf[vgmAdr + 1].val & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1].val & 0x7f, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcMultiPCMSetBank(outDatum od)
        {
            chipRegister.setMultiPCMSetBank((vgmBuf[vgmAdr + 1].val & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1].val & 0x7f, vgmBuf[vgmAdr + 2].val + vgmBuf[vgmAdr + 3].val * 0x100);
            vgmAdr += 4;
        }

        private void vcQSound(outDatum od)
        {
            //chipRegister.setQSoundRegister(0, vgmBuf[vgmAdr + 1].val, vgmBuf[vgmAdr + 2].val, vgmBuf[vgmAdr + 3].val);
            chipRegister.QSoundSetRegister(
                od,
                Audio.DriverSeqCounter,
                0,
                vgmBuf[vgmAdr + 3].val, //adr(register)
                vgmBuf[vgmAdr + 2].val + vgmBuf[vgmAdr + 1].val * 0x100//data
                );
            vgmAdr += 4;
        }

        private void vcYM2413(outDatum od)
        {
            chipRegister.YM2413SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr].val & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1].val, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcYM3812(outDatum od)
        {
            chipRegister.YM3812SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr].val & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1].val, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcHuC6280(outDatum od)
        {
            chipRegister.HuC6280SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr + 1].val & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1].val & 0x7f, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcGA20(outDatum od)
        {
            chipRegister.setGA20Register((vgmBuf[vgmAdr + 1].val & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1].val & 0x7f, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcYM2612Port0(outDatum od)
        {
            chipRegister.YM2612SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr].val & 0x80) == 0 ? 0 : 1, 0, vgmBuf[vgmAdr + 1].val, vgmBuf[vgmAdr + 2].val);//,  vgmFrameCounter);
            vgmAdr += 3;
        }

        private void vcYM2612Port1(outDatum od)
        {
            chipRegister.YM2612SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr].val & 0x80) == 0 ? 0 : 1, 1, vgmBuf[vgmAdr + 1].val, vgmBuf[vgmAdr + 2].val);//,  vgmFrameCounter);
            vgmAdr += 3;
        }

        private void vcYM2203(outDatum od)
        {
            chipRegister.YM2203SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr].val & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1].val, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcYM2608Port0(outDatum od)
        {
            chipRegister.YM2608SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr].val & 0x80) == 0 ? 0 : 1, 0, vgmBuf[vgmAdr + 1].val, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcYM2608Port1(outDatum od)
        {
            chipRegister.YM2608SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr].val & 0x80) == 0 ? 0 : 1, 1, vgmBuf[vgmAdr + 1].val, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcYM2610Port0(outDatum od)
        {
            chipRegister.YM2610SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr].val & 0x80) == 0 ? 0 : 1, 0, vgmBuf[vgmAdr + 1].val, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcYM2610Port1(outDatum od)
        {
            int adr = vgmBuf[vgmAdr + 1].val;
            int dat = vgmBuf[vgmAdr + 2].val;
            chipRegister.YM2610SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr].val & 0x80) == 0 ? 0 : 1, 1, adr, dat);
            vgmAdr += 3;
        }

        private void vcYMF262Port0(outDatum od)
        {
            chipRegister.YMF262SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr].val & 0x80) == 0 ? 0 : 1, 0, vgmBuf[vgmAdr + 1].val, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcYMF262Port1(outDatum od)
        {
            int adr = vgmBuf[vgmAdr + 1].val;
            int dat = vgmBuf[vgmAdr + 2].val;
            chipRegister.YMF262SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr].val & 0x80) == 0 ? 0 : 1, 1, adr, dat);
            vgmAdr += 3;
        }

        private void vcYM3526(outDatum od)
        {
            chipRegister.YM3526SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr].val & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1].val, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcY8950(outDatum od)
        {
            chipRegister.Y8950SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr].val & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1].val, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcYMZ280B(outDatum od)
        {
            chipRegister.setYMZ280BRegister((vgmBuf[vgmAdr].val & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1].val, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcYMF271(outDatum od)
        {
            chipRegister.YMF271SetRegister(
                od,Audio.DriverSeqCounter,
                (vgmBuf[vgmAdr + 1].val & 0x80) == 0 ? 0 : 1
                , vgmBuf[vgmAdr + 1].val & 0x7f
                , vgmBuf[vgmAdr + 2].val
                , vgmBuf[vgmAdr + 3].val
                );
            vgmAdr += 4;
        }

        private void vcYMF278B(outDatum od)
        {
            chipRegister.setYMF278BRegister(
                (vgmBuf[vgmAdr + 1].val & 0x80) == 0 ? 0 : 1
                , vgmBuf[vgmAdr + 1].val & 0x7f
                , vgmBuf[vgmAdr + 2].val
                , vgmBuf[vgmAdr + 3].val
                );
            //Console.WriteLine("fm:{0:x02}:{1:x02}:{2:x02}:", vgmBuf[vgmAdr + 1].val & 0x7f
            //, vgmBuf[vgmAdr + 2].val
            //, vgmBuf[vgmAdr + 3].val
            //);
            vgmAdr += 4;
        }

        private void vcYM2151(outDatum od)
        {
            chipRegister.YM2151SetRegister(od, Audio.DriverSeqCounter, (vgmBuf[vgmAdr].val & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1].val, vgmBuf[vgmAdr + 2].val);
            //, (vgmBuf[vgmAdr].val & 0x80) == 0 ? YM2151Hosei[0].val : YM2151Hosei[1].val, vgmFrameCounter);
            vgmAdr += 3;
        }

        private void vcOKIM6258(outDatum od)
        {
            chipRegister.writeOKIM6258(0, (byte)(vgmBuf[vgmAdr + 0x01].val & 0x7F), vgmBuf[vgmAdr + 0x02].val);
            vgmAdr += 3;
        }

        private void vcOKIM6295(outDatum od)
        {
            chipRegister.writeOKIM6295((byte)((vgmBuf[vgmAdr + 0x01].val & 0x80) == 0 ? 0 : 1), (byte)(vgmBuf[vgmAdr + 0x01].val & 0x7F), vgmBuf[vgmAdr + 0x02].val);
            vgmAdr += 3;
        }

        private void vcSEGAPCM(outDatum od)
        {
            //Console.WriteLine("{0:X4} {1:X4}", vgmBuf[vgmAdr + 0x01].val, vgmBuf[vgmAdr + 0x02].val);
            chipRegister.SEGAPCMSetRegister(od, Audio.DriverSeqCounter, 0, (int)((vgmBuf[vgmAdr + 0x01].val & 0xFF) | ((vgmBuf[vgmAdr + 0x02].val & 0xFF) << 8)), vgmBuf[vgmAdr + 0x03].val);
            vgmAdr += 4;
        }

        private void vcWaitNSamples(outDatum od)
        {
            if (jumpPointClock < 0)
            {
                Audio.DriverSeqCounter += (int)getLE16(vgmAdr + 1);
            }
            else
            {
                jumpPointClock -= (int)getLE16(vgmAdr + 1);
            }
            vgmAdr += 3;
        }

        private void vcWait735Samples(outDatum od)
        {
            if (jumpPointClock < 0)
            {
                Audio.DriverSeqCounter += 735;
            }
            else
            {
                jumpPointClock -= 735;
            }
            vgmAdr++;
        }

        private void vcWait882Samples(outDatum od)
        {
            if (jumpPointClock < 0)
            {
                Audio.DriverSeqCounter += 882;
            }
            else
            {
                jumpPointClock -= 882;
            }
            vgmAdr++;
        }

        private void vcOverrideLength(outDatum od)
        {
            vgmAdr += 4;
        }

        private void vcEndOfSoundData(outDatum od)
        {
            vgmAdr = (uint)vgmBuf.Length;
        }

        private void vcDataBlock(outDatum od)
        {

            uint bAdr = vgmAdr + 7;
            byte bType = vgmBuf[vgmAdr + 2].val;
            uint bLen = getLE32(vgmAdr + 3);
            byte chipID = 0;
            if ((bLen & 0x80000000) != 0)
            {
                bLen &= 0x7fffffff;
                chipID = 1;
            }

            switch (bType & 0xc0)
            {
                case 0x00:
                case 0x40:
                    AddPCMData(bType, bLen, bAdr);
                    vgmAdr += (uint)bLen + 7;
                    break;
                case 0x80:
                    uint romSize = getLE32(vgmAdr + 7);
                    uint startAddress = getLE32(vgmAdr + 0x0B);
                    switch (bType)
                    {
                        case 0x80:
                            //SEGA PCM
                            //chipRegister.SEGAPCMWritePCMData(Audio.DriverSeqCounter, chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15);
                            pcmDat.Clear();
                            for (uint i = vgmAdr + 15; i < vgmAdr + 15 + bLen - 8; i++) pcmDat.Add(vgmBuf[i].val);
                            chipRegister.SEGAPCMWritePCMData(od, Audio.DriverSeqCounter, chipID, romSize, startAddress, bLen - 8, pcmDat.ToArray(), 0);
                            //dumpDataForSegaPCM("SEGAPCM_PCMData", vgmAdr + 15, bLen - 8);
                            break;
                        case 0x81:

                            // YM2608
                            List<PackData> data = new List<PackData>
                            {
                                new PackData(null,chipRegister.YM2608[chipID],0,0x100+ 0x00, 0x20,null),
                                new PackData(null,chipRegister.YM2608[chipID],0,0x100+ 0x00, 0x21,null),
                                new PackData(null,chipRegister.YM2608[chipID],0,0x100+ 0x00, 0x00,null),

                                new PackData(null,chipRegister.YM2608[chipID],0,0x100+ 0x10, 0x00,null),
                                new PackData(null,chipRegister.YM2608[chipID],0,0x100+ 0x10, 0x80,null),

                                new PackData(null,chipRegister.YM2608[chipID],0,0x100+ 0x00, 0x61,null),
                                new PackData(null,chipRegister.YM2608[chipID],0,0x100+ 0x00, 0x68,null),
                                new PackData(null,chipRegister.YM2608[chipID],0,0x100+ 0x01, 0x00,null),

                                new PackData(null,chipRegister.YM2608[chipID],0,0x100+ 0x02, (byte)(startAddress >> 2),null),
                                new PackData(null,chipRegister.YM2608[chipID],0,0x100+ 0x03, (byte)(startAddress >> 10),null),
                                new PackData(null,chipRegister.YM2608[chipID],0,0x100+ 0x04, 0xff,null),
                                new PackData(null,chipRegister.YM2608[chipID],0,0x100+ 0x05, 0xff,null),
                                new PackData(null,chipRegister.YM2608[chipID],0,0x100+ 0x0c, 0xff,null),
                                new PackData(null,chipRegister.YM2608[chipID],0,0x100+ 0x0d, 0xff,null)
                            };

                            // データ転送
                            for (int cnt = 0; cnt < bLen - 8; cnt++)
                            {
                                data.Add(new PackData(null, chipRegister.YM2608[chipID], 0, 0x100 + 0x08, vgmBuf[vgmAdr + 15 + cnt].val, null));
                            }
                            data.Add(new PackData(null, chipRegister.YM2608[chipID], 0, 0x100 + 0x00, 0x00, null));
                            data.Add(new PackData(null, chipRegister.YM2608[chipID], 0, 0x100 + 0x10, 0x80, null));

                            //chipRegister.setYM2608Register(0x1, 0x10, 0x13, model);
                            //chipRegister.setYM2608Register(0x1, 0x10, 0x80, model);
                            //chipRegister.setYM2608Register(0x1, 0x00, 0x60, model);
                            //chipRegister.setYM2608Register(0x1, 0x01, 0x00, model);

                            //chipRegister.setYM2608Register(0x1, 0x02, (int)((startAddress >> 2) & 0xff), model);
                            //chipRegister.setYM2608Register(0x1, 0x03, (int)((startAddress >> 10) & 0xff), model);
                            //chipRegister.setYM2608Register(0x1, 0x04, (int)(((startAddress + bLen - 8) >> 2) & 0xff), model);
                            //chipRegister.setYM2608Register(0x1, 0x05, (int)(((startAddress + bLen - 8) >> 10) & 0xff), model);
                            //chipRegister.setYM2608Register(0x1, 0x0c, 0xff, model);
                            //chipRegister.setYM2608Register(0x1, 0x0d, 0xff, model);

                            //for (int cnt = 0; cnt < bLen - 8; cnt++)
                            //{
                            //    chipRegister.setYM2608Register(0x1, 0x08, vgmBuf[vgmAdr + 15 + cnt].val, model);
                            //    chipRegister.setYM2608Register(0x1, 0x10, 0x1b, model);
                            //    chipRegister.setYM2608Register(0x1, 0x10, 0x13, model);
                            //}

                            //chipRegister.setYM2608Register(0x1, 0x00, 0x00, model);
                            //chipRegister.setYM2608Register(0x1, 0x10, 0x80, model);

                            Chip dummyChip = new Chip(1);
                            dummyChip.Move(chipRegister.YM2608[chipID]);

                            if (chipRegister.YM2608[chipID].Model == EnmVRModel.RealModel)
                            {
                                if (setting.YM2608Type.OnlyPCMEmulation)
                                {
                                    dummyChip.Model = EnmVRModel.VirtualModel;
                                }
                                else
                                {
                                    Audio.DriverSeqCounter += (long)(bLen * 1.5);
                                }
                            }

                            chipRegister.YM2608SetRegister(od, Audio.DriverSeqCounter, dummyChip, data.ToArray());

                            //dumpData(dummyChip, "YM2608_ADPCM", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x82:
                            if (ym2610AdpcmA[chipID] == null || ym2610AdpcmA[chipID].Length != romSize) ym2610AdpcmA[chipID] = new byte[romSize];
                            if (ym2610AdpcmA[chipID].Length > 0)
                            {
                                for (int cnt = 0; cnt < bLen - 8; cnt++)
                                {
                                    ym2610AdpcmA[chipID][startAddress + cnt] = vgmBuf[vgmAdr + 15 + cnt].val;
                                }
                                //if (model == EnmModel.VirtualModel) 
                                chipRegister.YM2610WriteSetAdpcmA(od, Audio.DriverSeqCounter, chipID, ym2610AdpcmA[chipID]);
                                //else chipRegister.WriteYM2610_SetAdpcmA(chipID, model, (int)startAddress, (int)(bLen - 8), vgmBuf, (int)(vgmAdr + 15));
                                //dumpData(chipRegister.YM2610[chipID], "YM2610_ADPCMA", vgmAdr + 15, bLen - 8);
                            }
                            break;
                        case 0x83:
                            if (ym2610AdpcmB[chipID] == null || ym2610AdpcmB[chipID].Length != romSize) ym2610AdpcmB[chipID] = new byte[romSize];
                            if (ym2610AdpcmB[chipID].Length > 0)
                            {
                                for (int cnt = 0; cnt < bLen - 8; cnt++)
                                {
                                    ym2610AdpcmB[chipID][startAddress + cnt] = vgmBuf[vgmAdr + 15 + cnt].val;
                                }
                                //if (model == EnmModel.VirtualModel)
                                chipRegister.YM2610WriteSetAdpcmB(od, Audio.DriverSeqCounter, chipID, ym2610AdpcmB[chipID]);
                                //else chipRegister.WriteYM2610_SetAdpcmB(chipID, model, (int)startAddress, (int)(bLen - 8), vgmBuf, (int)(vgmAdr + 15));
                                //dumpData(chipRegister.YM2610[chipID], "YM2610_ADPCMB", vgmAdr + 15, bLen - 8);
                            }
                            break;

                        case 0x84:
                            // YMF278B
                            //chipRegister.writeYMF278BPCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15);
                            pcmDat.Clear();
                            for (uint i = vgmAdr + 15; i < vgmAdr + 15 + bLen - 8; i++) pcmDat.Add(vgmBuf[i].val);
                            chipRegister.writeYMF278BPCMData(chipID, romSize, startAddress, bLen - 8, pcmDat.ToArray(), 0);
                            //dumpData(model, "YMF278B_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x85:
                            // YMF271
                            //chipRegister.writeYMF271PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15);
                            pcmDat.Clear();
                            for (uint i = vgmAdr + 15; i < vgmAdr + 15 + bLen - 8; i++) pcmDat.Add(vgmBuf[i].val);
                            chipRegister.writeYMF271PCMData(chipID, romSize, startAddress, bLen - 8, pcmDat.ToArray(), 0);
                            //dumpData(model, "YMF271_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x86:
                            // YMZ280B
                            //chipRegister.writeYMZ280BPCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15);
                            pcmDat.Clear();
                            for (uint i = vgmAdr + 15; i < vgmAdr + 15 + bLen - 8; i++) pcmDat.Add(vgmBuf[i].val);
                            chipRegister.writeYMZ280BPCMData(chipID, romSize, startAddress, bLen - 8, pcmDat.ToArray(), 0);
                            //dumpData(model, "YMZ280B_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x88:
                            // Y8950
                            //chipRegister.writeY8950PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15);
                            pcmDat.Clear();
                            for (uint i = vgmAdr + 15; i < vgmAdr + 15 + bLen - 8; i++) pcmDat.Add(vgmBuf[i].val);
                            chipRegister.writeY8950PCMData(chipID, romSize, startAddress, bLen - 8, pcmDat.ToArray(), 0);
                            //dumpData(model, "Y8950_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x89:
                            // MultiPCM
                            //chipRegister.writeMultiPCMPCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15);
                            pcmDat.Clear();
                            for (uint i = vgmAdr + 15; i < vgmAdr + 15 + bLen - 8; i++) pcmDat.Add(vgmBuf[i].val);
                            chipRegister.writeMultiPCMPCMData(chipID, romSize, startAddress, bLen - 8, pcmDat.ToArray(), 0);
                            //dumpData(model, "MultiPCM_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x8b:
                            // OKIM6295
                            //chipRegister.writeOKIM6295PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15);
                            pcmDat.Clear();
                            for (uint i = vgmAdr + 15; i < vgmAdr + 15 + bLen - 8; i++) pcmDat.Add(vgmBuf[i].val);
                            chipRegister.writeOKIM6295PCMData(chipID, romSize, startAddress, bLen - 8, pcmDat.ToArray(), 0);
                            //dumpData(model, "OKIM6295_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x8c:
                            // K054539
                            //chipRegister.writeK054539PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15);
                            pcmDat.Clear();
                            for (uint i = vgmAdr + 15; i < vgmAdr + 15 + bLen - 8; i++) pcmDat.Add(vgmBuf[i].val);
                            chipRegister.writeK054539PCMData(chipID, romSize, startAddress, bLen - 8, pcmDat.ToArray(), 0);
                            //dumpData(model, "K054539_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x8d:

                            // C140

                            //chipRegister.C140WritePCMData(Audio.DriverSeqCounter, chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15);
                            pcmDat.Clear();
                            for (uint i = vgmAdr + 15; i < vgmAdr + 15 + bLen - 8; i++) pcmDat.Add(vgmBuf[i].val);
                            chipRegister.C140WritePCMData(od, Audio.DriverSeqCounter, chipID, romSize, startAddress, bLen - 8, pcmDat.ToArray(), 0);
                            //dumpData(model, "C140_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x8e:
                            // K053260
                            //chipRegister.writeK053260PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15);
                            pcmDat.Clear();
                            for (uint i = vgmAdr + 15; i < vgmAdr + 15 + bLen - 8; i++) pcmDat.Add(vgmBuf[i].val);
                            chipRegister.K053260WritePCMData(od, Audio.DriverSeqCounter, chipID, romSize, startAddress, bLen - 8, pcmDat.ToArray(), 0);
                            //dumpData(model, "K053260_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x8f:
                            // QSound
                            //chipRegister.writeQSoundPCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15);
                            pcmDat.Clear();
                            for (uint i = vgmAdr + 15; i < vgmAdr + 15 + bLen - 8; i++) pcmDat.Add(vgmBuf[i].val);
                            chipRegister.QSoundWritePCMData(od, Audio.DriverSeqCounter, chipID, romSize, startAddress, bLen - 8, pcmDat.ToArray(), 0);
                            //dumpData(model, "QSound_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x92:
                            // C352
                            //chipRegister.writeC352PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15);
                            pcmDat.Clear();
                            for (uint i = vgmAdr + 15; i < vgmAdr + 15 + bLen - 8; i++) pcmDat.Add(vgmBuf[i].val);
                            chipRegister.writeC352PCMData(chipID, romSize, startAddress, bLen - 8, pcmDat.ToArray(), 0);
                            //dumpData(model, "C352_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x93:
                            // GA20
                            //chipRegister.writeGA20PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15);
                            pcmDat.Clear();
                            for (uint i = vgmAdr + 15; i < vgmAdr + 15 + bLen - 8; i++) pcmDat.Add(vgmBuf[i].val);
                            chipRegister.writeGA20PCMData(chipID, romSize, startAddress, bLen - 8, pcmDat.ToArray(), 0);
                            //dumpData(model, "GA20_PCMData", vgmAdr + 15, bLen - 8);
                            break;
                    }
                    vgmAdr += (uint)bLen + 7;
                    break;
                case 0xc0:
                    uint stAdr = getLE16(vgmAdr + 7);
                    uint dataSize = bLen - 2;
                    uint ROMData = vgmAdr + 9;
                    if ((bType & 0x20) != 0)
                    {
                        stAdr = getLE32(vgmAdr + 7);
                        dataSize = bLen - 4;
                        ROMData = vgmAdr + 11;
                    }

                    try
                    {
                        switch (bType)
                        {
                            case 0xc0:
                                //chipRegister.writeRF5C68PCMData(chipID, stAdr, dataSize, vgmBuf, vgmAdr + 9);
                                pcmDat.Clear();
                                for (uint i = vgmAdr + 9; i < vgmAdr + 9 + dataSize; i++) pcmDat.Add(vgmBuf[i].val);
                                chipRegister.writeRF5C68PCMData(chipID, stAdr, dataSize, pcmDat.ToArray(), 0);
                                //dumpData(model, "RF5C68_PCMData(8BitMonoSigned)", vgmAdr + 9, dataSize);
                                break;
                            case 0xc1:
                                //chipRegister.writeRF5C164PCMData(chipID, stAdr, dataSize, vgmBuf, vgmAdr + 9);
                                pcmDat.Clear();
                                for (uint i = vgmAdr + 9; i < vgmAdr + 9 + dataSize; i++) pcmDat.Add(vgmBuf[i].val);
                                chipRegister.RF5C164WritePCMData(od, Audio.DriverSeqCounter, chipID, stAdr, dataSize, pcmDat.ToArray(), 0);
                                //dumpData(model, "RF5C164_PCMData(8BitMonoSigned)", vgmAdr + 9, dataSize);
                                break;
                            case 0xc2:
                                //chipRegister.writeNESPCMData(chipID, stAdr, dataSize, vgmBuf, vgmAdr + 9);
                                pcmDat.Clear();
                                for (uint i = vgmAdr + 9; i < vgmAdr + 9 + dataSize; i++) pcmDat.Add(vgmBuf[i].val);
                                chipRegister.writeNESPCMData(chipID, stAdr, dataSize, pcmDat.ToArray(), 0);
                                //dumpData(model, "NES_PCMData", vgmAdr + 9, dataSize);
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        log.ForcedWrite(e);
                    }

                    vgmAdr += bLen + 7;
                    break;
                default:
                    vgmAdr += bLen + 7;
                    break;
            }

        }

        private void vcPCMRamWrite(outDatum od)
        {

            isPcmRAMWrite = true;

            byte bType = (byte)(vgmBuf[vgmAdr + 2].val & 0x7f);
            //CurrentChip = (vgmBuf[vgmAdr + 2].val & 0x80)>>7;
            uint bReadOffset = getLE24(vgmAdr + 3);
            uint bWriteOffset = getLE24(vgmAdr + 6);
            uint bSize = getLE24(vgmAdr + 9);
            if (bSize == 0) bSize = 0x1000000;
            uint? pcmAdr = GetPCMAddressFromPCMBank(bType, bReadOffset);
            if (pcmAdr != null)
            {
                if (bType == 0x01)
                {
                    chipRegister.writeRF5C68PCMData(0, bWriteOffset, bSize, PCMBank[bType].Data, (uint)pcmAdr);
                }
                if (bType == 0x02)
                {
                    chipRegister.RF5C164WritePCMData(od, Audio.DriverSeqCounter, 0, bWriteOffset, bSize, PCMBank[bType].Data, (uint)pcmAdr);
                }
            }

            vgmAdr += 12;

            isPcmRAMWrite = false;

        }

        private void vcWaitN1Samples(outDatum od)
        {
            if (jumpPointClock < 0)
            {
                Audio.DriverSeqCounter += (int)(vgmBuf[vgmAdr].val - 0x6f);
            }
            else
            {
                jumpPointClock -= (int)(vgmBuf[vgmAdr].val - 0x6f);
            }
            vgmAdr++;
        }

        private void vcWaitNSamplesAndSendYM26120x2a(outDatum od)
        {
            byte dat = GetDACFromPCMBank();

            chipRegister.YM2612SetRegister(od, Audio.DriverSeqCounter, 0, 0, 0x2a, dat);
            //log.Write(Audio.DriverSeqCounter.ToString());

            if (jumpPointClock < 0)
            {
                Audio.DriverSeqCounter += (int)(vgmBuf[vgmAdr].val - 0x80);
            }
            else
            {
                jumpPointClock -= (int)(vgmBuf[vgmAdr].val - 0x80);
            }


            vgmAdr++;
        }

        private void vcSetupStreamControl(outDatum od)
        {
            //if (model != enmModel.VirtualModel)
            //{
            //    vgmAdr += 5;
            //    return;
            //}

            byte si = vgmBuf[vgmAdr + 1].val;
            if (si == 0xff)
            {
                vgmAdr += 5;
                return;
            }
            if (!DacCtrl[si].Enable)
            {
                dacControl.device_start_daccontrol(si);
                dacControl.device_reset_daccontrol(si);
                DacCtrl[si].Enable = true;
                DacCtrlUsg[DacCtrlUsed] = si;
                DacCtrlUsed++;
            }
            byte chipId = vgmBuf[vgmAdr + 2].val;
            byte port = vgmBuf[vgmAdr + 3].val;
            byte cmd = vgmBuf[vgmAdr + 4].val;

            dacControl.setup_chip(si, (byte)(chipId & 0x7F), (byte)((chipId & 0x80) >> 7), (uint)(port * 0x100 + cmd));
            vgmAdr += 5;
        }

        private void vcSetStreamData(outDatum od)
        {
            //if (model != enmModel.VirtualModel)
            //{
            //    vgmAdr += 5;
            //    return;
            //}

            byte si = vgmBuf[vgmAdr + 1].val;
            if (si == 0xff)
            {
                vgmAdr += 5;
                return;
            }
            DacCtrl[si].Bank = vgmBuf[vgmAdr + 2].val;
            if (DacCtrl[si].Bank >= PCM_BANK_COUNT)
                DacCtrl[si].Bank = 0x00;

            VGM_PCM_BANK TempPCM = PCMBank[DacCtrl[si].Bank];
            //Last95Max = TempPCM->BankCount;
            dacControl.set_data(si, TempPCM.Data, TempPCM.DataSize,
                            vgmBuf[vgmAdr + 3].val, vgmBuf[vgmAdr + 4].val);

            vgmAdr += 5;
        }

        private void vcSetStreamFrequency(outDatum od)
        {
            //if (model != enmModel.VirtualModel)
            //{
            //    vgmAdr += 6;
            //    return;
            //}

            byte si = vgmBuf[vgmAdr + 1].val;
            if (si == 0xFF || !DacCtrl[si].Enable)
            {
                vgmAdr += 0x06;
                return;
            }
            uint TempLng = getLE32(vgmAdr + 2);
            //Last95Freq = TempLng;
            dacControl.set_frequency(si, TempLng);
            vgmAdr += 6;
        }

        private void vcStartStream(outDatum od)
        {
            //if (model != enmModel.VirtualModel)
            //{
            //    vgmAdr += 8;
            //    return;
            //}

            byte si = vgmBuf[vgmAdr + 1].val;
            if (si == 0xFF || !DacCtrl[si].Enable || PCMBank[DacCtrl[si].Bank].BankCount == 0)
            {
                vgmAdr += 0x08;
                return;
            }
            uint DataStart = getLE32(vgmAdr + 2);
            //Last95Drum = 0xFFFF;
            byte TempByt = vgmBuf[vgmAdr + 6].val;
            uint DataLen = getLE32(vgmAdr + 7);
            dacControl.start(si, DataStart, TempByt, DataLen, od);
            vgmAdr += 0x0B;

        }

        private void vcStopStream(outDatum od)
        {
            //if (model != enmModel.VirtualModel)
            //{
            //    vgmAdr += 2;
            //    return;
            //}

            byte si = vgmBuf[vgmAdr + 1].val;
            if (si < 0xff && !DacCtrl[si].Enable)
            {
                vgmAdr += 0x02;
                return;
            }
            //Last95Drum = 0xFFFF;
            if (si < 0xFF)
            {
                dacControl.stop(si);
            }
            else
            {
                for (si = 0x00; si < 0xFF; si++)
                    dacControl.stop(si);
            }
            vgmAdr += 0x02;
        }

        private void vcStartStreamFastCall(outDatum od)
        {
            //if (model != enmModel.VirtualModel)
            //{
            //    vgmAdr += 5;
            //    return;
            //}

            byte CurChip = vgmBuf[vgmAdr + 1].val;
            if (CurChip == 0xFF || !DacCtrl[CurChip].Enable ||
                PCMBank[DacCtrl[CurChip].Bank].BankCount == 0)
            {
                vgmAdr += 0x05;
                return;
            }
            VGM_PCM_BANK TempPCM = PCMBank[DacCtrl[CurChip].Bank];
            uint TempSht = getLE16(vgmAdr + 2);
            //Last95Drum = TempSht;
            //Last95Max = TempPCM->BankCount;
            if (TempSht >= TempPCM.BankCount)
                TempSht = 0x00;
            VGM_PCM_DATA TempBnk = TempPCM.Bank[(int)TempSht];

            byte TempByt = (byte)(dacControl.DCTRL_LMODE_BYTES |
                        (vgmBuf[vgmAdr + 4].val & 0x10) |         // Reverse Mode
                        ((vgmBuf[vgmAdr + 4].val & 0x01) << 7));   // Looping
            dacControl.start(CurChip, TempBnk.DataStart, TempByt, TempBnk.DataSize, od);
            vgmAdr += 0x05;

        }

        private void vcSeekToOffsetInPCMDataBank(outDatum od)
        {
            PCMBank[0x00].DataPos = getLE32(vgmAdr + 1);
            vgmAdr += 5;
        }

        private void vcRf5c68(outDatum od)
        {
            byte id = (byte)((vgmBuf[vgmAdr + 1].val & 0x80) != 0 ? 1 : 0);
            byte cmd = (byte)(vgmBuf[vgmAdr + 1].val & 0x7f);
            chipRegister.writeRF5C68(id, cmd, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcRf5c68MemoryWrite(outDatum od)
        {
            uint offset = getLE16(vgmAdr + 1);
            chipRegister.writeRF5C68MemW(0, offset, vgmBuf[vgmAdr + 3].val);
            vgmAdr += 4;
        }

        private void vcRf5c164(outDatum od)
        {
            byte id = (byte)((vgmBuf[vgmAdr + 1].val & 0x80) != 0 ? 1 : 0);
            byte cmd = (byte)(vgmBuf[vgmAdr + 1].val & 0x7f);
            chipRegister.RF5C164SetRegister(od, Audio.DriverSeqCounter, id, cmd, vgmBuf[vgmAdr + 2].val);
            vgmAdr += 3;
        }

        private void vcRf5c164MemoryWrite(outDatum od)
        {
            uint offset = getLE16(vgmAdr + 1);
            chipRegister.writeRF5C164MemW(od, Audio.DriverSeqCounter, 0, offset, vgmBuf[vgmAdr + 3].val);
            vgmAdr += 4;
        }

        private void vcPWM(outDatum od)
        {
            byte cmd = (byte)((vgmBuf[vgmAdr + 1].val & 0xf0) >> 4);
            uint data = (uint)((vgmBuf[vgmAdr + 1].val & 0xf) * 0x100 + vgmBuf[vgmAdr + 2].val);
            chipRegister.writePWM(0, cmd, data);
            vgmAdr += 3;
        }

        private void vcK051649(outDatum od)
        {
            int scc1_port = vgmBuf[vgmAdr + 1].val & 0x7f;
            byte scc1_offset = vgmBuf[vgmAdr + 2].val;
            byte rDat = vgmBuf[vgmAdr + 3].val;
            byte scc1_chipid = (byte)((vgmBuf[vgmAdr + 1].val & 0x80) != 0 ? 1 : 0);
            vgmAdr += 4;
            chipRegister.K051649SetRegister(od, Audio.DriverSeqCounter, scc1_chipid, (int)((scc1_port << 1) | 0x00), scc1_offset);
            chipRegister.K051649SetRegister(od, Audio.DriverSeqCounter, scc1_chipid, (int)((scc1_port << 1) | 0x01), rDat);

        }

        private void vcK053260(outDatum od)
        {
            byte id = (byte)((vgmBuf[vgmAdr + 1].val & 0x80) != 0 ? 1 : 0);
            int adr = (int)(vgmBuf[vgmAdr + 1].val & 0x7f);
            byte data = vgmBuf[vgmAdr + 2].val;
            chipRegister.K053260SetRegister(od, Audio.DriverSeqCounter, id, adr, data);
            vgmAdr += 3;
        }

        private void vcK054539(outDatum od)
        {
            byte id = (byte)((vgmBuf[vgmAdr + 1].val & 0x80) != 0 ? 1 : 0);
            uint adr = (uint)((vgmBuf[vgmAdr + 1].val & 0x7f) * 0x100 + (vgmBuf[vgmAdr + 2].val & 0xff));
            byte data = vgmBuf[vgmAdr + 3].val;
            chipRegister.writeK054539(id, adr, data);
            vgmAdr += 4;
        }

        private void vcC140(outDatum od)
        {
            byte id = (byte)((vgmBuf[vgmAdr + 1].val & 0x80) != 0 ? 1 : 0);
            int adr = (vgmBuf[vgmAdr + 1].val & 0x7f) * 0x100 + (vgmBuf[vgmAdr + 2].val & 0xff);
            byte data = vgmBuf[vgmAdr + 3].val;
            chipRegister.C140SetRegister(od, Audio.DriverSeqCounter, id, adr, data);
            vgmAdr += 4;
        }

        private void vcC352(outDatum od)
        {
            byte id = (byte)((vgmBuf[vgmAdr + 1].val & 0x80) != 0 ? 1 : 0);
            int adr = (int)((vgmBuf[vgmAdr + 1].val & 0x7f) * 0x100 + (vgmBuf[vgmAdr + 2].val & 0xff));
            int data = (int)((vgmBuf[vgmAdr + 3].val & 0xff) * 0x100 + (vgmBuf[vgmAdr + 4].val & 0xff));

            chipRegister.C352SetRegister(od, Audio.DriverSeqCounter, id, adr, data);
            vgmAdr += 5;
        }

        private UInt32 getLE16(UInt32 adr)
        {
            UInt32 dat;
            dat = (UInt32)vgmBuf[adr].val + (UInt32)vgmBuf[adr + 1].val * 0x100;

            return dat;
        }

        private UInt32 getLE24(UInt32 adr)
        {
            UInt32 dat;
            dat = (UInt32)vgmBuf[adr].val + (UInt32)vgmBuf[adr + 1].val * 0x100 + (UInt32)vgmBuf[adr + 2].val * 0x10000;

            return dat;
        }

        private UInt32 getLE32(UInt32 adr)
        {
            UInt32 dat;
            dat = (UInt32)vgmBuf[adr].val + (UInt32)vgmBuf[adr + 1].val * 0x100 + (UInt32)vgmBuf[adr + 2].val * 0x10000 + (UInt32)vgmBuf[adr + 3].val * 0x1000000;

            return dat;
        }


        private void AddPCMData(byte Type, uint DataSize, uint Adr)
        {
            uint CurBnk;
            VGM_PCM_BANK TempPCM;
            VGM_PCM_DATA TempBnk;
            uint BankSize;
            //bool RetVal;
            byte BnkType;
            byte CurDAC;

            BnkType = (byte)(Type & 0x3F);
            if (BnkType >= PCM_BANK_COUNT || vgmCurLoop > 0)
                return;

            if (Type == 0x7F)
            {
                //ReadPCMTable(DataSize, Data);
                ReadPCMTable(DataSize, Adr);
                return;
            }

            TempPCM = PCMBank[BnkType];// &PCMBank[BnkType];
            TempPCM.BnkPos++;
            if (TempPCM.BnkPos <= TempPCM.BankCount)
                return; // Speed hack for restarting playback (skip already loaded blocks)
            CurBnk = TempPCM.BankCount;
            TempPCM.BankCount++;
            //if (Last95Max != 0xFFFF) Last95Max = TempPCM.BankCount;
            TempPCM.Bank.Add(new VGM_PCM_DATA());// = (VGM_PCM_DATA*)realloc(TempPCM->Bank,
                                                 // sizeof(VGM_PCM_DATA) * TempPCM->BankCount);

            if ((Type & 0x40) == 0)
                BankSize = DataSize;
            else
                BankSize = getLE32(Adr + 1);// ReadLE32(&Data[0x01]);

            byte[] newData = new byte[TempPCM.DataSize + BankSize];
            if (TempPCM.Data != null && TempPCM.Data.Length > 0)
                Array.Copy(TempPCM.Data, newData, TempPCM.Data.Length);
            TempPCM.Data = newData;

            //TempPCM.Data = new byte[TempPCM.DataSize + BankSize];// realloc(TempPCM->Data, TempPCM->DataSize + BankSize);
            TempBnk = TempPCM.Bank[(int)CurBnk];
            TempBnk.DataStart = TempPCM.DataSize;
            TempBnk.Data = new byte[BankSize];
            if ((Type & 0x40) == 0)
            {
                TempBnk.DataSize = DataSize;
                for (int i = 0; i < DataSize; i++)
                {
                    TempPCM.Data[i + TempBnk.DataStart] = vgmBuf[Adr + i].val;
                    TempBnk.Data[i] = vgmBuf[Adr + i].val;
                }
                //TempBnk.Data = TempPCM.Data + TempBnk.DataStart;
                //memcpy(TempBnk->Data, Data, DataSize);
            }
            else
            {
                //TempBnk.Data = TempPCM.Data + TempBnk.DataStart;
                bool RetVal = DecompressDataBlk(TempBnk, DataSize, Adr);
                if (RetVal == false)
                {
                    TempBnk.Data = null;
                    TempBnk.DataSize = 0x00;
                    //return;
                    goto RefreshDACStrm;    // sorry for the goto, but I don't want to copy-paste the code
                }
                for (int i = 0; i < BankSize; i++)// DataSize; i++)
                {
                    TempPCM.Data[i + TempBnk.DataStart] = TempBnk.Data[i];
                }
            }
            //if (BankSize != TempBnk.DataSize) Console.Write("Error reading Data Block! Data Size conflict!\n");
            TempPCM.DataSize += BankSize;

        // realloc may've moved the Bank block, so refresh all DAC Streams
        RefreshDACStrm:
            for (CurDAC = 0x00; CurDAC < DacCtrlUsed; CurDAC++)
            {
                if (DacCtrl[DacCtrlUsg[CurDAC]].Bank == BnkType)
                    dacControl.refresh_data(DacCtrlUsg[CurDAC], TempPCM.Data, TempPCM.DataSize);
            }

            return;
        }

        private bool DecompressDataBlk(VGM_PCM_DATA Bank, uint DataSize, uint Adr)
        {
            byte ComprType;
            byte BitDec;
            byte BitCmp;
            byte CmpSubType;
            uint AddVal;
            uint InPos;
            uint InDataEnd;
            uint OutPos;
            uint OutDataEnd;
            uint InVal;
            uint OutVal = 0;// FUINT16 OutVal;
            byte ValSize;
            byte InShift;
            byte OutShift;
            uint Ent1B = 0;// UINT8* Ent1B;
            uint Ent2B = 0;// UINT16* Ent2B;
            //#if defined(_DEBUG) && defined(WIN32)
            //	UINT32 Time;
            //#endif

            // ReadBits Variables
            byte BitsToRead;
            byte BitReadVal;
            byte InValB;
            byte BitMask;
            byte OutBit;

            // Variables for DPCM
            uint OutMask;

            //#if defined(_DEBUG) && defined(WIN32)
            //	Time = GetTickCount();
            //#endif
            ComprType = vgmBuf[Adr + 0].val;
            Bank.DataSize = getLE32(Adr + 1);

            switch (ComprType)
            {
                case 0x00:  // n-Bit compression
                    BitDec = vgmBuf[Adr + 5].val;
                    BitCmp = vgmBuf[Adr + 6].val;
                    CmpSubType = vgmBuf[Adr + 7].val;
                    AddVal = getLE16(Adr + 8);

                    if (CmpSubType == 0x02)
                    {
                        //Bank.DataSize = 0x00;
                        //return false;

                        Ent1B = 0;// (UINT8*)PCMTbl.Entries; // Big Endian note: Those are stored in LE and converted when reading.
                        Ent2B = 0;// (UINT16*)PCMTbl.Entries;
                        if (PCMTbl.EntryCount == 0)
                        {
                            Bank.DataSize = 0x00;
                            //printf("Error loading table-compressed data block! No table loaded!\n");
                            return false;
                        }
                        else if (BitDec != PCMTbl.BitDec || BitCmp != PCMTbl.BitCmp)
                        {
                            Bank.DataSize = 0x00;
                            //printf("Warning! Data block and loaded value table incompatible!\n");
                            return false;
                        }
                    }

                    ValSize = (byte)((BitDec + 7) / 8);
                    InPos = Adr + 0x0A;
                    InDataEnd = Adr + DataSize;
                    InShift = 0;
                    OutShift = (byte)(BitDec - BitCmp);
                    //                    OutDataEnd = Bank.Data + Bank.DataSize;
                    OutDataEnd = Bank.DataSize;

                    //for (OutPos = Bank->Data; OutPos < OutDataEnd && InPos < InDataEnd; OutPos += ValSize)
                    for (OutPos = 0; OutPos < OutDataEnd && InPos < InDataEnd; OutPos += ValSize)
                    {
                        //InVal = ReadBits(Data, InPos, &InShift, BitCmp);
                        // inlined - is 30% faster
                        OutBit = 0x00;
                        InVal = 0x0000;
                        BitsToRead = BitCmp;
                        while (BitsToRead != 0)
                        {
                            BitReadVal = (byte)((BitsToRead >= 8) ? 8 : BitsToRead);
                            BitsToRead -= BitReadVal;
                            BitMask = (byte)((1 << BitReadVal) - 1);

                            InShift += BitReadVal;
                            //InValB = (byte)((vgmBuf[InPos].val << InShift >> 8) & BitMask);
                            InValB = (byte)((vgmBuf[InPos].val << InShift >> 8) & BitMask);
                            if (InShift >= 8)
                            {
                                InShift -= 8;
                                InPos++;
                                if (InShift != 0)
                                    InValB |= (byte)((vgmBuf[InPos].val << InShift >> 8) & BitMask);
                            }

                            InVal |= (uint)(InValB << OutBit);
                            OutBit += BitReadVal;
                        }

                        switch (CmpSubType)
                        {
                            case 0x00:  // Copy
                                OutVal = InVal + AddVal;
                                break;
                            case 0x01:  // Shift Left
                                OutVal = (InVal << OutShift) + AddVal;
                                break;
                            case 0x02:  // Table
                                switch (ValSize)
                                {
                                    case 0x01:
                                        OutVal = PCMTbl.Entries[Ent1B + InVal];
                                        break;
                                    case 0x02:
                                        //#ifndef BIG_ENDIAN
                                        //					OutVal = Ent2B[InVal];
                                        //#else
                                        OutVal = (uint)(PCMTbl.Entries[Ent2B + InVal * 2] + PCMTbl.Entries[Ent2B + InVal * 2 + 1] * 0x100);// ReadLE16((UINT8*)&Ent2B[InVal]);
                                                                                                                                           //#endif
                                        break;
                                }
                                break;
                        }

                        //#ifndef BIG_ENDIAN
                        //			//memcpy(OutPos, &OutVal, ValSize);
                        //			if (ValSize == 0x01)
                        //               *((UINT8*)OutPos) = (UINT8)OutVal;
                        //			else //if (ValSize == 0x02)
                        //                *((UINT16*)OutPos) = (UINT16)OutVal;
                        //#else
                        if (ValSize == 0x01)
                        {
                            Bank.Data[OutPos] = (byte)OutVal;
                        }
                        else //if (ValSize == 0x02)
                        {
                            Bank.Data[OutPos + 0x00] = (byte)((OutVal & 0x00FF) >> 0);
                            Bank.Data[OutPos + 0x01] = (byte)((OutVal & 0xFF00) >> 8);
                        }
                        //#endif
                    }
                    break;
                case 0x01:  // Delta-PCM
                    BitDec = vgmBuf[Adr + 5].val;// Data[0x05].val;
                    BitCmp = vgmBuf[Adr + 6].val;// Data[0x06].val;
                    OutVal = getLE16(Adr + 8);// ReadLE16(&Data[0x08]);

                    Ent1B = 0;// (UINT8*)PCMTbl.Entries;
                    Ent2B = 0;// (UINT16*)PCMTbl.Entries;
                    if (PCMTbl.EntryCount == 0)
                    {
                        Bank.DataSize = 0x00;
                        //printf("Error loading table-compressed data block! No table loaded!\n");
                        return false;
                    }
                    else if (BitDec != PCMTbl.BitDec || BitCmp != PCMTbl.BitCmp)
                    {
                        Bank.DataSize = 0x00;
                        //printf("Warning! Data block and loaded value table incompatible!\n");
                        return false;
                    }

                    ValSize = (byte)((BitDec + 7) / 8);
                    OutMask = (uint)((1 << BitDec) - 1);
                    InPos = vgmBuf[Adr + 0xa].val;// Data + 0x0A;
                    InDataEnd = vgmBuf[Adr + DataSize].val;// Data + DataSize;
                    InShift = 0;
                    OutShift = (byte)(BitDec - BitCmp);
                    OutDataEnd = Bank.DataSize;// Bank.Data + Bank.DataSize;
                    AddVal = 0x0000;

                    //                    for (OutPos = Bank.Data; OutPos < OutDataEnd && InPos < InDataEnd; OutPos += ValSize)
                    for (OutPos = 0; OutPos < OutDataEnd && InPos < InDataEnd; OutPos += ValSize)
                    {
                        //InVal = ReadBits(Data, InPos, &InShift, BitCmp);
                        // inlined - is 30% faster
                        OutBit = 0x00;
                        InVal = 0x0000;
                        BitsToRead = BitCmp;
                        while (BitsToRead != 0)
                        {
                            BitReadVal = (byte)((BitsToRead >= 8) ? 8 : BitsToRead);
                            BitsToRead -= BitReadVal;
                            BitMask = (byte)((1 << BitReadVal) - 1);

                            InShift += BitReadVal;
                            InValB = (byte)((vgmBuf[InPos].val << InShift >> 8) & BitMask);
                            if (InShift >= 8)
                            {
                                InShift -= 8;
                                InPos++;
                                if (InShift != 0)
                                    InValB |= (byte)((vgmBuf[InPos].val << InShift >> 8) & BitMask);
                            }

                            InVal |= (byte)(InValB << OutBit);
                            OutBit += BitReadVal;
                        }

                        switch (ValSize)
                        {
                            case 0x01:
                                AddVal = PCMTbl.Entries[Ent1B + InVal];
                                OutVal += AddVal;
                                OutVal &= OutMask;
                                Bank.Data[OutPos] = (byte)OutVal;// *((UINT8*)OutPos) = (UINT8)OutVal;
                                break;
                            case 0x02:
                                //#ifndef BIG_ENDIAN
                                //				AddVal = Ent2B[InVal];
                                //#else
                                AddVal = (uint)(PCMTbl.Entries[Ent2B + InVal] + PCMTbl.Entries[Ent2B + InVal + 1] * 0x100);
                                //AddVal = ReadLE16((UINT8*)&Ent2B[InVal]);
                                //#endif
                                OutVal += AddVal;
                                OutVal &= OutMask;
                                //#ifndef BIG_ENDIAN
                                //				*((UINT16*)OutPos) = (UINT16)OutVal;
                                //#else
                                Bank.Data[OutPos + 0x00] = (byte)((OutVal & 0x00FF) >> 0);
                                Bank.Data[OutPos + 0x01] = (byte)((OutVal & 0xFF00) >> 8);
                                //#endif
                                break;
                        }
                    }
                    break;
                default:
                    //printf("Error: Unknown data block compression!\n");
                    return false;
            }

            //#if defined(_DEBUG) && defined(WIN32)
            //	Time = GetTickCount() - Time;
            //	printf("Decompression Time: %lu\n", Time);
            //#endif

            return true;
        }

        private void ReadPCMTable(uint DataSize, uint Adr)
        {
            byte ValSize;
            uint TblSize;

            PCMTbl.ComprType = vgmBuf[Adr + 0].val;// Data[0x00].val;
            PCMTbl.CmpSubType = vgmBuf[Adr + 1].val;// Data[0x01].val;
            PCMTbl.BitDec = vgmBuf[Adr + 2].val;// Data[0x02].val;
            PCMTbl.BitCmp = vgmBuf[Adr + 3].val;// Data[0x03].val;
            PCMTbl.EntryCount = getLE16(Adr + 4);// ReadLE16(&Data[0x04].val);

            ValSize = (byte)((PCMTbl.BitDec + 7) / 8);
            TblSize = PCMTbl.EntryCount * ValSize;

            PCMTbl.Entries = new byte[TblSize];// realloc(PCMTbl.Entries, TblSize);
            for (int i = 0; i < TblSize; i++) PCMTbl.Entries[i] = vgmBuf[Adr + 6 + i].val;
            //memcpy(PCMTbl.Entries, &Data[0x06], TblSize);

            if (DataSize < 0x06 + TblSize)
            {
                //Console.Write("Warning! Bad PCM Table Length!\n");
                //printf("Warning! Bad PCM Table Length!\n");
            }

            return;
        }

        private byte GetDACFromPCMBank()
        {
            // for YM2612 DAC data only
            /*VGM_PCM_BANK* TempPCM;
            UINT32 CurBnk;*/
            uint DataPos;

            /*TempPCM = &PCMBank[0x00];
            DataPos = TempPCM->DataPos;
            for (CurBnk = 0x00; CurBnk < TempPCM->BankCount; CurBnk ++)
            {
                if (DataPos < TempPCM->Bank[CurBnk].DataSize)
                {
                    if (TempPCM->DataPos < TempPCM->DataSize)
                        TempPCM->DataPos ++;
                    return TempPCM->Bank[CurBnk].Data[DataPos];
                }
                DataPos -= TempPCM->Bank[CurBnk].DataSize;
            }
            return 0x80;*/

            DataPos = PCMBank[0x00].DataPos;
            if (DataPos >= PCMBank[0x00].DataSize)
                return 0x80;

            PCMBank[0x00].DataPos++;
            return PCMBank[0x00].Bank[0].Data[DataPos];
        }

        private uint? GetPCMAddressFromPCMBank(byte Type, uint DataPos)
        {
            if (Type >= PCM_BANK_COUNT)
                return null;

            if (DataPos >= PCMBank[Type].DataSize)
                return null;

            return DataPos;
        }

        protected bool getInformationHeader()
        {
            chips = new List<string>();
            UsedChips = "";

            SN76489ClockValue = 0;// defaultSN76489ClockValue;
            YM2612ClockValue = 0;// defaultYM2612ClockValue;
            YM2151ClockValue = 0;
            SEGAPCMClockValue = 0;
            YM2203ClockValue = 0;
            YM2608ClockValue = 0;
            YM2610ClockValue = 0;
            YM3812ClockValue = 0;
            YMF262ClockValue = 0;
            RF5C68ClockValue = 0;
            RF5C164ClockValue = 0;// defaultRF5C164ClockValue;
            PWMClockValue = 0;// defaultPWMClockValue;
            OKIM6258ClockValue = 0;// defaultOKIM6258ClockValue;
            C140ClockValue = 0;// defaultC140ClockValue;
            OKIM6295ClockValue = 0;//defaultOKIM6295ClockValue;
            AY8910ClockValue = 0;
            YM2413ClockValue = 0;
            HuC6280ClockValue = 0;
            K054539ClockValue = 0;
            NESClockValue = 0;
            MultiPCMClockValue = 0;


            //ヘッダーを読み込めるサイズをもっているかチェック
            if (vgmBuf.Length < 0x40) return false;

            //ヘッダーから情報取得

            uint vgm = getLE32(0x00);
            if (vgm != FCC_VGM) return false;

            vgmEof = getLE32(0x04);

            uint version = getLE32(0x08);
            //バージョンチェック
            if (version < 0x0101) return false;
            Version = string.Format("{0}.{1}{2}", (version & 0xf00) / 0x100, (version & 0xf0) / 0x10, (version & 0xf));

            uint SN76489clock = getLE32(0x0c);
            if (SN76489clock != 0)
            {
                SN76489ClockValue = SN76489clock & 0x3fffffff;
                SN76489DualChipFlag = (SN76489clock & 0x40000000) != 0;
                if (SN76489DualChipFlag) chips.Add("SN76489x2");
                else chips.Add("SN76489");
            }

            uint YM2413clock = getLE32(0x10);
            if (YM2413clock != 0)
            {
                YM2413ClockValue = YM2413clock & 0x3fffffff;
                YM2413DualChipFlag = (YM2413clock & 0x40000000) != 0;
                if (YM2413DualChipFlag) chips.Add("YM2413x2");
                else chips.Add("YM2413");
            }

            TotalCounter = getLE32(0x18);
            if (TotalCounter < 0) return false;

            vgmLoopOffset = getLE32(0x1c);

            LoopCounter = getLE32(0x20);

            if (version > 0x0101)
            {

                uint YM2612clock = getLE32(0x2c);
                if (YM2612clock != 0)
                {
                    YM2612ClockValue = YM2612clock & 0x3fffffff;
                    YM2612DualChipFlag = (YM2612clock & 0x40000000) != 0;
                    if (YM2612DualChipFlag) chips.Add("YM2612x2");
                    else chips.Add("YM2612");
                }

                uint YM2151clock = getLE32(0x30);
                if (YM2151clock != 0)
                {
                    YM2151ClockValue = YM2151clock & 0x3fffffff;
                    YM2151DualChipFlag = (YM2151clock & 0x40000000) != 0;
                    if (YM2151DualChipFlag) chips.Add("YM2151x2");
                    else chips.Add("YM2151");
                }

                //SetYM2151Hosei();

                vgmDataOffset = getLE32(0x34);
                if (vgmDataOffset == 0)
                {
                    vgmDataOffset = 0x40;
                }
                else
                {
                    vgmDataOffset += 0x34;
                }

                if (version >= 0x0151)
                {
                    if (vgmDataOffset > 0x38)
                    {
                        uint SegaPCMclock = getLE32(0x38);
                        SEGAPCMClockValue = SegaPCMclock & 0x3fffffff;
                        SEGAPCMDualChipFlag = (SegaPCMclock & 0x40000000) != 0;
                        int SPCMInterface = (int)getLE32(0x3c);
                        if (SegaPCMclock != 0 && SPCMInterface != 0)
                        {
                            if (SEGAPCMDualChipFlag) chips.Add("Sega PCMx2");
                            else chips.Add("Sega PCM");
                            SEGAPCMInterface = SPCMInterface;
                        }
                    }

                    if (vgmDataOffset > 0x40)
                    {
                        uint RF5C68clock = getLE32(0x40);
                        if (RF5C68clock != 0)
                        {
                            RF5C68ClockValue = RF5C68clock & 0x3fffffff;
                            RF5C68DualChipFlag = (RF5C68clock & 0x40000000) != 0;
                            if (RF5C68DualChipFlag) chips.Add("RF5C68x2");
                            else chips.Add("RF5C68");
                        }
                    }

                    if (vgmDataOffset > 0x44)
                    {
                        uint YM2203clock = getLE32(0x44);
                        if (YM2203clock != 0)
                        {
                            YM2203ClockValue = YM2203clock & 0x3fffffff;
                            YM2203DualChipFlag = (YM2203clock & 0x40000000) != 0;
                            if (YM2203DualChipFlag) chips.Add("YM2203x2");
                            else chips.Add("YM2203");
                        }
                    }

                    if (vgmDataOffset > 0x48)
                    {
                        uint YM2608clock = getLE32(0x48);
                        if (YM2608clock != 0)
                        {
                            YM2608ClockValue = YM2608clock & 0x3fffffff;
                            YM2608DualChipFlag = (YM2608clock & 0x40000000) != 0;
                            if (YM2608DualChipFlag) chips.Add("YM2608x2");
                            else chips.Add("YM2608");
                        }
                    }

                    if (vgmDataOffset > 0x4c)
                    {
                        uint YM2610Bclock = getLE32(0x4c);
                        if (YM2610Bclock != 0)
                        {
                            YM2610ClockValue = YM2610Bclock & 0x3fffffff;
                            YM2610DualChipFlag = (YM2610Bclock & 0x40000000) != 0;
                            if (YM2610DualChipFlag) chips.Add("YM2610/Bx2");
                            else chips.Add("YM2610/B");
                        }
                    }

                    if (vgmDataOffset > 0x50)
                    {
                        uint YM3812clock = getLE32(0x50);
                        if (YM3812clock != 0)
                        {
                            YM3812ClockValue = YM3812clock & 0x3fffffff;
                            YM3812DualChipFlag = (YM3812clock & 0x40000000) != 0;
                            if (YM3812DualChipFlag) chips.Add("YM3812x2");
                            else chips.Add("YM3812");
                        }
                    }

                    if (vgmDataOffset > 0x54)
                    {
                        uint YM3526clock = getLE32(0x54);
                        if (YM3526clock != 0)
                        {
                            YM3526ClockValue = YM3526clock & 0x3fffffff;
                            YM3526DualChipFlag = (YM3526clock & 0x40000000) != 0;
                            if (YM3526DualChipFlag) chips.Add("YM3526x2");
                            else chips.Add("YM3526");
                        }
                    }

                    if (vgmDataOffset > 0x58)
                    {
                        uint Y8950clock = getLE32(0x58);
                        if (Y8950clock != 0)
                        {
                            Y8950ClockValue = Y8950clock & 0x3fffffff;
                            Y8950DualChipFlag = (Y8950clock & 0x40000000) != 0;
                            if (Y8950DualChipFlag) chips.Add("Y8950x2");
                            else chips.Add("Y8950");
                        }
                    }

                    if (vgmDataOffset > 0x5c)
                    {
                        uint YMF262clock = getLE32(0x5c);
                        if (YMF262clock != 0)
                        {
                            YMF262ClockValue = YMF262clock & 0x3fffffff;
                            YMF262DualChipFlag = (YMF262clock & 0x40000000) != 0;
                            if (YMF262DualChipFlag) chips.Add("YMF262x2");
                            else chips.Add("YMF262");
                        }
                    }

                    if (vgmDataOffset > 0x60)
                    {
                        uint YMF278Bclock = getLE32(0x60);
                        if (YMF278Bclock != 0)
                        {
                            YMF278BClockValue = YMF278Bclock & 0x3fffffff;
                            YMF278BDualChipFlag = (YMF278Bclock & 0x40000000) != 0;
                            if (YMF278BDualChipFlag) chips.Add("YMF278Bx2");
                            else chips.Add("YMF278B");
                        }
                    }

                    if (vgmDataOffset > 0x64)
                    {
                        uint YMF271clock = getLE32(0x64);
                        if (YMF271clock != 0)
                        {
                            YMF271ClockValue = YMF271clock & 0x3fffffff;
                            YMF271DualChipFlag = (YMF271clock & 0x40000000) != 0;
                            if (YMF271DualChipFlag) chips.Add("YMF271x2");
                            else chips.Add("YMF271");
                        }
                    }

                    if (vgmDataOffset > 0x68)
                    {
                        uint YMZ280Bclock = getLE32(0x68);
                        if (YMZ280Bclock != 0)
                        {
                            YMZ280BClockValue = YMZ280Bclock & 0x3fffffff;
                            YMZ280BDualChipFlag = (YMZ280Bclock & 0x40000000) != 0;
                            if (YMZ280BDualChipFlag) chips.Add("YMZ280Bx2");
                            else chips.Add("YMZ280B");
                        }
                    }

                    if (vgmDataOffset > 0x6c)
                    {
                        uint RF5C164clock = getLE32(0x6c);
                        if (RF5C164clock != 0)
                        {
                            RF5C164ClockValue = RF5C164clock & 0x3fffffff;
                            RF5C164DualChipFlag = (RF5C164clock & 0x40000000) != 0;
                            if (RF5C164DualChipFlag) chips.Add("RF5C164x2");
                            else chips.Add("RF5C164");
                        }
                    }


                    if (vgmDataOffset > 0x70)
                    {
                        uint PWMclock = getLE32(0x70);
                        if (PWMclock != 0)
                        {
                            chips.Add("PWM");
                            PWMClockValue = PWMclock;
                        }
                    }

                    if (vgmDataOffset > 0x74)
                    {
                        uint AY8910clock = getLE32(0x74);
                        if (AY8910clock != 0)
                        {
                            AY8910ClockValue = AY8910clock & 0x3fffffff;
                            AY8910DualChipFlag = (AY8910clock & 0x40000000) != 0;
                            if (AY8910DualChipFlag) chips.Add("AY8910x2");
                            else chips.Add("AY8910");
                        }
                    }
                }

                //OKIM6258ClockValue = 0;
                //HuC6280ClockValue = 0;
                //OKIM6295ClockValue = 0;

                if (version >= 0x0161)
                {
                    if (vgmDataOffset > 0x80)
                    {
                        uint DMGclock = getLE32(0x80);
                        if (DMGclock != 0)
                        {
                            DMGClockValue = DMGclock & 0x3fffffff;
                            DMGDualChipFlag = (DMGclock & 0x40000000) != 0;
                            if (DMGDualChipFlag) chips.Add("DMGx2");
                            else chips.Add("DMG");
                        }
                    }

                    if (vgmDataOffset > 0x84)
                    {
                        uint NESclock = getLE32(0x84);
                        if (NESclock != 0)
                        {
                            NESClockValue = NESclock & 0xbfffffff;
                            NESDualChipFlag = (NESclock & 0x40000000) != 0;
                            if (NESDualChipFlag) chips.Add("NES_APUx2");
                            else chips.Add("NES_APU");
                        }
                    }

                    if (vgmDataOffset > 0x88)
                    {
                        uint MultiPCMclock = getLE32(0x88);
                        if (MultiPCMclock != 0)
                        {
                            MultiPCMClockValue = MultiPCMclock & 0x3fffffff;
                            MultiPCMDualChipFlag = (MultiPCMclock & 0x40000000) != 0;
                            if (MultiPCMDualChipFlag) chips.Add("MultiPCMx2");
                            else chips.Add("MultiPCM");
                        }
                    }

                    if (vgmDataOffset > 0x90)
                    {
                        uint OKIM6258clock = getLE32(0x90);
                        if (OKIM6258clock != 0)
                        {
                            chips.Add("OKIM6258");
                            OKIM6258ClockValue = OKIM6258clock;
                            OKIM6258Type = vgmBuf[0x94].val;
                        }
                    }

                    if (vgmDataOffset > 0x9c)
                    {
                        uint K051649clock = getLE32(0x9c);
                        if (K051649clock != 0)
                        {
                            K051649ClockValue = K051649clock & 0x3fffffff;
                            K051649DualChipFlag = (K051649clock & 0x40000000) != 0;
                            if (K051649DualChipFlag) chips.Add("K051649x2");
                            else chips.Add("K051649");
                        }
                    }

                    if (vgmDataOffset > 0xa0)
                    {
                        uint K054539clock = getLE32(0xa0);
                        if (K054539clock != 0)
                        {
                            K054539ClockValue = K054539clock & 0x3fff_ffff;
                            K054539DualChipFlag = (K054539clock & 0x40000000) != 0;
                            if (K054539DualChipFlag) chips.Add("K054539x2");
                            else chips.Add("K054539");
                            K054539Flags = vgmBuf[0x95].val;
                        }
                    }

                    if (vgmDataOffset > 0xa4)
                    {

                        uint HuC6280clock = getLE32(0xa4);
                        if (HuC6280clock != 0)
                        {
                            HuC6280ClockValue = HuC6280clock & 0x3fff_ffff;
                            HuC6280DualChipFlag = (HuC6280clock & 0x40000000) != 0;
                            if (HuC6280DualChipFlag) chips.Add("HuC6280x2");
                            else chips.Add("HuC6280");
                        }
                    }

                    if (vgmDataOffset > 0xa8)
                    {

                        uint C140clock = getLE32(0xa8);
                        if (C140clock != 0)
                        {
                            C140ClockValue = C140clock & 0x3fff_ffff;
                            C140DualChipFlag = (C140clock & 0x4000_0000) != 0;
                            if (C140DualChipFlag) chips.Add("C140x2");
                            else chips.Add("C140");

                            switch (vgmBuf[0x96].val)
                            {
                                case 0x00:
                                    C140Type = MDSound.c140.C140_TYPE.SYSTEM2;
                                    break;
                                case 0x01:
                                    C140Type = MDSound.c140.C140_TYPE.SYSTEM21;
                                    break;
                                case 0x02:
                                default:
                                    C140Type = MDSound.c140.C140_TYPE.ASIC219;
                                    break;
                            }
                        }
                    }

                    if (vgmDataOffset > 0xac)
                    {

                        uint K053260clock = getLE32(0xac);
                        if (K053260clock != 0)
                        {
                            K053260ClockValue = K053260clock & 0x3fffffff;
                            K053260DualChipFlag = (K053260clock & 0x40000000) != 0;
                            if (K053260DualChipFlag) chips.Add("K053260x2");
                            else chips.Add("K053260");
                        }
                    }

                    if (vgmDataOffset > 0xb4)
                    {

                        uint QSoundclock = getLE32(0xb4);
                        if (QSoundclock != 0)
                        {
                            chips.Add("QSound");
                            QSoundClockValue = QSoundclock;
                        }
                    }

                    if (vgmDataOffset > 0x98)
                    {
                        uint OKIM6295clock = getLE32(0x98);
                        if (OKIM6295clock != 0)
                        {
                            OKIM6295DualChipFlag = (OKIM6295clock & 0x40000000) != 0;
                            if (OKIM6295DualChipFlag)
                            {
                                chips.Add("OKIM6295x2");
                            }
                            else
                            {
                                chips.Add("OKIM6295");
                            }
                            OKIM6295ClockValue = OKIM6295clock & 0xbfffffff;
                        }
                    }

                }
                if (version >= 0x0171)
                {
                    if (vgmDataOffset > 0xdc)
                    {

                        uint C352clock = getLE32(0xdc);
                        if (C352clock != 0)
                        {
                            C352ClockValue = C352clock & 0x3fff_ffff;
                            C352DualChipFlag = (C352clock & 0x4000_0000) != 0;
                            if (C352DualChipFlag) chips.Add("C352x2");
                            else chips.Add("C352");

                            C352ClockDivider = vgmBuf[0xd6].val;
                        }
                    }

                    if (vgmDataOffset > 0xe0)
                    {

                        uint GA20clock = getLE32(0xe0);
                        if (GA20clock != 0)
                        {
                            GA20DualChipFlag = (GA20clock & 0x40000000) != 0;
                            if (GA20DualChipFlag)
                            {
                                GA20ClockValue = GA20clock & 0x3fffffff;
                                chips.Add("GA20x2");
                            }
                            else
                            {
                                GA20ClockValue = GA20clock & 0xbfffffff;
                                chips.Add("GA20");
                            }
                        }
                    }

                }
            }
            else
            {
                vgmDataOffset = 0x40;
            }

            foreach (string chip in chips)
            {
                UsedChips += chip + " , ";
            }
            if (UsedChips.Length > 2)
            {
                UsedChips = UsedChips.Substring(0, UsedChips.Length - 3);
            }

            uint vgmGd3 = getLE32(0x14);
            if (vgmGd3 != 0)
            {
                uint vgmGd3Id = getLE32(vgmGd3 + 0x14);
                if (vgmGd3Id != FCC_GD3) return false;
                GD3 = getGD3Info(vgmBuf, vgmGd3);
            }

            return true;
        }

        public GD3 getGD3Info(outDatum[] buf, uint vgmGd3)
        {

            uint adr = vgmGd3 + 12 + 0x14;
            GD3 = Common.getGD3Info(buf, adr);
            GD3.UsedChips = UsedChips;

            return GD3;
        }

        public override GD3 getGD3Info(byte[] buf, uint vgmGd3)
        {
            throw new NotImplementedException();
        }
    }

    public class VGM_PCM_DATA
    {
        public uint DataSize;
        public byte[] Data;
        public uint DataStart;
    }

    public class VGM_PCM_BANK
    {
        public uint BankCount;
        public List<VGM_PCM_DATA> Bank = new List<VGM_PCM_DATA>();
        public uint DataSize;
        public byte[] Data;
        public uint DataPos;
        public uint BnkPos;
    }

    public class DACCTRL_DATA
    {
        public bool Enable;
        public byte Bank;
    }

    public class PCMBANK_TBL
    {
        public byte ComprType;
        public byte CmpSubType;
        public byte BitDec;
        public byte BitCmp;
        public uint EntryCount;
        public byte[] Entries;// void* Entries;
    }

    public class GD3
    {
        public string TrackName = "";
        public string TrackNameJ = "";
        public string GameName = "";
        public string GameNameJ = "";
        public string SystemName = "";
        public string SystemNameJ = "";
        public string Composer = "";
        public string ComposerJ = "";
        public string Converted = "";
        public string Notes = "";
        public string VGMBy = "";
        public string Version = "";
        public string UsedChips = "";

        public List<Tuple<int, int, string>> Lyrics = null;
    }


}
