using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLifetime
{
    class ServiceC : IServiceC, IDisposable
    {
        private int _n;
        public ServiceC(INumberService numberService)
        {
            _n = numberService.GetNumber();
            Console.WriteLine($"ctor {nameof(ServiceC)}, {_n}");
        }
        public void C() => Console.WriteLine($"{nameof(ServiceC)}, {_n}");

        public void Dispose() => Console.WriteLine($"disposing {nameof(ServiceC)}, {_n}");
    }
}
