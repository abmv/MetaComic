using System.Timers;
using System.Windows.Forms;

namespace MetaComics.Client.UI
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            Opacity = 0;
            Show();
            tmrFade.Enabled = true;
        }

        private void tmrFade_Elapsed(object sender, ElapsedEventArgs e)
        {
            Opacity += 0.05;
            if (Opacity >= .95)
            {
                Opacity = 1;
                tmrFade.Enabled = false;
            }
        }
    }
}