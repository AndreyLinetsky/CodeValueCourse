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

    public class Job : IDisposable
    {
        private IntPtr _hJob;
        private List<Process> _processes;
        private bool Disposed { get; set; }

        public Job(string name)
        {
            _hJob = NativeJob.CreateJobObject(IntPtr.Zero, name);
            if (_hJob == IntPtr.Zero)
            {
                throw new InvalidOperationException();
            }
            _processes = new List<Process>();
            Disposed = false;
        }

        public Job()
            : this(null)
        {
        }

        protected void AddProcessToJob(IntPtr hProcess)
        {
            CheckIfDisposed();

            if (!NativeJob.AssignProcessToJobObject(_hJob, hProcess))
                throw new InvalidOperationException("Failed to add process to job");
        }

        private void CheckIfDisposed()
        {
            if (Disposed)
            {
                throw new ObjectDisposedException("Job already disposed");
            }
        }

        public void AddProcessToJob(int pid)
        {
            AddProcessToJob(Process.GetProcessById(pid));
        }

        public void AddProcessToJob(Process proc)
        {
            Debug.Assert(proc != null);
            AddProcessToJob(proc.Handle);
            _processes.Add(proc);
        }

        public void Kill()
        {
            CheckIfDisposed();
            NativeJob.TerminateJobObject(_hJob, 0);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    foreach (Process proc in _processes)
                    {
                        proc.Dispose();
                    }
                }
                NativeJob.CloseHandle(_hJob);
                Disposed = true;
            }
        }
        ~Job()
        {
            Dispose(false);
        }
    }
}
