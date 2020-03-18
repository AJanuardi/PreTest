using System;

namespace Job_Vacation.Models
{
    public class TakeJob
    {
        public int id { get; set; }
        public Guid idjob { get; set; }
        public Guid idseeker { get; set; }
        public DateTime apply { get; set; }
    }
}