﻿/*
 * Author: Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub: @ClydeDz
 * Email: clydedsouza[at]outlook[dot]com
 */

using System;
using System.Configuration;

namespace FolderInspector.Constants
{
    /// <summary>
    /// Contains the application wide settings
    /// </summary>
    public class AppSettings
    {
        // Basic Settings

        /// <summary>
        /// Sets the root directory that you want to inspect
        /// </summary>
        public static string RootFileDirectory
        {
            get { return ConfigurationManager.AppSettings["RootFileDirectory"].ToString(); }
        }

        /// <summary>
        /// Sets the default header text to be used if custom text isn't specified
        /// </summary>
        public static string DefaultHeaderText
        {
            get { return ConfigurationManager.AppSettings["DefaultHeaderText"].ToString(); }
        }

        /// <summary>
        /// Sets the default footer text to be used if custom text isn't specified
        /// </summary>
        public static string DefaultFooterText
        {
            get { return ConfigurationManager.AppSettings["DefaultFooterText"].ToString(); }
        }

        /// <summary>
        /// Sets whether or not to inspect subdirectories of the root directory
        /// </summary>
        public static bool SearchSubDirectories
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["SearchSubDirectories"].ToString()); }
        }

        /// <summary>
        /// Sets whether or not to edit Word documents found in the directory
        /// </summary>
        public static bool EditWordDocuments
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["EditWordDocuments"].ToString()); }
        }

        /// <summary>
        /// Sets whether or not to edit Excel documents found in the directory
        /// </summary>
        public static bool EditExcelDocuments
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["EditExcelDocuments"].ToString()); }
        }

        /// <summary>
        /// Sets the file extension for a Word document to match it against
        /// </summary>
        public static string WordDocumentExtension
        {
            get { return ConfigurationManager.AppSettings["WordDocumentExtension"].ToString(); }
        }

        /// <summary>
        /// Sets the file extension for an Excel document to match it against
        /// </summary>
        public static string ExcelDocumentExtension
        {
            get { return ConfigurationManager.AppSettings["ExcelDocumentExtension"].ToString(); }
        }

        // Advance settings
      
        /// <summary>
        /// Sets whether or not to use custom header text
        /// </summary>
        public static bool UseCustomHeaderText
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["UseCustomHeaderText"].ToString()); }
        }

        /// <summary>
        /// Sets the custom header text
        /// </summary>
        public static string CustomHeaderText
        {
            get { return ConfigurationManager.AppSettings["CustomHeaderText"].ToString(); }
        }

        /// <summary>
        /// Sets whether or not to use custom footer text 
        /// </summary>
        public static bool UseCustomFooterText
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["UseCustomFooterText"].ToString()); }
        }

        /// <summary>
        /// Sets the custom footer text
        /// </summary>
        public static string CustomFooterText
        {
            get { return ConfigurationManager.AppSettings["CustomFooterText"].ToString(); }
        }

        /// <summary>
        /// Sets whether or not to append the file path to the header text
        /// </summary>
        public static bool AppendFilePathToHeaderText
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["AppendFilePathToHeaderText"].ToString()); }
        }

        /// <summary>
        /// Sets whether or not to append the file path to the footer text
        /// </summary>
        public static bool AppendFilePathToFooterText
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["AppendFilePathToFooterText"].ToString()); }
        }
    }
}