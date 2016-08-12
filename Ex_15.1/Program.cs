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
            using (Job currJob = new Job("FirstJob"))
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
        }
    }
}
