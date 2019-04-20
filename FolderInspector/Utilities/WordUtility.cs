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
            document.Headers.odd.InsertParagraph(headerText);

            document.AddFooters();
            document.Footers.odd.InsertParagraph(footerText);   
            
            document.Save();
        }
    }
}
