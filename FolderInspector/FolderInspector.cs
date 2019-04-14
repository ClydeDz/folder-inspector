/*
 * Author:  Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub:  @ClydeDz 
 */

using System;
using System.IO;
using FolderInspector.Constants;
using FolderInspector.Utilities;

namespace FolderInspector
{
    /// <summary>
    /// Starting point of the application
    /// </summary>
    internal class FolderInspector
    {
        internal static void Main(string[] args)
        {
            try
            {
                ConsoleLogUtility.PrintHeader();

                string path = @"" + AppSettings.RootFileDirectory;
                if (File.Exists(path))
                {
                    FolderUtility.ProcessFile(path);
                }
                else if (Directory.Exists(path))
                {
                    FolderUtility.ProcessDirectory(path);
                }
                else
                {
                    ConsoleLogUtility.WriteError($"{path} is not a valid file or directory.");
                }
                ConsoleLogUtility.WriteLog("Program ended");

#if DEBUG
                Console.Read();
#endif
            }
            catch (Exception ex)
            {
                ConsoleLogUtility.WriteError($"Folder Inspection encountered an exception. Here are the details: {ex.Message}");
                throw;
            }
        }
    }
}

