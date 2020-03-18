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
    public class LeaveRequestController : Controller
    {
        private AppDbContext _appdbcontext;
        private readonly ILogger<LeaveRequestController> _logger;

        public LeaveRequestController(ILogger<LeaveRequestController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appdbcontext = appDbContext;
        }
        
        [Authorize]
        public IActionResult Index(string search, int _crntpage=1)
        {
            ViewBag.search = search;
            var j = (from i in _appdbcontext.pagings select i).FirstOrDefault();
            if (j == null)
            {
                Paging paging = new Paging()
                {
                    CurrentPage = 1
                };
                _appdbcontext.pagings.Add(paging);
                _appdbcontext.SaveChanges();
                var y = (from i in _appdbcontext.leaves where i.status == "submitted" select i).Count();
            ViewBag.count = y;
            var z = _appdbcontext.pagings.Find(1);
            z.CurrentPage = _crntpage;
            _appdbcontext.SaveChanges();
            if (z.CurrentPage == 1)
            {
                if (search != null)
                {
                    var take = z.ShowItem;
                    var x = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="submitted") select i;
                    var k = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="allowed") select i;
                    var l = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="rejected") select i;
                    var get = from a in x.Take(take) select a;
                    var get1 = from a in k.Take(take) select a;
                    var get2 = from a in l.Take(take) select a;
                    ViewBag.emp = get;
                    ViewBag.emp1 = get1;
                    ViewBag.emp2 = get2;
                    ViewBag.page = z;
                    return View();
                }
                else
                {
                    var take = z.ShowItem;
                    var x = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.status == "submitted") select i;
                    var k = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.status == "allowed") select i;
                    var l = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.status == "rejected") select i;
                    var get = from a in x.Take(take) select a;
                    var get1 = from a in k.Take(take) select a;
                    var get2 = from a in l.Take(take) select a;
                    ViewBag.emp = get;
                    ViewBag.emp1 = get1;
                    ViewBag.emp2 = get2;
                    ViewBag.page = z;
                    return View();
                }
            }
            else
            {
                if (search != null)
                {
                    var take = z.ShowItem;
                    var x = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="submitted") select i;
                    var k = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="allowed") select i;
                    var l = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="rejected") select i;
                    var get = from a in x.Skip(take*(z.CurrentPage-1)).Take(take) select a;
                    var get1 = from a in k.Skip(take*(z.CurrentPage-1)).Take(take) select a;
                    var get2 = from a in l.Skip(take*(z.CurrentPage-1)).Take(take) select a;
                    ViewBag.emp = get;
                    ViewBag.emp1 = get1;
                    ViewBag.emp2 = get2;
                    ViewBag.page = z;
                    return View();
                }
                else
                {
                    var take = z.ShowItem;
                    var x = (from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.status == "submitted") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    var k = (from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.status == "allowed") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    var l = (from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.status == "rejected") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    ViewBag.emp = x;
                    ViewBag.emp1 = l;
                    ViewBag.emp2 = k;
                    ViewBag.page = z;
                    return View();
                }
            }
            }
            else
            {
                var y = (from i in _appdbcontext.leaves where i.status == "submitted" select i).Count();
            ViewBag.count = y;
            var z = _appdbcontext.pagings.Find(1);
            z.CurrentPage = _crntpage;
            _appdbcontext.SaveChanges();
            if (z.CurrentPage == 1)
            {
                if (search != null)
                {
                    var take = z.ShowItem;
                    var x = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="submitted") select i;
                    var k = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="allowed") select i;
                    var l = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="rejected") select i;
                    var get = from a in x.Take(take) select a;
                    var get1 = from a in k.Take(take) select a;
                    var get2 = from a in l.Take(take) select a;
                    ViewBag.emp = get;
                    ViewBag.emp1 = get1;
                    ViewBag.emp2 = get2;
                    ViewBag.page = z;
                    return View();
                }
                else
                {
                    var take = z.ShowItem;
                    var x = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.status == "submitted") select i;
                    var k = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.status == "allowed") select i;
                    var l = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.status == "rejected") select i;
                    var get = from a in x.Take(take) select a;
                    var get1 = from a in k.Take(take) select a;
                    var get2 = from a in l.Take(take) select a;
                    ViewBag.emp = get;
                    ViewBag.emp1 = get1;
                    ViewBag.emp2 = get2;
                    ViewBag.page = z;
                    return View();
                }
            }
            else
            {
                if (search != null)
                {
                    var take = z.ShowItem;
                    var x = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="submitted") select i;
                    var k = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="allowed") select i;
                    var l = from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="rejected") select i;
                    var get = from a in x.Skip(take*(z.CurrentPage-1)).Take(take) select a;
                    var get1 = from a in k.Skip(take*(z.CurrentPage-1)).Take(take) select a;
                    var get2 = from a in l.Skip(take*(z.CurrentPage-1)).Take(take) select a;
                    ViewBag.emp = get;
                    ViewBag.emp1 = get1;
                    ViewBag.emp2 = get2;
                    ViewBag.page = z;
                    return View();
                }
                else
                {
                    var take = z.ShowItem;
                    var x = (from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.status == "submitted") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    var k = (from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.status == "allowed") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    var l = (from i in _appdbcontext.leaves.OrderBy(a => a.outtime) where (i.status == "rejected") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    ViewBag.emp = x;
                    ViewBag.emp1 = l;
                    ViewBag.emp2 = k;
                    ViewBag.page = z;
                    return View();
                }
            }
            }
        }

        [Authorize]
        public IActionResult Allow(int id)
        {
            var x = (from i in _appdbcontext.leaves.OrderByDescending(a => a.id) where (i.id == id) select i).FirstOrDefault();
            x.status = "allowed";
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");   
        }

        [Authorize]
        public IActionResult Reject(int id)
        {
            var x = (from i in _appdbcontext.leaves.OrderByDescending(a => a.id) where (i.id == id) select i).FirstOrDefault();
            x.status = "rejected";
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");   
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();   
        }

        [Authorize]
        public IActionResult Information(int id)
        {
            var x = from i in _appdbcontext.leaves where i.id == id select i;
            ViewBag.emp = x;
            return View("Information");
        }

        [Authorize]
        public IActionResult Added(string name, string position, string department, DateTime outtime, DateTime intime)
        {
            Leave leave = new Leave()
            {
                name = name,
                position = position,
                department = department,
                outtime = outtime,
                intime = intime,
                status = "submitted"
            };
            _appdbcontext.leaves.Add(leave);
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Export()
        {
            var colom = new string[]
            {
                "id",
                "name",
                "position",
                "department",
                "outtime",
                "intime"
            };
            var employees = (from i in _appdbcontext.leaves select new object[]
            {
                i.id,
                i.name,
                i.position,
                i.department,
                i.outtime,
                i.intime
            }).ToList();
            var emp = new StringBuilder();
            employees.ForEach(line =>
            {
                emp.AppendLine(string.Join(",", line));
            });
            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", colom)}\r\n{emp.ToString()}");
            return File(buffer, "text/csv", $"LeaveRequest Info.csv");
        }

        [Authorize]
        public IActionResult ExportId(string search)
        {
            var colom = new string[]
            {
                "id",
                "name",
                "position",
                "department",
                "outtime",
                "intime"
            };
            var employees = (from i in _appdbcontext.leaves where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search)) select new object[]
            {
                i.id,
                i.name,
                i.position,
                i.department,
                i.outtime,
                i.intime
            }).ToList();
            var emp = new StringBuilder();
            employees.ForEach(line =>
            {
                emp.AppendLine(string.Join(",", line));
            });
            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", colom)}\r\n{emp.ToString()}");
            return File(buffer, "text/csv", $"LeaveRequest Info.csv");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
