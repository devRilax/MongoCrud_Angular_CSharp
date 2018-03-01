using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Test;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dll = new Client("orlando", "23");

            Console.WriteLine(dll.GreetinS());

            Console.ReadKey();
        }
    }
}
