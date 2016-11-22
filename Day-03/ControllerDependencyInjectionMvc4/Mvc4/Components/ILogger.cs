using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace Mvc4.Components
{
    [InheritedExport]
    public interface ILogger
    {
        void Log(string logData);
    }
}