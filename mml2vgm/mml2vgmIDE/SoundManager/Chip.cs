﻿using Core;
using mml2vgmIDE;

namespace SoundManager
{
    public class Chip
    {
        public bool Use;
        public long Delay;
        public EnmVRModel Model;
        public EnmZGMDevice Device;
        public int Index;
        public int Number;
        public int Hosei;

        private object lockobj = new object();
        private bool[] _ChMasks = null;
        public bool[] ChMasks
        {
            set
            {
                lock (lockobj) { _ChMasks = value; }
            }
            get
            {
                lock (lockobj) { return _ChMasks; }
            }
        }

        private int[] _ChMasksPG = null;
        public int[] ChMasksPG
        {
            set
            {
                lock (lockobj) { _ChMasksPG = value; }
            }
            get
            {
                lock (lockobj) { return _ChMasksPG; }
            }
        }

        public int currentCh { get; internal set; }

        public Chip(int Ch)
        {
            ChMasks = new bool[Ch];
            ChMasksPG = new int[Ch];
        }


        public void Move(Chip chip)
        {
            if (chip == null) return;

            this.Use = chip.Use;
            this.Delay = chip.Delay;
            this.Model = chip.Model;
            this.Device = chip.Device;
            this.Index = chip.Index;
            this.Number = chip.Number;
            this.Hosei = chip.Hosei;
            this.ChMasks = chip.ChMasks;
        }
    }
}
