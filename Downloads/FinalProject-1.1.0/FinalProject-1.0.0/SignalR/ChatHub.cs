using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using HR_App.Data;
using System.Linq;
using HR_App.Models;

namespace SignalR.SignalR
{

    public class Chathub: Hub
    {
        public AppDbContext _appdbContext;

        public Chathub (AppDbContext appDbContext)
        {
            _appdbContext = appDbContext;
        }
        public async Task Send(int counter)
        {
            Console.WriteLine(counter);
            var count = counter;
        }

    }
}