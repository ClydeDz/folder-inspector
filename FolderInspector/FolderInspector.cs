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
    public class FolderInspector
    {
        internal static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Program started");
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
                    Console.WriteLine("{0} is not a valid file or directory.", path);
                }
                Console.WriteLine("Program ended");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Folder Inspection encountered an exception. Here are the details: {0}", ex.Message);
                throw;
            }
        }  
    }
}

