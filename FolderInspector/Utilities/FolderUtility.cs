using FolderInspector.Constants;
using FolderInspector.Helper;
using System.IO;
using System.Security;

namespace FolderInspector.Utilities
{
    /// <summary>
    /// Contains the logic behind manipulating files and folders 
    /// </summary>
    public class FolderUtility: IFolderUtility
    {
        private IDocumentUtility _wordDocumentUtility;
        private IDocumentUtility _excelDocumentUtility;
        private IAppSettingsUtility _appSettings;

        public FolderUtility()
        { 
        }

        public FolderUtility(IDocumentUtility wordDocumentUtility, IDocumentUtility excelDocumentUtility, 
            IAppSettingsUtility appSettings)
        {
            _wordDocumentUtility = wordDocumentUtility;
            _excelDocumentUtility = excelDocumentUtility;
            _appSettings = appSettings;
        }

        /// <summary>
        /// Initiates file or directory processing.
        /// </summary>
        public void StartFileProcessing()
        {
            try
            {
                string path = _appSettings.RootFileDirectory;

                if (File.Exists(path))
                {
                    ProcessFile(path);
                    return;
                }

                if (Directory.Exists(path))
                {
                    ProcessDirectory(path);
                    return;
                }

                throw new FileNotFoundException($"{path} is not a valid file or directory.");
            }
            catch(SecurityException secEx)
            {
                throw secEx;
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
                if (IsWordFile(path))
                {
                    CommandLineHelper.WriteLog($"\tWord document found: {GetFileName(path)}");
                    _wordDocumentUtility.UpdateHeaderFooter(path, GetHeaderText(path), GetFooterText(path));
                }
            }
            if (_appSettings.EditExcelDocuments)
            {
                if (IsExcelFile(path))
                {
                    CommandLineHelper.WriteLog($"\tExcel document found: {GetFileName(path)}");
                    _excelDocumentUtility.UpdateHeaderFooter(path, GetHeaderText(path), GetFooterText(path));
                }
            }
        }


        /// <summary>
        /// Computes a header text
        /// </summary>
        /// <param name="filePath">Optionally, takes in the file path to append to the header text</param>
        /// <returns>Returns the header text content</returns>
        public string GetHeaderText(string filePath = "")
        {
            var headerText = _appSettings.AppendFilePathToHeaderText ? $" {filePath}" : "";
            bool useCustomHeaderText = _appSettings.UseCustomHeaderText && !string.IsNullOrEmpty(_appSettings.CustomHeaderText);
            if (useCustomHeaderText)
            { 
                return $"{_appSettings.CustomHeaderText}{headerText}";
            }
            return $"{_appSettings.DefaultHeaderText}{headerText}"; 
        }

        /// <summary>
        /// Computes a footer text
        /// </summary>
        /// <param name="filePath">Optionally, takes in the file path to append to the footer text</param>
        /// <returns>Return the footer text content</returns>
        public string GetFooterText(string filePath = "")
        {
            var footerText = _appSettings.AppendFilePathToFooterText ? $" {filePath}" : "";
            bool useCustomFooterText = _appSettings.UseCustomFooterText && !string.IsNullOrEmpty(_appSettings.CustomFooterText);
            if (useCustomFooterText)
            {
                return $"{_appSettings.CustomFooterText}{footerText}";
            }
            return $"{_appSettings.DefaultFooterText}{footerText}";
        }

        /// <summary>
        /// Confirms if the supplied file is a Word file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool IsWordFile(string filePath)
        {
            if (!filePath.Contains("."))
            {
                return false;
            }
            return filePath.Split('.')[1] == _appSettings.WordDocumentExtension;
        }

        /// <summary>
        /// Confirms if the supplied file is an Excel file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool IsExcelFile(string filePath)
        {
            if (!filePath.Contains("."))
            {
                return false;
            }
            return filePath.Split('.')[1] == _appSettings.ExcelDocumentExtension;
        }

        /// <summary>
        /// Gets the file name from the supplied path.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string GetFileName(string filePath)
        {
            var parts = filePath.Split('\\');
            return parts[parts.Length-1];
        }

        /// <summary>
        /// Confirms if the supplied command is help .
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool IsHelpCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                return false;
            }

            return command.ToLower().Trim() == AppConstants.CommandLineConstants.Help || command.ToLower().Trim() == AppConstants.CommandLineConstants.HelpShort;
        }

        /// <summary>
        /// Confirms if the supplied command is vesion. 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool IsVersionCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                return false;
            }

            return command.ToLower().Trim() == AppConstants.CommandLineConstants.Version || command.ToLower().Trim() == AppConstants.CommandLineConstants.VersionShort;
        }

        /// <summary>
        /// Confirms if the supplied command is config.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool IsConfigCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                return false;
            }

            return command.ToLower().Trim() == AppConstants.CommandLineConstants.ConfigurationFile || command.ToLower().Trim() == AppConstants.CommandLineConstants.ConfigurationFileShort;
        }

        /// <summary>
        /// Confiirms if content exists in a particular position of the supplied array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="positionToCheck"></param>
        /// <returns></returns>
        public bool DoesArrayContentExists(string[] array, int positionToCheck)
        {
            return positionToCheck < array.Length ? !string.IsNullOrEmpty(array[positionToCheck]) : false;
        } 
    }
}
