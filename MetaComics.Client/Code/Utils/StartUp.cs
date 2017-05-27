using System;
using Microsoft.Win32;
using NLog;

namespace MetaComics.Client.Code
{
    /// <summary>
    /// Utility.
    /// </summary>
    public class Util
    {
        private const string RUN_LOCATION = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Sets the autostart value for the assembly.
        /// </summary>
        /// <param name="keyName">Registry Key Name</param>
        /// <param name="assemblyLocation">Assembly location (e.g. Assembly.GetExecutingAssembly().Location)</param>
        public static void SetAutoStart(string keyName, string assemblyLocation)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
                key.SetValue(keyName, assemblyLocation);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        /// <summary>
        /// Returns whether auto start is enabled.
        /// </summary>
        /// <param name="keyName">Registry Key Name</param>
        /// <param name="assemblyLocation">Assembly location (e.g. Assembly.GetExecutingAssembly().Location)</param>
        public static bool IsAutoStartEnabled(string keyName, string assemblyLocation)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RUN_LOCATION);
            if (key == null)
                return false;
            var value = (string) key.GetValue(keyName);
            if (value == null)
                return false;
            return (value == assemblyLocation);
        }

        /// <summary>
        /// Unsets the autostart value for the assembly.
        /// </summary>
        /// <param name="keyName">Registry Key Name</param>
        public static void UnSetAutoStart(string keyName)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
                key.DeleteValue(keyName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }
    }
}