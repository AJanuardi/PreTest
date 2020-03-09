using System;

namespace HR_App.Models
{
    public class Attendance
    {
        public int id {get; set;}
        public string name { get; set; }
        public DateTime clockin { get; set; }
        public DateTime clockout { get; set; }
    }
}