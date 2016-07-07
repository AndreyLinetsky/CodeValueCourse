using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Personnel
{
    public class FileReader
    {
        private bool isPathExists = false;
        private string path;
        public FileReader(string inputPath)
        {
            path = inputPath;
            if (File.Exists(path))
            {
                isPathExists = true;
            }
        }

        public bool IsPathExists
        {
            get
            {
                return isPathExists;
            }
        }

        public List<string> ReadFromFile()
        {
            List<String> stringList = new List<string>();
            string currString;
            StreamReader reader = null;
            try
            {
                FileStream stm = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                reader = new StreamReader(stm);
                while (!reader.EndOfStream)
                {
                    currString = reader.ReadLine();
                    // Empty or whitespace lines should not be printed
                    if (!String.IsNullOrWhiteSpace(currString))
                    {
                        stringList.Add(currString);
                    }
                }
            }
            finally
            {
                if (reader != null)
                {
                    // Close also disposes the object 
                    reader.Close();
                }
            }
            return stringList;
        }
    }
}
