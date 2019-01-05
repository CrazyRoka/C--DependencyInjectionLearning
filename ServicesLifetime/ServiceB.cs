using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLifetime
{
    class ServiceB : IServiceB, IDisposable
    {
        private int _n;
        public ServiceB(INumberService numberService)
        {
            _n = numberService.GetNumber();
            Console.WriteLine($"ctor {nameof(ServiceB)}, {_n}");
        }
        public void B() => Console.WriteLine($"{nameof(ServiceB)}, {_n}");

        public void Dispose() => Console.WriteLine($"disposing {nameof(ServiceB)}, {_n}");
    }
}
