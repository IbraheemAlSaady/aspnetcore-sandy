using Sandy.Extensions;
using Sandy.LogWriters;
using Sandy.Models;
using Sandy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandy.Core
{
    internal static class Logger
    {
        internal static void LogInfo(Microsoft.AspNetCore.Http.HttpRequest request, string message = "")
        {
            try
            {
                var log = GetRequestLog(request, message, LogLevel.Info);
                FileWriter<RequestLog>.Log(log, Constants.InfoFilePath);
            }
            catch { throw; }

        }


        internal static void LogError(Microsoft.AspNetCore.Http.HttpRequest request, Exception exception,
            string errorMessage = "")
        {
            try
            {
                var log = GetErrorLog(request, LogLevel.Error, exception, errorMessage);
                FileWriter<ErrorLog>.Log(log, Constants.ErrorFilePath);
            }
            catch { throw; }
        }

        internal static void LogError(Microsoft.AspNetCore.Http.HttpRequest request,
            string errorMessage = "")
        {
            try
            {
                var log = GetErrorLog(request, LogLevel.Error, errorMessage);
                FileWriter<ErrorLog>.Log(log, Constants.ErrorFilePath);
            }
            catch { throw; }
        }

        internal static void LogDebug(Microsoft.AspNetCore.Http.HttpRequest request, string message = "")
        {
            try
            {
                var log = GetRequestLog(request, message, LogLevel.Debug);
                FileWriter<RequestLog>.Log(log, Constants.DebugFilePath);
            }
            catch { throw; }
        }

        internal static void LogWarning(Microsoft.AspNetCore.Http.HttpRequest request, string message = "")
        {
            try
            {
                var log = GetRequestLog(request, message, LogLevel.Warning);
                FileWriter<RequestLog>.Log(log, Constants.WarningFilePath);
            }
            catch { throw; }
        }

        internal static void LogFatal(Microsoft.AspNetCore.Http.HttpRequest request, Exception exception,
            string errorMessage = "")
        {
            try
            {
                var log = GetErrorLog(request, LogLevel.Fatal, exception, errorMessage);
                FileWriter<ErrorLog>.Log(log, Constants.FatalFilePath);
            }
            catch { throw; }
        }

        internal static void LogFatal(Microsoft.AspNetCore.Http.HttpRequest request,
            string errorMessage = "")
        {
            try
            {
                var log = GetErrorLog(request, LogLevel.Fatal, errorMessage);
                FileWriter<ErrorLog>.Log(log, Constants.FatalFilePath);
            }
            catch { throw; }
        }

        #region Helpers
        private static RequestLog GetRequestLog(Microsoft.AspNetCore.Http.HttpRequest request, string message,
            LogLevel level)
        {
            RequestLog log = new RequestLog();
            log.Req = request.Extract();
            log.HostName = request.Host.Host;
            log.Name = Constants.AppName;
            log.Message = message;
            log.LevelId = (int)level;
            return log;
        }

        private static ErrorLog GetErrorLog(Microsoft.AspNetCore.Http.HttpRequest request, LogLevel level,
            Exception exception, string message)
        {
            var log = new ErrorLog();
            log.Req = request.Extract();
            log.HostName = request.Host.Host;
            log.Name = Constants.AppName;
            log.Message = message ?? exception.Message;
            log.LevelId = (int)level;
            log.Error.Stack = exception.InnerException?.StackTrace;
            log.Error.Msg = exception.InnerException?.Message ?? message;
            log.Error.Code = exception.GetType().ToString();

            return log;
        }

        private static ErrorLog GetErrorLog(Microsoft.AspNetCore.Http.HttpRequest request, LogLevel level,
            string message)
        {
            var log = new ErrorLog();
            log.Req = request.Extract();
            log.HostName = request.Host.Host;
            log.Name = Constants.AppName;
            log.Message = message;
            log.LevelId = (int)level;
            log.Error.Stack = "";
            log.Error.Msg = message;
            log.Error.Code = "Error";

            return log;
        }
        #endregion
    }
}
