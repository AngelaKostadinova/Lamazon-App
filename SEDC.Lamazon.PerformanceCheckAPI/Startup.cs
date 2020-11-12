using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SEDC.Lamazon.Services.Helpers;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Services.Services;

namespace SEDC.Lamazon.PerformanceCheckAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddTransient<IOrderService, OrderService>();
            string connectionString = Configuration.GetValue<string>("LamazonConnectionString");
            DIModule.RegisterModule(services, connectionString);

            //services.AddTransient<IUserService, UserService>();
            services.AddTransient<IOrderService, OrderService>();
            //services.AddTransient<IProductService, ProductService>();
            services.AddAutoMapper();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
