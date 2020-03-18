using System;

namespace HR_App.Models
{
    public class Leave
    {
        public int id {get; set;}
        public string name { get; set; }
        public string position { get; set; }
        public string department { get; set; }
        public DateTime outtime { get; set; }
        public DateTime intime { get; set; }
        public string reason { get; set; }
        public string status { get; set; }
    }
}