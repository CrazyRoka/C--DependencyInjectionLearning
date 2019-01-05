using System;
using System.Collections.Generic;
using System.Text;

namespace DIWithConfiguration
{
    public class HomeController
    {
        private readonly IGreetingService _greatingService;

        public HomeController(IGreetingService greatingService)
        {
            _greatingService = greatingService ??
                throw new ArgumentNullException(nameof(greatingService));
        }

        public string Hello(string name) => _greatingService.Great(name);
    }
}
