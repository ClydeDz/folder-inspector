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
    internal class FolderUtility: IFolderUtility
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
        public string GetFooterText(string filePath = "")
        {
            if (_appSettings.UseCustomHeaderText && !string.IsNullOrEmpty(_appSettings.CustomFooterText))
            {
                return _appSettings.CustomFooterText + " " + (_appSettings.AppendFilePathToFooterText ? filePath: "");
            }
            return _appSettings.DefaultFooterText + " " + (_appSettings.AppendFilePathToFooterText ? filePath : "");
        }


        public void PrintHeader()
        {
            _logUtility.WriteLog($"Folder Inspector ({IntPtr.Size * 8}-bit .NET {Environment.Version})");
            _logUtility.WriteLog($"Version {Assembly.GetEntryAssembly().GetName().Version}");
            _logUtility.WriteLog("Copyright (C) 2019 Clyde D'Souza (https://clydedsouza.net).\n");
        }
    }
}
