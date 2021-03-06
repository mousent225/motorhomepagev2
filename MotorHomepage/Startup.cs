﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using MotorHomepage.Data.EF;
using MotorHomepage.Data.Entities;
using MotorHomepage.Data.IRepositories;
using MotorHomepage.Data.EF.Repositories;
using MotorHomepage.Application.Interfaces;
using MotorHomepage.Application.Implementation;
using MotorHomepage.Application.AutoMapper;
using MotorHomepage.Services;
using MotorHomepage.Infrastructure.Interfaces;
using MotorHomepage.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MotorHomepage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("MotorHomepage.Data.EF")));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // User settings
                options.User.RequireUniqueEmail = true;
            });
            //services.AddAutoMapper();

            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddTransient<DbInitializer>();
            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimPrincipalFactory>();
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));

            services.AddTransient<IBannerRepository, BannerRepository>();
            services.AddTransient<IBannerService, BannerService>();

            services.AddTransient<ISysMenuRepository, SysMenuRepository>();
            services.AddTransient<ISysMenuService, SysMenuService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/Dotnetcore-{Date}.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "arearoute",
                    template: "{area:exists}/{controller=Login}/{action=Index}/{id?}");
            });

        }
    }
}
