using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyPhongMay
{
    public enum CPU { i5, i7, r5, r7 }
    public enum RAM { SDRAM, DDR1, DDR2, DDR3, DDR4, DDR5}
    public class PC : Devices
    {
        public CPU CPUType;
        public RAM RAMType;
        public string POWER;
        private int PCIndex = 0;
        public PC()
        {
            this.Device_id = $"PC{PCIndex++}";
        }
        public PC(PC a) : base(a)
        {
            this.CPUType = a.CPUType;
            this.RAMType = a.RAMType;
            this.POWER = a.POWER;
        }
        public PC(DateTime Enumerate_date, DateTime LastCheck_date, string Device_id, CPU CPUType, RAM RAMType, string POWER)
            :base(Enumerate_date, LastCheck_date, Device_id)
        {
            this.CPUType = CPUType;
            this.RAMType = RAMType;
            this.POWER = POWER;
        }
        public override string Print_Info()
        {
                return base.Print_Info() + 
                $"CPU: {CPUType}\nRAM: {RAMType}\nPOWER: {POWER}";
        }

    }
}
