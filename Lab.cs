using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyPhongMay
{
    // Xây dựng lớp MyEventArgs kế thừa từ EventArgs
    public class MyEventArgs : EventArgs //được định nghĩa sẵn trong thư viện .NET
    {
        //Hàm khởi tạo dữ liệu
        public MyEventArgs()
        {

        }
        public MyEventArgs(string data)
        {
            this.Data = data;
        }
        // Lưu dữ liệu gửi đi từ publisher
        public string Data;
    }
    public class Lab
    {
        public readonly string Lab_ID;
        public string LabName { set; get; }
        public List <LabTasks> labtasks { set; get; }
        public Dictionary<string, Devices> devices { set; get; }
        public LabIncharge labInc { set; get; }
        public LabInstructor labIns { set; get; }
        public DateTime OpenTime { set; get; }
        public DateTime CloseTime { set; get; }
        public Lab() 
        {
            this.labtasks = new List<LabTasks>();
            this.devices = new Dictionary<string, Devices>();
        }
        public Lab(string Lab_ID, string LabName, LabInstructor labIns, LabIncharge labInc,
            DateTime OpenTime, DateTime CloseTime) {
            this.Lab_ID = Lab_ID;
            this.LabName = LabName;
            this.labIns = labIns;
            this.labInc = labInc;
            this.OpenTime = OpenTime;
            this.CloseTime = CloseTime;
            this.labtasks = new List<LabTasks>();
            this.devices = new Dictionary<string, Devices>();
        }
        public Lab(Lab x)
        {
            this.Lab_ID = x.Lab_ID;
            this.LabName = x.LabName;
            this.OpenTime = x.OpenTime;
            this.CloseTime = x.CloseTime;
            this.labtasks = x.labtasks;
            this.labtasks = new List<LabTasks>(x.labtasks);
            this.devices = new Dictionary<string, Devices>(x.devices);

        }
        public string Print_LabInfo()
        {
            return $"Ma Phong: {this.Lab_ID}\nTenPhong: {this.LabName}\nNguoi quan li: {this.labIns.Name}";
        }
        public void addDevice (params Devices[] Dlist)
        {
            foreach (var item in Dlist)
            {
                this.devices.Add(item.Device_id, item);
            }
        }
        public void noteTask(LabTasks congviec, MyEventArgs e)
        {
            this.labtasks.Add(congviec);
        }
        public void markDoneTask(LabTasks congviec, MyEventArgs e)
        {
            //tìm trong list labtasks 
            //congviec.NumOfTasks la index trong LabTasks
            this.labtasks[congviec.NumOfTasks].isDone = true;
            //đánh dấu congviec.isDone = true;
        }
        public void SeekingAndChecking(Devices thietbi, MyEventArgs e)
        {
            try
            {
                this.devices[thietbi.Device_id].LastCheck_date = System.DateTime.Now;
            }
            catch
            {
                e.Data = $"Phong nay khong co thiet bi {thietbi.Device_id}";
            }
        }
        public void SoftwareChecking(Software ungdung, MyEventArgs e)
        {
            try
            {
                ungdung.software[ungdung.SoftWare_name].IsInstalling = true;
                //e.Data = $"Dang cai dat phan mem {ungdung.SoftWare_name}..... CAI DAT THANH CONG!";

            }
            catch
            {
                e.Data = $"Phong nay khong co phan mem {ungdung.SoftWare_name}";
            }
        }
    }
}
