using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace DIWithConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            DefineConfiguration();
            using (ServiceProvider provider = RegisterServices())
            {
                var controller = provider.GetRequiredService<HomeController>();
                string result = controller.Hello("Roka");
                Console.WriteLine(result);
            }
        }

        static ServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddGreetingService(Configuration.GetSection("GreetingService"));
            services.AddTransient<HomeController>();
            return services.BuildServiceProvider();
        }

        static void DefineConfiguration()
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = configBuilder.Build();
        }

        public static IConfiguration Configuration { get; set; }
    }
}
