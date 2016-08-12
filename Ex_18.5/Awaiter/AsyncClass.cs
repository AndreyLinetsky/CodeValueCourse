using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awaiter
{
    public class AsyncClass
    {
        public async Task TestAwaiter()
        {
            Console.WriteLine("Awaiting 5 sec");
            await 5000;
            Console.WriteLine("Awaiting notepad");
            await Process.Start("Notepad");
        }
    }
}
