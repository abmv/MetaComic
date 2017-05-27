using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Cliver;
using NLog;

//1.Check  http://mcdailydilbert.codeplex.com/project/feeds/rss?ProjectRSSFeed=codeplex%3a%2f%2frelease%2fmcdailydilbert 
// for new release logic.
//  Check for updates by using the release RSS feed ([url:http://www.codeplex.com/chirpr/Project/ProjectRss.aspx?ProjectRSSFeed=codeplex%3a%2f%2frelease%2fchirpr]). Look for a title of "Released: [0-9]+\.[0-9]+((\.[0-9]+(\.[0-9]+)?)? ".
// [DONE]

namespace MetaComics.Client.Code
{
    internal class CodePlexUpdateChecker
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public static void CheckURL()
        {
            DateTime releaseDate = AppSettings.ReleaseDate;
            // in newVersion variable we will store the
            // version info from xml file
            Version newVersion = null;
            // and in this variable we will put the url we
            // would like to open so that the user can
            // download the new version
            // it can be a homepage or a direct
            // link to zip/exe file
            string url = "";
            XmlTextReader reader = null;
            try
            {
                _logger.Trace("Checking for updates....");
                // provide the XmlTextReader with the URL of
                // our xml document
                string xmlURL =
                    "http://metacomic.codeplex.com/project/feeds/rss?ProjectRSSFeed=codeplex%3a%2f%2frelease%2fmetacomic";
                reader = new XmlTextReader(xmlURL);
                // simply (and easily) skip the junk at the beginning
                reader.MoveToContent();
                // internal - as the XmlTextReader moves only
                // forward, we save current xml element name
                // in elementName variable. When we parse a
                // text node, we refer to elementName to check
                // what was the node name
                string elementName = "";
                // we check if the xml starts with a proper
                // "ourfancyapp" element node
                if ((reader.NodeType == XmlNodeType.Element) &&
                    (reader.Name == "rss"))
                {
                    while (reader.Read())
                    {
                        // when we find an element node,
                        // we remember its name
                        if (reader.NodeType == XmlNodeType.Element)
                            elementName = reader.Name;
                        if (elementName == "title")
                        {
                            if (reader.Value.StartsWith("Released") | reader.Value.StartsWith("RELEASED"))
                            {
                                string s = reader.Value;
                                //int start = s.IndexOf("(");
                                ////int end = s.IndexOf(")");
                                ////int n = text.indexOf("(");
                                //if (start >= 0)
                                //{
                                //    start = s.IndexOf("(", start + 1);
                                //}
                                //int end = s.IndexOf(")");
                                //string result = s.Substring(start, end - start - 1);
                                //string input1 = reader.Value;
                                //int start1 = input1.IndexOf("(");
                                //int stop1 = input1.IndexOf(")");
                                //string output1 = input1.Substring(start1 + 1, stop1 - start1 - 1);
                                MatchCollection matches = Regex.Matches(s, @"\(([^)]*)\)");
                                String output1 = matches[1].Groups[1].Value;
                                DateTimeRoutines.ParsedDateTime dt;
                                DateTimeRoutines.TryParseDateOrTime(output1,
                                                                    DateTimeRoutines.DateTimeFormat.USA_DATE, out dt);
                                UpdatesMessage(releaseDate, dt.DateTime);
                                return;
                            }
                        }
                        else
                        {
                            // for text nodes...
                            if ((reader.NodeType == XmlNodeType.Text) &&
                                (reader.HasValue))
                            {
                                // we check what the name of the node was
                                switch (elementName)
                                {
                                    case "version":
                                        // thats why we keep the version info
                                        // in xxx.xxx.xxx.xxx format
                                        // the Version class does the
                                        // parsing for us
                                        newVersion = new Version(reader.Value);
                                        break;
                                    case "url":
                                        url = reader.Value;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }

        private static void UpdatesMessage(DateTime releaseDate, DateTime dt)
        {
            if (releaseDate.CompareTo(dt) == 0)
            {
                MessageBox.Show("No updates are currently available.Check back later.", "Application Update Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            if (releaseDate.CompareTo(dt) > 0)
            {
                MessageBox.Show("No updates are currently available.Check back later.", "Application Update Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            if (releaseDate.CompareTo(dt) < 0)
            {
                DialogResult dlgRes;
                dlgRes =
                    MessageBox.Show(
                        "An update is available on codeplex site." + "\n" + "Would you like to open update page?",
                        "Application Update Information",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question);
                if (dlgRes == DialogResult.OK)
                {
                    Process.Start("http://metacomic.codeplex.com/releases/");
                }
            }
        }
    }
}