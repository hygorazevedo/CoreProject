using CoreProject.Core.Interface;
using CoreProject.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace CoreProject.Presentation
{
    class Program
    {
        #region Properties and Constructors
        public static IServiceProvider Services { get; set; }
        public static IConfiguration Configuration { get; set; }
        public static IApplication Application { get; set; } 
        #endregion

        #region Methods
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
            ConfigureServices(Configuration);

            Application = Services.GetService<IApplication>();
        }

        static void ConfigureServices(IConfiguration _configuration)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IApplication, Application>();
            services.AddSingleton<IClienteRepository, ClienteRepository>();
            services.AddDbContext<CoreContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("ConnectionStringDefault")));

            Services = services.BuildServiceProvider();
        }
        #endregion
    }
}