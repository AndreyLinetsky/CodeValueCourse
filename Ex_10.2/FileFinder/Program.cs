using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 2 && !String.IsNullOrWhiteSpace(args[0]) &&
                                    !String.IsNullOrWhiteSpace(args[1]))
            {
                DirectorySearch dirSearch = new DirectorySearch(args[0]);
                if (dirSearch.IsDirExists)
                {
                    List<FileInfo> files = dirSearch.FindFiles(args[0]);
                    foreach (FileInfo currFile in files)
                    {
                        if (currFile.Exists &&
                            currFile.Name.Contains(args[1]))
                        {
                            Trace.WriteLine(String.Format("File name is {0} and file length is {1}", currFile.FullName, currFile.Length));
                        }
                    }
                }
                else
                {
                    Trace.WriteLine(String.Format("Directory {0} does not exist", args[0]));
                }
            }
            else
            {
                Trace.WriteLine("Error! Please submit the correct path and filter word");
            }
        }
    }
}

