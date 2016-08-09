using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ProjectBuilder
{
    public class Project
    {
        public Project(int id)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Finished bulding project {id}");
        }
    }
}
