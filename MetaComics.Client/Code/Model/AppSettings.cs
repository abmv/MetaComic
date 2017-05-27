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

        public static int ComicFetchInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["ComicFetchInterval"]); }
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

        public static bool EnableScheduling
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["EnableScheduling"]); }
        }

        public static string ComicFetchIntervalTimeFormat
        {
            get { return (ConfigurationManager.AppSettings["ComicFetchIntervalTimeFormat"]); }
        }

        public static string ComicDotComRSSFeedURL
        {
            get { return (ConfigurationManager.AppSettings["ComicDotComRSSFeedURL"]); }
        }

        public static bool ConfimApplicationExit
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["ConfimApplicationExit"]); }
        }

        public static bool ViewerLastSelected
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["ViewerLastSelected"]); }
        }

        public static bool ShowWelcomefcScreen
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["ShowWelcomefcScreen"]); }
        }

        public static int PDFPageColor
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["PDFPageColor"]); }
        }

        public static int PDFAltPageColor
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["PDFAltPageColor"]); }
        }

        public static bool EnableAlternatePageBackroundColour
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["EnableAlternatePageBackroundColour"]); }
        }
    }
}