using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyPhongMay
{
    public class LabTasks : Lab
    {
        public readonly int NumOfTasks;
        private static int taskIndex = 0;
        public string Topics { set; get; }
        public bool isDone { set; get; }
        public LabTasks(string topic)
        {
            this.NumOfTasks = taskIndex++;
            this.Topics = topic;
            isDone = false;
        }
        public LabTasks()
        {
            this.NumOfTasks = taskIndex++;
            isDone = false;
        }
        public LabTasks(LabTasks a)
        {
            this.NumOfTasks = taskIndex++;
            this.Topics = a.Topics;
            this.isDone = a.isDone;
        }        
    }
}
