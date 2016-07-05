using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileFinder
{
    class Program
    {
        public List<FileInfo> GetFiles(string currDir)
        {
            List<FileInfo> files = new List<FileInfo>();
            try
            {
                DirectoryInfo dir = new DirectoryInfo(currDir);
                files = dir.GetFiles().ToList<FileInfo>();
                List<DirectoryInfo> directories = dir.GetDirectories().ToList<DirectoryInfo>();
                foreach (DirectoryInfo dirInfo in directories)
                {
                    if (dirInfo.Exists)
                    {
                        files.AddRange(GetFiles(dirInfo.FullName));
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return files;
        }

        static void Main(string[] args)
        {
            try
            {
                if (args.Length >= 2 && !String.IsNullOrWhiteSpace(args[0]) &&
                    !String.IsNullOrWhiteSpace(args[1]))
                {
                    if (Directory.Exists(args[0]))
                    {
                        Program prog = new Program();
                        List<FileInfo> files = prog.GetFiles(args[0]);
                        foreach (FileInfo currFile in files)
                        {
                            if (currFile.Exists &&
                                currFile.Name.Contains(args[1]))
                            {
                                Console.WriteLine("File name is {0} and file length is {1}", currFile.FullName, currFile.Length);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Directory {0} does not exist", args[0]);
                    }
                }
                else
                {
                    Console.WriteLine("Error! Please submit the correct path and filter word");
                }

            }

            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
