/*
 * Author:  Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub:  @ClydeDz 
 */

using System;

namespace FolderInspector.Utilities
{
    internal class ConsoleLogUtility: ILogUtility
    {
        /// <summary>
        /// Prints a standard message on the console output.
        /// </summary>
        /// <param name="message">Message to be printed.</param>
        public void WriteLog(string message)
        {
            Console.ResetColor();
            Console.WriteLine(message);
        }

        /// <summary>
        /// Prints an error message on the console output.
        /// </summary>
        /// <param name="message">Message to be printed.</param>
        public void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }      
    }
}
