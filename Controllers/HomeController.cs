using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Job_Vacation.Models;
using Job_Vacation.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.IO;
using MimeKit;

namespace Job_Vacation.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _appdbcontext;
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext, IConfiguration configuration)
        {
            Configuration = configuration;
            _appdbcontext = appDbContext;
            _logger = logger;
        }

        public IActionResult Register(string category)
        {
            if (category == "user")
            {
                return RedirectToAction("AddUser");
            }
            else
            {
                return RedirectToAction("AddCompany");
            }
        }

        public IActionResult AddUser()
        {
            return View();
        }

        public IActionResult AddCompany()
        {
            return View();
        }

        public IActionResult AddedUser(string name, DateTime birhtdate, string phone, string address, IFormFile cv, IFormFile photo, string username, string password, string email)
        {
            if (photo != null && cv != null)
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
            Seeker seeker = new Seeker
            {
                name = name,
                birthdate = birhtdate,
                phone = phone,
                address = address,
                cv = file1,
                photo = file,
                username = username+"u",
                password = password,
                email = email,
                status = "unverified"
            };
            _appdbcontext.seekers.Add(seeker);
            _appdbcontext.SaveChanges();
            var x = from i in _appdbcontext.seekers where (i.name == name && i.birthdate == birhtdate && i.email == email) select i;
            foreach (var i in x)
            {
            var message = new MimeMessage();
                message.To.Add(new MailboxAddress(name, email));
                message.From.Add(new MailboxAddress("JobSeeker","job@seeker.com"));
                message.Subject = "Thank You for Register your Account";
                message.Body = new TextPart("plain")
                {
                    Text = "Please Confirm your Account by Click This Link " + "https://localhost:5001/Home/ConfirmationUser/"+i.id
                };
                using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
                {
                    emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    emailClient.Connect("smtp.mailtrap.io", 587, false);
                    emailClient.Authenticate("e9bc7468600966", "089a1123f99e29");
                    emailClient.Send(message);
                    emailClient.Disconnect(true);
                }
            }
            return RedirectToAction("Verification");
            }
            else
            {
            return RedirectToAction("Internal");
            }
            
        }

        public IActionResult EditUser()
        {
            var token = HttpContext.Session.GetString("JWTToken");
            var jwtSec  = new JwtSecurityTokenHandler();
            var securityToken = jwtSec.ReadToken(token) as JwtSecurityToken;
            var sub = securityToken?.Claims.First(Claim => Claim.Type == "sub").Value;
            sub = sub.Remove(sub.Length - 1);
            var x = from i in _appdbcontext.seekers where i.username == sub select i;
            ViewBag.seekers = x;
            return View();
        }

        public IActionResult EditorUser(Guid id, string name, DateTime birhtdate, string phone, string address, IFormFile cv, IFormFile photo, string username, string password, string email)
        {
            if (photo != null && cv != null)
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
            var x = _appdbcontext.seekers.Find(id);
                x.name = name;
                x.birthdate = birhtdate;
                x.phone = phone;
                x.address = address;
                x.cv = file1;
                x.photo = file;
                x.username = username+"u";
                x.password = password;
                x.email = email;
            _appdbcontext.SaveChanges();
            return RedirectToAction("InformationUser/x.id");
            }

            else if (photo == null && cv != null)
            {
            var path1 = "wwwroot//cv";
            Directory.CreateDirectory(path1);
            var FileName1 = Path.Combine(path1, Path.GetFileName(cv.FileName));
            cv.CopyTo(new FileStream(FileName1, FileMode.Create));
            var file1 = FileName1.Substring(8).Replace(@"\","/");
            var x = _appdbcontext.seekers.Find(id);
                x.name = name;
                x.birthdate = birhtdate;
                x.phone = phone;
                x.address = address;
                x.cv = file1;
                x.username = username+"u";
                x.password = password;
                x.email = email;
            _appdbcontext.SaveChanges();
            return RedirectToAction("InformationUser/x.id");
            }

            else if (photo != null && cv == null)
            {
            var path = "wwwroot//images";
            Directory.CreateDirectory(path);
            var FileName= Path.Combine(path, Path.GetFileName(photo.FileName));
            photo.CopyTo(new FileStream(FileName, FileMode.Create));
            var file = FileName.Substring(8).Replace(@"\","/");
            var x = _appdbcontext.seekers.Find(id);
                x.name = name;
                x.birthdate = birhtdate;
                x.phone = phone;
                x.address = address;
                x.photo = file;
                x.username = username+"u";
                x.password = password;
                x.email = email;
            _appdbcontext.SaveChanges();
            return RedirectToAction("InformationUser/x.id");
            }
            else
            {
            var x = _appdbcontext.seekers.Find(id);
                x.name = name;
                x.birthdate = birhtdate;
                x.phone = phone;
                x.address = address;
                x.username = username+"u";
                x.password = password;
                x.email = email;
            _appdbcontext.SaveChanges();
            return RedirectToAction("InformationUser/x.id");
            }
        }

        public IActionResult AddedCompany(string name, string phone, string address, IFormFile logo, string username, string password, string email)
        {
            if (logo != null)
            {
            var path = "wwwroot//images";
            Directory.CreateDirectory(path);
            var FileName= Path.Combine(path, Path.GetFileName(logo.FileName));
            logo.CopyTo(new FileStream(FileName, FileMode.Create));
            var file = FileName.Substring(8).Replace(@"\","/");
            Company company = new Company
            {
                name = name,
                phone = phone,
                address = address,
                logo = file,
                username = username+"c",
                password = password,
                email = email,
                status = "unverified"
            };
            _appdbcontext.companies.Add(company);
            _appdbcontext.SaveChanges();
            var x = from i in _appdbcontext.companies where (i.name == name && i.phone == phone && i.email == email) select i;
            foreach (var i in x)
            {
            var message = new MimeMessage();
                message.To.Add(new MailboxAddress(name, email));
                message.From.Add(new MailboxAddress("JobSeeker","job@seeker.com"));
                message.Subject = "Thank You for Register your Account";
                message.Body = new TextPart("plain")
                {
                    Text = "Please Confirm your Account by Click This Link " + "https://localhost:5001/Home/ConfirmationCompany/"+i.id
                };
                using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
                {
                    emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    emailClient.Connect("smtp.mailtrap.io", 587, false);
                    emailClient.Authenticate("e9bc7468600966", "089a1123f99e29");
                    emailClient.Send(message);
                    emailClient.Disconnect(true);
                }
            }
            return RedirectToAction("Verification");
            }
            else
            {
            return RedirectToAction("Internal");
            }
            
        }

        public IActionResult EditCompany()
        {
            var token = HttpContext.Session.GetString("JWTToken");
            var jwtSec  = new JwtSecurityTokenHandler();
            var securityToken = jwtSec.ReadToken(token) as JwtSecurityToken;
            var sub = securityToken?.Claims.First(Claim => Claim.Type == "sub").Value;
            sub = sub.Remove(sub.Length - 1);
            var x = from i in _appdbcontext.seekers where i.username == sub select i;
            ViewBag.companies = x;
            return View();
        }

        public IActionResult EditorCompany(Guid id, string name, string phone, string address, IFormFile logo, string username, string password, string email)
        {
            if (logo != null)
            {
            var path = "wwwroot//images";
            Directory.CreateDirectory(path);
            var FileName= Path.Combine(path, Path.GetFileName(logo.FileName));
            logo.CopyTo(new FileStream(FileName, FileMode.Create));
            var file = FileName.Substring(8).Replace(@"\","/");
            var x = _appdbcontext.companies.Find(id);
                x.name = name;
                x.phone = phone;
                x.address = address;
                x.logo = file;
                x.username = username+"c";
                x.password = password;
                x.email = email;
            _appdbcontext.SaveChanges();
            return RedirectToAction("InformationCompany/x.id");
            }
            else
            {
                var x = _appdbcontext.companies.Find(id);
                x.name = name;
                x.phone = phone;
                x.address = address;
                x.username = username+"c";
                x.password = password;
                x.email = email;
                _appdbcontext.SaveChanges();
                return RedirectToAction("InformationCompany/x.id");
            }
        }

        public IActionResult Verification()
        {
            return View();
        }

        public IActionResult ConfirmationUser(Guid id)
        {
            var x = _appdbcontext.seekers.Find(id);
            x.status = "verified";
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ConfirmationCompany(Guid id)
        {
            var x = _appdbcontext.companies.Find(id);
            x.status = "verified";
            _appdbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DataUser()
        {
            var token = HttpContext.Session.GetString("JWTToken");
            var jwtSec  = new JwtSecurityTokenHandler();
            var securityToken = jwtSec.ReadToken(token) as JwtSecurityToken;
            var sub = securityToken?.Claims.First(Claim => Claim.Type == "sub").Value;
            var x = (from i in _appdbcontext.seekers where (i.username == sub) select i).FirstOrDefault();
            var y = from i in _appdbcontext.takejobs where i.idseeker == x.id select i;
            ViewBag.name = x.name;
            ViewBag.title = y;
            return View();
        }

        public IActionResult DataCompany()
        {
            var token = HttpContext.Session.GetString("JWTToken");
            var jwtSec  = new JwtSecurityTokenHandler();
            var securityToken = jwtSec.ReadToken(token) as JwtSecurityToken;
            var sub = securityToken?.Claims.First(Claim => Claim.Type == "sub").Value;
            sub = sub.Remove(sub.Length - 1);
            var x = (from i in _appdbcontext.companies where i.username == sub select i).FirstOrDefault();
            var y = from i in _appdbcontext.takejobs where i.idjob == x.id select i;
            ViewBag.companies = x;
            return View();
        }

        public IActionResult InformationUser(Guid id)
        {
            var x = _appdbcontext.seekers.Find(id);
            ViewBag.seekers = x;
            return View();
        }

        public IActionResult InformationCompany(Guid id)
        {
            var x = _appdbcontext.companies.Find(id);
            ViewBag.companies = x;
            return View();
        }

        public IActionResult Index(string username ,string password, string category)
        {
            if (category == "user")
            {
            IActionResult response = Unauthorized();
            var user = AuthenticatedUser1(username+"u", password);
                if(user != null)
                {
                    var token = GenerateJwtToken(user);
                    HttpContext.Session.SetString("JWTToken",token);
                    var get = HttpContext.Session.GetString("JWTToken");
                    return RedirectToAction("Jobvacation");
                }
            }

            else if (category == "company")
            {
            IActionResult response = Unauthorized();
            var user = AuthenticatedUser2(username+"c", password);
                if(user != null)
                {
                    var token = GenerateJwtToken(user);
                    HttpContext.Session.SetString("JWTToken",token);
                    var get = HttpContext.Session.GetString("JWTToken");
                    return RedirectToAction("Joblist");
                }
            }
            else if (category == "administrator")
            {
            IActionResult response = Unauthorized();
            var user = AuthenticatedUser3(username+"a", password);
            Console.WriteLine(user);
                if(user != null)
                {
                    var token = GenerateJwtToken(user);
                    HttpContext.Session.SetString("JWTToken",token);
                    var get = HttpContext.Session.GetString("JWTToken");
                    return RedirectToAction("Admin");
                }
            }
            return View();
        }

        private string GenerateJwtToken(User user)
        {
            var secuityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(secuityKey,SecurityAlgorithms.HmacSha256);
            
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,Convert.ToString(user.username)),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer:Configuration["Jwt:Issuer"],
                audience:Configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials:credentials);

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            
            return encodedToken;
        }

        private User AuthenticatedUser1(string username, string password)
        {
            User user = null;
            var x = from i in _appdbcontext.seekers select new {i.name,i.username,i.password,i.status};
            foreach(var i in x)
            {
                if( i.username == username && i.password == password && i.status == "verified")
                {
                    user = new User
                    {
                        username = username,
                        password = password,
                    };
                }
            }
            return user;
        }

        private User AuthenticatedUser2(string username, string password)
        {
            User user = null;
            var x = from i in _appdbcontext.companies select new {i.name,i.username,i.password,i.status};
            foreach(var i in x)
            {
                if( i.username == username && i.password == password && i.status == "verified")
                {
                    user = new User
                    {
                        username = username,
                        password = password,
                    };
                }
            }
            return user;
        }

        private User AuthenticatedUser3(string username, string password)
        {
            User user = null;
            var x = from i in _appdbcontext.administrators select new {i.name,i.username,i.password};
            foreach(var i in x)
            {
                if( i.username == username && i.password == password)
                {
                    user = new User
                    {
                        username = username,
                        password = password,
                    };
                }
            }
            return user;
        }

        public IActionResult Jobvacation()
        {
            var token = HttpContext.Session.GetString("JWTToken");
            if (token != null)
            {
            var jwtSec  = new JwtSecurityTokenHandler();
            var securityToken = jwtSec.ReadToken(token) as JwtSecurityToken;
            var sub = securityToken?.Claims.First(Claim => Claim.Type == "sub").Value;
            sub = sub.Remove(sub.Length - 1);
            ViewBag.sub = sub;
            }
            else
            {
                ViewBag.sub = null;
            }
            var x = from i in _appdbcontext.jobs select i;
            ViewBag.jobs = x;
            return View();
        }

        public IActionResult TakeJob(Guid idjob, Guid idseeker)
        {
            var x = from i in _appdbcontext.takejobs where i.idseeker == idseeker select i;
            foreach (var i in x)
            {
                if (i.idjob == idjob)
                {
                    return RedirectToAction("Fail");
                }
            }
            TakeJob takeJob = new TakeJob
            {
                idjob = idjob,
                idseeker =  idseeker,
                apply = DateTime.Now,
            };
            _appdbcontext.takejobs.Add(takeJob);
            _appdbcontext.SaveChanges();
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Joblist()
        {
            var token = HttpContext.Session.GetString("JWTToken");
            var jwtSec  = new JwtSecurityTokenHandler();
            var securityToken = jwtSec.ReadToken(token) as JwtSecurityToken;
            var sub = securityToken?.Claims.First(Claim => Claim.Type == "sub").Value;
            sub = sub.Remove(sub.Length - 1);
            var x = from i in _appdbcontext.jobs where i.usernamecompany == sub select i;
            ViewBag.Joblist = x;
            return View();
        }

        public IActionResult JobInfo(Guid id)
        {
            var token = HttpContext.Session.GetString("JWTToken");
            var jwtSec  = new JwtSecurityTokenHandler();
            var securityToken = jwtSec.ReadToken(token) as JwtSecurityToken;
            var sub = securityToken?.Claims.First(Claim => Claim.Type == "sub").Value;
            var y = (from i in _appdbcontext.seekers where i.username == sub select i).FirstOrDefault();
            if (sub != null)
            {
            ViewBag.sub = 1;
            }
            else
            {
                ViewBag.sub = y.id;
            }
            var x = _appdbcontext.jobs.Find(id);
            ViewBag.job = x;
            return View();
        }

        public IActionResult AddJob()
        {
            return View();
        }

        public IActionResult AddedJob(string title, string description, string requirement, string informations, IFormFile flyer, DateTime stardate, DateTime enddate)
        {
            if (flyer != null)
            {
            var path = "wwwroot//flyer";
            Directory.CreateDirectory(path);
            var FileName= Path.Combine(path, Path.GetFileName(flyer.FileName));
            flyer.CopyTo(new FileStream(FileName, FileMode.Create));
            var file = FileName.Substring(8).Replace(@"\","/");
            var token = HttpContext.Session.GetString("JWTToken");
            var jwtSec  = new JwtSecurityTokenHandler();
            var securityToken = jwtSec.ReadToken(token) as JwtSecurityToken;
            var sub = securityToken?.Claims.First(Claim => Claim.Type == "sub").Value;
            sub = sub.Remove(sub.Length - 1);
            Job job = new Job
            {
                usernamecompany = sub,
                title = title,
                description = description,
                requirement = requirement,
                informations = informations,
                flyer = file,
                stardate = stardate,
                enddate = enddate
            };
            _appdbcontext.jobs.Add(job);
            _appdbcontext.SaveChanges();
            }
            else
            {
            var token = HttpContext.Session.GetString("JWTToken");
            var jwtSec  = new JwtSecurityTokenHandler();
            var securityToken = jwtSec.ReadToken(token) as JwtSecurityToken;
            var sub = securityToken?.Claims.First(Claim => Claim.Type == "sub").Value;
            sub = sub.Remove(sub.Length - 1);
            Job job = new Job
            {
                usernamecompany = sub,
                title = title,
                description = description,
                requirement = requirement,
                informations = informations,
                stardate = stardate,
                enddate = enddate
            };
            _appdbcontext.jobs.Add(job);
            _appdbcontext.SaveChanges();
            }
            return RedirectToAction("Jobvacation");
        }

        public IActionResult Admin()
        {
            var x = from i in _appdbcontext.companies select i;
            ViewBag.companies = x;
            var y = from i in _appdbcontext.seekers select i;
            ViewBag.seekers = y;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class User
        {
            public string username;
            public string password;
        }
}
