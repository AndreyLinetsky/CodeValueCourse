using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel;
using System.IO;

namespace ObjLinq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string fileName = string.Concat("Log", System.DateTime.Today.ToString("dd-MM-yy"), ".txt");
            Console.WriteLine(fileName);
            FileStream fileLog = new FileStream(fileName, FileMode.Append);
            Trace.Listeners.Add(new TextWriterTraceListener(fileLog));
            Trace.WriteLine(" ");
            Trace.WriteLine("Interface info");
            var firstResult = Assembly.GetAssembly(typeof(string)).GetExportedTypes().Where(t => t.IsInterface).OrderBy(t => t.Name).Select(t => new
            {
                Name = t.Name,
                MethodCount = t.GetMethods().Length
            });
            foreach (var interType in firstResult)
            {
                Trace.WriteLine(interType);
            }
            Trace.WriteLine("");
            Trace.WriteLine("Process info");
            AccessCheck accCheck = new AccessCheck();;
            var secondResult = Process.GetProcesses().Where(p => p.Threads.Count < 5 && accCheck.IsAccessible(p)).OrderBy(p => p.Id).Select(p => new
            {
                Name = p.ProcessName,
                ID = p.Id,
                StartTime = p.StartTime
            });

            foreach (var proc in secondResult)
            {
                Trace.WriteLine(proc);
            }
            Trace.WriteLine("");
            Trace.WriteLine("Grouped process info");
            var thirdResult = Process.GetProcesses()
                .Where(p => p.Threads.Count < 5 && accCheck.IsAccessible(p))
                .OrderBy(p => p.Id)
                .GroupBy(p => new
                {
                    Name = p.ProcessName,
                    ID = p.Id,
                    StartTime = p.StartTime,
                    Priority = p.BasePriority
                }).OrderBy(g => g.Key.Priority).Select(g => new
                {
                    Name = g.Key.Name,
                    ID = g.Key.ID,
                    StartTime = g.Key.StartTime,
                    Priority = g.Key.Priority
                });
            foreach (var group in thirdResult)
            {
                Trace.WriteLine(group);
            }

            Trace.WriteLine("");
            
            var fourthResult = Process.GetProcesses().Select(p => p.Threads.Count).Sum();
            Trace.WriteLine($"Total system threads- {fourthResult}");
            Trace.WriteLine("");
            Trace.WriteLine("CopyTest");
            Car firstCar= new Car(2010,2000,20,"secret",12);
            Car secondCar = new Car(0, 0, 0, "", 0);
            MiniCar thirdCar = new MiniCar(0,0,11);
            firstCar.CopyTo(secondCar);
            Trace.WriteLine($"First car info - year: {firstCar.Year} ,fuel: {firstCar.FuelAmount}, price: {firstCar.Price},id: {firstCar.GetId()},name: {firstCar.GetName()}");
            Trace.WriteLine($"Second car info - year: {secondCar.Year} ,fuel: {secondCar.FuelAmount}, price: {secondCar.Price},id: {secondCar.GetId()},name: {secondCar.GetName()}");
            firstCar.CopyTo(thirdCar);
            Trace.WriteLine($"Mini car info - year: {thirdCar.Year} , price: {thirdCar.Price},fund saving: {thirdCar.FundSaving}");
            Trace.Flush();
            fileLog.Close();
        }
    }
}

