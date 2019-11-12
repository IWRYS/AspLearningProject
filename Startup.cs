using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp.net.LearningProject.Data;
using asp.net.LearningProject.Models;
using asp.net.LearningProject.Models.EmployeesModels;
using asp.net.LearningProject.Models.TownsModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace asp.net.LearningProject
{
    public class Startup
    {
        private readonly IConfiguration config;
        public Startup(IConfiguration config)
        {
            this.config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<MyProjectDBContext>(
                options=> options.UseSqlServer(config.GetConnectionString("MyProjectDBConnection")));
            services.AddMvc();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            services.AddScoped<ITownRepository,SQLTownRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
              //  DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
               //   developerExceptionPageOptions.SourceCodeLineCount = 10; // how many lines of code before and after the error in developer exception page

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            // to serve static files use UseStaticFiles()
            // to serve default files use UseDefaultFiles()
            // UseDefaultFiles() must be registered before UseStaticFiles()
            // UseFilerServer() combines the functionality of UseStaticFiles(),UseDefaultFiles() and UseDirectoryBrowser
            //FileServerOptions fileServerOptions = new FileServerOptions();
            // fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //  fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("home.html");
            // app.UseFileServer(fileServerOptions);

            app.UseFileServer();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
          
           
        }
    }
}
