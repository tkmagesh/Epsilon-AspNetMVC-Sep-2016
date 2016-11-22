using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4.Components
{
public class DefaultLogger : ILogger
{
    public void Log(string logData)
    {
        System.Diagnostics.Debug.WriteLine(logData, "default");
    }
}
}