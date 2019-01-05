using Microsoft.Extensions.DependencyInjection;
using System;

namespace WithDIContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            using(ServiceProvider provider = RegisterServices())
            {
                var controller = provider.GetRequiredService<HomeController>();
                string result = controller.Hello("Roka");
                Console.WriteLine(result);
            }
        }

        static ServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IGreetingService, GreetingService>();
            services.AddTransient<HomeController>();
            return services.BuildServiceProvider();
        }
    }
}
