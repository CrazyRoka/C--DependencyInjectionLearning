using System;
using System.Collections.Generic;
using System.Text;

namespace NoDI
{
    public class GreetingService
    {
        public string Great(string name) => $"Hello, {name}";
    }
}
