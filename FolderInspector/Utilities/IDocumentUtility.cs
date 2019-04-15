using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderInspector.Utilities
{
    internal interface IDocumentUtility
    {
        void UpdateHeaderFooter(string filePath, string headerText, string footerText);
    }
}
