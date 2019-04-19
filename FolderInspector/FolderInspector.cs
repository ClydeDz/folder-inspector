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
        private IFolderUtility _folderUtility; 

        public FolderInspector(IDocumentUtility wordDocumentUtility, IDocumentUtility excelDocumentUtility, 
            IAppSettingsUtility appSettings,IFolderUtility folderUtility)
        {
            _wordDocumentUtility = wordDocumentUtility;
            _excelDocumentUtility = excelDocumentUtility;
            _appSettings = appSettings;
            _folderUtility = folderUtility;
        }
        
        /// <summary>
        /// Applications entry point.
        /// </summary>
        /// <param name="args">Optionally supply command line arguments</param>
        internal static void Main(string[] args)
        {
            IFolderUtility _folderUtility; 

            try
            {
                CommandLineHelper.PrintHeader();

                var settings = ProcessCommandLineArguments(args);

                //Set applications configuration file
                if (settings.ConfigSupplied && string.IsNullOrEmpty(settings.ConfigFilePath)) {
                    throw new ConfigurationErrorsException("Please supply a configuration file");
                }
                var configMap = new ExeConfigurationFileMap();
                Configuration config;
                IAppSettingsUtility _globalConfig;
                try
                {
                    configMap.ExeConfigFilename = string.IsNullOrEmpty(settings.ConfigFilePath) ? AppConstants.DefaultConfigFile : settings.ConfigFilePath;
                    config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                    _globalConfig = new AppSettingsUtility(config);
                }
                catch
                {
                    throw new ConfigurationErrorsException("Invalid or no configuration file");
                }

                _folderUtility = new FolderUtility(new AppSettingsUtility(config), new ConsoleLogUtility());
                FolderInspector folderInspector = new FolderInspector(new WordUtility(), new ExcelUtility(), new AppSettingsUtility(config), _folderUtility);
                              

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
                    CommandLineHelper.WriteError($"{path} is not a valid file or directory.");
                }

#if DEBUG
                CommandLineHelper.WriteLog("\nProgram ended");
                Console.Read();
#endif
            }
            catch (Exception ex)
            {
                CommandLineHelper.WriteError($"Error: {ex.Message}");
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
            CommandLineHelper.WriteLog($"Processing: {targetDirectory}");
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
                    CommandLineHelper.WriteLog($"\tWord document found: {_folderUtility.GetFileName(path)}");
                    _wordDocumentUtility.UpdateHeaderFooter(path, _folderUtility.GetHeaderText(path), _folderUtility.GetFooterText(path));
                }
            }
            if (_appSettings.EditExcelDocuments)
            {
                if (_folderUtility.IsExcelFile(path))
                {
                    CommandLineHelper.WriteLog($"\tExcel document found: {_folderUtility.GetFileName(path)}");
                    _excelDocumentUtility.UpdateHeaderFooter(path, _folderUtility.GetHeaderText(path), _folderUtility.GetFooterText(path));
                }
            }
        }

        internal static CommandLineSettings ProcessCommandLineArguments(string[] arguments)
        {
            var settings = new CommandLineSettings();
            IFolderUtility _folderUtility = new FolderUtility();

            //Where only single arguments will be catered to
            for (var index = 0; index < arguments.Length; index++)
            {
                var currentArgument = arguments[index];

                if (_folderUtility.IsHelpCommand(currentArgument))
                {
                    CommandLineHelper.PrintHelp();
                    return settings;
                }

                if (_folderUtility.IsHelpCommand(currentArgument))
                {
                    CommandLineHelper.PrintHelp();
                    return settings;
                }
            }

            //Where multiple arguments are allowed
            for (var index = 0; index < arguments.Length; index++)
            {
                var currentArgument = arguments[index];

                if (_folderUtility.IsConfigCommand(currentArgument))
                {
                    settings.ConfigFilePath = _folderUtility.DoesArrayContentExists(arguments, index+1) ? arguments[index + 1]: AppConstants.DefaultConfigFile;
                    settings.ConfigSupplied = true;
                }
            }

            return settings;
        }
    }
}

