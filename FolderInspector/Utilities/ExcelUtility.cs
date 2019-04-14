/*
 * Author:  Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub:  @ClydeDz 
 */

using ClosedXML.Excel;

namespace FolderInspector.Utilities
{
    /// <summary>
    /// Contains methods to edit an Excel file
    /// </summary>
    internal class ExcelUtility
    {
        /// <summary>
        /// Edits the header and footer of the Excel file at the specified path.
        /// </summary>
        /// <param name="filePath">Complete file path</param>
        internal static void EditExcelHeaderFooter(string filePath)
        {
            var workbook = new XLWorkbook(filePath);
            var worksheet = workbook.Worksheets.Worksheet(1);

            worksheet.PageSetup.Header.Left.AddText(FolderUtility.GetHeaderText(filePath));
            worksheet.PageSetup.Footer.Left.AddText(FolderUtility.GetFooterText(filePath));

            workbook.SaveAs(filePath);
        }

    }
}
