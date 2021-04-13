﻿using Core;
using musicDriverInterface;
using System;
using System.Linq;

namespace mml2vgmIDE.MMLParameter
{
    public class YM2151 : Instrument
    {
        public YM2151(SoundManager.Chip chip, Setting setting) : base(8, chip,setting)
        {
            for (int i = 0; i < 8; i++)
            {
                vol[i] = 127;
                beforeTie[i] = false;
            }
        }

        public override string Name => "YM2151";

        protected override void SetInstrument(outDatum od, int ch, int cc)
        {
            if (od.args.Count == 3 && (od.args[2] != null && od.args[2].ToString() != ""))
                inst[od.linePos.ch] = od.args[2].ToString();
            else
                base.SetInstrument(od, ch, cc);
        }

        protected override void SetNote(outDatum od, int ch, int cc)
        {
            Core.Note nt = (Core.Note)od.args[0];
            int shift = nt.shift;
            string f = Math.Sign(shift) >= 0 ? string.Concat(Enumerable.Repeat("+", shift)) : string.Concat(Enumerable.Repeat("-", -shift));
            notecmd[od.linePos.ch] = string.Format("o{0}{1}{2}", octave[od.linePos.ch], nt.cmd, f);
            length[od.linePos.ch] = string.Format("{0:0.##}(#{1:d})", 1.0 * cc / nt.length, nt.length);

            if (!beforeTie[od.linePos.ch])
            {
                if (vol[od.linePos.ch] != null)
                {
                    keyOnMeter[od.linePos.ch] = (int)(256.0 / 128.0 * vol[od.linePos.ch]);
                }
            }
            beforeTie[od.linePos.ch] = nt.tieSw;
        }

        protected override void SetPan(outDatum od, int ch, int cc)
        {
            int n = (int)od.args[0];
            pan[od.linePos.ch] = n == 0 ? "-" : (n == 1 ? "Right" : (n == 2 ? "Left" : "Center"));
        }


    }
}
