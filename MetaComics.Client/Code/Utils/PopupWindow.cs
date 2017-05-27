//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//namespace MetaComics.Client.Code.Utils
//{
//    class PopupWindow
//    {
//    }
//}
using System.Drawing;
using System.Windows.Forms;

namespace MetaComics.Client.Code.Utils
{
    public class PopupWindow : ToolStripDropDown
    {
        private readonly ToolStripControlHost _host;
        private Control _content;

        public PopupWindow(Control content)
        {
            //Basic setup...
            AutoSize = false;
            DoubleBuffered = true;
            ResizeRedraw = true;
            _content = content;
            _host = new ToolStripControlHost(content);
            //Positioning and Sizing
            MinimumSize = content.MinimumSize;
            MaximumSize = content.Size;
            Size = content.Size;
            content.Location = Point.Empty;
            //Add the host to the list
            Items.Add(_host);
        }
    }
}