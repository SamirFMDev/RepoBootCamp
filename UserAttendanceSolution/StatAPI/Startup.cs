using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StatAPI.Consumers;
using StatAPI.proxies;
using StatAPI.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI;
using UserAPI.Services;

namespace StatAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMassTransit(config =>
            //{
            //    config.AddConsumer<AttendanceConsumer>();
            //    config.UsingRabbitMq((ctx, cfg) =>
            //    {
            //        cfg.Host("amqp://guest:guest@localhost:5672");

            //        cfg.ReceiveEndpoint("attendance-stat-queue", c => {
            //            c.ConfigureConsumer<AttendanceConsumer>(ctx);
            //        });
            //    });
            //});

            services.Configure<ApiUrls>(
                opts => Configuration.GetSection("ApiUrls").Bind(opts)
                );
            services.AddHttpClient<IUserProxy, UserProxy>();
            services.AddHttpClient<IAttendanceProxy, AttendanceProxy>();

            services.AddMassTransit(config =>
            {
                config.AddConsumer<AttendanceConsumer>();
                config.AddConsumer<UserConsumer>();
                config.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(Configuration.GetConnectionString("rabitmq")), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ReceiveEndpoint("attendance-stat-queue", c =>
                    {
                        c.ConfigureConsumer<AttendanceConsumer>(provider);
                    });
                    cfg.ReceiveEndpoint("user-stat-queue", c =>
                    {
                        c.ConfigureConsumer<UserConsumer>(provider);
                    });
                }));
            });
            services.AddMassTransitHostedService();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World from StatAPI!");
                });
            });
        }
    }
}
