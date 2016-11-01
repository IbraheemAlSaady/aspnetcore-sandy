
using Sandy.Extensions;
using Sandy.LogWriters;
using Sandy.Models;
using Sandy.Models.Enums;
using System;

namespace Sandy.Core
{
    public class JsonLogger : IJsonLogger
    {
        internal JsonLoggerOptions Options { get; private set; }

        public JsonLogger()
        {
            Options = new JsonLoggerOptions()
            {
                AppName = "DefaultApp",
                InfoFilePath = "C:/DefaultApp/Logs/DefaultApp-info.log",
                ErrorFilePath = "C:/DefaultApp/Logs/DefaultApp-error.log",
                DebugFilePath = "C:/DefaultApp/Logs/DefaultApp-debug.log",
                WarningFilePath = "C:/DefaultApp/Logs/DefaultApp-warning.log",
                FatalFilePath = "C:/DefaultApp/Logs/DefaultApp-fatal.log",
            };
        }

        public void SetOptions(JsonLoggerOptions options)
        {
            this.Options.AppName = options.AppName ?? this.Options.AppName;
            this.Options.InfoFilePath = options.InfoFilePath ?? this.Options.InfoFilePath ;
            this.Options.ErrorFilePath = options.ErrorFilePath ?? this.Options.ErrorFilePath;
            this.Options.DebugFilePath = options.DebugFilePath ?? this.Options.DebugFilePath;
            this.Options.WarningFilePath = options.WarningFilePath ?? this.Options.WarningFilePath;
            this.Options.FatalFilePath = options.FatalFilePath ?? this.Options.FatalFilePath;
            Constants.SetOptions(this.Options);
        }

        public void LogInfo(Microsoft.AspNetCore.Http.HttpRequest request, string message = "")
        {
            Logger.LogInfo(request, message);
        }

        public void LogError(Microsoft.AspNetCore.Http.HttpRequest request, Exception exception,
            string errorMessage = "")
        {
            Logger.LogError(request, exception, errorMessage);
        }

        public void LogError(Microsoft.AspNetCore.Http.HttpRequest request,
            string errorMessage = "")
        {
            Logger.LogError(request, errorMessage);
        }

        public void LogDebug(Microsoft.AspNetCore.Http.HttpRequest request, string message = "")
        {
            Logger.LogDebug(request, message);
        }

        public void LogWarning(Microsoft.AspNetCore.Http.HttpRequest request, string message = "")
        {
            Logger.LogWarning(request, message);
        }

        public void LogFatal(Microsoft.AspNetCore.Http.HttpRequest request, Exception exception,
           string errorMessage = "")
        {
            Logger.LogFatal(request, exception, errorMessage);
        }

        public void LogFatal(Microsoft.AspNetCore.Http.HttpRequest request, string errorMessage = "")
        {
            Logger.LogFatal(request, errorMessage);
        }
    }
}
