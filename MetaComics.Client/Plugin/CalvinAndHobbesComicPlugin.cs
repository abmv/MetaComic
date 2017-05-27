using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Net;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.Xml;
using MetaComics.Client.Code;

//The element with name 'RDF' and namespace 'http://www.w3.org/1999/02/22-rdf-syntax-ns#' is not an allowed feed format.

namespace MetaComics.Client.Plugin
{
    internal class CalvinAndHobbesComicPlugin : IComicPlugin
    {
        #region IComicPlugin Members

        public event AnnounceOutput WriteOutput;

        public string Description()
        {
            return "Calvin And Hobbes Comic Strip Retriver";
        }

        public void DownloadImageFromFeed(string datepublished, string feeditem)
        {
            var imagurl = new Uri(feeditem);
            byte[] imageData = DownloadData(imagurl); //DownloadData function from here
            var stream = new MemoryStream(imageData);
            Image img = Image.FromStream(stream);
            string FileName = imagurl.ToString().Substring(imagurl.ToString().LastIndexOf("/") + 1);
            string folder = CreateFolderStructure(datepublished) + "\\" + "cal_" + datepublished;
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

        public void ReadComicStripFeed()
        {
            //XmlReader reader = XmlReader.Create("http://wdr1.com/blog/calvin_and_hobbes.rdf");
            var request = (HttpWebRequest) WebRequest.Create("http://wdr1.com/blog/calvin_and_hobbes.rdf");
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0)";
            using (WebResponse response = request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (XmlReader reader = XmlReader.Create(responseStream))
            {
                var result = new SyndicationFeed();
                if (result == null)
                    throw new ArgumentNullException("result");
                else if (reader == null)
                    throw new ArgumentNullException("reader");
                reader.ReadStartElement(); // Read in <RDF>
                reader.ReadStartElement("channel"); // Read in <channel>
                while (reader.IsStartElement()) // Process <channel> children
                {
                    if (reader.IsStartElement("title"))
                        result.Title = new TextSyndicationContent(reader.ReadElementString());
                    else if (reader.IsStartElement("link"))
                        result.Links.Add(new SyndicationLink(new Uri(reader.ReadElementString())));
                    else if (reader.IsStartElement("description"))
                        result.Description = new TextSyndicationContent(reader.ReadElementString());
                    else
                        reader.Skip();
                }
                reader.ReadEndElement(); // Read in </channel>
                while (reader.IsStartElement())
                {
                    if (reader.IsStartElement("item"))
                    {
                        ReadItemFrom(reader);
                        break;
                    }
                    else
                        reader.Skip();
                }
                reader.Close();
            }
        }

        public Image ComicOfTheDay()
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            DirectoryInfo di = null;
            if (Directory.Exists(Application.StartupPath + "\\Strip\\Calvin And Hobbes\\"))
            {
                di = new DirectoryInfo(Application.StartupPath + "\\Strip\\Calvin And Hobbes\\" + currentDate);
                if (Directory.Exists(Application.StartupPath + "\\Strip\\Calvin And Hobbes\\" + currentDate))
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
            return "Calvin And Hobbes";
        }

        public string ComicFeedURL
        {
            get { return "http://wdr1.com/blog/calvin_and_hobbes.rdf"; }
        }

        public string Name
        {
            get { return "Calvin And Hobbes"; }
        }

        #endregion

        public override string ToString()
        {
            return "Calvin And Hobbes";
        }

        protected virtual void ReadItemFrom(XmlReader reader)
        {
            string filename = "";
            reader.ReadStartElement();
            while (reader.IsStartElement())
            {
                while (reader.Read())
                {
                    try
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Text: //Display the text in each element.
                                Console.WriteLine(reader.Value);
                                if (reader.Value.StartsWith("Calvin and Hobbes for "))
                                {
                                    filename = reader.Value;
                                    filename = filename.Replace("Calvin and Hobbes for ", "");
                                    string pattern = "MMMM d, yyyy";
                                    DateTime parsedDate;
                                    DateTime.TryParseExact(filename, pattern, null, DateTimeStyles.None, out parsedDate);
                                    filename = string.Format("{0:yyyy-MM-dd}", parsedDate);
                                }
                                if (reader.Value.EndsWith(".gif"))
                                {
                                    DownloadImageFromFeed(filename, reader.Value);
                                }
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
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

        private static string CreateFolderStructure(string datex)
        {
            string directoryString =
                CreateComicDir() + @"\" + datex;
            Directory.CreateDirectory(directoryString);
            return directoryString;
        }

        private static string CreateComicDir()
        {
            if (!Directory.Exists(AppSettings.ComicArchiveFolder +  "\\Calvin And Hobbes"))
            {
                Directory.CreateDirectory(AppSettings.ComicArchiveFolder + @"\" + "Calvin And Hobbes");
            }
            return AppSettings.ComicArchiveFolder + @"\" + "Calvin And Hobbes";
        }
    }
}