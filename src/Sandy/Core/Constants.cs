using Sandy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandy.Core
{
    internal static class Constants
    {
        internal static string AppName { get; private set; }
        internal static string InfoFilePath { get; private set; }
        internal static string ErrorFilePath { get; private set; }
        internal static string DebugFilePath { get; private set; }
        internal static string WarningFilePath { get; private set; }
        internal static string FatalFilePath { get; private set; }

        internal static void SetOptions(JsonLoggerOptions options)
        {
            AppName = options.AppName ?? options.AppName;
            InfoFilePath = options.InfoFilePath ?? options.InfoFilePath;
            ErrorFilePath = options.ErrorFilePath ?? options.ErrorFilePath;
            DebugFilePath = options.DebugFilePath ?? options.DebugFilePath;
            WarningFilePath = options.WarningFilePath ?? options.WarningFilePath;
            FatalFilePath = options.FatalFilePath ?? options.FatalFilePath;
        }
    }
}
