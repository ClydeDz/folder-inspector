/*
 * Author: Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub: @ClydeDz
 */

using System;
using System.IO;
using FolderInspector.Constants;

namespace FolderInspector.Services
{
    /// <summary>
    /// Contains the logic behind manipulating files and folders 
    /// </summary>
    public class FolderService
    {
        /// <summary>
        /// Process all files in the directory passed in, recurse on any directories 
        /// that are found, and process the files they contain.
        /// </summary>
        /// <param name="targetDirectory">Complete directory path</param>
        public static void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            if (AppSettings.SearchSubDirectories)
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
        public static void ProcessFile(string path)
        {
            Console.WriteLine("Processing file '{0}'.", path);
            if (AppSettings.EditWordDocuments)
            {
                if (path.Split('.')[1] == AppSettings.WordDocumentExtension)
                {
                    Console.WriteLine("Word document found: {0}", path.Split('.')[0]);
                    WordService.EditWordHeaderFooter(path);
                }
            }
            if (AppSettings.EditExcelDocuments)
            {
                if (path.Split('.')[1] == AppSettings.ExcelDocumentExtension)
                {
                    Console.WriteLine("Excel document found: {0}", path.Split('.')[0]);
                    ExcelService.EditExcelHeaderFooter(path);
                }
            }       

        }

        /// <summary>
        /// Computes a header text
        /// </summary>
        /// <param name="filePath">Optionally, takes in the file path to append to the header text</param>
        /// <returns>Returns the header text content</returns>
        public static string GetHeaderText(string filePath = "")
        {
            if(AppSettings.UseCustomHeaderText && !string.IsNullOrEmpty(AppSettings.CustomHeaderText))
            {
                return AppSettings.CustomHeaderText + " " + (AppSettings.AppendFilePathToHeaderText ? filePath : "");
            }
            return AppSettings.DefaultHeaderText + " " + (AppSettings.AppendFilePathToHeaderText ? filePath : "");
        }

        /// <summary>
        /// Computes a footer text
        /// </summary>
        /// <param name="filePath">Optionally, takes in the file path to append to the footer text</param>
        /// <returns>Return the footer text content</returns>
        public static string GetFooterText(string filePath = "")
        {
            if (AppSettings.UseCustomHeaderText && !string.IsNullOrEmpty(AppSettings.CustomFooterText))
            {
                return AppSettings.CustomFooterText + " " + (AppSettings.AppendFilePathToFooterText ? filePath: "");
            }
            return AppSettings.DefaultFooterText + " " + (AppSettings.AppendFilePathToFooterText ? filePath : "");
        }
    }
}
