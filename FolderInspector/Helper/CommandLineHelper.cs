using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FolderInspector.Helper
{
    public class CommandLineHelper
    {
        public static void PrintHelp()
        {
            Console.WriteLine("Help");
        }

        public static void WriteLog(string message)
        {
            Console.ResetColor();
            Console.WriteLine(message);
        }

        /// <summary>
        /// Prints an error message on the console output.
        /// </summary>
        /// <param name="message">Message to be printed.</param>
        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void PrintHeader()
        {
            Console.WriteLine($"Folder Inspector ({IntPtr.Size * 8}-bit .NET {Environment.Version})");
            Console.WriteLine($"Version {Assembly.GetEntryAssembly().GetName().Version}");
            Console.WriteLine("Copyright (C) 2019 Clyde D'Souza (https://clydedsouza.net).\n");
        }

        public static void PrintVersion()
        { 
            Console.WriteLine($"Version {Assembly.GetEntryAssembly().GetName().Version}"); 
        }
    }
}
