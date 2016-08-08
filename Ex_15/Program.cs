using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Jobs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part A
            using (Job currJob = new Job())
            {
                for (int i = 0; i < 3; i++)
                {
                    Process currNote = Process.Start("Notepad");
                    currJob.AddProcessToJob(currNote);
                }
                Console.WriteLine("Press enter to kill all the processes");
                Console.ReadLine();
                currJob.Kill();
            }
            // Part B
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    using (Job currJob = new Job($"Job number {i}", i * 100000))
                    {
                        //Process currNote = Process.Start("Notepad");
                        //currJob.AddProcessToJob(currNote);
                        Console.WriteLine(i);
                        currJob.Kill();
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
