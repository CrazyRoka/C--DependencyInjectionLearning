using System;
using System.Collections.Generic;
using System.Text;

namespace WithDI
{
    public class GreetingService : IGreetingService
    {
        public string Great(string name) => $"Hello, {name}";
    }
}
