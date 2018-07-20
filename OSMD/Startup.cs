using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OSMD.Data;
using OSMD.Models;
using OSMD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Facebook;

namespace OSMD
{
    public class Startup
    {
        //string _testSecret = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //public Startup(IHostingEnvironment env)
        //{
        //    var builder = new ConfigurationBuilder();

        //    if (env.IsDevelopment())
        //    {
        //        builder.AddUserSecrets<Startup>();
        //    }

        //    Configuration = builder.Build();
        //}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           // _testSecret = Configuration["MySecret"];
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(opts => {
                opts.Password.RequiredLength = 5;   // минимальная длина
                opts.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
                opts.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                opts.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                opts.Password.RequireDigit = false; // требуются ли цифры
            })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

             //Add application services;
            //    services.AddIdentity<ApplicationUser, IdentityRole>()
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<OSMD.Data.Migrations.People>();
            services.AddTransient<OSMD.Data.Migrations.Files>();
            services.AddTransient<OSMD.Data.Migrations.News_Table>();
            services.AddTransient<OSMD.Data.Migrations.News>();
            services.AddTransient<OSMD.Models.FileModel>();
            services.AddTransient<OSMD.Models.Person>();
            services.AddTransient<OSMD.Models.News>();
            services.AddTransient<OSMD.Models.PersonViewModel>();
            //services.AddAuthentication().AddFacebook(facebookOptions =>
            //{
            //    facebookOptions.AppId = Configuration["1597162847038158"];
            //    facebookOptions.AppSecret = Configuration["1b41ced56c30b5b43159664578e2586f"];
            //});
            services.AddSignalR();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //var result = string.IsNullOrEmpty(_testSecret) ? "Null" : "Not Null";
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"Secret is {result}");
            //});
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseFileServer();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chat");
            });

        }
    }
}
