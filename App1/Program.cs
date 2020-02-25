using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace App1
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host =  CreateHostBuilder(args).Build();
           using(var scope= host.Services.CreateScope()){
                var sp = scope.ServiceProvider;
                var context = sp.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();
                if(context.People.Any() == false) 
                {
                    context.People.Add(new Person {
                        Name = "John Doe"
                    });
                    context.SaveChanges();
                }
           }
           host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
