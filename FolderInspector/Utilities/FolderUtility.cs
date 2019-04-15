/*
 * Author:  Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub:  @ClydeDz
 */

using System;
using System.IO;
using FolderInspector.Constants;

namespace FolderInspector.Utilities
{
    /// <summary>
    /// Contains the logic behind manipulating files and folders 
    /// </summary>
    internal class FolderUtility
    {
        private IDocumentUtility _wordDocumentUtility;
        private IDocumentUtility _excelDocumentUtility;
        private ILogUtility _logUtility;
        private IAppSettings _appSettings;

        public FolderUtility(IDocumentUtility wordDocumentUtility, IDocumentUtility excelDocumentUtility, IAppSettings appSettings, ILogUtility logUtility)
        {
            _wordDocumentUtility = wordDocumentUtility;
            _excelDocumentUtility = excelDocumentUtility;
            _appSettings = appSettings;
            _logUtility = logUtility;
        }

        internal void Test()
        {
            Console.WriteLine(_appSettings.RootFileDirectory);
        }
        /// <summary>
        /// Process all files in the directory passed in, recurse on any directories 
        /// that are found, and process the files they contain.
        /// </summary>
        /// <param name="targetDirectory">Complete directory path</param>
        internal void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            if (_appSettings.SearchSubDirectories)
            {
                // Recurse into subdirectories of this directory.
                string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                foreach (string subdirectory in subdirectoryEntries)
                    ProcessDirectory(subdirectory);
            }
        }

        /// <summary>
        /// Contains the logic behind processing a given file
        /// </summary>
        /// <param name="path"></param>
        internal void ProcessFile(string path)
        {
            _logUtility.WriteLog($"Processing file {path}.");
            if (_appSettings.EditWordDocuments)
            {
                if (path.Split('.')[1] == _appSettings.WordDocumentExtension)
                {
                    _logUtility.WriteLog($"Word document found: {path.Split('.')[0]}"); 
                    _wordDocumentUtility.UpdateHeaderFooter(path, GetHeaderText(path), GetFooterText(path));
                }
            }
            if (_appSettings.EditExcelDocuments)
            {
                if (path.Split('.')[1] == _appSettings.ExcelDocumentExtension)
                {
                    _logUtility.WriteLog($"Excel document found: {path.Split('.')[0]}");
                    _excelDocumentUtility.UpdateHeaderFooter(path, GetHeaderText(path), GetFooterText(path));
                }
            }       

        }

        /// <summary>
        /// Computes a header text
        /// </summary>
        /// <param name="filePath">Optionally, takes in the file path to append to the header text</param>
        /// <returns>Returns the header text content</returns>
        internal string GetHeaderText(string filePath = "")
        {
            if(_appSettings.UseCustomHeaderText && !string.IsNullOrEmpty(_appSettings.CustomHeaderText))
            {
                return _appSettings.CustomHeaderText + " " + (_appSettings.AppendFilePathToHeaderText ? filePath : "");
            }
            return _appSettings.DefaultHeaderText + " " + (_appSettings.AppendFilePathToHeaderText ? filePath : "");
        }

        /// <summary>
        /// Computes a footer text
        /// </summary>
        /// <param name="filePath">Optionally, takes in the file path to append to the footer text</param>
        /// <returns>Return the footer text content</returns>
        internal string GetFooterText(string filePath = "")
        {
            if (_appSettings.UseCustomHeaderText && !string.IsNullOrEmpty(_appSettings.CustomFooterText))
            {
                return _appSettings.CustomFooterText + " " + (_appSettings.AppendFilePathToFooterText ? filePath: "");
            }
            return _appSettings.DefaultFooterText + " " + (_appSettings.AppendFilePathToFooterText ? filePath : "");
        }
    }
}
