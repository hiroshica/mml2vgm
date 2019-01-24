﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ClsOPN : ClsChip
    {
        public byte SSGKeyOn = 0x3f;


        public ClsOPN(ClsVgm parent, int chipID, string initialPartName, string stPath, bool isSecondary) : base(parent, chipID, initialPartName, stPath, isSecondary)
        {
        }


        public void OutSsgKeyOn(partWork pw)
        {
            int m = (pw.chip is YM2203) ? 0 : 3;
            byte pch = (byte)(pw.ch - (m + 6));
            int n = (pw.mixer & 0x1) + ((pw.mixer & 0x2) << 2);
            byte data = 0;

            data = (byte)(((ClsOPN)pw.chip).SSGKeyOn | (9 << pch));
            data &= (byte)(~(n << pch));
            ((ClsOPN)pw.chip).SSGKeyOn = data;

            SetSsgVolume(pw);
            if (pw.HardEnvelopeSw)
            {
                parent.OutData(pw.port0, 0x0d, (byte)(pw.HardEnvelopeType & 0xf));
            }
            parent.OutData(pw.port0, 0x07, data);
        }

        public void OutSsgKeyOff(partWork pw)
        {
            int m = (pw.chip is YM2203) ? 0 : 3;
            byte pch = (byte)(pw.ch - (m + 6));
            int n = 9;
            byte data = 0;

            data = (byte)(((ClsOPN)pw.chip).SSGKeyOn | (n << pch));
            ((ClsOPN)pw.chip).SSGKeyOn = data;

            parent.OutData(pw.port0, (byte)(0x08 + pch), 0);
            pw.beforeVolume = -1;
            parent.OutData(pw.port0, 0x07, data);

        }

        public void SetSsgVolume(partWork pw)
        {
            int m = (pw.chip is YM2203) ? 0 : 3;
            byte pch = (byte)(pw.ch - (m + 6));

            int vol = pw.volume;
            if (pw.envelopeMode)
            {
                vol = 0;
                if (pw.envIndex != -1)
                {
                    vol = pw.volume - (15 - pw.envVolume);
                }
            }

            for (int lfo = 0; lfo < 4; lfo++)
            {
                if (!pw.lfo[lfo].sw) continue;
                if (pw.lfo[lfo].type != eLfoType.Tremolo) continue;

                vol += pw.lfo[lfo].value + pw.lfo[lfo].param[6];
            }

            vol = Common.CheckRange(vol, 0, 15) + (pw.HardEnvelopeSw ? 0x10 : 0x00);

            if (pw.beforeVolume != vol)
            {
                parent.OutData(pw.port0, (byte)(0x08 + pch), (byte)vol);
                //pw.beforeVolume = pw.volume;
                pw.beforeVolume = vol;
            }
        }

        public void OutSsgNoise(partWork pw, int n)
        {
            parent.OutData(pw.port0, 0x06, (byte)(n & 0x1f));
        }

        public void SetSsgFNum(partWork pw)
        {
            int f = - pw.detune;
            for (int lfo = 0; lfo < 4; lfo++)
            {
                if (!pw.lfo[lfo].sw)
                {
                    continue;
                }
                if (pw.lfo[lfo].type != eLfoType.Vibrato)
                {
                    continue;
                }
                f -= pw.lfo[lfo].value + pw.lfo[lfo].param[6];
            }

            if (pw.octaveNow < 1)
            {
                f <<= -pw.octaveNow;
            }
            else
            {
                f >>= pw.octaveNow - 1;
            }

            if (pw.bendWaitCounter != -1)
            {
                f += pw.bendFnum;
            }
            else
            {
                f += GetSsgFNum(pw, pw.octaveNow, pw.noteCmd, pw.shift + pw.keyShift);//
            }

            f = Common.CheckRange(f, 0, 0xfff);
            if (pw.freq == f) return;

            pw.freq = f;

            byte data = 0;
            int n = (pw.chip is YM2203) ? 6 : 9;

            data = (byte)(f & 0xff);
            parent.OutData(pw.port0, (byte)(0 + (pw.ch - n) * 2), data);

            data = (byte)((f & 0xf00) >> 8);
            parent.OutData(pw.port0, (byte)(1 + (pw.ch - n) * 2), data);
        }

        public int GetSsgFNum(partWork pw, int octave, char noteCmd, int shift)
        {
            int o = octave - 1;
            int n = Const.NOTE.IndexOf(noteCmd) + shift;
            o += n / 12;
            o = Common.CheckRange(o, 0, 7);
            n %= 12;

            int f = o * 12 + n;
            if (f < 0) f = 0;
            if (f >= pw.chip.FNumTbl[1].Length) f = pw.chip.FNumTbl[1].Length - 1;

            return pw.chip.FNumTbl[1][f];
        }


        public void OutOPNSetPanAMSPMS(partWork pw, int pan, int ams, int pms)
        {
            //TODO: 効果音パートで指定されている場合の考慮不足
            int vch = pw.ch;
            byte port = pw.ch > 2 ? pw.port1 : pw.port0;
            vch = (byte)(vch > 2 ? vch - 3 : vch);

            pan = pan & 3;
            ams = ams & 7;
            pms = pms & 3;

            parent.OutData(port, (byte)(0xb4 + vch), (byte)((pan << 6) + (ams << 3) + pms));
        }

        public void OutOPNSetHardLfo(partWork pw, bool sw, int lfoNum)
        {
            parent.OutData(
                pw.port0
                , 0x22
                , (byte)((lfoNum & 7) + (sw ? 8 : 0))
                );
        }

        public void OutOPNSetCh3SpecialMode(partWork pw, bool sw)
        {
            // ignore Timer ^^;
            parent.OutData(
                pw.port0
                , 0x27
                , (byte)((sw ? 0x40 : 0))
                );
        }

        public void OutFmSetFeedbackAlgorithm(partWork pw, int fb, int alg)
        {
            int vch = pw.ch;
            byte port = pw.ch > 2 ? pw.port1 : pw.port0;
            vch = (byte)(vch > 2 ? vch - 3 : vch);

            fb &= 7;
            alg &= 7;

            parent.OutData(port, (byte)(0xb0 + vch), (byte)((fb << 3) + alg));
        }

        public void OutFmSetDtMl(partWork pw, int ope, int dt, int ml)
        {
            int vch = pw.ch;
            byte port = vch > 2 ? pw.port1 : pw.port0;
            vch = (byte)(vch > 2 ? vch - 3 : vch);

            ope = (ope == 1) ? 2 : ((ope == 2) ? 1 : ope);
            dt &= 7;
            ml &= 15;

            parent.OutData(port, (byte)(0x30 + vch + ope * 4), (byte)((dt << 4) + ml));
        }

        public void OutFmSetTl(partWork pw, int ope, int tl)
        {
            byte port = (pw.ch > 2 ? pw.port1 : pw.port0);
            int vch = (byte)(pw.ch > 2 ? pw.ch - 3 : pw.ch);

            ope = (ope == 1) ? 2 : ((ope == 2) ? 1 : ope);
            tl &= 0x7f;

            parent.OutData(port, (byte)(0x40 + vch + ope * 4), (byte)tl);
        }

        public void OutFmSetKsAr(partWork pw, int ope, int ks, int ar)
        {
            int vch = pw.ch;
            byte port = (pw.ch > 2 ? pw.port1 : pw.port0);
            vch = (byte)(vch > 2 ? vch - 3 : vch);

            ope = (ope == 1) ? 2 : ((ope == 2) ? 1 : ope);
            ks &= 3;
            ar &= 31;

            parent.OutData(port, (byte)(0x50 + vch + ope * 4), (byte)((ks << 6) + ar));
        }

        public void OutFmSetAmDr(partWork pw, int ope, int am, int dr)
        {
            int vch = pw.ch;
            byte port = (pw.ch > 2 ? pw.port1 : pw.port0);
            vch = (byte)(vch > 2 ? vch - 3 : vch);

            ope = (ope == 1) ? 2 : ((ope == 2) ? 1 : ope);
            am &= 1;
            dr &= 31;

            parent.OutData(port, (byte)(0x60 + vch + ope * 4), (byte)((am << 7) + dr));
        }

        public void OutFmSetSr(partWork pw, int ope, int sr)
        {
            int vch = pw.ch;
            byte port = pw.ch > 2 ? pw.port1 : pw.port0;
            vch = (byte)(vch > 2 ? vch - 3 : vch);

            ope = (ope == 1) ? 2 : ((ope == 2) ? 1 : ope);
            sr &= 31;

            parent.OutData(port, (byte)(0x70 + vch + ope * 4), (byte)(sr));
        }

        public void OutFmSetSlRr(partWork pw, int ope, int sl, int rr)
        {
            int vch = pw.ch;
            byte port = pw.ch > 2 ? pw.port1 : pw.port0;
            vch = (byte)(vch > 2 ? vch - 3 : vch);

            ope = (ope == 1) ? 2 : ((ope == 2) ? 1 : ope);
            sl &= 15;
            rr &= 15;

            parent.OutData(port, (byte)(0x80 + vch + ope * 4), (byte)((sl << 4) + rr));
        }

        public void OutFmSetSSGEG(partWork pw, int ope, int n)
        {
            int vch = pw.ch;
            byte port = pw.ch > 2 ? pw.port1 : pw.port0;
            vch = (byte)(vch > 2 ? vch - 3 : vch);

            ope = (ope == 1) ? 2 : ((ope == 2) ? 1 : ope);
            n &= 15;

            parent.OutData(port, (byte)(0x90 + vch + ope * 4), (byte)n);
        }

        /// <summary>
        /// FMボリュームの設定
        /// </summary>
        /// <param name="ch">チャンネル</param>
        /// <param name="vol">ボリューム値</param>
        /// <param name="n">音色番号</param>
        public void OutFmSetVolume(partWork pw, int vol, int n)
        {
            if (!parent.instFM.ContainsKey(n))
            {
                msgBox.setWrnMsg(string.Format(msg.get("E11000"), n), pw.getSrcFn(), pw.getLineNumber());
                return;
            }

            int alg = parent.instFM[n][45] & 0x7;
            int[] ope = new int[4] {
                parent.instFM[n][0*Const.INSTRUMENT_M_OPERATOR_SIZE + 6]
                , parent.instFM[n][1 * Const.INSTRUMENT_M_OPERATOR_SIZE + 6]
                , parent.instFM[n][2 * Const.INSTRUMENT_M_OPERATOR_SIZE + 6]
                , parent.instFM[n][3 * Const.INSTRUMENT_M_OPERATOR_SIZE + 6]
            };
            int[][] algs = new int[8][]
            {
                new int[4] { 0,0,0,1}
                ,new int[4] { 0,0,0,1}
                ,new int[4] { 0,0,0,1}
                ,new int[4] { 0,0,0,1}
                ,new int[4] { 0,1,0,1}
                ,new int[4] { 0,1,1,1}
                ,new int[4] { 0,1,1,1}
                ,new int[4] { 1,1,1,1}
            };

            for (int i = 0; i < 4; i++)
            {
                if (algs[alg][i] == 0 || (pw.slots & (1 << i)) == 0)
                {
                    continue;
                }
                ope[i] = ope[i] + (127 - vol);
                ope[i] = Common.CheckRange(ope[i], 0, 127);
            }

            partWork vpw = pw;
            int m = (pw.chip is YM2203) ? 0 : 3;
            if (pw.chip.lstPartWork[2].Ch3SpecialMode && pw.ch >= m + 3 && pw.ch < m + 6)
            {
                vpw = pw.chip.lstPartWork[2];
            }

            if ((pw.slots & 1) != 0) ((ClsOPN)pw.chip).OutFmSetTl(vpw, 0, ope[0]);
            if ((pw.slots & 2) != 0) ((ClsOPN)pw.chip).OutFmSetTl(vpw, 1, ope[1]);
            if ((pw.slots & 4) != 0) ((ClsOPN)pw.chip).OutFmSetTl(vpw, 2, ope[2]);
            if ((pw.slots & 8) != 0) ((ClsOPN)pw.chip).OutFmSetTl(vpw, 3, ope[3]);
        }

        public void OutFmCh3SpecialModeSetFnum(partWork pw, byte ope, int octave, int num)
        {
            ope &= 3;
            if (ope == 0)
            {
                parent.OutData(pw.port0, 0xa6, (byte)(((num & 0x700) >> 8) + (((octave - 1) & 0x7) << 3)));
                parent.OutData(pw.port0, 0xa2, (byte)(num & 0xff));
            }
            else
            {
                parent.OutData(pw.port0, (byte)(0xac + ope), (byte)(((num & 0x700) >> 8) + (((octave - 1) & 0x7) << 3)));
                parent.OutData(pw.port0, (byte)(0xa8 + ope), (byte)(num & 0xff));
            }
        }

        public void OutFmSetInstrument(partWork pw, int n, int vol)
        {

            if (!parent.instFM.ContainsKey(n))
            {
                msgBox.setWrnMsg(string.Format(msg.get("E11001"), n), pw.getSrcFn(), pw.getLineNumber());
                return;
            }

            int m = (pw.chip is YM2203) ? 0 : 3;

            if (pw.ch >= m + 3 && pw.ch < m + 6)
            {
                msgBox.setWrnMsg(msg.get("E11002"), pw.getSrcFn(), pw.getLineNumber());
                return;
            }

            for (int ope = 0; ope < 4; ope++)
            {

                ((ClsOPN)pw.chip).OutFmSetDtMl(pw, ope, parent.instFM[n][ope * Const.INSTRUMENT_M_OPERATOR_SIZE + 9], parent.instFM[n][ope * Const.INSTRUMENT_M_OPERATOR_SIZE + 8]);
                ((ClsOPN)pw.chip).OutFmSetKsAr(pw, ope, parent.instFM[n][ope * Const.INSTRUMENT_M_OPERATOR_SIZE + 7], parent.instFM[n][ope * Const.INSTRUMENT_M_OPERATOR_SIZE + 1]);
                ((ClsOPN)pw.chip).OutFmSetAmDr(pw, ope, parent.instFM[n][ope * Const.INSTRUMENT_M_OPERATOR_SIZE + 10], parent.instFM[n][ope * Const.INSTRUMENT_M_OPERATOR_SIZE + 2]);
                ((ClsOPN)pw.chip).OutFmSetSr(pw, ope, parent.instFM[n][ope * Const.INSTRUMENT_M_OPERATOR_SIZE + 3]);
                ((ClsOPN)pw.chip).OutFmSetSlRr(pw, ope, parent.instFM[n][ope * Const.INSTRUMENT_M_OPERATOR_SIZE + 5], parent.instFM[n][ope * Const.INSTRUMENT_M_OPERATOR_SIZE + 4]);
                ((ClsOPN)pw.chip).OutFmSetSSGEG(pw, ope, parent.instFM[n][ope * Const.INSTRUMENT_M_OPERATOR_SIZE + 11]);

            }
            pw.op1ml = parent.instFM[n][0 * Const.INSTRUMENT_M_OPERATOR_SIZE + 8];
            pw.op2ml = parent.instFM[n][1 * Const.INSTRUMENT_M_OPERATOR_SIZE + 8];
            pw.op3ml = parent.instFM[n][2 * Const.INSTRUMENT_M_OPERATOR_SIZE + 8];
            pw.op4ml = parent.instFM[n][3 * Const.INSTRUMENT_M_OPERATOR_SIZE + 8];
            pw.op1dt2 = 0;
            pw.op2dt2 = 0;
            pw.op3dt2 = 0;
            pw.op4dt2 = 0;

            ((ClsOPN)pw.chip).OutFmSetFeedbackAlgorithm(pw, parent.instFM[n][46], parent.instFM[n][45]);

            OutFmSetVolume(pw, vol, n);

        }

        public void OutFmKeyOff(partWork pw)
        {
            int n = (pw.chip is YM2203) ? 0 : 3;

            if (!pw.pcm)
            {
                if (pw.chip.lstPartWork[2].Ch3SpecialMode && pw.Type == enmChannelType.FMOPNex)
                {
                    pw.Ch3SpecialModeKeyOn = false;

                    int slot = (pw.chip.lstPartWork[2].Ch3SpecialModeKeyOn ? pw.chip.lstPartWork[2].slots : 0x0)
                        | (pw.chip.lstPartWork[n + 3].Ch3SpecialModeKeyOn ? pw.chip.lstPartWork[n + 3].slots : 0x0)
                        | (pw.chip.lstPartWork[n + 4].Ch3SpecialModeKeyOn ? pw.chip.lstPartWork[n + 4].slots : 0x0)
                        | (pw.chip.lstPartWork[n + 5].Ch3SpecialModeKeyOn ? pw.chip.lstPartWork[n + 5].slots : 0x0);

                    parent.OutData(pw.port0, 0x28, (byte)((slot << 4) + 2));
                }
                else
                {
                    if (pw.ch >= 0 && pw.ch < n + 3)
                    {
                        byte vch = (byte)((pw.ch > 2) ? pw.ch + 1 : pw.ch);
                        //key off
                        parent.OutData(pw.port0, 0x28, (byte)(0x00 + (vch & 7)));
                    }
                }

                return;
            }

            pw.pcmWaitKeyOnCounter = -1;
        }

        public void OutFmAllKeyOff()
        {

            foreach (partWork pw in lstPartWork)
            {
                if (pw.ch > 5) continue;

                OutFmKeyOff(pw);
                OutFmSetTl(pw, 0, 127);
                OutFmSetTl(pw, 1, 127);
                OutFmSetTl(pw, 2, 127);
                OutFmSetTl(pw, 3, 127);
            }

        }

        public void OutFmSetFnum(partWork pw, int octave, int num)
        {
            int freq;
            freq = ((num & 0x700) >> 8) + (((octave - 1) & 0x7) << 3);
            freq = (freq << 8) + (num & 0xff);

            if (freq == pw.freq) return;

            pw.freq = freq;

            if (pw.chip.lstPartWork[2].Ch3SpecialMode && pw.Type == enmChannelType.FMOPNex)
            {
                if ((pw.slots & 8) != 0)
                {
                    int f = pw.freq + pw.slotDetune[3];
                    parent.OutData(pw.port0, (byte)0xa6, (byte)((f & 0xff00) >> 8));
                    parent.OutData(pw.port0, (byte)0xa2, (byte)(f & 0xff));
                }
                if ((pw.slots & 4) != 0)
                {
                    int f = pw.freq + pw.slotDetune[2];
                    parent.OutData(pw.port0, (byte)0xac, (byte)((f & 0xff00) >> 8));
                    parent.OutData(pw.port0, (byte)0xa8, (byte)(f & 0xff));
                }
                if ((pw.slots & 1) != 0)
                {
                    int f = pw.freq + pw.slotDetune[0];
                    parent.OutData(pw.port0, (byte)0xad, (byte)((f & 0xff00) >> 8));
                    parent.OutData(pw.port0, (byte)0xa9, (byte)(f & 0xff));
                }
                if ((pw.slots & 2) != 0)
                {
                    int f = pw.freq + pw.slotDetune[1];
                    parent.OutData(pw.port0, (byte)0xae, (byte)((f & 0xff00) >> 8));
                    parent.OutData(pw.port0, (byte)0xaa, (byte)(f & 0xff));
                }
            }
            else
            {
                int n = (pw.chip is YM2203) ? 0 : 3;
                if (pw.ch >= n + 3 && pw.ch < n + 6)
                {
                    return;
                }
                if ((pw.chip is YM2612X) && pw.ch >= 9 && pw.ch <= 11)
                {
                    return;
                }
                if (pw.ch < n + 3)
                {
                    if (pw.pcm) return;

                    byte port = pw.ch > 2 ? pw.port1 : pw.port0;
                    byte vch = (byte)(pw.ch > 2 ? pw.ch - 3 : pw.ch);

                    parent.OutData(port, (byte)(0xa4 + vch), (byte)((pw.freq & 0xff00) >> 8));
                    parent.OutData(port, (byte)(0xa0 + vch), (byte)(pw.freq & 0xff));
                }
            }
        }

        public void OutFmKeyOn(partWork pw)
        {
            int n = (pw.chip is YM2203) ? 0 : 3;

            if (pw.chip is YM2612X && (pw.ch > 8 || pw.ch == 5) && pw.pcm)
            {
                ((YM2612X)pw.chip).OutYM2612XPcmKeyON(pw);
                return;
            }

            if (!pw.pcm)
            {
                if (pw.chip.lstPartWork[2].Ch3SpecialMode && pw.Type == enmChannelType.FMOPNex)
                {
                    pw.Ch3SpecialModeKeyOn = true;

                    int slot = (pw.chip.lstPartWork[2].Ch3SpecialModeKeyOn ? pw.chip.lstPartWork[2].slots : 0x0)
                        | (pw.chip.lstPartWork[n + 3].Ch3SpecialModeKeyOn ? pw.chip.lstPartWork[n + 3].slots : 0x0)
                        | (pw.chip.lstPartWork[n + 4].Ch3SpecialModeKeyOn ? pw.chip.lstPartWork[n + 4].slots : 0x0)
                        | (pw.chip.lstPartWork[n + 5].Ch3SpecialModeKeyOn ? pw.chip.lstPartWork[n + 5].slots : 0x0);

                    if (pw.chip is YM2612X)
                    {
                        parent.xgmKeyOnData.Add((byte)((slot << 4) + 2));
                    }
                    else
                    {
                        parent.OutData(pw.port0, 0x28, (byte)((slot << 4) + 2));
                    }
                }
                else
                {
                    if (pw.ch >= 0 && pw.ch < n + 3)
                    {
                        byte vch = (byte)((pw.ch > 2) ? pw.ch + 1 : pw.ch);
                        if (pw.chip is YM2612X)
                        {
                            parent.xgmKeyOnData.Add((byte)((pw.slots << 4) + (vch & 7)));
                        }
                        else
                        {
                            //key on
                            parent.OutData(pw.port0, 0x28, (byte)((pw.slots << 4) + (vch & 7)));
                        }
                    }
                }

                return;
            }


            if (!parent.instPCM.ContainsKey(pw.instrument)) return;

            float m = Const.pcmMTbl[pw.pcmNote] * (float)Math.Pow(2, (pw.pcmOctave - 4));
            pw.pcmBaseFreqPerFreq = Information.VGM_SAMPLE_PER_SECOND / ((float)parent.instPCM[pw.instrument].freq * m);
            pw.pcmFreqCountBuffer = 0.0f;
            long p = parent.instPCM[pw.instrument].stAdr;
            if (parent.info.Version == 1.51f)
            {
                parent.OutData(
                    0xe0
                    , (byte)(p & 0xff)
                    , (byte)((p & 0xff00) / 0x100)
                    , (byte)((p & 0xff0000) / 0x10000)
                    , (byte)((p & 0xff000000) / 0x10000)
                    );
            }
            else
            {
                long s = parent.instPCM[pw.instrument].size;
                long f = parent.instPCM[pw.instrument].freq;
                long w = 0;
                if (pw.gatetimePmode)
                {
                    w = pw.waitCounter * pw.gatetime / 8L;
                }
                else
                {
                    w = pw.waitCounter - pw.gatetime;
                }
                if (w < 1) w = 1;
                s = Math.Min(s, (long)(w * parent.info.samplesPerClock * f / 44100.0));

                if (!pw.streamSetup)
                {
                    parent.newStreamID++;
                    pw.streamID = parent.newStreamID;

                    parent.OutData(
                        // setup stream control
                        0x90
                        , (byte)pw.streamID
                        , (byte)(0x02 + (pw.isSecondary ? 0x80 : 0x00))
                        , 0x00
                        , 0x2a
                        // set stream data
                        , 0x91
                        , (byte)pw.streamID
                        , 0x00
                        , 0x01
                        , 0x00
                        );

                    pw.streamSetup = true;
                }

                if (pw.streamFreq != f)
                {
                    //Set Stream Frequency
                    parent.OutData(
                        0x92
                        , (byte)pw.streamID
                        , (byte)(f & 0xff)
                        , (byte)((f & 0xff00) / 0x100)
                        , (byte)((f & 0xff0000) / 0x10000)
                        , (byte)((f & 0xff000000) / 0x10000)
                        );

                    pw.streamFreq = f;
                }

                //Start Stream
                parent.OutData(
                    0x93
                    , (byte)pw.streamID

                    , (byte)(p & 0xff)
                    , (byte)((p & 0xff00) / 0x100)
                    , (byte)((p & 0xff0000) / 0x10000)
                    , (byte)((p & 0xff000000) / 0x10000)

                    , 0x01

                    , (byte)(s & 0xff)
                    , (byte)((s & 0xff00) / 0x100)
                    , (byte)((s & 0xff0000) / 0x10000)
                    , (byte)((s & 0xff000000) / 0x10000)
                    );
            }

            if (parent.instPCM[pw.instrument].status != enmPCMSTATUS.ERROR)
            {
                parent.instPCM[pw.instrument].status = enmPCMSTATUS.USED;
            }

        }


        public void SetFmFNum(partWork pw)
        {
            if (pw.noteCmd == (char)0)
            {
                return;
            }

            int[] ftbl = pw.chip.FNumTbl[0];

            int f = GetFmFNum(ftbl, pw.octaveNow, pw.noteCmd, pw.shift + pw.keyShift + pw.toneDoublerKeyShift);//
            if (pw.bendWaitCounter != -1)
            {
                f = pw.bendFnum;
            }
            int o = (f & 0xf000) / 0x1000;
            f &= 0xfff;

            f = f + pw.detune;
            for (int lfo = 0; lfo < 4; lfo++)
            {
                if (!pw.lfo[lfo].sw)
                {
                    continue;
                }
                if (pw.lfo[lfo].type != eLfoType.Vibrato)
                {
                    continue;
                }
                f += pw.lfo[lfo].value + pw.lfo[lfo].param[6];
            }
            while (f < ftbl[0])
            {
                if (o == 1)
                {
                    break;
                }
                o--;
                f = ftbl[0] * 2 - (ftbl[0] - f);
            }
            while (f >= ftbl[0] * 2)
            {
                if (o == 8)
                {
                    break;
                }
                o++;
                f = f - ftbl[0] * 2 + ftbl[0];
            }
            f = Common.CheckRange(f, 0, 0x7ff);
            OutFmSetFnum(pw, o, f);
        }

        public int GetFmFNum(int[] ftbl, int octave, char noteCmd, int shift)
        {
            int o = octave;
            int n = Const.NOTE.IndexOf(noteCmd) + shift;
            if (n >= 0)
            {
                o += n / 12;
                o = Common.CheckRange(o, 1, 8);
                n %= 12;
            }
            else
            {
                o += n / 12 - ((n % 12 == 0) ? 0 : 1);
                o = Common.CheckRange(o, 1, 8);
                n %= 12;
                if (n < 0) { n += 12; }
            }

            int f = ftbl[n];

            return (f & 0xfff) + (o & 0xf) * 0x1000;
        }

        public override int GetFNum(partWork pw, int octave, char cmd, int shift)
        {
            if (pw.Type == enmChannelType.FMOPN || pw.Type == enmChannelType.FMOPNex)
            {
                return GetFmFNum(FNumTbl[0], octave, cmd, shift);
            }
            if (pw.Type == enmChannelType.SSG)
            {
                return GetSsgFNum(pw, octave, cmd, shift);
            }
            return 0;
        }

        public override void GetFNumAtoB(partWork pw
            , out int a, int aOctaveNow, char aCmd, int aShift
            , out int b, int bOctaveNow, char bCmd, int bShift
            , int dir)
        {
            a = GetFNum(pw, aOctaveNow, aCmd, aShift);
            b = GetFNum(pw, bOctaveNow, bCmd, bShift);

            int oa = (a & 0xf000) / 0x1000;
            int ob = (b & 0xf000) / 0x1000;
            if (oa != ob)
            {
                if ((a & 0xfff) == FNumTbl[0][0])
                {
                    oa += Math.Sign(ob - oa);
                    a = (a & 0xfff) * 2 + oa * 0x1000;
                }
                else if ((b & 0xfff) == FNumTbl[0][0])
                {
                    ob += Math.Sign(oa - ob);
                    b = (b & 0xfff) * ((dir > 0) ? 2 : 1) + ob * 0x1000;
                }
            }
        }


        public void SetFmVolume(partWork pw)
        {
            int vol = pw.volume;

            for (int lfo = 0; lfo < 4; lfo++)
            {
                if (!pw.lfo[lfo].sw)
                {
                    continue;
                }
                if (pw.lfo[lfo].type != eLfoType.Tremolo)
                {
                    continue;
                }
                vol += pw.lfo[lfo].value + pw.lfo[lfo].param[6];
            }

            if (pw.beforeVolume != vol)
            {
                if (parent.instFM.ContainsKey(pw.instrument))
                {
                    OutFmSetVolume(pw, vol, pw.instrument);
                    pw.beforeVolume = vol;
                }
            }
        }

        public override void SetKeyOff(partWork pw)
        { }

        public override void SetVolume(partWork pw)
        {
            if (pw.Type == enmChannelType.FMOPN
                || pw.Type == enmChannelType.FMOPNex //効果音モード対応チャンネル
                || (pw.Type == enmChannelType.FMPCM && !pw.pcm) //OPN2PCMチャンネル
                || (pw.Type == enmChannelType.FMPCMex && !pw.pcm) //OPN2XPCMチャンネル
                )
            {
                SetFmVolume(pw);
            }
            else if (pw.Type == enmChannelType.SSG)
            {
                SetSsgVolume(pw);
            }
        }

        public override void SetLfoAtKeyOn(partWork pw)
        {
            for (int lfo = 0; lfo < 4; lfo++)
            {
                clsLfo pl = pw.lfo[lfo];
                if (!pl.sw)
                    continue;

                if (pl.param[5] != 1)
                    continue;

                pl.isEnd = false;
                pl.value = (pl.param[0] == 0) ? pl.param[6] : 0;//ディレイ中は振幅補正は適用されない
                pl.waitCounter = pl.param[0];
                pl.direction = pl.param[2] < 0 ? -1 : 1;

                if (pl.type == eLfoType.Vibrato)
                {
                    if (pw.Type == enmChannelType.FMOPN
                        || pw.Type == enmChannelType.FMOPNex)
                        SetFmFNum(pw);
                    else if (pw.Type == enmChannelType.SSG)
                        SetSsgFNum(pw);

                }

                if (pl.type == eLfoType.Tremolo)
                {
                    pw.beforeVolume = -1;
                    if (pw.Type == enmChannelType.FMOPN
                        || pw.Type == enmChannelType.FMOPNex)
                        SetFmVolume(pw);
                    else if (pw.Type == enmChannelType.SSG)
                        SetSsgVolume(pw);
                }

            }
        }

        public override void SetToneDoubler(partWork pw)
        {
        }

        public override int GetToneDoublerShift(partWork pw, int octave, char noteCmd, int shift)
        {
            return 0;
        }


        private void CmdY_ToneParamOPN(byte adr, partWork pw, byte op, byte dat)
        {
            int ch;
            if (pw.Type == enmChannelType.FMOPNex) ch = 2;
            else if (pw.Type == enmChannelType.FMOPN) ch = pw.ch;
            else return;

            byte port = (ch > 2 ? pw.port1 : pw.port0);
            int vch = ch;
            vch = (byte)(vch > 2 ? vch - 3 : vch);

            op = (byte)(op == 1 ? 2 : (op == 2 ? 1 : op));

            adr += (byte)(vch + (op << 2));

            parent.OutData(port, adr, dat);
        }

        private void CmdY_ToneParamOPN_FBAL(partWork pw, byte dat)
        {
            int ch;
            if (pw.Type == enmChannelType.FMOPNex) ch = 2;
            else if (pw.Type == enmChannelType.FMOPN) ch = pw.ch;
            else return;

            byte port = (ch > 2 ? pw.port1 : pw.port0);
            int vch = ch;
            vch = (byte)(vch > 2 ? vch - 3 : vch);

            byte adr = (byte)(0xb0 + vch);

            parent.OutData(port, adr, dat);
        }


        public override void CmdNoiseToneMixer(partWork pw, MML mml)
        {
            if (pw.Type == enmChannelType.SSG)
            {
                int n = (int)mml.args[0];
                n = Common.CheckRange(n, 0, 3);
                pw.mixer = n;
            }
        }

        public override void CmdNoise(partWork pw, MML mml)
        {
            int n = (int)mml.args[0];
            n = Common.CheckRange(n, 0, 31);
            pw.chip.lstPartWork[0].noise = n;//Chipの1Chに保存
            ((ClsOPN)pw.chip).OutSsgNoise(pw, n);
        }

        public override void CmdInstrument(partWork pw, MML mml)
        {
            char type = (char)mml.args[0];
            int n = (int)mml.args[1];

            if (type == 'I')
            {
                msgBox.setErrMsg(msg.get("E11003"), pw.getSrcFn(), pw.getLineNumber());
                return;
            }

            if (type == 'T')
            {
                n = Common.CheckRange(n, 0, 255);
                pw.toneDoubler = n;
                return;
            }

            if (type == 'E')
            {
                SetEnvelopParamFromInstrument(pw, n,mml);
                return;
            }

            if (pw.Type == enmChannelType.SSG)
            {
                SetEnvelopParamFromInstrument(pw, n,mml);
                return;
            }

            n = Common.CheckRange(n, 0, 255);
            if (pw.instrument == n) return;

            pw.instrument = n;
            ((ClsOPN)pw.chip).OutFmSetInstrument(pw, n, pw.volume);
        }

        public override void CmdEnvelope(partWork pw, MML mml)
        {

            base.CmdEnvelope(pw, mml);

            if (!(mml.args[0] is string))
            {
                msgBox.setErrMsg(msg.get("E11004")
                    ,mml.line.Fn
                    ,mml.line.Num);

                return;
            }

            string cmd = (string)mml.args[0];

            switch (cmd)
            {
                case "EOF":
                    if (pw.Type == enmChannelType.SSG)
                    {
                        pw.beforeVolume = -1;
                    }
                    break;
            }
        }

        public override void CmdExtendChannel(partWork pw, MML mml)
        {
            string cmd = (string)mml.args[0];

            switch (cmd)
            {
                case "EX":
                    int n = (int)mml.args[1];
                    byte res = 0;
                    while (n % 10 != 0)
                    {
                        if (n % 10 > 0 && n % 10 < 5)
                        {
                            res += (byte)(1 << (n % 10 - 1));
                        }
                        else
                        {
                            msgBox.setErrMsg(string.Format(msg.get("E11005"), n), pw.getSrcFn(), pw.getLineNumber());
                            break;
                        }
                        n /= 10;
                    }
                    if (res != 0)
                    {
                        pw.slotsEX = res;
                        if (pw.Ch3SpecialMode) pw.slots = pw.slotsEX;
                    }
                    break;
                case "EXON":
                    pw.Ch3SpecialMode = true;
                    ((ClsOPN)pw.chip).OutOPNSetCh3SpecialMode(pw, true);
                    foreach (partWork p in pw.chip.lstPartWork)
                    {
                        if (p.Type == enmChannelType.FMOPNex)
                        {
                            p.slots = p.slotsEX;
                            p.beforeVolume = -1;
                            p.beforeFNum = -1;
                            p.freq = -1;
                            //SetFmFNum(p);
                        }
                    }
                    break;
                case "EXOF":
                    pw.Ch3SpecialMode = false;
                    ((ClsOPN)pw.chip).OutOPNSetCh3SpecialMode(pw, false);
                    foreach (partWork p in pw.chip.lstPartWork) {
                        if (p.Type == enmChannelType.FMOPNex)
                        {
                            if (p.ch != 2) p.slots = 0;
                            else p.slots = p.slots4OP;
                            p.beforeVolume = -1;
                            p.beforeFNum = -1;
                            p.freq = -1;
                            //SetFmFNum(p);
                        }
                    }
                    break;
                case "EXD":
                    pw.slotDetune[0] = (int)mml.args[1];
                    pw.slotDetune[1] = (int)mml.args[2];
                    pw.slotDetune[2] = (int)mml.args[3];
                    pw.slotDetune[3] = (int)mml.args[4];
                    break;
            }
        }

        public override void CmdVolume(partWork pw, MML mml)
        {
            base.CmdVolume(pw, mml);
            //if (pw.Type == enmChannelType.FMOPN || pw.Type == enmChannelType.FMOPNex)
            //{
            //    SetFmVolume(pw);
            //}
            //if (pw.Type == enmChannelType.SSG)
            //{
            //    SetSsgVolume(pw);
            //}
        }

        public override void CmdY(partWork pw, MML mml)
        {
            if (mml.args[0] is string toneparamName)
            {
                byte op = (byte)mml.args[1];
                byte dat = (byte)mml.args[2];

                switch (toneparamName)
                {
                    case "DTML":
                        CmdY_ToneParamOPN(0x30, pw, op, dat);
                        break;
                    case "TL":
                        CmdY_ToneParamOPN(0x40, pw, op, dat);
                        break;
                    case "KSAR":
                        CmdY_ToneParamOPN(0x50, pw, op, dat);
                        break;
                    case "AMDR":
                        CmdY_ToneParamOPN(0x60, pw, op, dat);
                        break;
                    case "SR":
                        CmdY_ToneParamOPN(0x70, pw, op, dat);
                        break;
                    case "SLRR":
                        CmdY_ToneParamOPN(0x80, pw, op, dat);
                        break;
                    case "SSG":
                        CmdY_ToneParamOPN(0x90, pw, op, dat);
                        break;
                    case "FBAL":
                        CmdY_ToneParamOPN_FBAL(pw, dat);
                        break;
                }
            }
        }

        public override void CmdLoopExtProc(partWork pw, MML mml)
        {
        }

        public override void CmdHardEnvelope(partWork pw, MML mml)
        {
            if (pw.Type != enmChannelType.SSG) return;

            string cmd = (string)mml.args[0];
            int n = 0;

            switch (cmd)
            {
                case "EH":
                    n = (int)mml.args[1];
                    if (pw.HardEnvelopeSpeed != n)
                    {
                        parent.OutData(pw.port0, 0x0b, (byte)(n & 0xff));
                        parent.OutData(pw.port0, 0x0c, (byte)((n >> 8) & 0xff));
                        pw.HardEnvelopeSpeed = n;
                    }
                    break;
                case "EHON":
                    pw.HardEnvelopeSw = true;
                    break;
                case "EHOF":
                    pw.HardEnvelopeSw = false;
                    break;
                case "EHT":
                    n = (int)mml.args[1];
                    if (pw.HardEnvelopeType != n)
                    {
                        parent.OutData(pw.port0, 0x0d, (byte)(n & 0xf));
                        pw.HardEnvelopeType = n;
                    }
                    break;
            }
        }

    }
}
