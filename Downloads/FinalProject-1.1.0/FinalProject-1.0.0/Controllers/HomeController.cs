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
using Microsoft.IdentityModel.Tokens;
using System.Text.Encodings;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace HR_App.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _appdbcontext;
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration;
        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
            _appdbcontext = appDbContext;
        }

        public IActionResult Index(string Email ,int Password )
        {
            var y = (from i in _appdbcontext.leaves where i.status == "submitted" select i).Count();
            ViewBag.count = y;
            IActionResult response = Unauthorized();
            Console.WriteLine(Email);
            Console.WriteLine(Password);
            var user = AuthenticatedUser(Email,Password);
            if(user != null)
            {
                var token = GenerateJwtToken(user);
                HttpContext.Session.SetString("JWTToken",token);
                var get = HttpContext.Session.GetString("JWTToken");
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        private string GenerateJwtToken(User user)
        {
            var secuityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(secuityKey,SecurityAlgorithms.HmacSha256);
            
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,Convert.ToString(user.email)),
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

        private User AuthenticatedUser(string Email,int Password)
        {
            User user = null;
            var x = from i in _appdbcontext.users select new {i.nama,i.email,i.password};
            foreach(var i in x)
            {
                if(i.email == Email && (i.password == Password))
                {
                    user = new User
                    {
                        email = Email,
                        password = Password,
                    };
                }
            }
            return user;
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            var s = (from i in _appdbcontext.leaves where i.status == "submitted" select i).Count();
            ViewBag.count = s;
            var x = from i in _appdbcontext.leaves select i;
            ViewBag.outemp = x;
            var y = (from i in _appdbcontext.leaves where (DateTime.Now >= i.outtime  && i.status == "Approve" && DateTime.Now < i.intime) select i).Count();
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
            ViewBag.abs = List.Count();
            var o = from i in _appdbcontext.reminders where (i.events.Day >= DateTime.Now.Day) select i;
            var p = o.Take(5);
            ViewBag.reminders = p;
            var q = from i in _appdbcontext.applicants select i;
            var r = q.Take(5);
            ViewBag.apply = r;
            return View();
        }

        [Authorize]
        public IActionResult Reminder()
        {
            var x = from i in _appdbcontext.reminders select i;
            ViewBag.reminder = x;
            return View();
        }

        [Authorize]
        public IActionResult Data()
        {
            return View();
        }

        [Authorize]
        public IActionResult Add(string name, DateTime events)
        {
            Reminder reminder = new Reminder()
            {
                name = name,
                events = events,
            };
            _appdbcontext.reminders.Add(reminder);
            _appdbcontext.SaveChanges();
            return RedirectToAction("Reminder");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var x = (from i in _appdbcontext.reminders where (i.id == id) select i).FirstOrDefault();
            ViewBag.reminder = x;
            return View();
        }

        [Authorize]
        public IActionResult Editor(int id, string name, DateTime events)
        {
            var x = _appdbcontext.reminders.Find(id);
            x.name = name;
            x.events = events;
            _appdbcontext.SaveChanges();
            return RedirectToAction("Reminder");
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var x = _appdbcontext.reminders.Find(id);
            _appdbcontext.reminders.Remove(x);
            _appdbcontext.SaveChanges();
            return RedirectToAction("Reminder");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
