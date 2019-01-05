using System;
using System.Collections.Generic;
using System.Text;

namespace WithDIContainer
{
    public class GreetingService : IGreetingService
    {
        public string Great(string name) => $"Hello, {name}";
    }
}
