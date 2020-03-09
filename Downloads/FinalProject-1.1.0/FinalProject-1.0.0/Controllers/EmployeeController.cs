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
        
        public IActionResult Index(string search, int _crntpage=1)
        {
            var y = (from i in _appdbcontext.leaves where i.status == "submited" select i).Count();
            ViewBag.count = y;
            var z = _appdbcontext.pagings.Find(1);
            z.CurrentPage = _crntpage;
            _appdbcontext.SaveChanges();
            if (z.CurrentPage == 1)
            {
                if (search != null)
                {
                    var take = z.ShowItem;
                    var x = from i in _appdbcontext.employees where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search)) select i;
                    var get = from a in x.Skip(take*(z.CurrentPage - 1)).Take(take) select a;
                    ViewBag.emp = get;
                    ViewBag.page = z;
                    return View();
                }
                else
                {
                    var take = z.ShowItem;
                    var x = from i in _appdbcontext.employees select i;
                    ViewBag.emp = x;
                    var get = from a in x.Skip(take*(z.CurrentPage - 1)).Take(take) select a;
                    ViewBag.emp = get;
                    ViewBag.page = z;
                    return View();
                }
            }
            else
            {
                if (search != null)
                {
                    var take = z.ShowItem;
                    var x = from i in _appdbcontext.employees where (i.name.Contains(search) || i.position.Contains(search) || i.department.Contains(search) || i.status.Contains(search)) select i;
                    var get = from a in x.Skip(take*(z.CurrentPage - 1)).Take(take) select a;
                    ViewBag.emp = get;
                    ViewBag.page = z;
                    return View();
                }
                else
                {
                    var take = z.ShowItem;
                    var x = from i in _appdbcontext.employees select i;
                    ViewBag.emp = x;
                    var get = from a in x.Skip(take*(z.CurrentPage - 1)).Take(take) select a;
                    ViewBag.emp = get;
                    ViewBag.page = z;
                    return View();
                }
            }
        }

        public IActionResult Data()
        {
            return View();
        }

        public IActionResult AddNew(string name, string email, IFormFile photo, string phone, string gender, DateTime date, string place, string position, string department, string address, string nameugd1, string nameugd2, string nameugd3, string emergency1, string emergency2, string emergency3, string status, DateTime contract)
        {
                var path = "wwwroot//images";
                Directory.CreateDirectory(path);
                var FileName= Path.Combine(path, Path.GetFileName(photo.FileName));
                photo.CopyTo(new FileStream(FileName, FileMode.Create));
                var file = FileName.Substring(8).Replace(@"\","/");
                Employee data = new Employee()
                {
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

        public IActionResult Add(string name, string email, IFormFile photo, string phone, string gender, DateTime date, string place, string position, string department, string address, string nameugd1, string nameugd2, string nameugd3, string emergency1, string emergency2, string emergency3, string status, DateTime contract)
        {
                var path = "wwwroot//images";
                Directory.CreateDirectory(path);
                var FileName= Path.Combine(path, Path.GetFileName(photo.FileName));
                photo.CopyTo(new FileStream(FileName, FileMode.Create));
                var file = FileName.Substring(8).Replace(@"\","/");
                Employee data = new Employee()
                {
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

        public IActionResult Export()
        {
            var colom = new string[]
            {
                "id",
                "name",
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
                                    photo = rows[1].ToString(),
                                    email = rows[2].ToString(),
                                    phone =rows[3].ToString(),
                                    gender = rows[4].ToString(),
                                    bhirtdate = Convert.ToDateTime(rows[5].ToString()),
                                    bhirtplace = rows[6].ToString(),
                                    position = rows[7].ToString(),
                                    department = rows[8].ToString(),
                                    address = rows[9].ToString(),
                                    nameugd1 = rows[10].ToString(),
                                    emergency1 = rows[11].ToString(),
                                    nameugd2 = rows[12].ToString(),
                                    emergency2 = rows[13].ToString(),
                                    nameugd3 = rows[14].ToString(),
                                    emergency3 = rows[15].ToString(),
                                    status = rows[16].ToString(),
                                    contract = Convert.ToDateTime(rows[17].ToString()),

                                };
                                _appdbcontext.employees.Add(emp);
                            }
                            _appdbcontext.SaveChanges();
                        }
                        return Redirect("Index");
        }

        public IActionResult Information(Guid id)
        {
            var x = from i in _appdbcontext.employees where i.id == id select i;
            ViewBag.emp = x;
            return View("Information");
        }

        public IActionResult Delete(Guid id)
        {
            var x = _appdbcontext.employees.Find(id);
            _appdbcontext.employees.Remove(x);
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var x = from i in _appdbcontext.employees where i.id == id select i;
            ViewBag.emp = x;
            return View();
        }

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
                    emailClient.Authenticate("c2dd5c9169381f", "8d33632650e24e");
                    emailClient.Send(message);
                    emailClient.Disconnect(true);
                }
            return RedirectToAction("Index");
        }

        public IActionResult Editor(Guid id, string name, string email, IFormFile photo, string phone, string gender, DateTime bhirtdate, string bhirtplace, string position, string department, string address, string nameugd1, string nameugd2, string nameugd3, string emergency1, string emergency2, string emergency3, string status, DateTime contract)
        {
            var path = "wwwroot//images";
            Directory.CreateDirectory(path);
            var FileName= Path.Combine(path, Path.GetFileName(photo.FileName));
            photo.CopyTo(new FileStream(FileName, FileMode.Create));
            var file = FileName.Substring(8).Replace(@"\","/");
            var i = from y in _appdbcontext.employees where y.id == id select y;
            foreach (var x in i)
            {
                x.name = name;
                x.email = email;
                x.photo = file;
                x.phone = phone;
                x.gender = gender;
                x.bhirtdate = bhirtdate;
                x.bhirtplace = bhirtplace;
                x.position = position;
                x.department = department;
                x.address = address;
                x.nameugd1 = nameugd1;
                x.nameugd2 = nameugd2;
                x.nameugd3 = nameugd3;
                x.emergency1 = emergency1;
                x.emergency2 = emergency2;
                x.emergency3 = emergency3;
                x.status = status;
                x.contract = contract;
            }
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ExportId(string search)
        {
            var colom = new string[]
            {
                "id",
                "name",
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
