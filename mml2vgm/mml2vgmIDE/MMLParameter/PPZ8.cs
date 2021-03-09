﻿using Core;
using musicDriverInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mml2vgmIDE.MMLParameter
{
    public class PPZ8 : Instrument
    {
        public override string Name => "PPZ8";
        public EnmMmlFileFormat mmlType = EnmMmlFileFormat.GWI;
        private string[] noteStrTbl = new string[] { "c", "c+", "d", "d+", "e", "f", "f+", "g", "g+", "a", "a+", "b" };

        public PPZ8(SoundManager.Chip chip, Setting setting) : base(8, chip,setting)
        {
            for (int i = 0; i < 8; i++)
            {
                vol[i] = 0;
                beforeTie[i] = false;
            }
        }



        public override void SetParameter(outDatum od, int cc)
        {
            int n;
            string s;
            try
            {
                int ch = od.linePos.ch;
                if (isTrace)
                {
                    if (ch < TraceInfo.Length) TraceInfo[ch].Enqueue(od);
                }

                switch (od.type)
                {
                    case enmMMLType.ClockCounter:
                        if (od == null || od.args == null || od.args.Count < 1) break;
                        clockCounter[ch] = (int)od.args[0];
                        break;
                    case enmMMLType.Instrument:
                        if (od.args[0] is char && (char)od.args[0] == 'E')
                            envelope[od.linePos.ch] = ((int)od.args[1]).ToString();
                        else
                        {
                            if (setting.MMLParameter.dispInstrumentName
                                && od.args.Count == 3
                                && (od.args[2] != null
                                && od.args[2].ToString() != ""))
                                inst[od.linePos.ch] = od.args[2].ToString();
                            else
                                inst[od.linePos.ch] = od.args[1] != null ? od.args[1].ToString() : "(null)";
                        }
                        break;
                    //case enmMMLType.Envelope:
                    //envelope[od.linePos.ch] = (int)od.args[1];
                    //break;
                    case enmMMLType.Volume:
                        if (od.linePos != null)
                            vol[ch] = (int)od.args[0];
                        break;
                    case enmMMLType.Pan:
                        n = (int)od.args[0];
                        if (od.linePos.part == "SSG")
                        {
                            pan[ch] = "-";
                        }
                        else
                        {
                            pan[ch] = "-";
                            if (n != 0) {
                                n -= 5;
                                pan[ch] = string.Format("{0}({1})", (n == 0 ? "Center" : (n < 0 ? "Left" : "Right")), n);
                            }
                        }
                        break;
                    case enmMMLType.Octave:
                        octave[ch] = (int)od.args[0];
                        break;
                    case enmMMLType.OctaveDown:
                        octave[ch]--;
                        break;
                    case enmMMLType.OctaveUp:
                        octave[ch]++;
                        break;
                    case enmMMLType.Gatetime:
                        if (mmlType == EnmMmlFileFormat.MML)
                        {
                            gatetime[ch] = string.Format("Q%{0:d03} q{1}-{2},{3}"
                                , 255 - (int)od.args[0]
                                , (int)od.args[1]
                                , (byte)((int)od.args[3] + (int)od.args[1])
                                , (int)od.args[2]
                                );
                        }
                        break;
                    case enmMMLType.Note:
                        if (mmlType == EnmMmlFileFormat.MML)
                        {
                            if (od.args == null || od.args.Count <= 0) break;
                            if (ch < octave.Length)
                            {
                                octave[ch] = ((int)od.args[0] >> 4);
                                if (((int)od.args[0] & 0xf) < noteStrTbl.Length)
                                {
                                    notecmd[ch] = string.Format("o{0}{1}", octave[ch], noteStrTbl[((int)od.args[0] & 0xf)]);
                                    length[ch] = string.Format("{0:0.##}(#{1:d})", 1.0 * cc / (int)od.args[1], (int)od.args[1]);
                                    if (vol[ch] != null)
                                        keyOnMeter[ch] = (int)(256.0 / 255 * vol[ch]);
                                }
                                else
                                {
                                    notecmd[ch] = "r";
                                    length[ch] = string.Format("{0:0.##}(#{1:d})", 1.0 * cc / (int)od.args[1], (int)od.args[1]);
                                }
                            }
                        }
                        break;
                    case enmMMLType.Rest:
                        if (mmlType == EnmMmlFileFormat.MML)
                        {
                            if (od.args != null)
                            {
                                Core.Rest rs = (Core.Rest)od.args[0];
                                notecmd[ch] = "r";
                                length[ch] = string.Format("{0:0.##}(#{1:d})", 1.0 * cc / rs.length, rs.length);
                            }
                        }
                        break;
                    case enmMMLType.Envelope:
                        s = (string)od.args[0];
                        envSw[ch] = s == "EON" ? "ON " : "OFF";
                        break;
                    case enmMMLType.LfoSwitch:
                        s = (string)od.args[2];
                        lfoSw[ch] = s;
                        break;
                    case enmMMLType.Detune:
                        n = (int)od.args[0];
                        detune[ch] = n;
                        break;
                    case enmMMLType.KeyShift:
                        n = (int)od.args[0];
                        keyShift[ch] = n;
                        break;
                }
            }
            catch
            {
                ;//握りつぶす
            }
        }


    }
}
