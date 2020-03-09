using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HR_App.Models;
using HR_App.Data;

namespace HR_App.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _appdbcontext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appdbcontext = appDbContext;
        }

        public IActionResult Index()
        {
            var y = (from i in _appdbcontext.leaves where i.status == "submited" select i).Count();
            ViewBag.count = y;
            return View();
        }

        public IActionResult Dashboard()
        {
            var x = from i in _appdbcontext.leaves select i;
            ViewBag.outemp = x;
            var y = (from i in _appdbcontext.leaves select i).Count();
            ViewBag.outcount = y;
            var z = (from i in _appdbcontext.employees where i.gender == "male" select i).Count();
            ViewBag.male = z;
            var k = (from i in _appdbcontext.employees where i.gender == "female" select i).Count();
            ViewBag.female = k;
            var l = (from i in _appdbcontext.employees select i).Count();
            ViewBag.emp = l;
            var m = (from i in _appdbcontext.attendances where (i.clockin.Day == DateTime.Now.Day) select i);
            var n = m.GroupBy( m => m.name ).Select(g => new { Number = g.Key, Count = g.Count() });
            Dictionary<string, int> List = new Dictionary<string, int>();
                foreach (var a in n)
                {
                    List.Add(a.Number, a.Count);
                }
            ViewBag.abs = List;
            var o = from i in _appdbcontext.reminders where (i.events.Day >= DateTime.Now.Day) select i;
            var p = o.Take(5);
            ViewBag.reminders = p;
            var q = from i in _appdbcontext.applicants where (i.apply <= DateTime.Now) select i;
            var r = q.Take(5);
            ViewBag.apply = r;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
