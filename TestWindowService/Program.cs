using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace daphneservice
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var proc1 = new ProcessStartInfo();
            proc1.UseShellExecute = true;

            proc1.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;

            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Arguments = "/c daphne -b 10.1.1.44 -p 80 firstsite.asgi:application";
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new Scheduler() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
