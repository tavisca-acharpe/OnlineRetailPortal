﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ERPBackend.Contracts.Contracts;
using ERPBackend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StructureMap;

namespace ERPBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public IServiceProvider ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc();

        //    HttpConfiguration config = GlobalConfiguration.Configuration;

        //    var container = new StructureMap.Container();
        //    container.Configure(c =>
        //    {
        //        c.Populate(services);
        //        c.AddRegistry<Registration>();
        //    });

        //    return container.GetInstance<IServiceProvider>();
        //}

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MockProductDatabase>(
             Configuration.GetSection(nameof(MockProductDatabase)));



            services.AddSingleton<IProductService>(sp =>
               sp.GetRequiredService<IOptions<ProductService>>().Value);
            services.AddSingleton<IProductProvider>(sp =>
                sp.GetRequiredService<IOptions<MockProductDatabase>>().Value);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
