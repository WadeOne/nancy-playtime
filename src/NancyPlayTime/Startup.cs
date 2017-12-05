using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Nancy.Owin;
using NancyPlayTime.Middlewares;

namespace NancyPlayTime
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<CorrelationIdMiddleware>();
            app.UseOwin(buildFunc =>
            {
//                buildFunc(next => ctx =>
//                {
//                    Console.WriteLine("got requets");
//                    return next(ctx);
//                });
                buildFunc.UseNancy();
            });
        }
    }
}
