using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MetaComics.Client.Code;

namespace MetaComics.Client.UI
{
    public partial class Statistics : Form
    {
        private int file_count;

        public Statistics()
        {
            InitializeComponent();
            var oThread = new Thread(FillStats);
            oThread.Start();
        }

        ///
        /// Get the file count of a given directory recursively.
        ///
        public void GetDirectoryFileCount(string dir, string pattern)
        {
            //dir = dir + @"\";
            //get all the directories and files inside a directory
            string filter = "*.xml";
            String[] all_files = Directory.GetFileSystemEntries(dir);
            //loop through all items
            foreach (string file in all_files)
            {
                //check to see if the file is a directory if not increment the count
                if (Directory.Exists(file))
                {
                    //recursive call
                    GetDirectoryFileCount(file, filter);
                }
                else
                {
                    //increment file count
                    file_count++;
                }
            }
        }

        private void FillStats()
        {
            lblEnabledPlugins.Text = "Enabled Comic Strip Plugins:" + PluginInfo.internalList.Count;
            int todaycount = 0;
            int yesterdaycount = 0;
            if (Directory.Exists(AppSettings.ComicArchiveFolder))
            {
                var dir = new DirectoryInfo(AppSettings.ComicArchiveFolder);
                long size = getDirSize(dir);
                lblTotalDatabaseSizeInfoValue.Text = Utlity.FormatFileSize(size);
                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    ctlComicsList.Items.Add(d.Name);
                }
            }
            lblTotalComicStripFolders.Text = ctlComicsList.Items.Count + " comic strips folders found.";
            if (Directory.Exists(AppSettings.ComicArchiveFolder))
            {
                string[] folders = Directory.GetDirectories(AppSettings.ComicArchiveFolder, "*",
                                                            SearchOption.AllDirectories);
                foreach (string folder in folders)
                {
                    string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                    string yesterdayDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    if (Directory.Exists(folder + "\\" + currentDate))
                    {
                        //MessageBox.Show("Found: " + folder + "\\" + currentDate);
                        todaycount = todaycount + 1;
                    }
                    if (Directory.Exists(folder + "\\" + yesterdayDate))
                    {
                        //MessageBox.Show("Found: " + folder + "\\" + currentDate);
                        yesterdaycount = yesterdaycount + 1;
                    }
                }
                lblTodayUpdateStatus.Text = todaycount + "  comic strips have updates for today.";
                lblYesterdayUpdateStatus.Text = yesterdaycount + "  comic strips have updates for yesterday.";
            }
        }

        public long getDirSize(DirectoryInfo dir)
        {
            long size = 0;
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo fi in files)
                size += fi.Length;
            foreach (DirectoryInfo di in dirs)
                size += getDirSize(di);
            return size;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ctlComicsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dirpath = Application.StartupPath + "\\Strip" + "\\" + ctlComicsList.SelectedItem + "\\";
            GetDirectoryFileCount(dirpath, "");
            lblComicStripCountValue.Text = "";
            lblComicStripCountValue.Text = "Total Comic Strips: " + file_count/2;
            file_count = 0;
        }
    }
}