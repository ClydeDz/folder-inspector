/*
 * Author:  Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub:  @ClydeDz
 */

using System;
using System.IO;
using System.Reflection;

namespace FolderInspector.Utilities
{
    /// <summary>
    /// Contains the logic behind manipulating files and folders 
    /// </summary>
    public class FolderUtility: IFolderUtility
    {
        //private IDocumentUtility _wordDocumentUtility;
        //private IDocumentUtility _excelDocumentUtility;
        private IAppSettingsUtility _appSettings;
        private ILogUtility _logUtility;

        public FolderUtility(IAppSettingsUtility appSettings, ILogUtility logUtility)
        {
            //_wordDocumentUtility = wordDocumentUtility;
            //_excelDocumentUtility = excelDocumentUtility;
            _appSettings = appSettings;
            _logUtility = logUtility;
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

        public bool IsWordFile(string filePath)
        {
            if (!filePath.Contains("."))
            {
                return false;
            }
            return filePath.Split('.')[1] == _appSettings.WordDocumentExtension;
        }

        public bool IsExcelFile(string filePath)
        {
            if (!filePath.Contains("."))
            {
                return false;
            }
            return filePath.Split('.')[1] == _appSettings.ExcelDocumentExtension;
        }

        public string GetFileName(string filePath)
        {
            var parts = filePath.Split('\\');
            return parts[parts.Length-1];
        }

        public void PrintHeader()
        {
            _logUtility.WriteLog($"Folder Inspector ({IntPtr.Size * 8}-bit .NET {Environment.Version})");
            _logUtility.WriteLog($"Version {Assembly.GetEntryAssembly().GetName().Version}");
            _logUtility.WriteLog("Copyright (C) 2019 Clyde D'Souza (https://clydedsouza.net).\n");
        }
    }
}
