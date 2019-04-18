using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderInspector.Utilities
{
    interface IFolderUtility
    {
        string GetHeaderText(string path = "");
        string GetFooterText(string path = "");
        bool IsWordFile(string filePath);
        bool IsExcelFile(string filePath);
        string GetFileName(string filePath);
        bool IsHelpCommand(string command);
        bool IsConfigurationFileCommand(string command);
        void PrintHeader();
    }
}
