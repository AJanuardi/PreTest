using System;

namespace HR_App.Models
{
public class Paging
    {
        public int Id { get; set; }
        public int ShowItem { get; set; } = 4;
        public string StatusPage { get; set; }
        public int CurrentPage { get; set; }
    }
}