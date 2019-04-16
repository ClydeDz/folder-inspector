using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderInspector.Utilities
{
    class AppSettingsUtility: IAppSettingsUtility
    {
        public AppSettingsUtility(Configuration configuration)
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
