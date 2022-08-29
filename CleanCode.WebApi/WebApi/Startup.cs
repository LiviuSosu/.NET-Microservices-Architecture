using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using MicroservicesProjectArchitecture.Application.Articles.Queries.GetArticles;
using MicroservicesProjectArchitecture.Infrastructure;
using MicroservicesProjectArchitecture.Persistance;
using MicroservicesProjectArchitecture.WebApi.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MicroservicesProjectArchitecture.WebApi
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
            //services.AddTransient<IServiceProvider, ServiceProvider>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddMediatR(typeof(GetArticlesListQueryHandler).GetTypeInfo().Assembly);

            // Add DbContext using SQL Server Provider
            services.AddDbContext<MicroservicesPatternDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")
                , x => x.MigrationsAssembly("MicroservicesProjectArchitecture.Migrations")
                ));


            var _configuration = new Configuration();

            //add JWT here

            services.Add(new ServiceDescriptor(typeof(Common.ILogger), typeof(Logger), ServiceLifetime.Singleton));
            services.Add(new ServiceDescriptor(typeof(Common.IConfiguration), typeof(Configuration), ServiceLifetime.Singleton));
            //AddAuthentications(services);

            services.AddControllers();    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
