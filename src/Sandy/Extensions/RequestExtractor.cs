using Microsoft.AspNetCore.Http;
using Sandy.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sandy.Extensions
{
    internal static class RequestExtractor
    {
        internal static string[] _excludedHeaders = { "cookie" };

        /// <summary>
        /// extracts the request information
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static RequestInfo Extract(this HttpRequest request)
        {
            var requestInfo = new RequestInfo();

            requestInfo.Method = request.HttpContext.Request.Method;
            requestInfo.Headers = GetHeaders(request);
            requestInfo.RemoteAddress = request.HttpContext.Connection.RemoteIpAddress.ToString();
            requestInfo.RemotePort = request.HttpContext.Connection.RemotePort.ToString();
            requestInfo.Url = request.Path;
            requestInfo.Body =
                request.Method.ToLowerInvariant() == "post" ?
                new System.IO.StreamReader(request.Body).ReadToEnd() : string.Empty;

            return requestInfo;
        }

        /// <summary>
        /// gets the headers from the request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static Dictionary<string, string> GetHeaders(HttpRequest request)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();

            for (int i = 0; i < request.Headers.Keys.Count; i++)
            {
                var key = request.Headers.Keys.ElementAt(i);
                if (IsHeaderExcluded(key)) continue;

                headers.Add(key, request.Headers[key]);
            }
            return headers;
        }


        /// <summary>
        /// checks if a key header is excluded in the pre defined list
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static bool IsHeaderExcluded(string key)
        {
            return _excludedHeaders.Any(h => h.ToLowerInvariant().Equals(key.ToLowerInvariant()));
        }
    }
}
