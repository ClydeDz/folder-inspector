/*
 * Author: Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub: @ClydeDz
 * Email: clydedsouza[at]outlook[dot]com
 */

using ClosedXML.Excel;

namespace FolderInspector.Services
{
    /// <summary>
    /// Contains methods to edit an Excel file
    /// </summary>
    public class ExcelService
    {
        /// <summary>
        /// Edits the header and footer of the Excel file at the specified path.
        /// </summary>
        /// <param name="filePath">Complete file path</param>
        public static void EditExcelHeaderFooter(string filePath)
        {
            var workbook = new XLWorkbook(filePath);
            var worksheet = workbook.Worksheets.Worksheet(1);

            worksheet.PageSetup.Header.Left.AddText(FolderService.GetHeaderText(filePath));
            worksheet.PageSetup.Footer.Left.AddText(FolderService.GetFooterText(filePath));

            workbook.SaveAs(filePath);
        }

    }
}
