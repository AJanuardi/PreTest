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
    public class ApplicantController : Controller
    {
        private AppDbContext _appdbcontext;
        private readonly ILogger<ApplicantController> _logger;

        public ApplicantController(ILogger<ApplicantController> logger, AppDbContext appDbContext)
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
                    var x = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.name.Contains(search) || i.status.Contains(search) && i.status=="unprocessed") select i;
                    var k = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.name.Contains(search) || i.status.Contains(search) && i.status=="psychotest") select i;
                    var l = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.name.Contains(search) || i.status.Contains(search) && i.status=="interview") select i;
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
                    var x = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.status == "unprocessed") select i;
                    var k = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.status == "psychotest") select i;
                    var l = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.status == "interview") select i;
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
                    var x = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.name.Contains(search) || i.status.Contains(search) && i.status=="unprocessed") select i;
                    var k = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.name.Contains(search) || i.status.Contains(search) && i.status=="psychotest") select i;
                    var l = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.name.Contains(search) || i.status.Contains(search) && i.status=="interview") select i;
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
                    var x = (from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.status == "unprocessed") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    var k = (from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.status == "psychotest") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    var l = (from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.status == "interview") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    ViewBag.emp = x;
                    ViewBag.emp1 = k;
                    ViewBag.emp2 = l;
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
                    var x = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.name.Contains(search) || i.status.Contains(search) && i.status=="unprocessed") select i;
                    var k = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.name.Contains(search) || i.status.Contains(search) && i.status=="psychotest") select i;
                    var l = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.name.Contains(search) || i.status.Contains(search) && i.status=="interview") select i;
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
                    var x = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.status == "unprocessed") select i;
                    var k = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.status == "psychotest") select i;
                    var l = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.status == "interview") select i;
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
                    var x = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.name.Contains(search) || i.status.Contains(search) && i.status=="unprocessed") select i;
                    var k = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.name.Contains(search) || i.status.Contains(search) && i.status=="psychotest") select i;
                    var l = from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.name.Contains(search) || i.status.Contains(search) && i.status=="interview") select i;
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
                    var x = (from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.status == "unprocessed") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    var k = (from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.status == "psychotest") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    var l = (from i in _appdbcontext.applicants.OrderByDescending(a => a.apply) where (i.status == "interview") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    ViewBag.emp = x;
                    ViewBag.emp1 = k;
                    ViewBag.emp2 = l;
                    ViewBag.page = z;
                    return View();
                }
            }
            }
        }

        [Authorize]
        public IActionResult Data()
        {
            return View();
        }

        [Authorize]
        public IActionResult Information(Guid id)
        {
            var x = from i in _appdbcontext.applicants where i.id == id select i;
            ViewBag.app = x;
            return View();
        }

        [Authorize]
        public IActionResult Delete(Guid id)
        {
            var x = _appdbcontext.applicants.Find(id);
            _appdbcontext.applicants.Remove(x);
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Edit(Guid id)
        {
            var x = from i in _appdbcontext.applicants where i.id == id select i;
            ViewBag.app = x;
            return View();
        }

        [Authorize]
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
                    gender = x.gender,
                    position = x.posisi,
                    status = "Probation"
                };
                _appdbcontext.employees.Add(employee);
                _appdbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Fail(Guid id)
        {
            var x = (from i in _appdbcontext.applicants where i.id == id select i).FirstOrDefault();
            x.status = "reject";
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Editor(Guid id, string name, string email, IFormFile photo, IFormFile cv, string phone, string gender, DateTime date, string place, string address, string posisi)
        {
            if (photo != null && cv != null)
            {
            var path1 = "wwwroot//cv";
            Directory.CreateDirectory(path1);
            var FileName1= Path.Combine(path1, Path.GetFileName(cv.FileName));
            cv.CopyTo(new FileStream(FileName1, FileMode.Create));
            var file1 = FileName1.Substring(8).Replace(@"\","/");
            var path = "wwwroot//images";
            Directory.CreateDirectory(path);
            var FileName= Path.Combine(path, Path.GetFileName(photo.FileName));
            photo.CopyTo(new FileStream(FileName, FileMode.Create));
            var file = FileName.Substring(8).Replace(@"\","/");
            var i = _appdbcontext.applicants.Find(id);
                i.name = name;
                i.email = email;
                i.photo = file;
                i.cv = file1;
                i.phone = phone;
                i.gender = gender;
                i.bhirtdate = date;
                i.bhirtplace = place;
                i.address = address;
                i.posisi = posisi;
            _appdbcontext.SaveChanges();
            }
            else if (photo == null && cv != null)
            {
            var path1 = "wwwroot//cv";
            Directory.CreateDirectory(path1);
            var FileName1= Path.Combine(path1, Path.GetFileName(cv.FileName));
            cv.CopyTo(new FileStream(FileName1, FileMode.Create));
            var file1 = FileName1.Substring(8).Replace(@"\","/");
            var i = _appdbcontext.applicants.Find(id);
                i.name = name;
                i.email = email;
                i.cv = file1;
                i.phone = phone;
                i.gender = gender;
                i.bhirtdate = date;
                i.bhirtplace = place;
                i.address = address;
                i.posisi = posisi;
            _appdbcontext.SaveChanges();
            }
            else if (photo != null && cv == null)
            {
            var path = "wwwroot//images";
            Directory.CreateDirectory(path);
            var FileName= Path.Combine(path, Path.GetFileName(photo.FileName));
            photo.CopyTo(new FileStream(FileName, FileMode.Create));
            var file = FileName.Substring(8).Replace(@"\","/");
            var i = _appdbcontext.applicants.Find(id);
                i.name = name;
                i.email = email;
                i.photo = file;
                i.phone = phone;
                i.gender = gender;
                i.bhirtdate = date;
                i.bhirtplace = place;
                i.address = address;
                i.posisi = posisi;
            _appdbcontext.SaveChanges();
            }
            else if (photo == null && cv == null)
            {
            var i = _appdbcontext.applicants.Find(id);
                i.name = name;
                i.email = email;
                i.phone = phone;
                i.gender = gender;
                i.bhirtdate = date;
                i.bhirtplace = place;
                i.address = address;
                i.posisi = posisi;
                _appdbcontext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult AddNew(string name, string email, IFormFile photo, IFormFile cv, string phone, string gender, DateTime date, string place, string address, string posisi)
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
                    bhirtdate = date,
                    bhirtplace = place,
                    address = address,
                    status = "unprocessed",
                    apply = DateTime.Now,
                    posisi = posisi
                };
                _appdbcontext.applicants.Add(data);
                _appdbcontext.SaveChanges();
                return RedirectToAction("Data");
        }

        [Authorize]
        public IActionResult Add(string name, string email, IFormFile photo, IFormFile cv, string phone, string gender, DateTime date, string place, string posisi, string address)
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
                    bhirtdate = date,
                    bhirtplace = place,
                    address = address,
                    status = "unprocessed",
                    apply = DateTime.Now,
                    posisi = posisi
                };
                _appdbcontext.applicants.Add(data);
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
                "cv",
                "photo",
                "email",
                "phone",
                "gender",
                "bhirtdate",
                "bhirtplace",
                "address",
                "status",
                "apply"
            };
            var employees = (from i in _appdbcontext.applicants select new object[]
            {
                i.id,
                i.name,
                i.cv,
                i.photo,
                i.email,
                i.phone,
                i.gender,
                i.bhirtdate,
                i.bhirtplace,
                i.address,
                i.status,
                i.apply
            }).ToList();
            var emp = new StringBuilder();
            employees.ForEach(line =>
            {
                emp.AppendLine(string.Join(",", line));
            });
            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", colom)}\r\n{emp.ToString()}");
            return File(buffer, "text/csv", $"Applicants Info.csv");
        }

        [Authorize]
        public IActionResult ExportId(string search)
        {
            var colom = new string[]
            {
                "id",
                "name",
                "cv",
                "photo",
                "email",
                "phone",
                "gender",
                "bhirtdate",
                "bhirtplace",
                "address",
                "status",
                "apply"
            };
            var employees = (from i in _appdbcontext.applicants where (i.name.Contains(search) ||  i.status.Contains(search)) select new object[]
            {
                i.id,
                i.name,
                i.photo,
                i.email,
                i.phone,
                i.gender,
                i.bhirtdate,
                i.bhirtplace,
                i.address,
                i.status,
                i.apply
            }).ToList();
            var emp = new StringBuilder();
            employees.ForEach(line =>
            {
                emp.AppendLine(string.Join(",", line));
            });
            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", colom)}\r\n{emp.ToString()}");
            return File(buffer, "text/csv", $"Applicants Info.csv");
        }

        [Authorize]
        public IActionResult Import([FromForm(Name="Upload")] IFormFile Upload)
        {
                        using (var sreader = new StreamReader(Upload.OpenReadStream()))
                        {
                            string[] headers = sreader.ReadLine().Split(',');
                            while(!sreader.EndOfStream)
                            {
                                string[] rows = sreader.ReadLine().Split(',');
                                Applicant emp = new Applicant()
                                {

                                    name = rows[0].ToString(),
                                    cv = rows[1].ToString(),
                                    photo = rows[2].ToString(),
                                    email = rows[3].ToString(),
                                    phone =rows[4].ToString(),
                                    gender = rows[5].ToString(),
                                    bhirtdate = Convert.ToDateTime(rows[6].ToString()),
                                    bhirtplace = rows[7].ToString(),
                                    address = rows[8].ToString(),
                                    status = rows[9].ToString(),
                                    apply = Convert.ToDateTime(rows[10].ToString()),

                                };
                                _appdbcontext.applicants.Add(emp);
                            }
                            _appdbcontext.SaveChanges();
                        }
                        return Redirect("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
