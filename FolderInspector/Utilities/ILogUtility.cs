﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderInspector.Utilities
{
    public interface ILogUtility
    {
        void WriteLog(string message);
        void WriteError(string message);
    }
}