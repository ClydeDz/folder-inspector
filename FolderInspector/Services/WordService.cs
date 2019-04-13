/*
 * Author: Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub: @ClydeDz 
 */

using Novacode;

namespace FolderInspector.Services
{
    /// <summary>
    /// Contains methods to edit a Word file
    /// </summary>
    public class WordService
    {
        /// <summary>
        /// Edits the header and footer of the Word file at the specified path
        /// </summary>
        /// <param name="filePath">Complete file path</param>
        public static void EditWordHeaderFooter(string filePath)
        {
            DocX document = DocX.Load(filePath);            
            document.AddHeaders();
            document.AddFooters();
            
            Header header_default = document.Headers.odd;
            Paragraph p1 = header_default.InsertParagraph();
            p1.InsertText(FolderService.GetHeaderText(filePath));

            Footer footer_default = document.Footers.odd;
            Paragraph p3 = footer_default.InsertParagraph();
            p3.InsertText(FolderService.GetFooterText(filePath));
            
            document.Save();
        }
    }
}
