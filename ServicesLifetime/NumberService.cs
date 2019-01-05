using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ServicesLifetime
{
    class NumberService : INumberService
    {
        private int _number = 0;
        public int GetNumber() => Interlocked.Increment(ref _number);
    }
}
