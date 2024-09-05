using System;

namespace SomerenModel
{
    public class Activity
    {
        public int ActivityID { get; private set; }
        public string Name { get; private set; }
        public DateTime StartDayTime { get; private set; }
        public DateTime EndDayTime { get; private set; }

        public Activity(int id, string name, DateTime startDayTime, DateTime endDayTime)
        {
            ActivityID = id;
            Name = name;
            StartDayTime = startDayTime;
            EndDayTime = endDayTime;
        }
    }
}