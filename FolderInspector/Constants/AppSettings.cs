﻿/*
 * Author:  Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub:  @ClydeDz 
 */

using System;
using System.Configuration;

namespace FolderInspector.Constants
{
    public interface IAppSettings
    {
        string RootFileDirectory { get; set; }
        string DefaultHeaderText { get; set; }
        string DefaultFooterText { get; set; }
        bool SearchSubDirectories { get; set; }
        bool EditWordDocuments { get; set; }
        bool EditExcelDocuments { get; set; }
        string WordDocumentExtension { get; set; }
        string ExcelDocumentExtension { get; set; }
        bool UseCustomHeaderText { get; set; }
        string CustomHeaderText { get; set; }
        bool UseCustomFooterText { get; set; }
        string CustomFooterText { get; set; }
        bool AppendFilePathToHeaderText { get; set; }
        bool AppendFilePathToFooterText { get; set; }
    }

    /// <summary>
    /// Contains the application wide settings
    /// </summary>
    public class AppSettings: IAppSettings
    {

        public AppSettings(string rootFileDirectory, string defaultHeaderText, string defaultFooterText, bool searchSubDirectories, bool editWordDocuments, bool editExcelDocuments, string wordDocumentExtension, string excelDocumentExtension, bool useCustomHeaderText, string customHeaderText, bool useCustomFooterText, string customFooterText, bool appendFilePathToHeaderText, bool appendFilePathToFooterText)
        {
            RootFileDirectory = rootFileDirectory;
            DefaultHeaderText = defaultHeaderText;
            DefaultFooterText = defaultFooterText;
            SearchSubDirectories = searchSubDirectories;
            EditWordDocuments = editWordDocuments;
            EditExcelDocuments = editExcelDocuments;
            WordDocumentExtension = wordDocumentExtension;
            ExcelDocumentExtension = excelDocumentExtension;
            UseCustomHeaderText = useCustomHeaderText;
            CustomHeaderText = customHeaderText;
            UseCustomFooterText = useCustomFooterText;
            CustomFooterText = customFooterText;
            AppendFilePathToHeaderText = appendFilePathToHeaderText;
            AppendFilePathToFooterText = appendFilePathToFooterText;
        }

        public AppSettings(Configuration configuration)
        {
            RootFileDirectory = configuration.AppSettings.Settings["RootFileDirectory"].Value;
            DefaultHeaderText = configuration.AppSettings.Settings["DefaultHeaderText"].Value;
            DefaultFooterText = configuration.AppSettings.Settings["DefaultFooterText"].Value;
            SearchSubDirectories = Convert.ToBoolean(configuration.AppSettings.Settings["SearchSubDirectories"].Value);
            EditWordDocuments = Convert.ToBoolean(configuration.AppSettings.Settings["EditWordDocuments"].Value);
            EditExcelDocuments = Convert.ToBoolean(configuration.AppSettings.Settings["EditExcelDocuments"].Value);
            WordDocumentExtension = configuration.AppSettings.Settings["WordDocumentExtension"].Value;
            ExcelDocumentExtension = configuration.AppSettings.Settings["ExcelDocumentExtension"].Value;
            UseCustomHeaderText = Convert.ToBoolean(configuration.AppSettings.Settings["UseCustomHeaderText"].Value);
            CustomHeaderText = configuration.AppSettings.Settings["CustomHeaderText"].Value;
            UseCustomFooterText = Convert.ToBoolean(configuration.AppSettings.Settings["UseCustomFooterText"].Value);
            CustomFooterText = configuration.AppSettings.Settings["CustomFooterText"].Value;
            AppendFilePathToHeaderText = Convert.ToBoolean(configuration.AppSettings.Settings["AppendFilePathToHeaderText"].Value);
            AppendFilePathToFooterText = Convert.ToBoolean(configuration.AppSettings.Settings["AppendFilePathToFooterText"].Value);
        }

        /// <summary>
        /// Sets the root directory that you want to inspect
        /// </summary>
        public string RootFileDirectory { get; set; }

        /// <summary>
        /// Sets the default header text to be used if custom text isn't specified
        /// </summary>
        public string DefaultHeaderText { get; set; }

        /// <summary>
        /// Sets the default footer text to be used if custom text isn't specified
        /// </summary>
        public string DefaultFooterText { get; set; }

        /// <summary>
        /// Sets whether or not to inspect subdirectories of the root directory
        /// </summary>
        public bool SearchSubDirectories { get; set; }

        /// <summary>
        /// Sets whether or not to edit Word documents found in the directory
        /// </summary>
        public bool EditWordDocuments { get; set; }

        /// <summary>
        /// Sets whether or not to edit Excel documents found in the directory
        /// </summary>
        public bool EditExcelDocuments { get; set; }

        /// <summary>
        /// Sets the file extension for a Word document to match it against
        /// </summary>
        public string WordDocumentExtension { get; set; }

        /// <summary>
        /// Sets the file extension for an Excel document to match it against
        /// </summary>
        public string ExcelDocumentExtension { get; set; }

        /// <summary>
        /// Sets whether or not to use custom header text
        /// </summary>
        public bool UseCustomHeaderText { get; set; }

        /// <summary>
        /// Sets the custom header text
        /// </summary>
        public string CustomHeaderText { get; set; }

        /// <summary>
        /// Sets whether or not to use custom footer text 
        /// </summary>
        public bool UseCustomFooterText { get; set; }

        /// <summary>
        /// Sets the custom footer text
        /// </summary>
        public string CustomFooterText { get; set; }

        /// <summary>
        /// Sets whether or not to append the file path to the header text
        /// </summary>
        public bool AppendFilePathToHeaderText { get; set; }

        /// <summary>
        /// Sets whether or not to append the file path to the footer text
        /// </summary>
        public bool AppendFilePathToFooterText { get; set; }

    }
}
