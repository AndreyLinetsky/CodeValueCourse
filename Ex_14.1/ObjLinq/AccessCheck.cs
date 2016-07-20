using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
namespace ObjLinq
{
    public class AccessCheck
    {
        public  bool IsAccessible(Process proc)
        {
            try
            {
                return proc.StartTime.Equals(proc.StartTime);
            }
            catch (Win32Exception ex)
            {
                Trace.WriteLine($"Name = {proc.ProcessName} , ID = {proc.Id}, {ex.Message}");
                return false;
            }
        }
    }
}
