using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Configuration;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

namespace ConsoleApp
{
    class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<DirectoryController>();
            services.AddTransient<DirectoryService>();
            services.AddTransient<DirectoryRepository>();
        }

        //Autofac
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<DirectoryService>().InstancePerLifetimeScope();
        }



    }
}
