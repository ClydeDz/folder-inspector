/*
 * Author:  Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub:  @ClydeDz 
 */
 
 using System;

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
            Console.ForegroundColor = ConsoleColor.White;
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
    }
}
