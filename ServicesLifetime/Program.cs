using Microsoft.Extensions.DependencyInjection;
using System;

namespace ServicesLifetime
{
    class Program
    {
        static void Main(string[] args)
        {
            SingletonAndTransient();
            //UsingScoped();
            //CustomFactories();
        }

        private static void SingletonAndTransient()
        {
            Console.WriteLine(nameof(SingletonAndTransient));

            ServiceProvider RegisterServices()
            {
                IServiceCollection services = new ServiceCollection();
                services.AddSingleton<INumberService, NumberService>();
                services.AddTransient<ControllerX>();
                services.AddTransient<IServiceB, ServiceB>();
                services.AddSingleton<IServiceA, ServiceA>();
                return services.BuildServiceProvider();
            }

            using(ServiceProvider container = RegisterServices())
            {
                ControllerX x = container.GetRequiredService<ControllerX>();
                x.M();
                x.M();
                Console.WriteLine($"requesting {nameof(ControllerX)}");
                ControllerX x2 = container.GetRequiredService<ControllerX>();
                x2.M();
                Console.WriteLine();
            }
        }

        private static void UsingScoped()
        {
            Console.WriteLine(nameof(UsingScoped));

            ServiceProvider RegisterServices()
            {
                IServiceCollection services = new ServiceCollection();
                services.AddSingleton<INumberService, NumberService>();
                services.AddTransient<ControllerX>();
                services.AddSingleton<IServiceB, ServiceB>();
                services.AddScoped<IServiceA, ServiceA>();
                services.AddTransient<IServiceC, ServiceC>();
                return services.BuildServiceProvider();
            }

            using (ServiceProvider container = RegisterServices())
            {
                using(IServiceScope scope1 = container.CreateScope())
                {
                    IServiceA a1 = scope1.ServiceProvider.GetRequiredService<IServiceA>();
                    a1.A();
                    IServiceA a2 = scope1.ServiceProvider.GetRequiredService<IServiceA>();
                    a2.A();
                    IServiceB b1 = scope1.ServiceProvider.GetRequiredService<IServiceB>();
                    b1.B();
                    IServiceB b2 = scope1.ServiceProvider.GetRequiredService<IServiceB>();
                    b2.B();
                    IServiceC c1 = scope1.ServiceProvider.GetRequiredService<IServiceC>();
                    c1.C();
                    IServiceC c2 = scope1.ServiceProvider.GetRequiredService<IServiceC>();
                    c2.C();
                }

                Console.WriteLine("end of scope 1");

                using (IServiceScope scope2 = container.CreateScope())
                {
                    IServiceA a1 = scope2.ServiceProvider.GetRequiredService<IServiceA>();
                    a1.A();
                    IServiceA a2 = scope2.ServiceProvider.GetRequiredService<IServiceA>();
                    a2.A();
                    IServiceB b1 = scope2.ServiceProvider.GetRequiredService<IServiceB>();
                    b1.B();
                    IServiceB b2 = scope2.ServiceProvider.GetRequiredService<IServiceB>();
                    b2.B();
                    IServiceC c1 = scope2.ServiceProvider.GetRequiredService<IServiceC>();
                    c1.C();
                    IServiceC c2 = scope2.ServiceProvider.GetRequiredService<IServiceC>();
                    c2.C();
                }

                Console.WriteLine("end of scope 2");
            }
        }

        private static void CustomFactories()
        {
            Console.WriteLine(nameof(CustomFactories));

            IServiceB CreateServiceBFactory(IServiceProvider provider) => new ServiceB(provider.GetService<INumberService>());

            ServiceProvider RegisterServices()
            {
                var numberService = new NumberService();

                IServiceCollection services = new ServiceCollection();
                services.AddSingleton<INumberService>(numberService);
                services.AddTransient<IServiceB>(CreateServiceBFactory);
                services.AddSingleton<IServiceA, ServiceA>();
                return services.BuildServiceProvider();
            }

            using(ServiceProvider container = RegisterServices())
            {
                IServiceA a1 = container.GetService<IServiceA>();
                IServiceA a2 = container.GetService<IServiceA>();
                IServiceB b1 = container.GetService<IServiceB>();
                IServiceB b2 = container.GetService<IServiceB>();
            }
        }
    }
}
