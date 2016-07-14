using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AttribDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Analayze currAnalayze = new Analayze();
            if (currAnalayze.AnalayzeAssembly(Assembly.GetExecutingAssembly()))
            {
                Console.WriteLine("All the reviews were approved");
            }
            else
            {
                Console.WriteLine("Not all the reviews were approved");
            }
            if (currAnalayze.AnalayzeAssembly(Assembly.GetAssembly(typeof(System.Int32))))
            {
                Console.WriteLine("All the reviews were approved");
            }
            else
            {
                Console.WriteLine("Not all the reviews were approved");
            }
        }
    }
}
