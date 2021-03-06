﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

using AspNetCoreVideo.Services;
using AspNetCoreVideo.Data;

namespace AspNetCoreVideo
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true);

            if (env.IsDevelopment())
                builder.AddUserSecrets<Startup>();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var conn = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<VideoDbContext>(options => options.UseSqlServer(conn));
            services.AddMvc();
            // ex 1 services.AddSingleton<IMessageService, HardCodedMessageService>();
            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IMessageService, ConfigurationMessageService>();
            //services.AddScoped<IVideoData, MockVideoData>();
            //services.AddSingleton<IVideoData, MockVideoData>();
            services.AddScoped<IVideoData, SqlVideoData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMessageService msg)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            ///app.UseStaticFiles(); used for testing serving up a static file

            app.Run(async (context) =>
            {
                // ex 1 await context.Response.WriteAsync("Hello, from my World, yeah!");
                // ex 2 var message = Configuration["Message"];
                // ex 2 await context.Response.WriteAsync(message);
                //throw new Exception("Fake Exception");
                await context.Response.WriteAsync(msg.GetMessage());
            });
        }
    }
}
