/*
 * Author:  Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub:  @ClydeDz 
 */
 
 using System;
using System.Reflection;

namespace FolderInspector.Utilities
{
    internal class ConsoleLogUtility
    {
        /// <summary>
        /// Prints a standard message on the console output.
        /// </summary>
        /// <param name="message">Message to be printed.</param>
        internal static void WriteLog(string message)
        {
            Console.ResetColor();
            Console.WriteLine(message);
        }

        /// <summary>
        /// Prints an error message on the console output.
        /// </summary>
        /// <param name="message">Message to be printed.</param>
        internal static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }      
        
        internal static void PrintHeader()
        {
            WriteLog($"Folder Inspector ({IntPtr.Size * 8}-bit .NET {Environment.Version})");
            WriteLog($"Version {Assembly.GetEntryAssembly().GetName().Version}");
            WriteLog("Copyright (C) 2019 Clyde D'Souza (https://clydedsouza.net).\n");
        }
    }
}
