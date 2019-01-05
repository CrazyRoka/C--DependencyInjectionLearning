using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLifetime
{
    class ServiceA : IServiceA, IDisposable
    {
        private int _n;
        public ServiceA(INumberService numberService)
        {
            _n = numberService.GetNumber();
            Console.WriteLine($"ctor {nameof(ServiceA)}, {_n}");
        }
        public void A() => Console.WriteLine($"{nameof(ServiceA)}, {_n}");

        public void Dispose() => Console.WriteLine($"disposing {nameof(ServiceA)}, {_n}");
    }
}
