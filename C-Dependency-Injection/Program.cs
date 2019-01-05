using System;

namespace NoDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new HomeController();
            string result = controller.Hello("Roka");
            Console.WriteLine(result);
        }
    }
}
