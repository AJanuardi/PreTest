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
    public class LeaveRequestController : Controller
    {
        private AppDbContext _appdbcontext;
        private readonly ILogger<LeaveRequestController> _logger;

        public LeaveRequestController(ILogger<LeaveRequestController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appdbcontext = appDbContext;
        }
        
        public IActionResult Index()
        {
            var x = from i in _appdbcontext.leaves select i;
            ViewBag.leave = x;
            var y = (from i in _appdbcontext.leaves where i.status == "submited" select i).Count();
            ViewBag.count = y;
            return View();
        }

        public IActionResult Allow(int id)
        {
            var x = (from i in _appdbcontext.leaves.OrderByDescending(a => a.id) where (i.id == id) select i).FirstOrDefault();
            x.status = "allowed";
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");   
        }

        public IActionResult Reject(int id)
        {
            var x = (from i in _appdbcontext.leaves.OrderByDescending(a => a.id) where (i.id == id) select i).FirstOrDefault();
            x.status = "reject";
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");   
        }

        public IActionResult Add()
        {
            return View();   
        }

        public IActionResult Added(string name, string position, string department, DateTime outtime, DateTime intime, string status)
        {
            Leave leave = new Leave()
            {
                name = name,
                position = position,
                department = department,
                outtime = outtime,
                intime = intime,
                status = "submited"
            };
            _appdbcontext.leaves.Add(leave);
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
