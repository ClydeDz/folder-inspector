using System;
using System.IO;
using System.Reflection;

namespace FolderInspector.Helper
{
    public class CommandLineHelper
    {
        /// <summary>
        /// Prints a standard message on the console output
        /// </summary>
        /// <param name="message"></param>
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


        /// <summary>
        /// Prints meta information for this application.
        /// </summary>
        public static void PrintCopyright()
        {
            Console.WriteLine($"Folder Inspector ({IntPtr.Size * 8}-bit .NET {Environment.Version})");
            Console.WriteLine($"Version {Assembly.GetEntryAssembly().GetName().Version}");
            Console.WriteLine("Copyright (C) 2019 Clyde D'Souza (https://clydedsouza.net).");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints version number of the application.
        /// </summary>
        public static void PrintVersion()
        { 
            Console.WriteLine($"Version {Assembly.GetEntryAssembly().GetName().Version}"); 
        }

        /// <summary>
        /// Prints help contents for this application.
        /// </summary>
        public static void PrintHelp()
        {
            string executableName = Path.GetFileNameWithoutExtension(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            Console.WriteLine($"Usage: {executableName} [command] [args]");
            Console.WriteLine($"Example usage: {executableName} -h");
            Console.WriteLine();
            Console.WriteLine("Valid commands  Alias   Args                 Explanation");
            Console.WriteLine("--------------  -----   -----------------    -----------");
            Console.WriteLine("--config        -c      .config file name    Supply a custom configuration file");
            Console.WriteLine("--help          -h                           Displays the help screen");
            Console.WriteLine("--version       -v                           Gets the application version"); 
        }
    }
}
