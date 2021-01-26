using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyPhongMay
{
    public class Log
    {
        public DateTime date { set; get; }
        public string content { set; get; }
        public Log()
        {

        }
        public Log(DateTime date, string content)
        {
            this.date = date;
            this.content = content;
        }
        public Log(Log x)
        {
            this.date = x.date;
            this.content = x.content;
        }
    }
    public abstract class Devices : Lab
    {
        public List<Software> soft;
        public List<Log> log;
        public string Device_id { set; get; }
        public DateTime Enumerate_date { set; get; }
        public DateTime LastCheck_date { set; get; }
        public int Driver;
        public Devices()
        {
            this.Driver = 0;
        }
        public Devices(DateTime Enumerate_date, DateTime LastCheck_date, string Device_id) 
        {
            this.Enumerate_date = Enumerate_date;
            this.LastCheck_date = LastCheck_date;
            this.Device_id = Device_id;
        }
        public Devices(Devices a)
        {
            this.Enumerate_date = a.Enumerate_date;
            this.LastCheck_date = a.LastCheck_date;
            this.Device_id = a.Device_id;
        }
        public virtual string Print_Info()
        {
            return $"Ma thiet bi: {Device_id}\nNgay dang kiem: {Enumerate_date}\nNgay kiem tra cuoi cung: {LastCheck_date}\n";
        }
        public bool IsUsing { set; get; }
        public bool IsBroken { set; get; }
        public string Announce_Status()
        {            
            if (IsUsing)
                return "Dang duoc su dung";
            if(IsBroken)
                return "Dang bi hong";
            return "Dang trong";
        }
        public void Broken()
        {
            this.IsBroken = true;
            LabTasks fixBroken = new LabTasks($"Sua may {this.Device_id}");
        }
        //Event kiểm tra phần mềm
        public delegate object DelegateCheckSoft(Devices a, Software ungdung);
        public event DelegateCheckSoft EventCheckSoft;
        public object thucThiEventCheckSoft(Devices a, Software ungdung)
        {

            return EventCheckSoft?.Invoke(a, ungdung);
        }

        //Event cập nhật driver
        public delegate object DelegateDriver(Devices a);
        public event DelegateDriver EventDriver;
        public object thucThiEventDriver(Devices a)
        {

            return EventDriver?.Invoke(a);
        }
    }
}
