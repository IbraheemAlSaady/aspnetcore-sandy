using Microsoft.AspNetCore.Http;
using Sandy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandy.Extensions
{
    public static class RequestExtension
    {
        /// <summary>
        /// Logs the rquest information with log level info
        /// </summary>
        /// <param name="request"></param>
        /// <param name="message"></param>
        public static void LogInfo(this HttpRequest request, string message = "")
        {
            Logger.LogInfo(request, message);
        }

        /// <summary>
        /// logs the request information with log level debug
        /// </summary>
        /// <param name="request"></param>
        /// <param name="message"></param>
        public static void LogDebug(this HttpRequest request, string message = "")
        {
            Logger.LogDebug(request, message);
        }

        /// <summary>
        /// logs the request information with log level warning
        /// </summary>
        /// <param name="request"></param>
        /// <param name="message"></param>
        public static void LogWarning(this HttpRequest request, string message = "")
        {
            Logger.LogWarning(request, message);
        }

        /// <summary>
        /// logs the request information with log level error including exception
        /// </summary>
        /// <param name="request"></param>
        /// <param name="ex"></param>
        /// <param name="errorMessage"></param>
        public static void LogError(this HttpRequest request, Exception ex, string errorMessage = "")
        {
            Logger.LogError(request, ex, errorMessage);
        }

        /// <summary>
        /// logs the request information with log level error
        /// </summary>
        /// <param name="request"></param>
        /// <param name="errorMessage"></param>
        public static void LogError(this HttpRequest request, string errorMessage = "")
        {
            Logger.LogError(request, errorMessage);
        }

        /// <summary>
        /// logs the request information with log level fatal including exception
        /// </summary>
        /// <param name="request"></param>
        /// <param name="ex"></param>
        /// <param name="errorMessage"></param>
        public static void LogFatal(this HttpRequest request, Exception ex, string errorMessage = "")
        {
            Logger.LogFatal(request, ex, errorMessage);
        }

        /// <summary>
        /// logs the request information with log level fatal
        /// </summary>
        /// <param name="request"></param>
        /// <param name="errorMessage"></param>
        public static void LogFatal(this HttpRequest request, string errorMessage = "")
        {
            Logger.LogFatal(request, errorMessage);
        }
    }
}
