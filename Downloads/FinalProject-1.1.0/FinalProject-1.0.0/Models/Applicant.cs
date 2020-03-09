using System;

namespace HR_App.Models
{
    public class Applicant
    {
        public Guid id {get; set;}
        public string name { get; set; }
        public string cv { get; set; }
        public string photo { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public DateTime bhirtdate { get; set; }
        public string bhirtplace { get; set; }
        public string address { get; set; }
        public string status { get; set; }
        public DateTime apply { get; set; }
    }
}