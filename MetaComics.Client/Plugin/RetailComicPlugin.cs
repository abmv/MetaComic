using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using MetaComics.Client.Code;

namespace MetaComics.Client.Plugin
{
    public sealed class RetailComicPlugin : IComicPlugin
    {
        #region IComicPlugin Members

        public void ReadComicStripFeed()
        {
            var request = (HttpWebRequest) WebRequest.Create("http://www.retailcomic.com/?feed=rss2");
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0)";
            using (WebResponse response = request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (XmlReader reader = XmlReader.Create(responseStream))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                foreach (SyndicationItem item in feed.Items)
                {
                    string x = item.Title.Text;
                    DateTime parsedDate;
                    //DateTime.TryParseExact(x, pattern, null, DateTimeStyles.None, out parsedDate);
                    try
                    {
                        parsedDate = DateTime.Parse(x);
                        string n = string.Format("{0:yyyy-MM-dd_}", parsedDate);
                        DownloadImageFromFeed(n, item.Summary.Text);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                reader.Close();
            }
        }

        public void DownloadImageFromFeed(string datepublished, string feeditem)
        {
            feeditem = feeditem.Replace("<p>", "");
            feeditem = feeditem.Replace("</p>", "");
            feeditem = feeditem.Replace("\n        \n    ", "");
            feeditem = feeditem.Replace("\n        ", "");
            if (!feeditem.Contains("/>"))
            {
                feeditem = feeditem + "/>";
            }
            List<Uri> x = FetchLinksFromSource(feeditem);
            Uri imagurl = x[0];
            byte[] imageData = DownloadData(imagurl); //DownloadData function from here
            var stream = new MemoryStream(imageData);
            Image img = Image.FromStream(stream);
            string FileName = imagurl.ToString().Substring(imagurl.ToString().LastIndexOf("/") + 1);
            string folder = CreateFolderStructure(datepublished.Remove(datepublished.Length - 1, 1)) + "\\" + "rtl_" +
                            datepublished;
            if (!Directory.Exists(folder))
            {
                if (!File.Exists(folder + FileName))
                    img.Save(folder + FileName);
                File.Copy("Category.xml",
                          CreateFolderStructure(datepublished.Remove(datepublished.Length - 1, 1)) + "\\" + "\\" +
                          "Category.xml", true);
            }
            stream.Close();
        }

        public Image ComicOfTheDay()
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            DirectoryInfo di = null;
            if (Directory.Exists(Application.StartupPath + "\\Strip\\Retail\\"))
            {
                di = new DirectoryInfo(Application.StartupPath + "\\Strip\\Retail\\" + currentDate);
                if (Directory.Exists(Application.StartupPath + "\\Strip\\Retail\\" + currentDate))
                {
                    FileInfo[] fiArr = di.GetFiles("*.gif");
                    int x = fiArr.GetLength(0);
                    for (int i = 0; i < x; i++)
                    {
                        if (File.Exists(di + "\\" + fiArr[i].Name))
                        {
                            Image ximg = Image.FromFile(di + "\\" + fiArr[i].Name);
                            var stream = new MemoryStream(ImageToByteArray(ximg));
                            return Image.FromStream(stream);
                        }
                    }
                }
            }
            return null;
        }

        public Image ComicOfTheDay(string comicStrip)
        {
            return ComicOfTheDay();
        }

        public string ComicName()
        {
            return "Retail";
        }

        public string ComicFeedURL
        {
            get { return "http://www.retailcomic.com/?feed=rss2"; }
        }

        public string Name
        {
            get { return "Retail"; }
        }

        public event AnnounceOutput WriteOutput;

        public string Description()
        {
            return "Retail Comic Strip Retriver";
        }

        #endregion

        public override string ToString()
        {
            return "Retail";
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

        private static string CreateFolderStructure(string datex)
        {
            string directoryString =
                CreateComicDir() + @"\" + datex;
            Directory.CreateDirectory(directoryString);
            return directoryString;
        }

        private static string CreateComicDir()
        {
            if (!Directory.Exists(AppSettings.ComicArchiveFolder + "\\Retail"))
            {
                Directory.CreateDirectory(AppSettings.ComicArchiveFolder + @"\" + "Retail");
            }
            return AppSettings.ComicArchiveFolder + "Retail";
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

        public static List<Uri> FetchLinksFromSource(string htmlSource)
        {
            var links = new List<Uri>();
            string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
            MatchCollection matchesImgSrc = Regex.Matches(htmlSource, regexImgSrc,
                                                          RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (Match m in matchesImgSrc)
            {
                string href = m.Groups[1].Value;
                links.Add(new Uri(href));
            }
            return links;
        }
    }
}