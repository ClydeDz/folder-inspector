/*
 * Author:  Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub:  @ClydeDz 
 */

using System;
using System.Configuration;
using System.IO;
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
            IAppSettingsUtility _globalConfig;

            try
            { 
                var configMap = new ExeConfigurationFileMap();
                configMap.ExeConfigFilename = args[0];
                var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                 
                _globalConfig = new AppSettingsUtility(config);
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
                throw;
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
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName);
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
    }
}

