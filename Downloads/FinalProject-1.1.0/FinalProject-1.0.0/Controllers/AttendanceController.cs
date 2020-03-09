using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HR_App.Models;
using HR_App.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

namespace HR_App.Controllers
{
    public class AttendanceController : Controller
    {
        private AppDbContext _appdbcontext;
        private readonly ILogger<AttendanceController> _logger;

        public AttendanceController(ILogger<AttendanceController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appdbcontext = appDbContext;
        }
        
        public IActionResult Index()
        {
            var x = from i in _appdbcontext.attendances select i;
            ViewBag.att = x;
            var y = (from i in _appdbcontext.leaves where i.status == "submited" select i).Count();
            ViewBag.count = y;
            return View();
        }

        public IActionResult DataClockIn()
        {
            return View();
        }

        public IActionResult DataClockOut()
        {
            return View();
        }

        public IActionResult ClockIn(string name)
        {
                Attendance att = new Attendance()
                {
                    name = name,
                    clockin = DateTime.Now
                };
                _appdbcontext.attendances.Add(att);
                _appdbcontext.SaveChanges();
                return RedirectToAction("Index");
        }

        public IActionResult ClockOut(string name)
        {
                var x = (from i in _appdbcontext.attendances.OrderByDescending(a => a.id) where i.name == name select i).FirstOrDefault();
                var clockout = DateTime.Now;
                if (x.clockin.ToString("MM/dd/yyyy") == clockout.ToString("MM/dd/yyyy"))
                {
                    x.clockout = clockout;
                    _appdbcontext.SaveChanges();
                    return RedirectToAction("Index");
                }
                return Ok("Fail");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
