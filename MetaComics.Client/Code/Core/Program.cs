using System;
using System.Threading;
using System.Windows.Forms;
using ExceptionReporting;
using MetaComics.Client.Code;
using MetaComics.Client.Plugin;
using MetaComics.Client.UI;
using NLog;
using NLog.Config;

namespace MetaComics.Client
{
    internal static class Program
    {
        // private static Logger _logger = LogManager.GetCurrentClassLogger();
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.IsTerminating)
            {
                _logger.Info("Application is terminating due to an unhandled exception in a secondary thread.");
            }
            LogFatalException(e.ExceptionObject as Exception);
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            LogFatalException(e.Exception);
        }

        private static void LogFatalException(Exception exc)
        {
            string message = String.Format(
                "(Application version {0}) {1}", Application.ProductVersion, exc.Message);
            _logger.FatalException(message, exc);
            // Application.Exit(); // Encouraged, but not required
        }

        [STAThread]
        private static void Main(string[] args)
        {
            if (AppSettings.Logging == false)
            {
                //NLog.Config.XmlLoggingConfiguration servers = (NLog.Config.XmlLoggingConfiguration)ConfigurationManager.GetSection("nlog");
                LoggingRuleCollection rules = LogManager.Configuration.LoggingRules;
                foreach (LoggingRule rule in rules)
                {
                    rule.DisableLoggingForLevel(LogLevel.Trace);
                }
                LogManager.ReconfigExistingLoggers();
                LogManager.Configuration.RemoveTarget("file");
            }
            if (AppSettings.Logging)
            {
                //NLog.Config.XmlLoggingConfiguration servers = (NLog.Config.XmlLoggingConfiguration)ConfigurationManager.GetSection("nlog");
                LoggingRuleCollection rules = LogManager.Configuration.LoggingRules;
                foreach (LoggingRule rule in rules)
                {
                    rule.IsLoggingEnabledForLevel(LogLevel.Trace);
                }
                LogManager.ReconfigExistingLoggers();
                LogManager.Configuration.RemoveTarget("file");
            }
            Application.ThreadException += OnThreadException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            try
            {
                using (var spi = new SingleProgramInstance())
                {
                    if (spi.IsSingleInstance)
                    {
                        if (args.Length > 0)
                        {
                            switch (args[0].ToUpper())
                            {
                                case "BACKGROUND":
                                    //  int result = 100 / int.Parse("0");
                                    _logger.Trace("Recieved parameter as background.Running in system tray.");
                                    Application.EnableVisualStyles();
                                    Application.SetCompatibleTextRenderingDefault(false);
                                    var mainUi = new MainUI();
                                    mainUi.notifyIcon.Visible = true;
                                    mainUi.Hide();
                                    Application.Run();
                                    break;
                                case "SILENT":
                                    _logger.Trace("Running in slient mode");
                                    foreach (IComicPlugin plugin in PluginInfo.internalList)
                                    {
                                        try
                                        {
                                            plugin.ReadComicStripFeed();
                                            _logger.Trace("Reading comic strip for " + plugin.Name);
                                        }
                                        catch (Exception ex)
                                        {
                                            _logger.Trace(ex);
                                            continue;
                                        }
                                    }
                                    break;
                                default:
                                    // int result = 100 / int.Parse("0");
                                    _logger.Trace("Running in normal mode");
                                    Application.EnableVisualStyles();
                                    Application.SetCompatibleTextRenderingDefault(false);
                                    Application.Run(new MainUI());
                                    break;
                            }
                            //if (args[0].ToUpper() == "BACKGROUND")
                            //{
                            //    //  int result = 100 / int.Parse("0");
                            //    _logger.Trace("Recieved parameter as background.Running in system tray.");
                            //    Application.EnableVisualStyles();
                            //    Application.SetCompatibleTextRenderingDefault(false);
                            //    var mainUi = new MainUI();
                            //    mainUi.notifyIcon.Visible = true;
                            //    mainUi.Hide();
                            //    Application.Run();
                            //}
                            //else
                            //{
                            //    //  int result = 100 / int.Parse("0");
                            //    Application.EnableVisualStyles();
                            //    Application.SetCompatibleTextRenderingDefault(false);
                            //    _logger.Trace("Running in normal mode");
                            //    Application.Run(new MainUI());
                            //}
                        }
                        else
                        {
                            // int result = 100 / int.Parse("0");
                            _logger.Trace("Running in normal mode");
                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);
                            Application.Run(new MainUI());
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "One copy of MetaComic Client is already running \n Only one instance of the MetaComic Client application can run at a time.",
                            "Application Information: Multiple Instance Detected ! ", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        spi.RaiseOtherProcess();
                    }
                }
            }
            catch (Exception ex)
            {
                var reporter = new ExceptionReporter();
                reporter.ReadConfig(); // optionally, read properties from the application's config file
                reporter.Config.ShowSysInfoTab = false; // alternatively, set properties programmatically
                reporter.Config.ShowFlatButtons = true; // this particular config is code-only
                reporter.Config.EmailReportAddress = "mcdailydilbert@gmail.com";
                reporter.Show(ex);
                _logger.Error(ex);
            }
        }
    }
}