using Sandy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandy.Core
{
    public interface IJsonLogger
    {
        /// <summary>
        /// sets and overrides the default options 
        /// </summary>
        /// <param name="options"></param>
        void SetOptions(JsonLoggerOptions options);

        /// <summary>
        /// Logs the rquest information with log level info
        /// </summary>
        /// <param name="request"></param>
        /// <param name="message"></param>
        void LogInfo(Microsoft.AspNetCore.Http.HttpRequest request, string message = "");

        /// <summary>
        /// logs the request information with log level error including exception
        /// </summary>
        /// <param name="request"></param>
        /// <param name="exception"></param>
        /// <param name="errorMessage"></param>
        void LogError(Microsoft.AspNetCore.Http.HttpRequest request,
            Exception exception, string errorMessage);

        /// <summary>
        /// logs the request information with log level error
        /// </summary>
        /// <param name="request"></param>
        /// <param name="errorMessage"></param>
        void LogError(Microsoft.AspNetCore.Http.HttpRequest request, string errorMessage = "");

        /// <summary>
        /// logs the request information with log level debug
        /// </summary>
        /// <param name="request"></param>
        /// <param name="message"></param>
        void LogDebug(Microsoft.AspNetCore.Http.HttpRequest request, string message  = "");

        /// <summary>
        /// logs the request information with log level warning
        /// </summary>
        /// <param name="request"></param>
        /// <param name="message"></param>
        void LogWarning(Microsoft.AspNetCore.Http.HttpRequest request, string message = "");

        /// <summary>
        /// logs the request information with log level fatal
        /// </summary>
        /// <param name="request"></param>
        /// <param name="message"></param>
        void LogFatal(Microsoft.AspNetCore.Http.HttpRequest request, string message = "");

        /// <summary>
        /// logs the request information with log level fatal including exception
        /// </summary>
        /// <param name="request"></param>
        /// <param name="exception"></param>
        /// <param name="errorMessage"></param>
        void LogFatal(Microsoft.AspNetCore.Http.HttpRequest request, Exception exception,
            string errorMessage = "");
    }
}
