using System;

namespace Job_Vacation.Models
{
    public class Seeker
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public DateTime birthdate { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string cv { get; set; }
        public string photo { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string status { get; set; }
    }
}