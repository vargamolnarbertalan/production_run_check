using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace runCheck
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static void Main(string[] args)
        {
            
            var handle = GetConsoleWindow();

            // Hide
            ShowWindow(handle, SW_HIDE);

            int alreadyrunning = 0;
            
            while (true && alreadyrunning == 0)
            {
                Process[] r6 = Process.GetProcessesByName("RainbowSix");
                
                Console.Clear();
                if (r6.Length == 0)
                {
                    //Console.WriteLine("nothing");                    
                }
                else
                {
                    //Console.WriteLine("run");
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.WorkingDirectory = "C:/Program Files/obs-studio/bin/64bit/";
                    startInfo.FileName = "obs64.exe";
                    startInfo.Arguments = "--startreplaybuffer --minimize-to-tray";
                    Process.Start(startInfo);
                    alreadyrunning = 1;                    
                }                
                Thread.Sleep(1000);
            }         
            
            //Console.ReadKey();
        }
        
    }
}
