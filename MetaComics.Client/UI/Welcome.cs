using System;
using System.Configuration;
using System.Windows.Forms;

namespace MetaComics.Client.UI
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (chkDoNotShowAtStartUp.Checked)
            {
                config.AppSettings.Settings["ShowWelcomefcScreen"].Value = "False";
            }
            else
            {
                config.AppSettings.Settings["ShowWelcomefcScreen"].Value = "True";
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            Close();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            AcceptButton = btnOK;
        }
    }
}