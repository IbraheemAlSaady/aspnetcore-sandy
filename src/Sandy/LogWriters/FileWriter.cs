using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandy.LogWriters
{
    internal static class FileWriter<T>
    {
        /// <summary>
        /// Logs the log into the specified path
        /// </summary>
        /// <param name="log"></param>
        /// <param name="path"></param>
        internal static void Log(T log, string path)
        {
            try
            {
                CreateIfNotExist(path);
                AppendToLog(log, path);
            }
            catch (System.UnauthorizedAccessException)
            {
                throw new System.Exception("not allowed to write on the specified file, permission is needed.");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        #region Helpers

        /// <summary>
        /// Reads the log and appends the log item to it
        /// </summary>
        /// <param name="log"></param>
        /// <param name="path"></param>
        private static void AppendToLog(T log, string path)
        {
            var json = JsonConvert.SerializeObject(log, Formatting.Indented);
            System.IO.File.AppendAllText(path, json);
        }


        /// <summary>
        /// reads a log using JsonTextReader
        /// </summary>
        /// <param name="log"></param>
        /// <param name="path"></param>
        private static void ReadLog(string path)
        {
            using (System.IO.Stream stream = System.IO.File.OpenRead(path))
            using (System.IO.StreamReader streamReader = new System.IO.StreamReader(stream))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                reader.SupportMultipleContent = true;

                var serializer = new JsonSerializer();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        T log = serializer.Deserialize<T>(reader);
                    }
                }
            }
        }

        /// <summary>
        /// checks if a path exists and if it doesn't it will create the directory
        /// </summary>
        /// <param name="path"></param>
        private static void CreateIfNotExist(string path)
        {
            var directory = System.IO.Path.GetDirectoryName(path);

            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
                GrantAccess(directory);
            }
        }

        /// <summary>
        /// grant a full access to a file path
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        private static bool GrantAccess(string fullPath)
        {
            //DirectorySecurity sec = new DirectorySecurity();
            //DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            //DirectorySecurity dSecurity = dInfo.GetAccessControl();
            //dSecurity.AddAccessRule(new FileSystemAccessRule(new System.Security.Principal.SecurityIdentifier(
            //    System.Security.Principal.WellKnownSidType.WorldSid, null), 
            //    FileSystemRights.FullControl, 
            //    InheritanceFlags.ObjectInherit | 
            //    InheritanceFlags.ContainerInherit, 
            //    PropagationFlags.NoPropagateInherit, 
            //    AccessControlType.Allow));
            //dInfo.SetAccessControl(dSecurity);

            return true;
        }

        #endregion
    }
}
