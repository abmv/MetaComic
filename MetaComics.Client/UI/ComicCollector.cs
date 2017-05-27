using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using MetaComic.Plugin.HTMLParser.HTML;
using MetaComics.Client.Code;

//NOTE: Include http header for fetch protocol.

namespace MetaComics.Client.UI
{
    public partial class ComicCollector : Form
    {
        public ComicCollector()
        {
            InitializeComponent();
        }

        //http://content.comicskingdom.net/Bizarro/
        //http://www.seattlepi.com/fun/comic.asp?feature_id=Bizarro
        private void btnCollect_Click(object sender, EventArgs e)
        {
            //System.Net.WebRequest objRequest;
            //string strURL = txtURL.Text;
            //objRequest = System.Net.WebRequest.Create(strURL);
            //objRequest.Timeout = 5000;
            //((HttpWebRequest) objRequest).UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0)";
            var oThread = new Thread(Collect);
            oThread.Start();
        }

        private void Collect()
        {
            ListBox.ObjectCollection x = ctlComicList.Items;
            foreach (string VARIABLE in x)
            {
                var imagurl = new Uri(VARIABLE);
                byte[] imageData = DownloadData(imagurl); //DownloadData function from here
                var stream = new MemoryStream(imageData);
                Image img = Image.FromStream(stream);
                string fileName = imagurl.Segments[imagurl.Segments.Length - 1];
                img.Save(txtCollectionFolder.Text + "\\" + fileName);
                //string FileName = imagurl.ToString().Substring(imagurl.ToString().LastIndexOf("/") + 1);
                //string folder = CreateFolderStructure(datepublished.Remove(datepublished.Length - 1, 1)) + "\\" + "bc_" +
                //             datepublished;
                //if (!Directory.Exists(folder))
                //{
                //    img.Save(folder + FileName);
                //    File.Copy("Category.xml",
                //              CreateFolderStructure(datepublished.Remove(datepublished.Length - 1, 1)) + "\\" + "\\" +
                //              "Category.xml", true);
                //}
            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            var oThread = new Thread(GoFetchDir);
            oThread.Start();
        }

        private void GoFetchDir()
        {
            if (!String.IsNullOrEmpty(txtURL.Text))
            {
                lblComicsInfo.Text = "Enter a URL address:";
                string url = txtURL.Text;
                lblComicsInfo.Text = "Scanning hyperlinks at: " + txtURL.Text;
                string page = GetPage(url);
                if (page == null)
                {
                    MessageBox.Show("Can't process that type of file,"
                                    +
                                    "please specify an HTML file URL."
                        );
                    return;
                }
                var parse = new ParseHTML();
                parse.Source = page;
                while (!parse.Eof())
                {
                    char ch = parse.Parse();
                    if (ch == 0)
                    {
                        AttributeList tag = parse.GetTag();
                        if (tag["href"] != null)
                            if (tag["href"].Value.EndsWith("_hires.gif"))
                            {
                                string urlx = "http://content.comicskingdom.net/Bizarro/";
                                ctlComicList.Items.Add(urlx +
                                                       tag["href"].Value);
                            }
                    }
                }
            }
        }

        private static byte[] DownloadData(Uri imagurl)
        {
            var myReq = (HttpWebRequest) WebRequest.Create(imagurl);
            (myReq).UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0)";
            WebResponse myResp = myReq.GetResponse();
            byte[] b = null;
            using (Stream stream = myResp.GetResponseStream())
            using (var ms = new MemoryStream())
            {
                int count = 0;
                do
                {
                    var buf = new byte[1024];
                    count = stream.Read(buf, 0, 1024);
                    ms.Write(buf, 0, count);
                } while (stream.CanRead && count > 0);
                b = ms.ToArray();
            }
            return b;
        }

        //http://content.comicskingdom.net/Bizarro/?C=M;O=A
        //private byte[] DownloadData(string Url, out string responseUrl)
        //{
        //    byte[] downloadedData = new byte[0];
        //    try
        //    {
        //        //Get a data stream from the url
        //        WebRequest req = WebRequest.Create(Url);
        //       // req.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0)";
        //        WebResponse response = req.GetResponse();
        //        Stream stream = response.GetResponseStream();
        //        responseUrl = response.ResponseUri.ToString();
        //        //Download in chuncks
        //        byte[] buffer = new byte[1024];
        //        //Get Total Size
        //        int dataLength = (int)response.ContentLength;
        //        //Download to memory
        //        //Note: adjust the streams here to download directly to the hard drive
        //        MemoryStream memStream = new MemoryStream();
        //        while (true)
        //        {
        //            //Try to read the data
        //            int bytesRead = stream.Read(buffer, 0, buffer.Length);
        //            if (bytesRead == 0)
        //            {
        //                break;
        //            }
        //            else
        //            {
        //                //Write the downloaded data
        //                memStream.Write(buffer, 0, bytesRead);
        //            }
        //        }
        //        //Convert the downloaded stream to a byte array
        //        downloadedData = memStream.ToArray();
        //        //Clean up
        //        stream.Close();
        //        memStream.Close();
        //    }
        //    catch (Exception)
        //    {
        //        responseUrl = string.Empty;
        //        return new byte[0];
        //    }
        //    return downloadedData;
        //}
        //public List<string> FetchImages(string Url)
        //{
        //    List<string> imageList = new List<string>();
        //    //Append http:// if necessary
        //    if (!Url.StartsWith("http://") && !Url.StartsWith("https://"))
        //        Url = "http://" + Url;
        //    string responseUrl = string.Empty;
        //    string htmlData = ASCIIEncoding.ASCII.GetString(DownloadData(Url, out responseUrl));
        //    if (responseUrl != string.Empty)
        //        Url = responseUrl;
        //    if (htmlData != string.Empty)
        //    {
        //        string imageHtmlCode = "<img";
        //        string imageSrcCode = @"src=""";
        //        int index = htmlData.IndexOf(imageHtmlCode);
        //        while (index != -1)
        //        {
        //            //Remove previous data
        //            htmlData = htmlData.Substring(index);
        //            //Find the location of the two quotes that mark the image's location
        //            int brackedEnd = htmlData.IndexOf('>'); //make sure data will be inside img tag
        //            int start = htmlData.IndexOf(imageSrcCode) + imageSrcCode.Length;
        //            int end = htmlData.IndexOf('"', start + 1);
        //            //Extract the line
        //            if (end > start && start < brackedEnd)
        //            {
        //                string loc = htmlData.Substring(start, end - start);
        //                //Store line
        //                imageList.Add(loc);
        //            }
        //            //Move index to next image location
        //            if (imageHtmlCode.Length < htmlData.Length)
        //                index = htmlData.IndexOf(imageHtmlCode, imageHtmlCode.Length);
        //            else
        //                index = -1;
        //        }
        //        //Format the image URLs
        //        for (int i = 0; i < imageList.Count; i++)
        //        {
        //            string img = imageList[i];
        //            string baseUrl = GetBaseURL(Url);
        //            if ((!img.StartsWith("http://") && !img.StartsWith("https://"))
        //                && baseUrl != string.Empty)
        //                img = baseUrl + "/" + img.TrimStart('/');
        //            imageList[i] = img;
        //        }
        //    }
        //    return imageList;
        //}
        private string GetBaseURL(string Url)
        {
            int inx = Url.IndexOf("://") + "://".Length;
            int end = Url.IndexOf('/', inx);
            string baseUrl = string.Empty;
            if (end != -1)
                return Url.Substring(0, end);
            else
                return string.Empty;
        }

        public static string GetPage(string url)
        {
            WebResponse response = null;
            Stream stream = null;
            StreamReader
                reader = null;
            try
            {
                var request =
                    (HttpWebRequest) WebRequest.Create(url);
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0)";
                response = request.GetResponse();
                stream = response.GetResponseStream();
                if (!response.ContentType.ToLower().StartsWith("text/"))
                    return null;
                string buffer = "", line;
                reader = new StreamReader(stream);
                while ((line = reader.ReadLine()) != null)
                {
                    buffer += line + "\r\n";
                }
                return buffer;
            }
            catch (WebException e)
            {
                Console.WriteLine("Can't download:" + e);
                return null;
            }
            catch (IOException e)
            {
                Console.WriteLine("Can't download:" + e);
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (stream != null)
                    stream.Close();
                if (response != null)
                    response.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSetCollectionFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.SelectedPath = txtCollectionFolder.Text;
            folderBrowserDialog.ShowDialog(this);
            //if (String.IsNullOrEmpty(txtCollectionFolder.Text)) 
            //{
            //    folderBrowserDialog.SelectedPath = txtCollectionFolder.Text;
            //}
            folderBrowserDialog.Description = "Select a folder to save collection:";
            txtCollectionFolder.Text = folderBrowserDialog.SelectedPath;
        }

        private void ComicCollector_Load(object sender, EventArgs e)
        {
            txtCollectionFolder.Text = AppSettings.ComicArchiveFolder;
        }
    }
}