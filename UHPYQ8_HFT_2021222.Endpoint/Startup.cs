using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UHPYQ8_HFT_2021222.Logic.Classes;
using UHPYQ8_HFT_2021222.Models;
using UHPYQ8_HFT_2021222.Repository;
using UHPYQ8_HFT_2021222.Repository.Interface;
using UHPYQ8_HFT_2021222.Repository.ModelRepositories;

namespace UHPYQ8_HFT_2021222.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<GameDbContext>();

            services.AddTransient<IRepository<Game>, GameRepository>();
            services.AddTransient<IRepository<Game_publisher>, Game_publisherRepository>();
            services.AddTransient<IRepository<Platform>, PlatformRepository>();
            services.AddTransient<IRepository<Publisher>, PublisherRepository>();

            services.AddTransient<IGameLogic, GameLogic>();
            services.AddTransient<IGame_publisherLogic, Game_publisherLogic>();
            services.AddTransient<IPlatformLogic, PlatformLogic>();
            services.AddTransient<IPublisherLogic, PublisherLogic>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Feleves.Endpoint2", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Feleves.Endpoint2 v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
