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
using FolderInspector.Helper;
using FolderInspector.Utilities;

namespace FolderInspector
{ 
    internal class FolderInspector
    {
        private IDocumentUtility _wordDocumentUtility;
        private IDocumentUtility _excelDocumentUtility;
        private IAppSettingsUtility _appSettings;
        private ILogUtility _logUtility;
        private IFolderUtility _folderUtility; 

        public FolderInspector(IDocumentUtility wordDocumentUtility, IDocumentUtility excelDocumentUtility, 
            IAppSettingsUtility appSettings, ILogUtility logUtility, IFolderUtility folderUtility)
        {
            _wordDocumentUtility = wordDocumentUtility;
            _excelDocumentUtility = excelDocumentUtility;
            _appSettings = appSettings;
            _logUtility = logUtility;
            _folderUtility = folderUtility;
        }
        
        /// <summary>
        /// Applications entry point.
        /// </summary>
        /// <param name="args">Optionally supply command line arguments</param>
        internal static void Main(string[] args)
        {
            ILogUtility _logUtility;
            IFolderUtility _folderUtility; 

            try
            {
               
                var settings = ProcessCommandLineArguments(args);
                var configMap = new ExeConfigurationFileMap();
                configMap.ExeConfigFilename = settings.ConfigFilePath; // args[0];
                var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                IAppSettingsUtility _globalConfig = new AppSettingsUtility(config);

                _logUtility = new ConsoleLogUtility();
                _folderUtility = new FolderUtility(new AppSettingsUtility(config), new ConsoleLogUtility());
                FolderInspector folderInspector = new FolderInspector(new WordUtility(), new ExcelUtility(), new AppSettingsUtility(config), new ConsoleLogUtility(), _folderUtility);

                _folderUtility.PrintHeader();

                string path = _globalConfig.RootFileDirectory; 

                if (File.Exists(path))
                {
                    folderInspector.ProcessFile(path);
                }
                else if (Directory.Exists(path))
                {
                    folderInspector.ProcessDirectory(path);
                }
                else
                {
                    _logUtility.WriteError($"{path} is not a valid file or directory.");
                }

#if DEBUG
                _logUtility.WriteLog("\nProgram ended");
                Console.Read();
#endif
            }
            catch (Exception ex)
            {
                _logUtility = new ConsoleLogUtility();
                _logUtility.WriteError($"Folder Inspection encountered an exception. Here are the details: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Process all files in the directory passed in, recurse on any directories 
        /// that are found, and process the files they contain.
        /// </summary>
        /// <param name="targetDirectory">Complete directory path</param>
        internal void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            _logUtility.WriteLog($"Processing: {targetDirectory}");
            string[] allFiles = Directory.GetFiles(targetDirectory);
            foreach (string eachFile in allFiles)
            {
                ProcessFile(eachFile);
            }

            if (_appSettings.SearchSubDirectories)
            {
                // Recurse into subdirectories of this directory.
                string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                foreach (string subdirectory in subdirectoryEntries)
                {
                    ProcessDirectory(subdirectory);
                }
            }
        }

        /// <summary>
        /// Contains the logic behind processing a given file
        /// </summary>
        /// <param name="path"></param>
        internal void ProcessFile(string path)
        {
            if (_appSettings.EditWordDocuments)
            {
                if (_folderUtility.IsWordFile(path))
                {
                    _logUtility.WriteLog($"\tWord document found: {_folderUtility.GetFileName(path)}");
                    _wordDocumentUtility.UpdateHeaderFooter(path, _folderUtility.GetHeaderText(path), _folderUtility.GetFooterText(path));
                }
            }
            if (_appSettings.EditExcelDocuments)
            {
                if (_folderUtility.IsExcelFile(path))
                {
                    _logUtility.WriteLog($"\tExcel document found: {_folderUtility.GetFileName(path)}");
                    _excelDocumentUtility.UpdateHeaderFooter(path, _folderUtility.GetHeaderText(path), _folderUtility.GetFooterText(path));
                }
            }
        }

        internal static CommandLineSettings ProcessCommandLineArguments(string[] arguments)
        {
            var settings = new CommandLineSettings();
            IFolderUtility _folderUtility = new FolderUtility();

            for (var index = 0; index < arguments.Length; index++)
            {
                var currentArgument = arguments[index];

                if (_folderUtility.IsHelpCommand(currentArgument))
                {
                    CommandLineHelper.PrintHelp();
                }

                if (_folderUtility.IsConfigurationFileCommand(currentArgument))
                { 
                    settings.ConfigFilePath = arguments[index+1];
                }
            }

            return settings;
        }
    }
}

