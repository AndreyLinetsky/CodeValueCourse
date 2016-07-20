using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;
using System.Diagnostics;
using System.IO;
namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = string.Concat("Log", System.DateTime.Today.ToString("dd-MM-yy"), ".txt");
            Console.WriteLine(fileName);
            FileStream fileLog = new FileStream(fileName, FileMode.Append);
            Trace.Listeners.Add(new TextWriterTraceListener(fileLog));

            var xml = Assembly.GetAssembly(typeof(string)).GetExportedTypes().Where(t => t.IsClass).Select(t =>
                new XElement("Type", new XAttribute("FullName", t.FullName),
                    new XElement("Properties",
                        t.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                            .Select(
                                p =>
                                    new XElement("Property", new XAttribute("Name", p.Name),
                                        new XAttribute("Type", p.PropertyType)))),
                    new XElement("Methods",
                        t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                            .Select(
                                m =>
                                    new XElement("Method", new XAttribute("Name", m.Name),
                                        new XAttribute("ReturnType", m.ReturnType),
                                        new XElement("Parameters",
                                        m.GetParameters()
                                            .Select(
                                                par =>
                                                   new XElement("Parameter", new XAttribute("Name", par.Name),
                                                            new XAttribute("Type", par.ParameterType)))))))));
            var xmltypes = new XElement("XML", xml);
            Trace.WriteLine(xmltypes);
            Trace.Flush();
            fileLog.Close();
            Trace.Listeners.Clear();
            fileName = string.Concat("xlog", System.DateTime.Today.ToString("dd-MM-yy"), ".txt");
            Console.WriteLine(fileName);
            fileLog = new FileStream(fileName, FileMode.Append);
            Trace.Listeners.Add(new TextWriterTraceListener(fileLog));
            Trace.WriteLine("");
            Trace.WriteLine("3.a");
            var firstResult =
                xml.Where(t => t.Element("Properties").Descendants().Count() == 0)
                    .OrderBy(t => (string)t.Attribute("FullName"))
                    .Select(t => (string)t.Attribute("FullName"));

            foreach (var xmlType in firstResult)
            {
                Trace.WriteLine($"Name: {xmlType}");
            }
            var count = firstResult.Count();
            Trace.WriteLine($"Total types without props - {count}");

            Trace.WriteLine("");
            Trace.WriteLine("3.b");
            var secondResult =
                xml.Select(t => t.Descendants("Method").Count()).Sum();
            Trace.WriteLine($"Total methods - {secondResult}");
            Trace.WriteLine("");
            Trace.WriteLine("3.c");
            var thirdCount =
                xml.Select(t => t.Descendants("Property").Count()).Sum();
            Trace.WriteLine($"Total properties - {thirdCount}");

            Trace.Flush();
            fileLog.Close();
        }
    }
}
