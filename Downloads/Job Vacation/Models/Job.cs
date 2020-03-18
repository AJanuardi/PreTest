using System;

namespace Job_Vacation.Models
{
    public class Job
    {
        public Guid id { get; set; }
        public string usernamecompany { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string requirement { get; set; }
        public string informations { get; set; }
        public string flyer { get; set; }
        public DateTime stardate { get; set; }
        public DateTime enddate { get; set; }


    }
}