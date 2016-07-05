using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace FileFinder
{
    public class DirectorySearch
    {
        private bool isDirExists = false;
        public DirectorySearch(string path)
        {
            if (Directory.Exists(path))
            {
                isDirExists = true;
            }
        }

        public bool IsDirExists
        {
            get
            {
                return isDirExists;
            }
        }

        public List<FileInfo> FindFiles(string currDir)
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
                        files.AddRange(FindFiles(dirInfo.FullName));
                    }
                }
            }
            catch (IOException ex)
            {
                Trace.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return files;
        }
    }
}
