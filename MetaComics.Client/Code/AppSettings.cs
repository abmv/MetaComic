using System;
using System.Configuration;

namespace MetaComics.Client.Code
{
    /// <summary>
    /// Application Setting Properties Class.
    /// </summary>
    internal class AppSettings
    {
        public static bool ActivePlugins
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["ActivePlugins"]); }
        }

        public static string ComicArchiveFolder
        {
            get { return ConfigurationManager.AppSettings["ComicArchiveFolder"]; }
        }

        public static string DisclamimerAgree
        {
            get { return ConfigurationManager.AppSettings["DisclamimerAgree"]; }
        }



        public static DateTime ReleaseDate
        {
            get { return DateTime.Parse(ConfigurationManager.AppSettings["ReleaseDate"]); }
        }

        public static bool StartMinimized
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["StartMinimized"]); }
        }

        public static bool StartOnWindowsLogon
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["StartOnWindowsLogon"]); }
        }


        public static bool LoggingMode
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["LoggingMode"]); }
        }

        public static bool Logging
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["Logging"]); }
        }
    }
}