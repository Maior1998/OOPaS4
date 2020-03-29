using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            ChocolateBoiler test = ChocolateBoiler.GetBoiler();
            test.Fill();
            Task.Run(()=>test.Boil());
            Thread.Sleep(2000);
            test.Boil();
            Console.WriteLine();
        }
    }
}
