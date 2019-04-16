using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderInspector.Utilities
{
    public interface IAppSettingsUtility
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
}
