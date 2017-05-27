using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting;
using System.Windows.Forms;
using ExceptionReporting;
using MetaComics.Client.Code;
using MetaComics.Client.Plugin;

namespace MetaComics.Client.UI
{
    public partial class Plugins : Form
    {
        public static string[] strArray;
        public static List<string> blackList;

        public Plugins()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Plugins_Load(object sender, EventArgs e)
        {
            LoadPlugins();
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            SelectedHandlers.Items.AddRange(AvailableHandlers.Items);
            AvailableHandlers.Items.Clear();
        }

        private void Deselect_Click(object sender, EventArgs e)
        {
            DeselectItem();
        }

        private void DeselectAll_Click(object sender, EventArgs e)
        {
            AvailableHandlers.Items.AddRange(SelectedHandlers.Items);
            SelectedHandlers.Items.Clear();
        }

        private void DeselectItem()
        {
            if (SelectedHandlers.SelectedItem != null)
            {
                AvailableHandlers.Items.Add(SelectedHandlers.SelectedItem);
                SelectedHandlers.Items.Remove(SelectedHandlers.SelectedItem);
            }
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            IList<string> strings = new List<string>();
            PluginInfo.internalList.Clear();
            string joined = "";
            foreach (IComicPlugin plg in SelectedHandlers.Items)
            {
                if (PluginInfo.internalList.Contains<IComicPlugin>(plg))
                {
                    PluginInfo.internalList.Remove(plg);
                    strings.Remove(plg.Name);
                    Description.Text = "Removed";
                }
                else
                {
                    PluginInfo.internalList.Add(plg);
                    strings.Add(plg.Name);
                    Description.Text = "Added";
                }
                string[] array = strings.ToArray();
                joined = string.Join(",", strings.ToArray());
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ActivePlugins"].Value = joined;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void SelectOne_Click(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void SelectItem()
        {
            if (AvailableHandlers.SelectedItem != null)
            {
                SelectedHandlers.Items.Add(AvailableHandlers.SelectedItem);
                AvailableHandlers.Items.Remove(AvailableHandlers.SelectedItem);
            }
        }

        private void AvailableHandlers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            // Displays the description of the class.
            //
            try
            {
                if (AvailableHandlers.SelectedItem == null)
                    return;
                var plug = (IComicPlugin) AvailableHandlers.SelectedItem;
                Description.Text = plug.Description();
                plug = null;
            }
            catch
            {
            }
        }

        private void SelectedHandlers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            // Displays the description of the class.
            //
            try
            {
                if (SelectedHandlers.SelectedItem == null)
                    return;
                var plug = (IComicPlugin) SelectedHandlers.SelectedItem;
                Description.Text = plug.Description();
                plug = null;
            }
            catch
            {
            }
        }

        ///	<summary>
        ///	Loads the plugins from the configuration file.
        ///	</summary>
        private void LoadPlugins()
        {
            blackList = new List<string>();
            string strValue = ConfigurationManager.AppSettings["ActivePlugins"];
            strArray = strValue.Split(',');
            var arList = new ArrayList();
            for (int i = 0; i < strArray.Length; i++)
            {
                arList.Add(strArray[i]);
                blackList.Add(strArray[i]);
            }
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
                        //
                        if (blackList != null)
                        {
                            if (blackList.Contains(plug.Name))
                            {
                                AvailableHandlers.Items.Remove(plug);
                                SelectedHandlers.Items.Add(plug);
                            }
                            else
                            {
                                AvailableHandlers.Items.Add(plug);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        var reporter = new ExceptionReporter();
                        reporter.ReadConfig(); // optionally, read properties from the application's config file
                        reporter.Config.ShowSysInfoTab = false; // alternatively, set properties programmatically
                        reporter.Config.ShowFlatButtons = true; // this particular config is code-only
                        reporter.Show(e);
                    }
                }
            }
        }
    }
}