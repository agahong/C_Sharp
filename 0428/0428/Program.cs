using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428
{
    class Program
    {
        static void Main(string[] args)
        {
            ClimateMonitor monitor = new
                ClimateMonitor(new FileLogger("wblog.txt"));
//                ClimateMonitor(new ConsoleLogger("wblog.txt"));

            monitor.start();
        }
    }
}
