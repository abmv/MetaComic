using System;
using System.Configuration;
using System.Text;
using System.Windows.Forms;

namespace MetaComics.Client.UI
{
    public partial class Disclaimer : Form
    {
        public Disclaimer()
        {
            InitializeComponent();
            var sb = new StringBuilder(3085);
            sb.AppendLine(@"End User License Agreement (EULA)");
            sb.AppendLine(@"");
            sb.AppendLine(@"Downloading and Updates.");
            sb.AppendLine(@"");
            sb.AppendLine(
                @"MetaComic Client downloads only those files that are both authorized by you for download (specifically or by category or subscription).");
            sb.AppendLine(@"");
            sb.AppendLine(@"Disclaimer of Warranty.");
            sb.AppendLine(@"");
            sb.AppendLine(
                @"MetaComic Client disclaims any responsibility for harm resulting from MetaComic Client or any software or content downloaded using MetaComic Client, whether or not MetaComic Client approved such software or content. MetaComic Client approval does not guarantee that software or content from an approved partner will function, sound, or appear as offered or hoped, or be complete, accurate, or free from bugs, errors, viruses, or other harmful content. MetaComic Client expressly disclaims all warranties and conditions, express or implied, including any implied warranties and conditions of merchantability, fitness for a particular purpose, and noninfringement, and any warranties and conditions arising out of course of dealing or usage of trade regarding the MetaComic Client software or any software or content you download using the MetaComic Client software. No advice or information, whether oral or written, obtained from MetaComic Client or elsewhere will create any warranty or condition not expressly stated in this agreement. Some jurisdictions do not allow certain limitations on implied warranties, so the above limitation may not apply to you to its full extent.");
            sb.AppendLine(@"");
            sb.AppendLine(
                @"All intellectual property rights, including without limitation copyright, in any Information or content provided vests in it’s licensors. You may only make a copy of this content for your personal non-commercial use provided that you keep all copyright and other proprietary notices intact and you agree not to modify, reproduce, republish, upload, post, distribute or otherwise transmit or use the Information or content provided by us in any way without our prior written consent. If you do wish to use any such Information or content please contact it’s licensors and they will let you know in what terms if any you may be able to use the same.");
            sb.AppendLine(@"");
            sb.AppendLine(@"RSS URLS");
            sb.AppendLine(@"");
            sb.AppendLine(@"All URLs currenly used in the application are directly publised");
            sb.AppendLine(@"URL available on the websites or webservers.");
            sb.AppendLine(@"");
            sb.AppendLine(@"If you feel any content or part of the URL used in the");
            sb.AppendLine(@"program may not be of valid use,please contact authors ");
            sb.AppendLine(@"for immediate removal.");
            sb.AppendLine(@"");
            sb.AppendLine(@"Trademarks");
            sb.AppendLine(@"");
            sb.AppendLine(
                @"Trademarks, registered trademarks, product names or logos, and company names or logos if used are the property of their respective owners.");
            sb.AppendLine(@"");
            sb.AppendLine(
                @"MetaComic Client is not responsible for any third party website or website content (including, without limitation, any advertising appearing therein) which can be accessed through MetaComic Client.  MetaComic Client includes links to other websites for information purposes only and makes no representation whatsoever about any such link, website or content.");
            sb.AppendLine(@"");
            sb.AppendLine(
                @"MetaComic Client is provided for personal use only.You may not charge or receive any payment (including payment in kind) for MetaComic Client.");
            sb.AppendLine(@"");
            sb.AppendLine(@"You are required to remove any RSS feed that may be discontinue ");
            sb.AppendLine(@"by the provider as notified.");
            txtDisclaimer.Text = sb.ToString();
        }

        private void btnAgree_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["DisclamimerAgree"].Value = "UserAgreed";
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            Close();
        }

        private void btnDisagree_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}