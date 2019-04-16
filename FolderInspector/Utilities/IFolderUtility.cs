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
        void PrintHeader();
    }
}
