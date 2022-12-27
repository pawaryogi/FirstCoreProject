using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IEmployeeInterface, MockEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions dv = new DeveloperExceptionPageOptions()
                {
                    SourceCodeLineCount = 1
                };

                app.UseDeveloperExceptionPage(dv);
            }
            else if(env.IsStaging() || env.IsProduction() || env.IsEnvironment("UAT"))
            {
                app.UseExceptionHandler("/Error");
            }

            //DefaultFilesOptions defaultFilesop = new DefaultFilesOptions();
            //defaultFilesop.DefaultFileNames.Clear();
            //defaultFilesop.DefaultFileNames.Add("fooody.html");

            //app.UseDefaultFiles(defaultFilesop);
            //app.UseStaticFiles();

            FileServerOptions fileserver = new FileServerOptions();
            fileserver.DefaultFilesOptions.DefaultFileNames.Clear();
            fileserver.DefaultFilesOptions.DefaultFileNames.Add("fooody1.html");
            app.UseFileServer(fileserver);
            
            
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                //await context.Response.WriteAsync("Hello World!");
                //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                ///throw new Exception("Server error while processing the request");
                //await context.Response.WriteAsync(_config["MyKey"]);

                await context.Response.WriteAsync("Hosting Environment : " + env.EnvironmentName);
            });

           
        }
    }
}
