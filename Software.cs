using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyPhongMay
{

    public enum SubCpu { Intel, Ryzen, Both }
    public class Software
    {
        public string SoftWare_name { set; get; }
        public SubCpu subCpu { set; get; }
        public bool IsInstalling { set; get; }
        public bool IsUninstalling { set; get; }
        public bool IsUpdating { set; get; }
        public Dictionary <string, Software> software { set; get; }
        public void addSoftware(params Software[] Slist)
        {
            foreach (Software item in Slist)
            {
                this.software.Add(item.SoftWare_name, item);
            }
        }
        public void SettingUp() { }
        public Software()
        {
            this.software = new Dictionary<string, Software>();
        }
        public Software(string software_name, SubCpu a)
        {
            this.SoftWare_name = software_name;
            this.subCpu = a;
            this.software = new Dictionary<string, Software>();
        }
        public Software(Software x)
        {
            this.SoftWare_name = x.SoftWare_name;
            this.subCpu = x.subCpu;
            this.software = new Dictionary<string, Software>(x.software);
        }
        public static Software operator +(Software a, Software b)
        {
            string result = a.SoftWare_name + b.SoftWare_name;
            Software c = new Software(result, SubCpu.Both);
            return c;
        }
    }
}
