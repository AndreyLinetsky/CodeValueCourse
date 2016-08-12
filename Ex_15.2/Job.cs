using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Jobs
{
    static class NativeJob
    {
        [DllImport("kernel32")]
        public static extern IntPtr CreateJobObject(IntPtr sa, string name);

        [DllImport("kernel32", SetLastError = true)]
        public static extern bool AssignProcessToJobObject(IntPtr hjob, IntPtr hprocess);

        [DllImport("kernel32")]
        public static extern bool CloseHandle(IntPtr h);

        [DllImport("kernel32")]
        public static extern bool TerminateJobObject(IntPtr hjob, uint code);
    }

    public class Job
    {
        private long _size;
        private string _name;
        public Job(string name, long sizeInByte)
        {
            if (sizeInByte < 1)
            {
                throw new ArgumentOutOfRangeException("Size", "Size must be greater than 0");
            }
            _size = sizeInByte;
            _name = name;
            GC.AddMemoryPressure(_size);
            Console.WriteLine($"{_name} was created", _name);
        }

        public Job()
            : this(null, 1)
        {
        }

        ~Job()
        {
            if (_size > 0)
            {
                GC.RemoveMemoryPressure(_size);
                Console.WriteLine($"{_name} was released", _name);
            }
        }
    }
}
