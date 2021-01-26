using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyPhongMay
{
    public enum Level { Bronze, Silver, Gold, Platinum}
    public class LabIncharge
    {
        public string Name { set; get; }
        public Level level { set; get; }
        public LabIncharge() { }
        public LabIncharge(string Name, Level level)
        {
            this.Name = Name;
            this.level = level;
        }
        public LabIncharge(LabIncharge a)
        {
            this.Name = a.Name;
            this.level = a.level;
        }
        //Cập nhật phần mềm
        public string InstallSoftware(Devices x, Software y)
        {
            x.log.Add(new Log(System.DateTime.Now, $"{Name}: cai dat phan mem {y.SoftWare_name}"));
            x.soft.Add(y);
            return $"{Name}: dang cai dat phan mem {y.SoftWare_name} cho {x.Device_id}";
        }
        //Duy trì thiết bị
        public string Maitenance(Devices x) 
        {
            x.log.Add(new Log(System.DateTime.Now, $"{Name}: bao tri"));
            return $"{Name}: dang bao tri {x.Device_id}";
        }
        //Nâng cấp thiết bị
        public string Upgrading(Devices x) 
        {
            x.log.Add(new Log(System.DateTime.Now, $"{Name}: nang cap"));
            return $"{Name}: dang nang cap {x.Device_id}..... \nDone";
        }
        //Sửa chữa thiết bị
        public string Repairing(Devices x)
        {
            x.log.Add(new Log(System.DateTime.Now, $"{Name}: sua chua"));
            x.IsBroken = false;
            return $"{Name}: dang sua chua {x.Device_id}..... \nDone";
        }

        //Event xác nhận công việc thành công
        public void confirmDoneTask(LabTasks congviec, MyEventArgs e)
        {
            EVconfirmDoneTask?.Invoke(congviec, e);
            //chỉ thực hiện truy vấn khi có subscribe event
        }
        public delegate void EVconfirmDoneTaskHandler(LabTasks congviec, MyEventArgs e);
        public event EVconfirmDoneTaskHandler EVconfirmDoneTask; //cái này là mark cái task đó hoàn thành

        //Event kiểm tra thiết bị
        public void CheckDevices(Devices thietbi, MyEventArgs e)
        {
            EVcheckDevice?.Invoke(thietbi, e);
        }
        public delegate void TruyVanHandle(Devices thietbi, MyEventArgs e);
        public event TruyVanHandle EVcheckDevice;

        //Event cài đặt phần mềm
        public delegate void DelegateInstall(Software ungdung, MyEventArgs e);
        public event DelegateInstall EventInstall;
        public void thucThiEventInstall(Software ungdung, MyEventArgs e)
        {

            EventInstall?.Invoke(ungdung, e);
        }

        //Event gỡ cài đặt phần mềm
        public delegate void DelegateUninstall(Software ungdung, MyEventArgs e);
        public event DelegateUninstall EventUninstall;
        public void thucThiEventUninstall(Software ungdung, MyEventArgs e)
        {

            EventUninstall?.Invoke(ungdung, e);
        }

        //Event cập nhật phần mềm
        public delegate void DelegateUpdate(Software ungdung, MyEventArgs e);
        public event DelegateUpdate EventUpdate;
        public void thucThiEventUpdate(Software ungdung, MyEventArgs e)
        {

            EventUpdate?.Invoke(ungdung, e);
        }

        //Event kiểm tra phần mềm có tương thích với CPU hay không
        public delegate object DelegateCheckSoftSuiCpu(PC a, Software ungdung);
        public event DelegateCheckSoftSuiCpu EventCheckSoftSuiCpu;
        public object thucThiEventCheckSoftSuiCpu(PC a, Software ungdung)
        {

            return EventCheckSoftSuiCpu?.Invoke(a, ungdung);
        }

        //Event kiểm tra Driver máy tính có đầy đủ hay chưa
        public delegate object DelegateCheckDriver(Devices a);
        public event DelegateCheckDriver EventCheckDriver;
        public object thucThiEventCheckDriver(Devices a)
        {

            return EventCheckDriver?.Invoke(a);
        }

    }
}
