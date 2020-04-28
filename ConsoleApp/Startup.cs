using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

namespace ConsoleApp
{
    public class Startup
    {
        //public IConfiguration Configuration { get; }
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public Startup()
        {

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddTransient<UtilityService>();
        //    services.AddTransient<DirectoryRepository>();
        //}

        //Autofac
        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    builder.RegisterType<UtilityService>().InstancePerLifetimeScope();
        //}



    }
}
