using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listString = new List<string>();
            string path = @"C:\Users\Andrey\Source\Repos\CodeValueCourse\Ex_10.1\Personnel\Personnel.txt";
            FileReader fileReader = new FileReader(path);
            if (fileReader.IsPathExists)
            {
                listString = fileReader.ReadFromFile();
                foreach (string printString in listString)
                {
                    Console.WriteLine(printString);
                }
            }
            else
            {
                Console.WriteLine("File {0} does not exist", path);
            }
        }
    }
}
