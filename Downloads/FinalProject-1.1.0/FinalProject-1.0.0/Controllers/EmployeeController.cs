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
using System.Net;
using System.Net.Mail;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit;
using Microsoft.AspNetCore.Authorization;

namespace HR_App.Controllers
{
    public class EmployeeController : Controller
    {
        private AppDbContext _appdbcontext;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appdbcontext = appDbContext;
        }
        
        [Authorize]
        public IActionResult Index(string search, int _crntpage=1)
        {
            var j = (from i in _appdbcontext.pagings select i).FirstOrDefault();
            ViewBag.search = search;
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
                    var x = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="Probation") select i;
                    var k = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="Contract") select i;
                    var l = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="Permanent") select i;
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
                    var x = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.status == "Probation") select i;
                    var k = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.status == "Contract") select i;
                    var l = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.status == "Permanent") select i;
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
                    var x = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="Probation") select i;
                    var k = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="Contract") select i;
                    var l = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="Permanent") select i;
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
                    var x = (from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.status == "Probation") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    var k = (from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.status == "Permanent") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    var l = (from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.status == "Contract") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    foreach (var i in x)
                    {
                        Console.WriteLine(i.name);
                    }
                    foreach (var i in k)
                    {
                        Console.WriteLine(i.name);
                    }
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
                    var x = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="Probation") select i;
                    var k = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="Contract") select i;
                    var l = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="Permanent") select i;
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
                    var x = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.status == "Probation") select i;
                    var k = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.status == "Contract") select i;
                    var l = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.status == "Permanent") select i;
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
                    var x = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="Probation") select i;
                    var k = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="Contract") select i;
                    var l = from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search) && i.status=="Permanent") select i;
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
                    var x = (from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.status == "Probation") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    var k = (from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.status == "Permanent") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    var l = (from i in _appdbcontext.employees.OrderBy(a => a.name) where (i.status == "Contract") select i).Skip(take*(z.CurrentPage-1)).Take(take);
                    foreach (var i in x)
                    {
                        Console.WriteLine(i.name);
                    }
                    foreach (var i in k)
                    {
                        Console.WriteLine(i.name);
                    }
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
        public IActionResult Data()
        {
            return View();
        }

        [Authorize]
        public IActionResult AddNew(string name, string email, IFormFile cv, IFormFile photo, string phone, string gender, DateTime date, string place, string position, string department, string address, string nameugd1, string nameugd2, string nameugd3, string emergency1, string emergency2, string emergency3, string status, DateTime contract)
        {
                var path1 = "wwwroot//cv";
                Directory.CreateDirectory(path1);
                var FileName1 = Path.Combine(path1, Path.GetFileName(cv.FileName));
                cv.CopyTo(new FileStream(FileName1, FileMode.Create));
                var file1 = FileName1.Substring(8).Replace(@"\","/");
                var path = "wwwroot//images";
                Directory.CreateDirectory(path);
                var FileName= Path.Combine(path, Path.GetFileName(photo.FileName));
                photo.CopyTo(new FileStream(FileName, FileMode.Create));
                var file = FileName.Substring(8).Replace(@"\","/");
                Employee data = new Employee()
                {
                    cv = file1,
                    photo = file,
                    name = name,
                    email = email,
                    phone = phone,
                    gender = gender,
                    bhirtdate = date,
                    bhirtplace = place,
                    position = position,
                    department = department,
                    address = address,
                    nameugd1 = nameugd1,
                    nameugd2 = nameugd2,
                    nameugd3 = nameugd3,
                    emergency1 = emergency1,
                    emergency2 = emergency2,
                    emergency3 = emergency3,
                    status = status,
                    contract = contract
                };
                _appdbcontext.employees.Add(data);
                _appdbcontext.SaveChanges();
                return RedirectToAction("Data");
        }

        [Authorize]
        public IActionResult Add(string name, string email, IFormFile cv, IFormFile photo, string phone, string gender, DateTime date, string place, string position, string department, string address, string nameugd1, string nameugd2, string nameugd3, string emergency1, string emergency2, string emergency3, string status, DateTime contract)
        {
                var path1 = "wwwroot//cv";
                Directory.CreateDirectory(path1);
                var FileName1 = Path.Combine(path1, Path.GetFileName(cv.FileName));
                cv.CopyTo(new FileStream(FileName1, FileMode.Create));
                var file1 = FileName1.Substring(8).Replace(@"\","/");
                var path = "wwwroot//images";
                Directory.CreateDirectory(path);
                var FileName= Path.Combine(path, Path.GetFileName(photo.FileName));
                photo.CopyTo(new FileStream(FileName, FileMode.Create));
                var file = FileName.Substring(8).Replace(@"\","/");
                Employee data = new Employee()
                {
                    cv = file1,
                    photo = file,
                    name = name,
                    email = email,
                    phone = phone,
                    gender = gender,
                    bhirtdate = date,
                    bhirtplace = place,
                    position = position,
                    department = department,
                    address = address,
                    nameugd1 = nameugd1,
                    nameugd2 = nameugd2,
                    nameugd3 = nameugd3,
                    emergency1 = emergency1,
                    emergency2 = emergency2,
                    emergency3 = emergency3,
                    status = status,
                    contract = contract
                };
                _appdbcontext.employees.Add(data);
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
                "position",
                "department",
                "address",
                "nameugd1",
                "emergency1",
                "nameugd2",
                "emergency2",
                "nameugd3",
                "emergency3",
                "status",
                "contract"
            };
            var employees = (from i in _appdbcontext.employees select new object[]
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
                i.position,
                i.department,
                i.address,
                i.nameugd1,
                i.emergency1,
                i.nameugd2,
                i.emergency2,
                i.nameugd3,
                i.emergency3,
                i.status,
                i.contract
            }).ToList();
            var emp = new StringBuilder();
            employees.ForEach(line =>
            {
                emp.AppendLine(string.Join(",", line));
            });
            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", colom)}\r\n{emp.ToString()}");
            return File(buffer, "text/csv", $"Employees Info.csv");
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
                                Employee emp = new Employee()
                                {

                                    name = rows[0].ToString(),
                                    cv = rows[1].ToString(),
                                    photo = rows[2].ToString(),
                                    email = rows[3].ToString(),
                                    phone =rows[4].ToString(),
                                    gender = rows[5].ToString(),
                                    bhirtdate = Convert.ToDateTime(rows[6].ToString()),
                                    bhirtplace = rows[7].ToString(),
                                    position = rows[8].ToString(),
                                    department = rows[9].ToString(),
                                    address = rows[10].ToString(),
                                    nameugd1 = rows[11].ToString(),
                                    emergency1 = rows[12].ToString(),
                                    nameugd2 = rows[13].ToString(),
                                    emergency2 = rows[14].ToString(),
                                    nameugd3 = rows[15].ToString(),
                                    emergency3 = rows[16].ToString(),
                                    status = rows[17].ToString(),
                                    contract = Convert.ToDateTime(rows[18].ToString()),

                                };
                                _appdbcontext.employees.Add(emp);
                            }
                            _appdbcontext.SaveChanges();
                        }
                        return Redirect("Index");
        }

        [Authorize]
        public IActionResult Information(Guid id)
        {
            var x = from i in _appdbcontext.employees where i.id == id select i;
            ViewBag.emp = x;
            return View("Information");
        }

        [Authorize]
        public IActionResult Delete(Guid id)
        {
            var x = _appdbcontext.employees.Find(id);
            _appdbcontext.employees.Remove(x);
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Edit(Guid id)
        {
            var x = from i in _appdbcontext.employees where i.id == id select i;
            ViewBag.emp = x;
            return View();
        }

        [Authorize]
        public IActionResult Warning(Guid id)
        {
            var x = _appdbcontext.employees.Find(id);
            var message = new MimeMessage();
                message.To.Add(new MailboxAddress(x.name, x.email));
                message.From.Add(new MailboxAddress("HR","HRAPP@hr.com"));
                message.Subject = "Infromation of Warning System for "+x.name+" (Urgent!)";
                message.Body = new TextPart("plain")
                {
                    Text = @"Good Day, "+x.name+",\n"
                        +"With this email you had a warning for your Activity\n"
                        +"Please you sure to contact your Supervisor for resolve this problem\n"
                        +"Warm Regards,\n"
                        +"HC Divition"
                };
                using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
                {
                    emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    emailClient.Connect("smtp.mailtrap.io", 587, false);
                    emailClient.Authenticate("e9bc7468600966", "089a1123f99e29");
                    emailClient.Send(message);
                    emailClient.Disconnect(true);
                }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Editor(Guid id, string name, string email,IFormFile cv, IFormFile photo, string phone, string gender, DateTime date, string place, string position, string department, string address, string nameugd1, string nameugd2, string nameugd3, string emergency1, string emergency2, string emergency3, string status, DateTime contract)
        {
            Console.WriteLine(id);
            if ( photo != null && cv != null)
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
                var i = _appdbcontext.employees.Find(id);
                    i.name = name;
                    i.email = email;
                    i.cv = file1;
                    i.photo = file;
                    i.phone = phone;
                    i.gender = gender;
                    i.bhirtdate = date;
                    i.bhirtplace = place;
                    i.position = position;
                    i.department = department;
                    i.address = address;
                    i.nameugd1 = nameugd1;
                    i.nameugd2 = nameugd2;
                    i.nameugd3 = nameugd3;
                    i.emergency1 = emergency1;
                    i.emergency2 = emergency2;
                    i.emergency3 = emergency3;
                    i.status = status;
                    i.contract = contract;
                _appdbcontext.SaveChanges();
            }
            else if (photo == null && cv != null)
            {
                var path1 = "wwwroot//cv";
                Directory.CreateDirectory(path1);
                var FileName1= Path.Combine(path1, Path.GetFileName(cv.FileName));
                cv.CopyTo(new FileStream(FileName1, FileMode.Create));
                var file1 = FileName1.Substring(8).Replace(@"\","/");
                var i = _appdbcontext.employees.Find(id);
                    i.name = name;
                    i.cv = file1;
                    i.email = email;
                    i.phone = phone;
                    i.gender = gender;
                    i.bhirtdate = date;
                    i.bhirtplace = place;
                    i.position = position;
                    i.department = department;
                    i.address = address;
                    i.nameugd1 = nameugd1;
                    i.nameugd2 = nameugd2;
                    i.nameugd3 = nameugd3;
                    i.emergency1 = emergency1;
                    i.emergency2 = emergency2;
                    i.emergency3 = emergency3;
                    i.status = status;
                    i.contract = contract;
                    _appdbcontext.SaveChanges();
            }
            else if (photo != null && cv == null)
            {
                var path = "wwwroot//images";
                Directory.CreateDirectory(path);
                var FileName= Path.Combine(path, Path.GetFileName(photo.FileName));
                photo.CopyTo(new FileStream(FileName, FileMode.Create));
                var file = FileName.Substring(8).Replace(@"\","/");
                var i = _appdbcontext.employees.Find(id);
                    i.name = name;
                    i.photo = file;
                    i.email = email;
                    i.phone = phone;
                    i.gender = gender;
                    i.bhirtdate = date;
                    i.bhirtplace = place;
                    i.position = position;
                    i.department = department;
                    i.address = address;
                    i.nameugd1 = nameugd1;
                    i.nameugd2 = nameugd2;
                    i.nameugd3 = nameugd3;
                    i.emergency1 = emergency1;
                    i.emergency2 = emergency2;
                    i.emergency3 = emergency3;
                    i.status = status;
                    i.contract = contract;
                    _appdbcontext.SaveChanges();
            }
            else if (photo == null && cv == null)
            {
                var i = _appdbcontext.employees.Find(id);
                    i.name = name;
                    i.email = email;
                    i.phone = phone;
                    i.gender = gender;
                    i.bhirtdate = date;
                    i.bhirtplace = place;
                    i.position = position;
                    i.department = department;
                    i.address = address;
                    i.nameugd1 = nameugd1;
                    i.nameugd2 = nameugd2;
                    i.nameugd3 = nameugd3;
                    i.emergency1 = emergency1;
                    i.emergency2 = emergency2;
                    i.emergency3 = emergency3;
                    i.status = status;
                    i.contract = contract;
                    _appdbcontext.SaveChanges();
            }
            return RedirectToAction("Index");
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
                "position",
                "department",
                "address",
                "nameugd1",
                "emergency1",
                "nameugd2",
                "emergency2",
                "nameugd3",
                "emergency3",
                "status",
                "contract"
            };
            var employees = (from i in _appdbcontext.employees where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search)) select new object[]
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
                i.position,
                i.department,
                i.address,
                i.nameugd1,
                i.emergency1,
                i.nameugd2,
                i.emergency2,
                i.nameugd3,
                i.emergency3,
                i.status,
                i.contract
            }).ToList();
            var emp = new StringBuilder();
            employees.ForEach(line =>
            {
                emp.AppendLine(string.Join(",", line));
            });
            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", colom)}\r\n{emp.ToString()}");
            return File(buffer, "text/csv", $"Employees Info.csv");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class Warning
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
