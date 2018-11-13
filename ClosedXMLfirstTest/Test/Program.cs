using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (ulong i = 0; i < 999999999; i++)
            {
                string.IsNullOrEmpty("");
            }
            Console.WriteLine(watch.Elapsed);
            Console.Read();
        }
    }
}
