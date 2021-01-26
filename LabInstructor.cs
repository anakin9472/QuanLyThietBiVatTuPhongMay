using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyPhongMay
{
    public class LabInstructor
    {
        public string Name { set; get; }
        public string Course { set; get; }
        public LabInstructor()
        {

        }
        public LabInstructor(string Name,string Course)
        {
            this.Name = Name;
            this.Course = Course;
        }
        public LabInstructor(LabInstructor a)
        {
            this.Name = a.Name;
            this.Course = a.Course;
        }
        //Mỗi công việc do instructor giao cho phòng máy (Distribute tasks)
        //Người vận hành phòng máy hoặc student sẽ nhận được những công việc đó
        //Mỗi đối tượng công việc sẽ có các cách thực thi khác nhau tùy theo nội dung công việc được truyền vào (topic)
        public void giveTask(LabTasks congviec, MyEventArgs e)
        {
            EVgiveTask?.Invoke(congviec, e);
            //chỉ thực hiện truy vấn khi có subscribe event
        }
        public event TruyVanHandler EVgiveTask;
        public delegate void TruyVanHandler(LabTasks congviec, MyEventArgs e);
    }
}