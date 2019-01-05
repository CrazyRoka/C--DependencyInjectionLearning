using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIWithOptions
{
    class Program
    {
        static void Main(string[] args)
        {
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
            services.AddGreetingService(options =>
            {
                options.From = "Toch";
            });
            services.AddTransient<HomeController>();
            return services.BuildServiceProvider();
        }
    }
}
