using System;
using System.IO;
using System.Net;
using MetaComic.Plugin.HTMLParser.HTML;

namespace MetaComics.Client.Code
{
    /// <summary>
    /// FindLinks is a class that will test the HTML parser.
    /// This short example will prompt for a URL and then
    /// scan that URL for links.
    /// This source code may be used freely under the
    /// Limited GNU Public License(LGPL).
    ///
    /// Written by Jeff Heaton (http://www.jeffheaton.com)
    /// </summary>
    internal class FindLinks
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Console.Write("Enter a URL address:");
            string url = Console.ReadLine();
            Console.WriteLine("Scanning hyperlinks at: " + url);
            string page = GetPage(url);
            if (page == null)
            {
                Console.WriteLine("Can't process that type of file,"
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
                        Console.WriteLine("Found link: " +
                                          tag["href"].Value);
                }
            }
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
    }
}