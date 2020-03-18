using System;

namespace Job_Vacation.Models
{
    public class Company
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string logo { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string status { get; set; }

    }
}