using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Vanara.PInvoke;

namespace Tyln.Core
{
    public class DesktopHelpers
    {
        public static IEnumerable<Process> GetAltTabProcesses()
        {
            // IEnumerable<Process> processes = Process.GetProcesses().Where(proc => proc.MainWindowHandle != IntPtr.Zero);
            return Process.GetProcesses().Where(IsAltTabProcess);
        }

        private static bool IsAltTabProcess(Process process)
        {
            HWND handle;
            try
            {
                handle = process.Handle;
            }
            catch (Win32Exception)
            {
                return false;
            }

            if (process.MainWindowHandle == IntPtr.Zero)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(process.MainWindowTitle))
            {
                return false;
            }

            if (process.Threads.Cast<ProcessThread>().Any(thread => thread.WaitReason == ThreadWaitReason.Suspended))
            {
                return false;
            }
            

            return true;
        }

    }
}