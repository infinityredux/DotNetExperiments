using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NetCoreExperiment.Data;
using Microsoft.Extensions.Logging;

namespace NetCoreExperiment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            if (host.Services.GetService<IHostingEnvironment>().IsDevelopment())
            {
                // For development purposes only, recreate the database each time we run
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        var context = services.GetRequiredService<ApplicationDbContext>();
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(0, ex, "An error occurred while recreating the database.");
                    }
                }
            }

            host.Run();
        }
    }
}
