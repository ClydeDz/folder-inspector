using Novacode;

namespace FolderInspector.Utilities
{
    /// <summary>
    /// Contains methods to edit a Word file
    /// </summary>
    internal class WordUtility: IDocumentUtility
    {
        /// <summary>
        /// Edits the header and footer of the Word file at the specified path
        /// </summary>
        /// <param name="filePath">Complete file path</param>
        public void UpdateHeaderFooter(string filePath, string headerText, string footerText)
        {
            DocX document = DocX.Load(filePath);            
            document.AddHeaders();
            document.AddFooters();
            
            Header header_default = document.Headers.odd;
            Paragraph p1 = header_default.InsertParagraph();
            p1.InsertText(headerText);

            Footer footer_default = document.Footers.odd;
            Paragraph p3 = footer_default.InsertParagraph();
            p3.InsertText(footerText);
            
            document.Save();
        }
    }
}
