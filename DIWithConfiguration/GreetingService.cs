using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIWithConfiguration
{
    public class GreetingService : IGreetingService
    {
        private readonly string _from;
        public GreetingService(IOptions<GreetingServiceOptions> options) => _from = options.Value.From;

        public string Great(string name) => $"Hello, {name}! Greeting from {_from}";
    }
}
