using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool mutexWasCreated;
            Mutex newMutex = new Mutex(true, "SyncFileMutex", out mutexWasCreated);
            if (!Directory.Exists(@"c:\temp"))
            {
                Directory.CreateDirectory(@"c:\temp");
            }
            Console.WriteLine("Starting writing");
            for (int i = 0; i < 10000; i++)
            {
                if (!mutexWasCreated)
                {
                    newMutex.WaitOne();
                }
                using (StreamWriter streamWriter = new StreamWriter(@"c:\temp\data.txt", true))
                {
                    Console.WriteLine($"Current process is {Process.GetCurrentProcess().Id},Line Number {i}");
                    streamWriter.WriteLine($"Current process is {Process.GetCurrentProcess().Id},Line Number {i}");
                }
                newMutex.ReleaseMutex();
            }
            Console.WriteLine("Finished writing");
        }
    }
}
