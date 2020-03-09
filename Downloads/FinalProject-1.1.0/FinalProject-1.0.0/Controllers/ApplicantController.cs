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
    public class ApplicantController : Controller
    {
        private AppDbContext _appdbcontext;
        private readonly ILogger<ApplicantController> _logger;

        public ApplicantController(ILogger<ApplicantController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appdbcontext = appDbContext;
        }
        
        public IActionResult Index()
        {
            var x = from i in _appdbcontext.applicants select i;
            ViewBag.app = x;
            var y = (from i in _appdbcontext.leaves where i.status == "submited" select i).Count();
            ViewBag.count = y;
            return View();
        }

        public IActionResult Data()
        {
            return View();
        }

        public IActionResult Information(Guid id)
        {
            var x = from i in _appdbcontext.applicants where i.id == id select i;
            ViewBag.app = x;
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            var x = _appdbcontext.applicants.Find(id);
            _appdbcontext.applicants.Remove(x);
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var x = from i in _appdbcontext.applicants where i.id == id select i;
            ViewBag.app = x;
            return View();
        }

        public IActionResult Status(Guid id)
        {
            var x = (from i in _appdbcontext.applicants where i.id == id select i).FirstOrDefault();
            if (x.status == "unprocessed")
            {
                x.status = "psychotest";
                _appdbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (x.status == "psychotest")
            {
                x.status = "interview";
                _appdbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (x.status == "interview")
            {
                x.status = "hired";
                _appdbcontext.SaveChanges();
                Employee employee = new Employee()
                {
                    name = x.name,
                    phone = x.phone,
                    email = x.email,
                    address = x.address,
                    bhirtdate = x.bhirtdate,
                    bhirtplace = x.bhirtplace,
                    gender = x.gender
                };
                _appdbcontext.employees.Add(employee);
                _appdbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Fail(Guid id)
        {
            var x = (from i in _appdbcontext.applicants where i.id == id select i).FirstOrDefault();
            x.status = "reject";
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Editor(Guid id, string name, string email, IFormFile photo, IFormFile cv, string phone, string gender, DateTime bhirtdate, string bhirtplace, string position, string department, string address)
        {
            var path1 = "wwwroot//cv";
            Directory.CreateDirectory(path1);
            var FileName1= Path.Combine(path1, Path.GetFileName(cv.FileName));
            photo.CopyTo(new FileStream(FileName1, FileMode.Create));
            var file1 = FileName1.Substring(8).Replace(@"\","/");
            var path = "wwwroot//images";
            Directory.CreateDirectory(path);
            var FileName= Path.Combine(path, Path.GetFileName(photo.FileName));
            photo.CopyTo(new FileStream(FileName, FileMode.Create));
            var file = FileName.Substring(8).Replace(@"\","/");
            var i = from y in _appdbcontext.applicants where y.id == id select y;
            foreach (var x in i)
            {
                x.name = name;
                x.email = email;
                x.photo = file;
                x.phone = phone;
                x.gender = gender;
                x.bhirtdate = bhirtdate;
                x.bhirtplace = bhirtplace;
                x.address = address;
                x.status = "unprocessed";
            }
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AddNew(string name, string email, IFormFile photo, IFormFile cv, string phone, string gender, DateTime bhirtdate, string bhirtplace, string position, string department, string address)
        {
                var path1 = "wwwroot//cv";
                Directory.CreateDirectory(path1);
                var FileName1= Path.Combine(path1, Path.GetFileName(cv.FileName));
                photo.CopyTo(new FileStream(FileName1, FileMode.Create));
                var file1 = FileName1.Substring(8).Replace(@"\","/");
                var path = "wwwroot//images";
                Directory.CreateDirectory(path);
                var FileName= Path.Combine(path, Path.GetFileName(photo.FileName));
                photo.CopyTo(new FileStream(FileName, FileMode.Create));
                var file = FileName.Substring(8).Replace(@"\","/");
                Applicant data = new Applicant()
                {
                    photo = file,
                    cv = file1,
                    name = name,
                    email = email,
                    phone = phone,
                    gender = gender,
                    bhirtdate = bhirtdate,
                    bhirtplace = bhirtplace,
                    address = address,
                    status = "unprocessed"
                };
                _appdbcontext.applicants.Add(data);
                _appdbcontext.SaveChanges();
                return RedirectToAction("Data");
        }

        public IActionResult Add(string name, string email, IFormFile photo, IFormFile cv, string phone, string gender, DateTime bhirtdate, string bhirtplace, string position, string department, string address)
        {
                var path1 = "wwwroot//cv";
                Directory.CreateDirectory(path1);
                var FileName1= Path.Combine(path1, Path.GetFileName(cv.FileName));
                photo.CopyTo(new FileStream(FileName1, FileMode.Create));
                var file1 = FileName1.Substring(8).Replace(@"\","/");
                var path = "wwwroot//images";
                Directory.CreateDirectory(path);
                var FileName= Path.Combine(path, Path.GetFileName(photo.FileName));
                photo.CopyTo(new FileStream(FileName, FileMode.Create));
                var file = FileName.Substring(8).Replace(@"\","/");
                Applicant data = new Applicant()
                {
                    photo = file,
                    cv = file1,
                    name = name,
                    email = email,
                    phone = phone,
                    gender = gender,
                    bhirtdate = bhirtdate,
                    bhirtplace = bhirtplace,
                    address = address,
                    status = "unprocessed"
                };
                _appdbcontext.applicants.Add(data);
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
