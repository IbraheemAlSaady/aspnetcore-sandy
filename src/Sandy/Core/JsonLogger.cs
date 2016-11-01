
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
        }

        public void LogInfo(Microsoft.AspNetCore.Http.HttpRequest request, string message = "")
        {
            try
            {
                var log = GetRequestLog(request, message, LogLevel.Info);
                FileWriter<RequestLog>.Log(log, Options.InfoFilePath);
            }
            catch { throw; }

        }

        public void LogError(Microsoft.AspNetCore.Http.HttpRequest request, Exception exception,
            string errorMessage = "")
        {
            try
            {
                var log = GetErrorLog(request, LogLevel.Error, exception, errorMessage);
                FileWriter<ErrorLog>.Log(log, Options.ErrorFilePath);
            }
            catch { throw; }
        }

        public void LogError(Microsoft.AspNetCore.Http.HttpRequest request,
            string errorMessage = "")
        {
            try
            {
                var log = GetErrorLog(request, LogLevel.Error, errorMessage);
                FileWriter<ErrorLog>.Log(log, Options.ErrorFilePath);
            }
            catch { throw; }
        }

        public void LogDebug(Microsoft.AspNetCore.Http.HttpRequest request, string message = "")
        {
            try
            {
                var log = GetRequestLog(request, message, LogLevel.Debug);
                FileWriter<RequestLog>.Log(log, Options.DebugFilePath);
            }
            catch { throw; }
        }

        public void LogWarning(Microsoft.AspNetCore.Http.HttpRequest request, string message = "")
        {
            try
            {
                var log = GetRequestLog(request, message, LogLevel.Warning);
                FileWriter<RequestLog>.Log(log, Options.WarningFilePath);
            }
            catch { throw; }
        }

        public void LogFatal(Microsoft.AspNetCore.Http.HttpRequest request, Exception exception,
           string errorMessage = "")
        {
            try
            {
                var log = GetErrorLog(request, LogLevel.Fatal, exception, errorMessage);
                FileWriter<ErrorLog>.Log(log, Options.FatalFilePath);
            }
            catch { throw; }
        }

        public void LogFatal(Microsoft.AspNetCore.Http.HttpRequest request, string errorMessage = "")
        {
            try
            {
                var log = GetErrorLog(request, LogLevel.Fatal, errorMessage);
                FileWriter<ErrorLog>.Log(log, Options.FatalFilePath);
            }
            catch { throw; }
        }

        #region Helpers

        private RequestLog GetRequestLog(Microsoft.AspNetCore.Http.HttpRequest request, string message,
            LogLevel level)
        {
            RequestLog log = new RequestLog();
            log.Req = request.Extract();
            log.HostName = request.Host.Host;
            log.Name = Options.AppName;
            log.Message = message;
            log.LevelId = (int)level;
            return log;
        }

        private ErrorLog GetErrorLog(Microsoft.AspNetCore.Http.HttpRequest request, LogLevel level,
            Exception exception, string message)
        {
            var log = new ErrorLog();
            log.Req = request.Extract();
            log.HostName = request.Host.Host;
            log.Name = Options.AppName;
            log.Message = message ?? exception.Message;
            log.LevelId = (int)level;
            log.Stack = exception.InnerException?.StackTrace;
            log.Msg = exception.InnerException?.Message;
            log.Code = "Error";

            return log;
        }

        private ErrorLog GetErrorLog(Microsoft.AspNetCore.Http.HttpRequest request, LogLevel level,
            string message)
        {
            var log = new ErrorLog();
            log.Req = request.Extract();
            log.HostName = request.Host.Host;
            log.Name = Options.AppName;
            log.Message = message;
            log.LevelId = (int)level;
            log.Stack = "";
            log.Msg = message;
            log.Code = "Error";

            return log;
        }

        #endregion
    }
}
