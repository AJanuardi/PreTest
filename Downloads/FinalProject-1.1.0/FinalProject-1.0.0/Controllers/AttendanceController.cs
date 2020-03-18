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
using Microsoft.AspNetCore.Authorization;

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
        
        [Authorize]
        public IActionResult Index()
        {
            var y = (from i in _appdbcontext.leaves where i.status == "submitted" select i).Count();
            ViewBag.count = y;
            var z = from i in _appdbcontext.employees.OrderBy(x => x.name) select i;
            ViewBag.emp = z;
            return View();
        }

        public IActionResult Data(string name)
        {
            var x = (from i in _appdbcontext.attendances.OrderByDescending(a => a.clockin) where (i.name == name) select i);
            ViewBag.att = x;
            var y = (from i in _appdbcontext.attendances.OrderBy(a => a.clockin) where (i.name == name) select i).FirstOrDefault();
            ViewBag.name = y;
            return View();
        }

        [Authorize]
        public IActionResult DataClockIn()
        {
            return View();
        }

        [Authorize]
        public IActionResult DataClockOut()
        {
            return View();
        }

        [Authorize]
        public IActionResult ClockIn(string name, DateTime date)
        {
                Attendance att = new Attendance()
                {
                    name = name,
                    clockin = date
                };
                _appdbcontext.attendances.Add(att);
                _appdbcontext.SaveChanges();
                return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult ClockOut(string name, DateTime date)
        {
                var x = (from i in _appdbcontext.attendances.OrderByDescending(a => a.id) where i.name == name select i).FirstOrDefault();
                if (x.clockin.ToString("MM/dd/yyyy") == date.ToString("MM/dd/yyyy"))
                {
                    x.clockout = date;
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
