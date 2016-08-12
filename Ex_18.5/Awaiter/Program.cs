using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Awaiter
{
    public class Program
    {
        static void Main(string[] args)
        {
            AsyncClass async = new AsyncClass();
            async.TestAwaiter().Wait();
        }
    }
}
