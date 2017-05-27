using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MetaComics.Client.Code;

namespace MetaComics.Client.UI
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            lblSchedule.Enabled = false;
            txtComicFetchInterval.Enabled = false;
            ctlPeriodGrp.Enabled = false;
            chkVerboseLogging.Enabled = false;
            string keyName = "MetaComic Client";
            string assemblyLocation = Assembly.GetExecutingAssembly().Location; // Or the EXE path.
            if (Util.IsAutoStartEnabled(keyName, assemblyLocation))
                chkLoadWindowsOnStart.Checked = true;
            else
            {
                chkLoadWindowsOnStart.Checked = false;
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ctlPageColor.Value = Color.FromArgb(AppSettings.PDFPageColor);
            if (config.AppSettings.Settings["EnableAlternatePageBackroundColour"].Value == "True")
            {
                chkEnableAlternatePageBackroundColour.Checked = true;
                lblNextPageColor.Enabled = true;
                ctlAltPageColor.Enabled = true;
                ctlAltPageColor.Value = Color.FromArgb(AppSettings.PDFAltPageColor);
            }
            else
            {
                chkEnableAlternatePageBackroundColour.Checked = false;
                lblNextPageColor.Enabled = false;
                ctlAltPageColor.Enabled = false;
            }
            if (config.AppSettings.Settings["EnableScheduling"].Value == "True")
            {
                chkEnableScheduling.Checked = true;
                lblSchedule.Enabled = true;
                txtComicFetchInterval.Enabled = true;
                ctlPeriodGrp.Enabled = true;
            }
            if (config.AppSettings.Settings["ConfimApplicationExit"].Value == "True")
            {
                chkConfirmExit.Checked = true;
            }
            if (String.IsNullOrEmpty(config.AppSettings.Settings["ComicArchiveFolder"].Value))
            {
                txtComicArchiveFolder.Text = Directory.GetCurrentDirectory() + "\\Strip";
                //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["ComicArchiveFolder"].Value = Directory.GetCurrentDirectory() + "\\Strip";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            txtComicArchiveFolder.Text = config.AppSettings.Settings["ComicArchiveFolder"].Value;
            txtComicComRSSFeed.Text = config.AppSettings.Settings["ComicDotComRSSFeedURL"].Value;
            if (config.AppSettings.Settings["ComicFetchIntervalTimeFormat"].Value == "Hours")
                ctlHoursCheck.Checked = true;
            if (config.AppSettings.Settings["ComicFetchIntervalTimeFormat"].Value == "Minutes")
                ctlMinutesCheck.Checked = true;
            if (config.AppSettings.Settings["ComicFetchIntervalTimeFormat"].Value == "Seconds")
                ctlSeconds.Checked = true;
            if (config.AppSettings.Settings["LoggingMode"].Value == "Verbose")
                chkVerboseLogging.Checked = true;
            else
            {
                chkVerboseLogging.Checked = false;
            }
            if (config.AppSettings.Settings["Logging"].Value == "True")
            {
                chkEnableLogging.Checked = true;
                btnOpenLogFolder.Enabled = true;
            }
            else
            {
                chkEnableLogging.Checked = false;
                btnOpenLogFolder.Enabled = false;
            }
            if (config.AppSettings.Settings["StartMinimized"].Value == "True")
                chkStartMinimized.Checked = true;
            else
            {
                chkStartMinimized.Checked = false;
            }
            txtComicFetchInterval.Text = config.AppSettings.Settings["ComicFetchInterval"].Value;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Color pdfPageBackgroundColour = ctlPageColor.Value;
            Color pdfAltPageBackgroundColour = ctlAltPageColor.Value;
            //config.AppSettings.Settings["PDFPageColor"].Value = pdfPageBackgroundColour.R.ToString() + pdfPageBackgroundColour.G.ToString() + pdfPageBackgroundColour.G.ToString();
            //config.AppSettings.Settings["PDFAltPageColor"].Value = pdfAltPageBackgroundColour.R.ToString() + pdfAltPageBackgroundColour.G.ToString() + pdfAltPageBackgroundColour.G.ToString();
            config.AppSettings.Settings["PDFPageColor"].Value = pdfPageBackgroundColour.ToArgb().ToString();
            config.AppSettings.Settings["PDFAltPageColor"].Value = pdfAltPageBackgroundColour.ToArgb().ToString();
            if (chkEnableScheduling.Checked)
            {
                config.AppSettings.Settings["EnableScheduling"].Value = "True";
            }
            else
            {
                config.AppSettings.Settings["EnableScheduling"].Value = "False";
            }
            if (chkConfirmExit.Checked)
            {
                config.AppSettings.Settings["ConfimApplicationExit"].Value = "True";
            }
            else
            {
                config.AppSettings.Settings["ConfimApplicationExit"].Value = "False";
            }
            if (ctlHoursCheck.Checked)
            {
                double x = TimeSpanUtil.ConvertHoursToMinutes(Convert.ToDouble(txtComicFetchInterval.Text));
                config.AppSettings.Settings["ComicFetchInterval"].Value = x.ToString();
                config.AppSettings.Settings["ComicFetchIntervalTimeFormat"].Value = "Hours";
            }
            if (ctlSeconds.Checked)
            {
                double x = TimeSpanUtil.ConvertSecondsToMinutes(Convert.ToDouble(txtComicFetchInterval.Text));
                config.AppSettings.Settings["ComicFetchInterval"].Value = x.ToString();
                config.AppSettings.Settings["ComicFetchIntervalTimeFormat"].Value = "Seconds";
            }
            if (ctlMinutesCheck.Checked)
            {
                double x = (Convert.ToDouble(txtComicFetchInterval.Text));
                config.AppSettings.Settings["ComicFetchInterval"].Value = x.ToString();
                config.AppSettings.Settings["ComicFetchIntervalTimeFormat"].Value = "Minutes";
            }
            config.AppSettings.Settings["ComicArchiveFolder"].Value = txtComicArchiveFolder.Text + "\\";
            config.AppSettings.Settings["ComicDotComRSSFeedURL"].Value = txtComicComRSSFeed.Text;
            if (chkEnableLogging.Checked)
            {
                config.AppSettings.Settings["Logging"].Value = "True";
            }
            else
            {
                config.AppSettings.Settings["Logging"].Value = "False";
            }
            if (chkVerboseLogging.Checked)
            {
                config.AppSettings.Settings["LoggingMode"].Value = "Verbose";
            }
            else
            {
                config.AppSettings.Settings["LoggingMode"].Value = "Default";
            }
            if (chkStartMinimized.Checked)
            {
                config.AppSettings.Settings["StartMinimized"].Value = "True";
            }
            else
            {
                config.AppSettings.Settings["StartMinimized"].Value = "False";
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void btnTempImageFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog(this);
            txtComicArchiveFolder.Text = folderBrowserDialog.SelectedPath;
        }

        private void chkLoadWindowsOnStart_CheckedChanged(object sender, EventArgs e)
        {
            string keyName = "MetaComic Client";
            string assemblyLocation = Assembly.GetExecutingAssembly().Location + " background"; // Or the EXE path.
            if (chkLoadWindowsOnStart.Checked)
            {
                // Set Auto-start.
                Util.SetAutoStart(keyName, assemblyLocation);
            }
            else
            {
                //// Unset Auto-start.
                if (Util.IsAutoStartEnabled(keyName, assemblyLocation))
                    Util.UnSetAutoStart(keyName);
            }
        }

        private void ctlHoursCheck_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ctlMinutesCheck_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ctlSeconds_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnOpenLogFolder_Click(object sender, EventArgs e)
        {
            //Application.StartupPath
            string myPath = Application.StartupPath + "\\" + "log";
            var prc = new Process();
            prc.StartInfo.FileName = myPath;
            prc.Start();
        }

        private void chkEnableLogging_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableLogging.Checked)
            {
                chkVerboseLogging.Enabled = true;
                btnOpenLogFolder.Enabled = true;
            }
            else
            {
                chkVerboseLogging.Enabled = false;
                btnOpenLogFolder.Enabled = false;
            }
        }

        private void chkEnableLogging_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkEnableLogging.Checked)
            {
                chkVerboseLogging.Enabled = true;
            }
            else
            {
                chkVerboseLogging.Enabled = false;
            }
        }

        private void chkEnableScheduling_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableScheduling.Checked)
            {
                lblSchedule.Enabled = true;
                txtComicFetchInterval.Enabled = true;
                ctlPeriodGrp.Enabled = true;
            }
            else
            {
                lblSchedule.Enabled = false;
                txtComicFetchInterval.Enabled = false;
                ctlPeriodGrp.Enabled = false;
            }
        }

        private void chkEnableAlternatePageBackroundColour_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableAlternatePageBackroundColour.Checked)
            {
                lblNextPageColor.Enabled = true;
                ctlAltPageColor.Enabled = true;
            }
            else
            {
                lblNextPageColor.Enabled = false;
                ctlAltPageColor.Enabled = false;
            }
        }
    }
}