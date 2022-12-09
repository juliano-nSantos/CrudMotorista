using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace Infra.Shared.Utils
{
    public static class Constants
    {
        private static IConfigurationBuilder GetConfigurationBuilder()
        {
            return new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");
        }

        public static string GetParameterById(string key)
        {
            var builder = GetConfigurationBuilder();
            var config = builder.Build();

            return config[$"Parameters:{key}"];
        }

        public static string Secret()
        {
            var builder = GetConfigurationBuilder();
            var config = builder.Build();

            return config[$"Seguranca:Token"].ToString();
        }

        public static string NameBaseMongoDB()
        {
            return GetParameterById("NameDataBaseMongoDb");
        }

        public static string Path()
        {
            return GetParameterById("Path");
        }

        public static string WriteDirectory(string directory)
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            string pathYear = string.Empty;
            pathYear = Path() + DateTime.Now.Year;
            string pathMonth2 = string.Empty;
            pathMonth2 = pathYear + "\\" + culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month));
            string pathDay2 = string.Empty;
            pathDay2 = pathMonth2 + "\\" + DateTime.Now.Day + "\\";
            string pathDirectory2 = string.Empty;
            pathDirectory2 = pathDay2 + "\\" + directory + "\\";

            ValidateDirectory(pathYear);
            ValidateDirectory(pathMonth2);
            ValidateDirectory(pathDay2);
            ValidateDirectory(pathDirectory2);

            return pathDirectory2;
        }

        private static void ValidateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {

                }
            }
        }
    }
}