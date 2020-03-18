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
    public class BroadcastController : Controller
    {
        private AppDbContext _appdbcontext;
        private readonly ILogger<BroadcastController> _logger;

        public BroadcastController(ILogger<BroadcastController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appdbcontext = appDbContext;
        }
        
        [Authorize]
        public IActionResult Index()
        {
            var x = from i in _appdbcontext.broadcasts.OrderByDescending(a => a.date) select i;
            ViewBag.broad = x;
            var y = (from i in _appdbcontext.leaves where i.status == "submitted" select i).Count();
            ViewBag.count = y;
            return View();
        }

        [Authorize]
        public IActionResult Add(string title, string body)
        {
            Broadcast broad = new Broadcast()
            {
                title = title,
                date = DateTime.Now,
                body = body,
            };
            _appdbcontext.broadcasts.Add(broad);
            _appdbcontext.SaveChanges();
            var message = new MimeMessage();
            var x = from i in _appdbcontext.employees select i;
            foreach (var i in x)
            {
                message.To.Add(new MailboxAddress(i.name, i.email));
                message.From.Add(new MailboxAddress("HR","HRAPP@hr.com"));
                message.Subject = title;
                message.Body = new TextPart("plain")
                {
                    Text = body
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
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
