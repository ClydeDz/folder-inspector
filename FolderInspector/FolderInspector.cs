/*
 * Author:  Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub:  @ClydeDz 
 */

using System;
using System.Configuration;
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
            ILogUtility logUtility = new ConsoleLogUtility();

            try
            {
                
                ConsoleLogUtility.PrintHeader(); 
                var configMap = new ExeConfigurationFileMap();
                configMap.ExeConfigFilename = args[0];
                var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                AppSettings globalConfig = new AppSettings(config); 
                FolderUtility folderUtility = new FolderUtility(new WordUtility(), new ExcelUtility(), new AppSettings(config), new ConsoleLogUtility());
                 

                string path = globalConfig.RootFileDirectory;
                Console.WriteLine("a " +path);
                if (File.Exists(path))
                { 
                    folderUtility.ProcessFile(path);
                }
                else if (Directory.Exists(path))
                {
                    folderUtility.ProcessDirectory(path); 
                }
                else
                {
                    logUtility.WriteError($"{path} is not a valid file or directory.");
                }
                logUtility.WriteLog("Program ended");

#if DEBUG
                Console.Read();
#endif
            }
            catch (Exception ex)
            {
                logUtility.WriteError($"Folder Inspection encountered an exception. Here are the details: {ex.Message}");
                throw;
            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}

