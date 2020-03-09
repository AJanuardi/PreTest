using System;

namespace HR_App.Models
{
    public class Employee
    {
        public Guid id {get; set;}
        public string name { get; set; }
        public string photo { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public DateTime bhirtdate { get; set; }
        public string bhirtplace { get; set; }
        public string position { get; set; }
        public string department { get; set; }
        public string address { get; set; }
        public string nameugd1 { get; set; }
        public string emergency1 { get; set; }
        public string nameugd2 { get; set; }    
        public string emergency2 { get; set; }
        public string nameugd3 { get; set; }
        public string emergency3 { get; set; }
        public string status { get; set; } 
        public DateTime contract { get; set; }
    }
}