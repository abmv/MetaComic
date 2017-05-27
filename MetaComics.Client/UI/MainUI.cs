using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using FullScreenMode;
using MetaComics.Client.Code;
using MetaComics.Client.Plugin;
using NLog;
using Timer = System.Windows.Forms.Timer;

namespace MetaComics.Client.UI
{
    public partial class MainUI : Form
    {
        // Creates a delegate with the same signature as the method used for a long operation
        // In this case we'll use SomeLongOperation()
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public static string[] strArray;
        public static List<string> activePluginList;
        public static string currentFilePath;
        public static string currentFileName;
        private static string xfilename;
        private static readonly IList<string> todaycomiclist = new List<string>();
        private readonly FullScreen _FullScreen;
        private readonly Timer timerx = new Timer();
        private readonly Timer timery = new Timer();
        private bool bResult;
        private int begin;
        private Category cat;
        private int end;
        private int file_count;
        private string[] folderFile;
        private int selected;
        private string strAction;
        private string strExp;

        //const and dll functions for moving form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //call functions to move the form in your form's MouseDown event
        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public MainUI()
        {
            InitializeComponent();
            stripPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _FullScreen = new FullScreen(this);
            //tmrFade.Enabled = true;
            activePluginList = new List<string>();
            string strValue = ConfigurationManager.AppSettings["ActivePlugins"];
            _logger.Trace(strValue);
            strArray = strValue.Split(',');
            var arList = new ArrayList();
            for (int i = 0; i < strArray.Length; i++)
            {
                arList.Add(strArray[i]);
                activePluginList.Add(strArray[i]);
            }
            LoadPlugins();
            FillCombo();
            toolStripStatusLabel1.Text = DateTime.Now.ToString("F");
            if (File.Exists(Application.StartupPath + "\\" + "MetaComics.jpg"))
                stripPictureBox.Image = Image.FromFile(Application.StartupPath + "\\" + "MetaComics.jpg");
            if (AppSettings.EnableScheduling)
            {
                timerx.Tick += time_Tick;
            }
        }

        private void SetTimer()
        {
            int timeInterval;
            try
            {
                //timeInterval = 2000;
                //Convert.ToInt32(AppSettings.ComicFetchInterval)*60000;
                timeInterval = AppSettings.ComicFetchInterval*60000;
                timerx.Interval = timeInterval;
                timerx.Enabled = true;
            }
            catch (Exception ex)
            {
                // UIHelper.WriteLogError("The following exception occurred " + ex.Message);
                // UIHelper.WriteLogError(ex.Message);
                // timeInterval = 20;
                // UIHelper.WriteLog("Proceeding with Time Interval " + timeInterval.ToString() + "  due to exception.");
                //timerx.Interval = timeInterval * 60000;
                //timerx.Enabled = true;
            }
        }

        private void time_Tick(object sender, EventArgs e)
        {
            timerx.Enabled = false;
            //UIHelper.WriteLog("Automated Transfer Operation Tiggered: " + DateTime.Now.ToString());
            StartTransfer();
            timerx.Enabled = true;
        }

        private void StartTransfer()
        {
            //// create an instance of SomeLongOperationDelegate
            SomeLongOperationDelegate someLongOperationDelegate = SomeLongOperation;
            //// start asynchronous operation, pass someLongOperationDelegate as a parameter, so we can get it back later on callback
            someLongOperationDelegate.BeginInvoke(SomeLongOperationCallBack, someLongOperationDelegate);
            //CalvinAndHobbesComicPlugin doonesburyPlugin = new CalvinAndHobbesComicPlugin();
            //doonesburyPlugin.ReadComicStripFeed();
        }

        /// <summary>
        /// Sets any controls on the form that you want to have set prior to starting the long operation
        /// </summary>
        /// <param name="Enabled">Enable or disable controls</param>
        private void SetFormControls(bool Enabled)
        {
            // update any controls here, if you want to (such as enable or disable controls)
            // this.buttonGo.Enabled = Enabled;
            btnExit.Enabled = Enabled;
            btnMinimize.Enabled = Enabled;
            btnArchives.Enabled = Enabled;
            FillCombo();
        }

        /// <summary>
        /// Checks whether or not an Invoke is required and calls the method accordingly
        /// </summary>
        /// <param name="value">value of string to go into the listbox</param>
        private void UpdateUI(string value)
        {
            // if the calling thread is not the same thread that created the controls to be updated
            // call an Invoke to update controls
            if (InvokeRequired)
                Invoke(new UpdateUIDelegate(UpdateUIHelper), new object[] {value});
            else
                UpdateUIHelper(value);
        }

        /// <summary>
        /// Updates the user interface with whatever needs to be updated
        /// </summary>
        /// <param name="value">value of string to go into the listbox</param>
        private void UpdateUIHelper(string value)
        {
            //listboxResults.Items.Add(
            //    new StringBuilder(value).
            //        Append(" (Parent Managed TID: ").
            //        Append(Thread.CurrentThread.ManagedThreadId.ToString()).
            //        Append(")").ToString());
            listboxResults.Items.Add(
                new StringBuilder(value));
            listboxResults.SelectedIndex = (listboxResults.Items.Count - 1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //if(NetChecker.CheckIfNetConnectionAvailable())
            //{
            //    DialogResult dlgRes;
            //    dlgRes =
            //        MessageBox.Show("MetaComic did not detect net connection.", "Application Information",
            //                        MessageBoxButtons.OKCancel,
            //                        MessageBoxIcon.Question);
            //    if (dlgRes == DialogResult.OK)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //// create an instance of SomeLongOperationDelegate
            SomeLongOperationDelegate someLongOperationDelegate = SomeLongOperation;
            //// start asynchronous operation, pass someLongOperationDelegate as a parameter, so we can get it back later on callback
            someLongOperationDelegate.BeginInvoke(SomeLongOperationCallBack, someLongOperationDelegate);
            //CalvinAndHobbesComicPlugin doonesburyPlugin = new CalvinAndHobbesComicPlugin();
            //doonesburyPlugin.ReadComicStripFeed();
        }

        /// <summary>
        /// Long operation such as a call to the database
        /// Step 4
        /// </summary>
        /// <returns>bool value to indicate success</returns>
        private bool SomeLongOperation()
        {
            // perform some longish operation
            foreach (IComicPlugin plugin in PluginInfo.internalList)
            {
                try
                {
                    UpdateUI("Fetching updates for " + plugin.ComicName() + " Comic Strip....");
                    _logger.Trace("Fetching updates for " + plugin.ComicName() + " Comic Strip....");
                    plugin.ReadComicStripFeed();
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            FillCombo();
            return true;
        }

        /// <summary>
        /// CallBack for the someLongOperationDelegate instance
        /// Step 5 and 6
        /// </summary>
        /// <param name="result">IAsyncResult object</param>
        private void SomeLongOperationCallBack(IAsyncResult result)
        {
            // original delegate passed in the asyncState parameter, get it back here
            ((SomeLongOperationDelegate) result.AsyncState).EndInvoke(result);
            // update the user interface
            UpdateUI(
                //new StringBuilder("Comic Strip Fetch Completed." + "\n" + " CallBack (Managed TID: ").
                //    Append(Thread.CurrentThread.ManagedThreadId.ToString()).
                //    Append(")").ToString());
                "Comic Strip fetch completed.");
            // start an asynchronous operation to set the controls on the form
            BeginInvoke(new SetFormControlsDelegate(SetFormControls), new object[] {true});
        }

        [DllImport("url.dll")]
        public static extern bool InetIsOffline(int dwFlags);

        public static bool IsOffline()
        {
            return InetIsOffline(0);
        }

        public static bool IsOnline()
        {
            return !InetIsOffline(0);
        }

        private void btnArchives_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbxComic.Text))
            {
                var archive = new Archive(cbxComic.Text, "");
                archive.Show(this);
            }
            else
            {
                var archive = new Archive();
                archive.Show(this);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            notifyIcon.BalloonTipText = "MetaComic Client is minimized to system tray." +
                                        Environment.NewLine + "Click on system tray icon to maximize.";
            notifyIcon.BalloonTipTitle =
                Text = "MetaComic Client " + "v." + Application.ProductVersion;
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(500);
            Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (AppSettings.ConfimApplicationExit)
            {
                DialogResult dlgRes;
                dlgRes =
                    MessageBox.Show("Are you sure you want to Exit ?", "Confirm Exit Application",
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question);
                if (dlgRes == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(cbxComic.Text))
                    {
                        config.AppSettings.Settings["ViewerLastSelected"].Value = cbxComic.Text;
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                    }
                    Application.Exit();
                }
                else
                {
                    return;
                }
            }
            if (!String.IsNullOrEmpty(cbxComic.Text))
            {
                config.AppSettings.Settings["ViewerLastSelected"].Value = cbxComic.Text;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            Application.Exit();
        }

        //Reading Image Headers to Get Width and Height
        //http://www.codeproject.com/KB/cs/ReadingImageHeaders.aspx
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ab = new AboutBox();
            ab.AppTitle = "MetaComic Client";
            ab.AppDescription = "MetaComic : RSS/XML Daily Comic Strip Viewer & Archiver.";
            ab.AppVersion = Application.ProductVersion;
            ab.AppCopyright = "http://metacomic.codeplex.com/license";
            //ab.AppMoreInfo = @"WARNING: This computer program is protected by copyright law and international treaties. " +
            //                 @"Circumvention of any copy protection scheme may result in severe civil and criminal penalties, " +
            //                 @"and will be prosecuted to maximum extent possible under law." + Environment.NewLine +
            //                 Environment.NewLine +
            //                 Environment.NewLine +
            ab.AppMoreInfo = Environment.NewLine +
                             @"Dilbert is a trademark of Scott Adams." +
                             Environment.NewLine +
                             Environment.NewLine +
                             @"Garfield is a trademark of Jim Davis." +
                             Environment.NewLine +
                             Environment.NewLine +
                             @"Doonesbury is a trademark of Garry Trudeau." +
                             Environment.NewLine +
                             Environment.NewLine +
                             @"Calvin and Hobbes is a trademark of Bill Watterson." +
                             Environment.NewLine +
                             Environment.NewLine +
                             @"Third Party Acknowledgement" +
                             Environment.NewLine +
                             Environment.NewLine +
                             @"MetaComics Client expresses gratitude and thanks to the authors of these third party components." +
                             Environment.NewLine +
                             Environment.NewLine +
                             "Contains DateTimeRoutines by Sergey Stoyan, CliverSoft.com (http://www.codeproject.com/KB/datetime/date_time_parser_cs.aspx?display=Print)" +
                             Environment.NewLine +
                             Environment.NewLine +
                             "Using XML as Database with Dataset (http://www.codeproject.com/KB/database/XMLData.aspx)" +
                             Environment.NewLine +
                             Environment.NewLine +
                             "Processing files within a file structure with plug-ins and events (http://www.codeproject.com/KB/files/eventdirprocessing.aspx)" +
                             Environment.NewLine +
                             Environment.NewLine +
                             "ImageBox Control with Zoom/Pan Capability (http://www.codeproject.com/KB/miscctrl/zoompancontrol.aspx)" +
                             Environment.NewLine +
                             Environment.NewLine +
                             "DotNetZip - Zip and Unzip in C#, VB, any .NET language (http://dotnetzip.codeplex.com/)" +
                             Environment.NewLine +
                             Environment.NewLine +
                             "Syndicating and Consuming RSS 1.0 (RDF) Feeds in ASP.NET 3.5 (http://www.4guysfromrolla.com/articles/031809-1.aspx)" +
                             Environment.NewLine +
                             Environment.NewLine +
                             "ColorPicker Controls for WinForms by  Jonathan Wood (http://www.blackbeltcoder.com/Articles/controls/colorpicker-controls-for-winforms)" +
                             Environment.NewLine +
                             Environment.NewLine +
                             "A Simple Image Slide Show (http://www.codeproject.com/KB/GDI-plus/vision.aspx)" +
                             Environment.NewLine +
                             Environment.NewLine +
                             "AboutBox by Jeff Atwood http://www.codeproject.com/KB/vb/aboutbox.aspx";
            //Show a WinForm in FullScreen mode using C# http://www.codeproject.com/KB/cs/WinForm_FullScreen.aspx
            ab.AppDetailsButton = true;
            ab.ShowDialog(this);
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oThread = new Thread(CheckUpdate);
            oThread.Start();
        }

        private void CheckUpdate()
        {
            CodePlexUpdateChecker.CheckURL();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string helpfilepath = Application.StartupPath + "\\" + "metacomicsclient.chm";
            if (!File.Exists(helpfilepath))
            {
                MessageBox.Show("Help file metacomicsclient.chm not found!", "Application Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                Process.Start("metacomicsclient.chm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occurred: " + ex.Message, "Application Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        private void archiverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var archive = new Archive();
            archive.Show(this);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var options = new Options();
            options.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (AppSettings.ConfimApplicationExit)
            {
                DialogResult dlgRes;
                dlgRes =
                    MessageBox.Show("Are you sure you want to Exit ?", "Confirm Exit Application",
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question);
                if (dlgRes == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(cbxComic.Text))
                    {
                        config.AppSettings.Settings["ViewerLastSelected"].Value = cbxComic.Text;
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                    }
                    Application.Exit();
                }
                else
                {
                    return;
                }
            }
            if (!String.IsNullOrEmpty(cbxComic.Text))
            {
                config.AppSettings.Settings["ViewerLastSelected"].Value = cbxComic.Text;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            Application.Exit();
        }

        public void FillCombo()
        {
            //if (!Directory.Exists(Application.StartupPath + "\\Strip\\"))
            //return;
            //string[] dirlist = Directory.GetDirectories(Application.StartupPath + "\\Strip\\");
            if (!Directory.Exists(AppSettings.ComicArchiveFolder))
                return;
            string[] dirlist = Directory.GetDirectories(AppSettings.ComicArchiveFolder);
            foreach (string s in dirlist)
            {
                if (!cbxComic.Items.Contains(s.Remove(0, s.LastIndexOf("\\") + 1)))
                {
                    cbxComic.Items.Add(s.Remove(0, s.LastIndexOf("\\") + 1));
                }
            }
            //Utlity.ProcessDir(Application.StartupPath, 3);
        }

        private void LoadPlugins()
        {
            //activePluginList = new List<string>()
            //                {
            //                    "Doonesbury"
            //                };
            var sep = new[] {','};
            foreach (string s in ConfigurationSettings.AppSettings.AllKeys)
            {
                if (s.StartsWith("Plugin"))
                {
                    string[] temp = ConfigurationSettings.AppSettings.GetValues(s);
                    string[] var = temp[0].Split(sep);
                    ObjectHandle obj = null;
                    try
                    {
                        //
                        // We try to create	an instance	of an object that contains an implementation of	the	IComicPlugin	interface.
                        // The object to load is specified in the app.config file.
                        //
                        obj = Activator.CreateInstanceFrom(Application.StartupPath + "\\" + var[0].Trim(), var[1].Trim());
                        var plug = (IComicPlugin) obj.Unwrap();
                        if (activePluginList != null)
                            if (activePluginList.Contains(plug.Name))
                            {
                                PluginInfo.internalList.Add(plug);
                            }
                    }
                    catch (Exception e)
                    {
                        _logger.Error(e);
                        MessageBox.Show(this, e.Message, "Error");
                    }
                }
            }
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            timery.Interval = 50000;
            timery.Tick += timey_Tick;
            stripPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            Text = "MetaComics Client " + "v." + Application.ProductVersion;
            //hide notify icon on start
            notifyIcon.Visible = false;
            if (AppSettings.StartMinimized)
            {
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
            if (AppSettings.EnableScheduling)
            {
                SetTimer();
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cbxComic.SelectedIndex = cbxComic.FindStringExact(config.AppSettings.Settings["ViewerLastSelected"].Value);
            if (AppSettings.ShowWelcomefcScreen)
            {
                var welcome = new Welcome();
                welcome.ShowDialog(this);
            }
        }

        private void pluginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var plugin = new Plugins();
            plugin.Show(this);
        }

        public void ShowMyImage(Image fileToDisplay, int xSize, int ySize)
        {
            stripPictureBox.AutoChangeMaxSize = true;
            // Stretches the image to fit the pictureBox.
            stripPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            stripPictureBox.ClientSize = new Size(xSize, ySize);
            stripPictureBox.Image = fileToDisplay;
        }

        public byte[] ImageToByteArray(Image p_ImageIn)
        {
            byte[] aRet = null;
            using (var oMS = new MemoryStream())
            {
                p_ImageIn.Save(oMS, ImageFormat.Gif);
                aRet = oMS.ToArray();
            }
            // Possibly dispose image too here, if no extra manipulation is needed
            //      Remember, Image is sent by ref, so if you dispose it inside method it will not be available outside either.
            // p_ImageIn.Dispose();
            return aRet;
        }

        public Image ComicOfTheDay(string comicStrip)
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            DirectoryInfo di = null;
            if (Directory.Exists(AppSettings.ComicArchiveFolder + "\\" + comicStrip + "\\"))
            {
                di = new DirectoryInfo(AppSettings.ComicArchiveFolder + "\\" + comicStrip + "\\" + currentDate);
                if (Directory.Exists(AppSettings.ComicArchiveFolder + "\\" + comicStrip + "\\" + currentDate))
                {
                    FileInfo[] fiArr = di.GetFiles("*.gif");
                    int x = fiArr.GetLength(0);
                    for (int i = 0; i < x; i++)
                    {
                        if (File.Exists(di + "\\" + fiArr[i].Name))
                        {
                            Image ximg = Image.FromFile(di + "\\" + fiArr[i].Name);
                            currentFilePath = di + "\\" + fiArr[i].Name;
                            currentFileName = fiArr[i].Name;
                            var stream = new MemoryStream(ImageToByteArray(ximg));
                            return Image.FromStream(stream);
                        }
                    }
                }
            }
            if (Directory.Exists(Application.StartupPath + "\\Strip\\" + comicStrip + "\\"))
            {
                di = new DirectoryInfo(Application.StartupPath + "\\Strip\\" + comicStrip + "\\" + currentDate);
                if (Directory.Exists(Application.StartupPath + "\\Strip\\" + comicStrip + "\\" + currentDate))
                {
                    FileInfo[] fiArr = di.GetFiles("*.jpg");
                    int x = fiArr.GetLength(0);
                    for (int i = 0; i < x; i++)
                    {
                        if (File.Exists(di + "\\" + fiArr[i].Name))
                        {
                            Image ximg = Image.FromFile(di + "\\" + fiArr[i].Name);
                            currentFilePath = di + "\\" + fiArr[i].Name;
                            currentFileName = fiArr[i].Name;
                            var stream = new MemoryStream(ImageToByteArray(ximg));
                            return Image.FromStream(stream);
                        }
                    }
                }
            }
            if (Directory.Exists(Application.StartupPath + "\\Strip\\" + comicStrip + "\\"))
            {
                di = new DirectoryInfo(Application.StartupPath + "\\Strip\\" + comicStrip + "\\" + currentDate);
                if (Directory.Exists(Application.StartupPath + "\\Strip\\" + comicStrip + "\\" + currentDate))
                {
                    FileInfo[] fiArr = di.GetFiles("*.png");
                    int x = fiArr.GetLength(0);
                    for (int i = 0; i < x; i++)
                    {
                        if (File.Exists(di + "\\" + fiArr[i].Name))
                        {
                            Image ximg = Image.FromFile(di + "\\" + fiArr[i].Name);
                            currentFilePath = di + "\\" + fiArr[i].Name;
                            currentFileName = fiArr[i].Name;
                            var stream = new MemoryStream(ImageToByteArray(ximg));
                            return Image.FromStream(stream);
                        }
                    }
                }
            }
            if (Directory.Exists(Application.StartupPath + "\\Strip\\" + comicStrip + "\\"))
            {
                di = new DirectoryInfo(Application.StartupPath + "\\Strip\\" + comicStrip + "\\" + currentDate);
                if (Directory.Exists(Application.StartupPath + "\\Strip\\" + comicStrip + "\\" + currentDate))
                {
                    FileInfo[] fiArr = di.GetFiles("*.jpeg");
                    int x = fiArr.GetLength(0);
                    for (int i = 0; i < x; i++)
                    {
                        if (File.Exists(di + "\\" + fiArr[i].Name))
                        {
                            Image ximg = Image.FromFile(di + "\\" + fiArr[i].Name);
                            currentFilePath = di + "\\" + fiArr[i].Name;
                            currentFileName = fiArr[i].Name;
                            var stream = new MemoryStream(ImageToByteArray(ximg));
                            return Image.FromStream(stream);
                        }
                    }
                }
            }
            return null;
        }

//        double maxAspect = (double)resizeMaxWidth / (double)resizeMaxHeight;
//double aspect = (double)image.Width/(double)image.Height;
//if (maxAspect > aspect && image.Width > resizeMaxWidth) {
//   //Width is the bigger dimension relative to max bounds
//   resizeWidth = resizeMaxWidth;
//   resizeHeight = resizeMaxWidth / aspect;
//}else if (maxAspect <= aspect && image.Height > resizeMaxHeight){
//   //Height is the bigger dimension
//   resizeHeight = resizeMaxHeight;
//   resizeWidth = resizeMaxWidth * aspect;
//}
        private void cbxComic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbxComic.Text))
            {
                //List<IComicPlugin> x = PluginInfo.internalList;
                //foreach (IComicPlugin plugin in x)
                //{
                //    if (cbxComic.Text == plugin.ComicName())
                //    {
                Image imgcs = ComicOfTheDay(cbxComic.Text);
                if (imgcs != null)
                {
                    Size = new Size(imgcs.Width + 75, imgcs.Height + 170);
                    //var resizeMaxWidth = 600;
                    //    //imgcs.Width + 75;
                    //var resizeMaxHeight = 500;
                    //    //imgcs.Height + 75;
                    //double resizeWidth = 0.0;
                    //double resizeHeight = 0.0;
                    //if(true)
                    //{
                    //    double maxAspect = (double)resizeMaxWidth / (double)resizeMaxHeight;
                    //    double aspect = (double)imgcs.Width / (double)imgcs.Height;
                    //    if (maxAspect > aspect && imgcs.Width > resizeMaxWidth)
                    //    {
                    //        //Width is the bigger dimension relative to max bounds
                    //        resizeWidth = resizeMaxWidth;
                    //        resizeHeight = resizeMaxWidth / aspect;
                    //    }
                    //    else if (maxAspect <= aspect && imgcs.Height > resizeMaxHeight)
                    //    {
                    //        //Height is the bigger dimension
                    //        resizeHeight = resizeMaxHeight;
                    //        resizeWidth = resizeMaxWidth * aspect;
                    //    }
                    //    ShowMyImage(imgcs, System.Convert.ToInt32(resizeWidth), System.Convert.ToInt32(resizeHeight));     
                    //}
                    //if(true)
                    //{
                    //    // You have the new height, you need the new width
                    //    int orgHeight = 1200;
                    //    int orgWidth = 1920;
                    //    int newHeight = 400;
                    //    int newWidth = (newHeight * orgWidth) / orgHeight; // 640
                    //// You have the new width, you need the new height.
                    //int orgWidth = 1920;
                    //int orgHeight = 1200;
                    //int newWidth = 800;
                    //int newHeight = (newWidth * orgHeight) / orgWidth; // 500
                    //    Image x = ResizeImage(imgcs, newHeight, newWidth);
                    //    ShowMyImage(x, x.Width, x.Height);   
                    //}
                    ShowMyImage(imgcs, imgcs.Width, imgcs.Height);
                    //stripPictureBox.Size = new Size(imgcs.Width, imgcs.Height);
                    //stripPictureBox.Image = imgcs;
                    //stripPictureBox.Show();
                    Text = "MetaComic Client Ver 2.3 " + "- You are viewing: " + cbxComic.Text;
                }
                //}
                //}
            }
        }

        private static Image ResizeImage(Image image, int desWidth, int desHeight)
        {
            int x, y, w, h;
            if (image.Height > image.Width)
            {
                w = (image.Width*desHeight)/image.Height;
                h = desHeight;
                x = (desWidth - w)/2;
                y = 0;
            }
            else
            {
                w = desWidth;
                h = (image.Height*desWidth)/image.Width;
                x = 0;
                y = (desHeight - h)/2;
            }
            var bmp = new Bitmap(desWidth, desHeight);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, x, y, w, h);
            }
            return bmp;
        }

        private void openComicStripDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string myPath = AppSettings.ComicArchiveFolder;
            var prc = new Process();
            prc.StartInfo.FileName = myPath;
            prc.Start();
        }

        private void visitWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://metacomic.codeplex.com/");
        }

        private void onlineHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://metacomic.codeplex.com/documentation");
        }

        private void MainUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            //notifyIcon.Visible = false;
            switch (e.CloseReason)
            {
                case CloseReason.TaskManagerClosing:
                case CloseReason.ApplicationExitCall:
                case CloseReason.WindowsShutDown:
                    break;
                default:
                    e.Cancel = true;
                    notifyIcon.Visible = true;
                    base.Hide();
                    break;
            }
        }

        private void minimizeToSystemTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.BalloonTipText = "MetaComics Client is minimized to system tray." +
                                        Environment.NewLine + "Click on system tray icon to maximize.";
            notifyIcon.BalloonTipTitle =
                Text = "MetaComics Client " + "v." + Application.ProductVersion;
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(500);
            Hide();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var statistics = new Statistics();
            statistics.Show(this);
        }

        private void disclaimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AppSettings.DisclamimerAgree == "UserNotAgreed")
            {
                var disclaimer = new Disclaimer();
                disclaimer.Show(this);
            }
        }

        private void comicCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var comicCollector = new ComicCollector();
            comicCollector.Show(this);
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowScreen();
        }

        private void ShowScreen()
        {
            if (fullScreenToolStripMenuItem.Checked == false)
            {
                // show FullScreen
                _FullScreen.ShowFullScreen();
                fullScreenToolStripMenuItem.Checked = true;
            }
            else
            {
                // Hide FullScreen
                _FullScreen.ShowFullScreen();
                fullScreenToolStripMenuItem.Checked = false;
            }
        }

        private void stripPictureBox_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            return;
        }

        private void MainUI_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            return;
        }

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://metacomic.codeplex.com/workitem/list/basic");
        }

        private void feedbackOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://metacomic.codeplex.com/discussions");
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
            Visible = true;
            Activate();
        }

        //private void notifyIcon_MouseDown_1(object sender, MouseEventArgs e)
        //{
        //    contextMenuStrip.Show();
        //}

        private void comicNewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rssReader = new RSSReader();
            rssReader.Show();
        }

        private void showImage(string s)
        {
            Image imgtemp = Image.FromFile(s);
            stripPictureBox.Image = imgtemp;
            if (s != null)
            {
                // Size = new Size(imgtemp.Width + 75, imgtemp.Height + 170);
                ShowMyImage(imgtemp, imgtemp.Width, imgtemp.Height);
                Text = "MetaComic Client Ver 2.3 " + "- You are viewing: " + cbxComic.Text;
            }
        }

        private void GetComicStripList()
        {
            if (Directory.Exists(AppSettings.ComicArchiveFolder))
            {
                string[] folders = Directory.GetDirectories(AppSettings.ComicArchiveFolder, "*",
                                                            SearchOption.AllDirectories);
                foreach (string folder in folders)
                {
                    string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                    string pathx = folder + "\\" + currentDate;
                    if (Directory.Exists(folder + "\\" + currentDate))
                    {
                        string[] part1 = null, part2 = null, part3 = null;
                        part1 = Directory.GetFiles(pathx, "*.jpg", SearchOption.AllDirectories);
                        part2 = Directory.GetFiles(pathx, "*.jpeg", SearchOption.AllDirectories);
                        part3 = Directory.GetFiles(pathx, "*.gif", SearchOption.AllDirectories);
                        folderFile = new string[part1.Length + part2.Length + part3.Length];
                        Array.Copy(part1, 0, folderFile, 0, part1.Length);
                        Array.Copy(part2, 0, folderFile, part1.Length, part2.Length);
                        Array.Copy(part3, 0, folderFile, part1.Length + part2.Length, part3.Length);
                        if (folderFile.Length == 1)
                            todaycomiclist.Add(folderFile[0]);
                    }
                }
                folderFile = ToArray(todaycomiclist);
                selected = 0;
                begin = 0;
                end = folderFile.Length;
                if (selected == folderFile.Length - 1)
                {
                    selected = 0;
                    showImage(folderFile[selected]);
                }
                else
                {
                    selected = selected + 1;
                    showImage(folderFile[selected]);
                }
            }
        }

        public static T[] ToArray<T>(IList<T> list)
        {
            if (list is Array) return (T[]) list;
            var retval = new T[list.Count];
            for (int i = 0; i < retval.Length; i++)
                retval[i] = list[i];
            return retval;
        }

        private void nextImage()
        {
            if (selected == folderFile.Length - 1)
            {
                selected = 0;
                showImage(folderFile[selected]);
            }
            else
            {
                selected = selected + 1;
                showImage(folderFile[selected]);
            }
        }

        ////MessageBox.Show("Found: " + folder + "\\" + currentDate);
        //               string pathx = folder + "\\" + currentDate;
        //                   //Application.StartupPath + "\\Strip" + "\\" + cbxComic.Text + "\\";
        //               string[] part1 = null, part2 = null, part3 = null;
        //               part1 = Directory.GetFiles(pathx, "*.jpg", SearchOption.AllDirectories);
        //               part2 = Directory.GetFiles(pathx, "*.jpeg", SearchOption.AllDirectories);
        //               part3 = Directory.GetFiles(pathx, "*.gif", SearchOption.AllDirectories);
        //               folderFile = new string[part1.Length + part2.Length + part3.Length];
        //               Array.Copy(part1, 0, folderFile, 0, part1.Length);
        //               Array.Copy(part2, 0, folderFile, part1.Length, part2.Length);
        //               Array.Copy(part3, 0, folderFile, part1.Length + part2.Length, part3.Length);
        //               selected = 0;
        //               begin = 0;
        //               end = folderFile.Length;
        //               //showImage(folderFile[selected]);
        //               if (selected == folderFile.Length - 1)
        //               {
        //                   selected = 0;
        //                   showImage(folderFile[selected]);
        //               }
        //               else
        //               {
        //                   selected = selected + 1;
        //                   showImage(folderFile[selected]);
        //               }
        private void addToFavouriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XElement doc = XElement.Load("BookMarksDB.xml");
            var xml =
                new XElement("BookMark",
                             new XElement("Image", currentFileName),
                             new XElement("ImagePath", currentFilePath),
                             new XElement("BookMarkedDate", DateTime.Now.ToString())
                    );
            doc.Add(xml);
            doc.Save("BookMarksDB.xml");
        }

        private void slideshowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //go to dir D:\stuff\My Dropbox\MCDailyDilbert\MetaComics.Client\bin\Debug\Strip
            //go to each sub dir and check if a folder by date of today exist
            //get each jpg.png,gif in that folder by full path and store in array
            //use that as slideshow feed
            GetComicStripList();
            if (timery.Enabled)
            {
                timery.Enabled = false;
                // button4.Text = "<< START Slide Show >>";
            }
            else
            {
                timery.Enabled = true;
                //  button4.Text = "<< STOP Slide Show >>";
            }
        }

        private void timey_Tick(object sender, EventArgs e)
        {
            nextImage();
        }

        //#region Nested type: SetFormControlsDelegate

        #region Nested type: SetFormControlsDelegate

        private delegate void SetFormControlsDelegate(bool Enabled);

        #endregion

        //#region Nested type: SomeLongOperationDelegate

        #region Nested type: SomeLongOperationDelegate

        private delegate bool SomeLongOperationDelegate();

        #endregion

        // Creates a delegate with the same signature as the method used to update the UI
        // In this case we'll use UpdateUIHelper(string value)
        //#region Nested type: UpdateUIDelegate

        #region Nested type: UpdateUIDelegate

        private delegate void UpdateUIDelegate(string value);

        #endregion

        private void stripPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void MainUI_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}