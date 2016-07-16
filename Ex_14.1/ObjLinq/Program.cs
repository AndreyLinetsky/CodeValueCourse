using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel;

namespace ObjLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Interface info");
            var firstResult = Assembly.GetAssembly(typeof(string)).GetExportedTypes().Where(t => t.IsInterface).OrderBy(t => t.Name).Select(t => new
            {
                Name = t.Name,
                MethodCount = t.GetMethods().Length
            });
            foreach (var interType in firstResult)
            {
                Console.WriteLine(interType);
            }
            Console.WriteLine();
            Console.WriteLine("Process info");
            var secondResult = Process.GetProcesses().Where(t => t.Threads.Count < 5 && t.).OrderBy(t => t.Id).Select(t => new
            {
                Name = t.ProcessName,
                ID = t.Id,
                StartTime = t.StartTime
            });
            try
            {
                foreach (var proc in secondResult)
                {
                    Console.WriteLine(proc);
                }
            }
            catch (Win32Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

