using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyPhongMay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============= QUAN LY THIET BI VAT TU PHONG MAY =============");
            LabInstructor nguyen = new LabInstructor("Nguyen Van A", "Thiet bi phan cung");
            LabIncharge minh = new LabIncharge("Nguyen Van B", Level.Bronze);
            Lab a = new Lab("A5-303", "Phong may 1", nguyen, minh, new DateTime(125), new DateTime(263));
            Console.WriteLine(a.Print_LabInfo());

            //Default
            a.labIns.EVgiveTask += a.noteTask;   //subscribe event: theo dõi sự kiện
            a.labIns.EVgiveTask += confirmTask;
            a.labInc.EVconfirmDoneTask += a.markDoneTask;
            a.labInc.EVconfirmDoneTask += confirmTask;

            LabTasks b = new LabTasks();
            Console.Write($"Nhap cong viec thu {b.NumOfTasks + 1}: ");
            b.Topics = Console.ReadLine();
            a.labIns.giveTask(b, new MyEventArgs("Da ban giao cong viec "));
            a.labInc.confirmDoneTask(b, new MyEventArgs("Da lam xong "));
            Console.WriteLine(a.labtasks[0].isDone);

            //LabTasks task2 = new LabTasks();
            //Console.Write($"Nhap cong viec thu {task2.NumOfTasks + 1}: ");
            //task2.Topics = Console.ReadLine();
            //a.labIns.giveTask(task2, new MyEventArgs("taks2"));
            //a.labInc.confirmDoneTask(task2, new MyEventArgs("Da lam xong "));
            //Console.WriteLine(a.labtasks[1].isDone);

            Devices PC01 = new PC(new DateTime(100), new DateTime(225), "may1", CPU.i5, RAM.DDR4, "700W");
            //Console.WriteLine(PC01.Print_Info());
            Console.Write($"Nhap ID thiet bi can kiem tra: ");
            PC01.Device_id = Console.ReadLine();
            a.addDevice(PC01);
            a.labInc.EVcheckDevice += a.SeekingAndChecking;
            a.labInc.EVcheckDevice += confirmCheckDevices;
            a.labInc.CheckDevices(PC01, new MyEventArgs($"Da kiem tra thiet bi {PC01.Device_id}"));
            Console.WriteLine(PC01.Print_Info());

            //Install
            Console.Write($"Nhap phan mem can tien hanh cac thao tac: ");
            Software ungdung1 = new Software();
            ungdung1.SoftWare_name = Console.ReadLine();
            ungdung1.addSoftware(ungdung1);
            a.labInc.EventInstall += a.SoftwareChecking;
            a.labInc.EventInstall += Install;
            a.labInc.thucThiEventInstall(ungdung1, new MyEventArgs($"Dang cai dat phan mem { ungdung1.SoftWare_name }..... CAI DAT THANH CONG!"));

            //UnInstall
            a.labInc.EventUninstall += a.SoftwareChecking;
            a.labInc.EventUninstall += Uninstall;
            a.labInc.thucThiEventUninstall(ungdung1, new MyEventArgs($"Dang go cai dat phan mem { ungdung1.SoftWare_name }..... GO CAI DAT THANH CONG!"));


            //Update
            a.labInc.EventUpdate += a.SoftwareChecking;
            a.labInc.EventUpdate += Update;
            a.labInc.thucThiEventUpdate(ungdung1, new MyEventArgs($"Dang go cai dat phan mem { ungdung1.SoftWare_name }..... CAP NHAT THANH CONG!"));

            Software ungdung2 = new Software("unikey", SubCpu.Ryzen);
            Software c = ungdung1 + ungdung2;
            Console.WriteLine(c.SoftWare_name + " " + c.subCpu);

            PC01.EventCheckSoft += CheckSoft;
            Console.WriteLine(PC01.thucThiEventCheckSoft(PC01, ungdung1));

            PC test = new PC(PC01.Enumerate_date, PC01.LastCheck_date, PC01.Device_id, CPU.i5, RAM.DDR4, "550W");
            a.labInc.EventCheckSoftSuiCpu += CheckSoftSuiCpu;
            Console.WriteLine(a.labInc.thucThiEventCheckSoftSuiCpu(test, ungdung1));

            PC01.EventDriver += Driver;
            Console.WriteLine(PC01.thucThiEventDriver(PC01));

            a.labInc.EventCheckDriver += CheckDriver;
            Console.WriteLine(a.labInc.thucThiEventCheckDriver(PC01));
        }
        public static void confirmTask(LabTasks congviec, MyEventArgs e)
        {
            Console.WriteLine($"{e.Data}: {congviec.Topics}");
        }
        public static void confirmCheckDevices(Devices thietbi, MyEventArgs e)
        {
            Console.WriteLine($"{e.Data}");
        }
        public static void Install(Software ungdung, MyEventArgs e)
        {
            Console.WriteLine($"{e.Data}");
        }
        public static void Uninstall(Software ungdung, MyEventArgs e)
        {
            Console.WriteLine($"{e.Data}");
        }
        public static void Update(Software ungdung, MyEventArgs e)
        {
            Console.WriteLine($"{e.Data}");
        }
        private static object CheckSoft(Devices a, Software ungdung)
        {

            return "Phan mem " + ungdung.SoftWare_name + " hoat dong binh thuong";
        }
        private static object Driver(Devices a)
        {
            a.Driver = 1;
            return "Da cap nhat thanh cong day du Driver cho thiet bi ";
        }
        public static object CheckSoftSuiCpu(PC a, Software ungdung)
        {
            if ((a.CPUType == CPU.i5 && ungdung.subCpu == SubCpu.Intel) || (a.CPUType == CPU.i7 && ungdung.subCpu == SubCpu.Intel) ||
                (a.CPUType == CPU.i7 && ungdung.subCpu == SubCpu.Both) || (a.CPUType == CPU.i7 && ungdung.subCpu == SubCpu.Both) ||
                (a.CPUType == CPU.r5 && ungdung.subCpu == SubCpu.Ryzen) || (a.CPUType == CPU.r7 && ungdung.subCpu == SubCpu.Ryzen) ||
                (a.CPUType == CPU.r5 && ungdung.subCpu == SubCpu.Both) || (a.CPUType == CPU.r7 && ungdung.subCpu == SubCpu.Both))
                return "Phan mem " + ungdung.SoftWare_name + " phu hop voi may tinh";
            else return "Phan mem " + ungdung.SoftWare_name + " khong phu hop voi may tinh";
        }
        public static object CheckDriver(Devices a)
        {
            if (a.Driver == 0) return Driver(a);
            else return "Thiet bi da day du Diver";


        }
    }
}
