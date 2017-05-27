using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Ionic.Zip;
using MetaComics.Client.Code;
using MetaComics.Client.Code.PDF;
using NLog;

namespace MetaComics.Client.UI
{
    public partial class Archive : Form
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public static string currentFilePath;
        public static string currentFileName;
        public static string mainuiSelectedComic;
        private static string xfilename;
        private bool bResult;
        private int begin;
        private Category cat;
        private int end;
        private int file_count;
        private string[] folderFile;
        private int selected;
        private string strAction;
        private string strExp;

        public Archive()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = DateTime.Now.ToString("F");
        }

        public Archive(string comicstrip, string date)
        {
            InitializeComponent();
            mainuiSelectedComic = comicstrip;
        }

        ///
        /// Get the file count of a given directory recursively.
        ///
        public void GetDirectoryFileCount(string dir)
        {
            dir = dir + @"\";
            //get all the directories and files inside a directory
            String[] all_files = Directory.GetFileSystemEntries(dir);
            //loop through all items
            foreach (string file in all_files)
            {
                //check to see if the file is a directory if not increment the count
                if (Directory.Exists(file))
                {
                    //recursive call
                    GetDirectoryFileCount(file);
                }
                else
                {
                    //increment file count
                    file_count++;
                }
            }
        }

        public void FillComicCombo()
        {
            if (!Directory.Exists(AppSettings.ComicArchiveFolder))
                return;
            string[] dirlist = Directory.GetDirectories(AppSettings.ComicArchiveFolder + "\\");
            foreach (string s in dirlist)
            {
                cbxComic.Items.Add(s.Remove(0, s.LastIndexOf("\\") + 1));
            }
            cbxComic.Items.Add("Favourites");
            cbxComic.SelectedIndex = cbxComic.FindStringExact(mainuiSelectedComic);
            cbxArchiveStrip.SelectedIndex = cbxComic.FindStringExact(mainuiSelectedComic);
            //Utlity.ProcessDir(Application.StartupPath, 3);
        }

        private void Archive_Load(object sender, EventArgs e)
        {
            FillComicCombo();
            if (!String.IsNullOrEmpty(cbxComic.Text))
            {
                FillCombo(cbxComic.Text);
            }
            ActiveForm.KeyPreview = true;
        }

        public void FillCombo(string comicFolder)
        {
            cbxArchiveStrip.Items.Clear();
            if (!Directory.Exists(AppSettings.ComicArchiveFolder + "\\" + comicFolder + "\\"))
                return;
            string[] dirlist = Directory.GetDirectories(AppSettings.ComicArchiveFolder + "\\" + comicFolder + "\\");
            foreach (string s in dirlist)
            {
                try
                {
                    cbxArchiveStrip.Items.Add(
                        Utlity.ParseStringToDate(s.Remove(0, s.LastIndexOf("\\") + 1)).ToString("yyyy-MM-dd"));
                }
                catch (Exception)
                {
                }
            }
            Utlity.ProcessDir(Application.StartupPath, 3);
        }

        private void btnViewComicStrip_Click(object sender, EventArgs e)
        {
            if (cbxArchiveStrip.Text == "")
                return;
            try
            {
                GetImageFromStripFolder();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetImageFromStripFolder(string path)
        {
            //string folder = cbxArchiveStrip.Text;
            //var di = new DirectoryInfo(Application.StartupPath + "\\Strip" + "\\" + cbxComic.Text + "\\" + folder);
            //// Get a reference to each file in that directory.
            //FileInfo[] fiArr = di.GetFiles("*.gif");
            //var dirInfo = new DirectoryInfo(Application.StartupPath + "\\Strip" + "\\" + cbxComic.Text + "\\" + folder);
            //FileInfo[] fileInfo1 = dirInfo.GetFiles("*.*");
            //FileInfo[] fileSubset = (from item in fileInfo1
            //                         where
            //                             item.Name.EndsWith("jpg") || item.Name.EndsWith("gif") ||
            //                             item.Name.EndsWith("png")
            //                         select item).ToArray();
            //int x = fileSubset.GetLength(0);
            //for (int i = 0; i < x; i++)
            //{
            //    string path = Application.StartupPath + "\\Strip" + "\\" + cbxComic.Text + "\\" + folder + "\\" +
            //                  fileSubset[i].Name;
            if (File.Exists(path))
            {
                ArchiveStripPictureBox.Image =
                    Image.FromFile(path);
                //FileAttributes sx = File.GetAttributes(path);
                var info = new FileInfo(path);
                long fileSize = info.Length;
                string strFileSize = Utlity.FormatFileSize(fileSize);
                currentFilePath = path;
                currentFileName = info.Name;
                xfilename = info.FullName;
                ctlInfo.Text = "Viewing File: " + info.Name + " | File Size: " + strFileSize + "|";
                file_count = 0;
                ArchiveStripPictureBox.Show();
            }
            //}
        }

        private void GetComicStripList()
        {
            //string[] imagePaths = Directory.GetFiles(Application.StartupPath + "\\Strip" + "\\" + cbxComic.Text + "\\", "*.gif", SearchOption.AllDirectories);
            //foreach (var imagePath in imagePaths)
            //{
            //    pictureBox1.Image = Image.FromFile(imagePath);
            //}
            string pathx = Application.StartupPath + "\\Strip" + "\\" + cbxComic.Text + "\\";
            string[] part1 = null, part2 = null, part3 = null;
            part1 = Directory.GetFiles(pathx, "*.jpg", SearchOption.AllDirectories);
            part2 = Directory.GetFiles(pathx, "*.jpeg", SearchOption.AllDirectories);
            part3 = Directory.GetFiles(pathx, "*.gif", SearchOption.AllDirectories);
            folderFile = new string[part1.Length + part2.Length + part3.Length];
            Array.Copy(part1, 0, folderFile, 0, part1.Length);
            Array.Copy(part2, 0, folderFile, part1.Length, part2.Length);
            Array.Copy(part3, 0, folderFile, part1.Length + part2.Length, part3.Length);
            selected = 0;
            begin = 0;
            end = folderFile.Length;
            //showImage(folderFile[selected]);
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

        private void showImage(string s)
        {
            Image imgtemp = Image.FromFile(s);
            // ArchiveStripPictureBox.Width = imgtemp.Width / 2;
            //  ArchiveStripPictureBox.Height = imgtemp.Height / 2;
            ArchiveStripPictureBox.Image = imgtemp;
        }

        private void GetImageFromStripFolder()
        {
            string folder = cbxArchiveStrip.Text;
            var di = new DirectoryInfo(AppSettings.ComicArchiveFolder + "\\" + cbxComic.Text + "\\" + folder);
            // Get a reference to each file in that directory.
            FileInfo[] fiArr = di.GetFiles("*.gif");
            var dirInfo = new DirectoryInfo(AppSettings.ComicArchiveFolder + "\\" + cbxComic.Text + "\\" + folder);
            FileInfo[] fileInfo1 = dirInfo.GetFiles("*.*");
            FileInfo[] fileSubset = (from item in fileInfo1
                                     where
                                         item.Name.EndsWith("jpg") || item.Name.EndsWith("gif") ||
                                         item.Name.EndsWith("png")
                                     select item).ToArray();
            int x = fileSubset.GetLength(0);
            for (int i = 0; i < x; i++)
            {
                string path = AppSettings.ComicArchiveFolder + "\\" + cbxComic.Text + "\\" + folder + "\\" +
                              fileSubset[i].Name;
                if (File.Exists(path))
                {
                    ArchiveStripPictureBox.Image =
                        Image.FromFile(path);
                    FileAttributes sx = File.GetAttributes(path);
                    var info = new FileInfo(path);
                    long fileSize = info.Length;
                    string strFileSize = Utlity.FormatFileSize(fileSize);
                    currentFilePath = path;
                    xfilename = info.FullName;
                    currentFileName = info.Name;
                    ctlInfo.Text = "Viewing File: " + info.Name + " | File Size: " + strFileSize + "|";
                    file_count = 0;
                    ArchiveStripPictureBox.Show();
                }
            }
        }

        private void cbxArchiveStrip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxComic.Text == "Favourites")
            {
                GetImageFromStripFolder(cbxArchiveStrip.Text);
            }
            if (cbxArchiveStrip.Text == "")
                return;
            try
            {
                GetImageFromStripFolder();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            IList list = null;
            string folder = cbxArchiveStrip.Text;
            var di = new DirectoryInfo(AppSettings.ComicArchiveFolder + "\\" + cbxComic.Text + "\\" + folder);
            FileInfo[] fiArr = di.GetFiles("*.xml");
            int x = fiArr.GetLength(0);
            for (int i = 0; i < x; i++)
            {
                list =
                    CategoryList.GetCategoryList(AppSettings.ComicArchiveFolder + "\\" + cbxComic.Text + "\\" +
                                                 folder + "\\" + fiArr[i].Name);
                //delay 
            }
            ctlTagList.DataSource = list;
            ctlTagList.DisplayMember = "CategoryName";
            txtTag.Clear();
        }

        private void btnTags_Click(object sender, EventArgs e)
        {
            string path = "";
            string folder = cbxArchiveStrip.Text;
            var di = new DirectoryInfo(Application.StartupPath + "\\Strip" + "\\" + cbxComic.Text + "\\" + folder);
            FileInfo[] fiArr = di.GetFiles("*.xml");
            int x = fiArr.GetLength(0);
            for (int i = 0; i < x; i++)
            {
                path = Application.StartupPath + "\\Strip" + "\\" + cbxComic.Text + "\\" + folder + "\\" + fiArr[i].Name;
            }
            SaveOrUpdateData(path);
            txtTag.Clear();
        }

        public void SaveOrUpdateData(String path)
        {
            if (isValidate())
            {
                IsAlreadyExist();
                SaveOrUpdateAction(path);
                if (!bResult)
                {
                    //MessageBox.Show(strExp, "[Modified Dialog]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //MessageBox.Show(strExp, "[Modified Dialog]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void SaveOrUpdateAction(string path)
        {
            var rand = new Random();
            var bytes = new byte[4];
            rand.NextBytes(bytes);
            cat = new Category();
            cat.CategoryID = bytes[0].ToString();
            cat.CategoryName = txtTag.Text;
            if (strAction.Equals("insert"))
            {
                try
                {
                    CategoryList.InsertCategory(cat, path);
                    bResult = true;
                    strExp = "Record " + cat.CategoryID.Trim() + " successfully insert to datasource";
                }
                catch (Exception exp)
                {
                    bResult = false;
                    strExp = "Record " + cat.CategoryID.Trim() + " failed insert to datasource\n Message : " +
                             exp.Message;
                }
            }
            else
            {
                try
                {
                    CategoryList.UpdateCategory(cat, path);
                    bResult = true;
                    strExp = "Record " + cat.CategoryID.Trim() + " successfully update to datasource";
                }
                catch (Exception exp)
                {
                    bResult = false;
                    strExp = "Record " + cat.CategoryID.Trim() + " failed update to datasource\n Message : " +
                             exp.Message;
                }
            }
            populate();
        }

        private void populate()
        {
            IList list = null;
            string path = "";
            string folder = cbxArchiveStrip.Text;
            var di = new DirectoryInfo(Application.StartupPath + "\\Strip" + "\\" + cbxComic.Text + "\\" + folder);
            FileInfo[] fiArr = di.GetFiles("*.xml");
            int x = fiArr.GetLength(0);
            for (int i = 0; i < x; i++)
            {
                path = Application.StartupPath + "\\Strip" + "\\" + cbxComic.Text + "\\" + folder + "\\" + fiArr[i].Name;
                list =
                    CategoryList.GetCategoryList(Application.StartupPath + "\\Strip" + "\\" + cbxComic.Text + "\\" +
                                                 folder + "\\" + fiArr[i].Name);
            }
            ctlTagList.DataSource = list;
            ctlTagList.DisplayMember = "CategoryName";
        }

        private void IsAlreadyExist()
        {
            cat = CategoryList.GetCategory(txtTag.Text);
            if (cat != null)
            {
                strAction = "update";
            }
            else
            {
                strAction = "insert";
            }
        }

        private bool isValidate()
        {
            if (txtTag.Text != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Archive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnDeleteTag_Click(object sender, EventArgs e)
        {
            string path = "";
            string folder = cbxArchiveStrip.Text;
            var di = new DirectoryInfo(Application.StartupPath + "\\Strip" + "\\" + cbxComic.Text + "\\" + folder);
            FileInfo[] fiArr = di.GetFiles("*.xml");
            int x = fiArr.GetLength(0);
            for (int i = 0; i < x; i++)
            {
                path = Application.StartupPath + "\\Strip" + "\\" + cbxComic.Text + "\\" + folder + "\\" + fiArr[i].Name;
            }
            DeleteData(path);
        }

        private void DeleteData(string path)
        {
            try
            {
                //DialogResult rslt = MessageBox.Show("Are sure want to delete this record no : " +
                //    txtTag.Text + " ?", "[Confirmation]", MessageBoxButtons.YesNo);
                //if (rslt == DialogResult.Yes)
                //{
                string item;
                item = txtTag.Text;
                CategoryList.DeleteBasedOnCategoryName(item, path);
                bResult = true;
                //}
            }
            catch (Exception exp)
            {
                bResult = false;
                strExp = "Record " + txtTag.Text.Trim() + " failed delete to datasource\n Message : " + exp.Message;
                _logger.Error(exp);
                MessageBox.Show(strExp, "[Status Dialog]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            populate();
            txtTag.Clear();
        }

        private void ctlTagList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTag != null)
                if (ctlTagList.SelectedItem != null)
                    txtTag.Text = ((DataRowView) (ctlTagList.SelectedItem)).Row.ItemArray[1].ToString();
        }

        private void btnGenerateComic_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbxComic.Text))
            {
                string path = Application.StartupPath + "\\Strip" + "\\" + cbxComic.Text + "\\";
                if (ctlCBZComicFormat.Checked)
                {
                    using (var zip = new ZipFile())
                    {
                        zip.AddDirectory(path, "Dilbert Comic");
                        zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                        zip.Save(cbxComic.Text + ".cbz");
                        ctlInfo.Text = "Comic Book Archive file (CBZ) created in application folder";
                        string myPath = Application.StartupPath;
                        var prc = new Process();
                        prc.StartInfo.FileName = myPath;
                        prc.Start();
                    }
                }
                if (ctlPDFComicFormat.Checked)
                {
                    ComicStrip2PDF.CreatePdfFile(path, cbxComic.Text);
                }
            }
        }

        //private void MakePDF()
        //{
        //    FileSystem fileSystem = new FileSystem(Application.StartupPath + "\\Strip\\Dilbert\\");
        //    ArrayList a = fileSystem.GetDirectories();
        //    //MessageBox.Show("addraylist :" + a.Count.ToString());
        //    //pdfDocument myDoc = new pdfDocument("TUTORIAL", "ME");
        //    List<DirectoryStructure> newdirList = new List<DirectoryStructure>();
        //    foreach (DirectoryStructure ds in a)
        //    {
        //        if (a.Count > 0)
        //        {
        //            newdirList.Add(ds);
        //        }
        //    }
        //    foreach (DirectoryStructure structure in newdirList)
        //    {
        //while(structure.fileList.Count<=0)
        //{
        //    myDoc.addImageReference(structure.di.FullName + "\\dil.jpg", "logo" + structure.di.Name);
        //    pdfPage myPage = myDoc.addPage();
        //    //if (structure.di.Name == "01312008") MessageBox.Show("hi");
        //    myPage.addImage(myDoc.getImageReference("logo" + structure.di.Name), 60, 333, 272, 375);
        //    myDoc.createPDF(
        //        @"W:\\Dev Project\\trunk\\MetaComics\\MetaComics.Client\\bin\\Debug\\Strip\\Dilberttest.pdf");
        //}
        //if (structure.fileList.Count < 8) MessageBox.Show(newdirList.Count.ToString());
        //if (structure.fileList.Count > 8)
        //{
        //    myDoc.addImageReference(structure.di.FullName + "\\dil.jpg", "logo" + structure.di.Name);
        //    pdfPage myPage = myDoc.addPage();
        //    //if (structure.di.Name == "01312008") MessageBox.Show("hi");
        //    myPage.addImage(myDoc.getImageReference("logo" + structure.di.Name), 60, 333, 272, 375);
        //    myDoc.createPDF(
        //        @"W:\\Dev Project\\trunk\\MetaComics\\MetaComics.Client\\bin\\Debug\\Strip\\Dilberttest.pdf");
        //}
        //myDoc.addImageReference(structure.di.FullName + "\\dil.jpg", "logo" + structure.di.Name);
        //pdfPage myPage = myDoc.addPage();
        ////if (structure.di.Name == "01312008") MessageBox.Show("hi");
        //myPage.addImage(myDoc.getImageReference("logo" + structure.di.Name), 60, 333, 272, 375);
        //myDoc.createPDF(
        //    @"W:\\Dev Project\\trunk\\MetaComics\\MetaComics.Client\\bin\\Debug\\Strip\\Dilberttest.pdf");
        //}
        //foreach (DirectoryStructure ds in a)
        //{
        //    if (ds.fileList.Count > 0)
        //    {
        //        myDoc.addImageReference(ds.di.FullName + "\\dil.jpg", "logo" + ds.di.Name);
        //        pdfPage myPage = myDoc.addPage();
        //        myPage.addImage(myDoc.getImageReference("logo" + ds.di.Name), 60, 333, 272, 375);
        //        myDoc.createPDF(
        //            @"W:\\Dev Project\\trunk\\MetaComics\\MetaComics.Client\\bin\\Debug\\Strip\\Dilberttest.pdf");
        //    }
        //}
        //Process.Start(@"W:\\Dev Project\\trunk\\MetaComics\\MetaComics.Client\\bin\\Debug\\Strip\\Dilberttest.pdf");
        //myPage = null;
        //myDoc = null;
        //}
        private void cbxComic_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxArchiveStrip.Items.Clear();
            if (cbxComic.Text == "Favourites")
            {
                btnAddToFavourite.Enabled = false;
                cbxArchiveStrip.ResetText();
                cbxArchiveStrip.Items.Clear();
                var doc = new XmlDocument();
                doc.Load("BookMarksDB.xml");
                XmlNodeList colorList = doc.SelectNodes("BookMarks/BookMark");
                foreach (XmlNode color in colorList)
                {
                    foreach (XmlNode xxxx in color)
                    {
                        if (xxxx.Name == "ImagePath")
                            cbxArchiveStrip.Items.Add((((xxxx))).InnerText);
                    }
                }
            }
            else
            {
                btnAddToFavourite.Enabled = true;
                cbxArchiveStrip.ResetText();
                cbxArchiveStrip.Items.Clear();
                string dirpath = AppSettings.ComicArchiveFolder + "\\" + cbxComic.Text + "\\";
                //Application.StartupPath + "\\Strip" + "\\" + cbxComic.Text + "\\";
                GetDirectoryFileCount(dirpath);
                ctlInfo.Text = "";
                ctlTotalComics.Text = "| Total Comic Strips: " + file_count/2;
                file_count = 0;
                FillCombo(cbxComic.Text);
                cbxArchiveStrip.ResetText();
            }
        }

        private void ArchiveStripPictureBox_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            return;
        }

        private void Archive_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            return;
        }

        private void btnAddToFavourite_Click(object sender, EventArgs e)
        {
            XElement doc = XElement.Load("BookMarksDB.xml");
            //var xml = new XElement("BookMarks",
            //                       new XElement("BookMark",
            //                                    new XElement("Image", currentFileName),
            //                                    new XElement("ImagePath", currentFilePath),
            //                                    new XElement("BookMarkedDate", DateTime.Now.ToString())
            //                           )
            //  );
            if (cbxComic.Text != "Favourites")
            {
                var xml =
                    new XElement("BookMark",
                                 new XElement("Image", currentFileName),
                                 new XElement("ImagePath", currentFilePath),
                                 new XElement("BookMarkedDate", DateTime.Now.ToString())
                        );
                doc.Add(xml);
                doc.Save("BookMarksDB.xml");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //explorer /select  D:\stuff\My Dropbox\MCDailyDilbert\MetaComics.Client\bin\Debug\Strip\FamilyCircus\2011-02-10\fs_2011-02-10_158807.gif
            Process.Start("explorer.exe", "/select," + xfilename);
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

        private void btnSlideShow_Click(object sender, EventArgs e)
        {
            GetComicStripList();
            if (timer.Enabled)
            {
                timer.Enabled = false;
                // button4.Text = "<< START Slide Show >>";
            }
            else
            {
                timer.Enabled = true;
                //  button4.Text = "<< STOP Slide Show >>";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            nextImage();
            //timer.Enabled = true;
            //GetComicStripList();
            //timer.Enabled = false;
        }

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    var popup = new PopupWindow(txtComicInfo);
        //    popup.Show();
        //} 
    }
}