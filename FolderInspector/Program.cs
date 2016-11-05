/*
 * Author: Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub: @ClydeDz
 * Email: clydedsouza[at]outlook[dot]com
 */

using System;
using System.IO;
using FolderInspector.Constants;
using FolderInspector.Services;

namespace FolderInspector
{
    /// <summary>
    /// Starting point of the application
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Program started");
                string path = @"" + AppSettings.RootFileDirectory;
                if (File.Exists(path))
                {
                    FolderService.ProcessFile(path);
                }
                else if (Directory.Exists(path))
                {
                    FolderService.ProcessDirectory(path);
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

