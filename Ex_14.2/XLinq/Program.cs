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
            string fileName = string.Concat("Log_XML", System.DateTime.Today.ToString("dd-MM-yy"), ".txt");
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
                            .Where(m => !m.IsSpecialName)
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
            var printXml = new XElement("XML", xml);
            Trace.WriteLine(printXml);
            Trace.Flush();
            fileLog.Close();
            Trace.Listeners.Clear();
            fileName = string.Concat("log_Query", System.DateTime.Today.ToString("dd-MM-yy"), ".txt");
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
            var thirdResult = xml.Descendants("Parameter").GroupBy(t => (string)t.Attribute("Type")).Select(g => new
            {
                parmType = g.Key,
                parmCount = g.Count()
            }).OrderByDescending(parm => parm.parmCount).First();
            Trace.WriteLine(thirdResult);
            Trace.WriteLine("");
            Trace.WriteLine("3.d");
            var fourthResult =
                xml.OrderByDescending(t => t.Descendants("Method").Count()).Select(t => new
                {
                    Name = (string)t.Attribute("FullName"),
                    MethodCount = t.Descendants("Method").Count(),
                    PropCount = t.Descendants("Property").Count()
                });
            var newXml =
                fourthResult.Select(
                    t =>
                        new XElement("Type", new XAttribute("FullName", t.Name),
                            new XAttribute("MethodCount", t.MethodCount),
                            new XAttribute("PropertiesCount", t.PropCount)));
            var newXmlShow = new XElement("NewXML", newXml);
            Trace.WriteLine(newXmlShow);
            Trace.WriteLine("");
            Trace.WriteLine("3.e");
            var fifthResult =
                xml.OrderBy(t => (string)t.Attribute("FullName"))
                    .GroupBy(t => new
                    {
                        Name = (string)t.Attribute("FullName"),
                        MethodCount = t.Descendants("Method").Count()
                    })
                    .OrderByDescending(g => g.Key.MethodCount).Select(g => new
                    {
                        Name = g.Key.Name,
                        MethodCount = g.Key.MethodCount
                    });
            foreach (var xmlType in fifthResult)
            {
                Trace.WriteLine(xmlType);
            }
            Trace.Flush();
            fileLog.Close();
        }
    }
}
