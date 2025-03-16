using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameworkProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace firstWeb
{
    public class Program
    {
        private static Users Userglobal = new Users();
        private static Invoices Invoiceglobal = new Invoices();

        public static Users USERGLOBAL
        {
            get { return Userglobal; }
            set { Userglobal = value; }
        }
        public static Invoices INVOICEGLOBAL
        {
            get { return Invoiceglobal; }
            set { Invoiceglobal = value; }
        }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
