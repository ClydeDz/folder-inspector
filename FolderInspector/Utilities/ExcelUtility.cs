using ClosedXML.Excel;

namespace FolderInspector.Utilities
{
    /// <summary>
    /// Contains methods to edit an Excel file
    /// </summary>
    internal class ExcelUtility: IDocumentUtility
    {
        /// <summary>
        /// Edits the header and footer of the Excel file at the specified path.
        /// </summary>
        /// <param name="filePath">Complete file path</param>
        public void UpdateHeaderFooter(string filePath, string headerText, string footerText)
        {
            var workbook = new XLWorkbook(filePath);
            var worksheet = workbook.Worksheets.Worksheet(1);

            worksheet.PageSetup.Header.Left.AddText(headerText);
            worksheet.PageSetup.Footer.Left.AddText(footerText);

            workbook.SaveAs(filePath);
        }

    }
}
