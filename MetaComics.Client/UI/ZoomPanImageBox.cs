/* 
 * Developed by Shannon Young.  http://www.smallwisdom.com
 * Copyright 2005
 * 
 * You are welcome to use, edit, and redistribute this code.
 * 
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Smallwisdom.Windows.Forms
{
    /// <summary>
    /// ZoomPanImageBox is a specialized ImageBox with Pan and Zoom control.
    /// </summary>
    public class ZoomPanImageBox : UserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private readonly Container components;

        /// <summary>
        /// The zoom factor for this control.  Currently, it is hardcoded, 
        /// but perhaps a nice addition would be to set this?
        /// </summary>
        private readonly double[] zoomFactor = {.25, .33, .50, .66, .80, 1, 1.25, 1.5, 2.0, 2.5, 3.0};

        // zoom controls
        private GroupBox groupBox1;
        private Panel imagePanel;
        private PictureBox imgBox;
        private Label lblCenter;
        private Label lblMax;
        private Label lblMin;
        private TrackBar scrollZoom;
        //#region Construct, Dispose
        public ZoomPanImageBox()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            // Initialize anything not included in the designer
            init();
        }

        /// <summary>
        /// Image loaded into the box.
        /// </summary>
        [Browsable(true),
         Description("Image loaded into the box.")]
        public Image Image
        {
            get { return imgBox.Image; }
            set
            {
                // Set the image value
                imgBox.Image = value;
                // enable the zoom control if this is not a null image
                scrollZoom.Enabled = (value != null);
                if (scrollZoom.Enabled)
                {
                    // reset zoom control
                    scrollZoom.Value = scrollZoom.Maximum/2;
                    // Initially, the zoom factor is 100% so set the
                    // ImageBox size equal to the Image size.
                    imgBox.Size = value.Size;
                }
                else
                {
                    // If null image, then reset the imgBox size
                    // to the size of the panel so that there are no
                    // scroll bars.
                    imgBox.Size = imagePanel.Size;
                }
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        //#region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            lblMax = new Label();
            lblMin = new Label();
            lblCenter = new Label();
            scrollZoom = new TrackBar();
            imagePanel = new Panel();
            imgBox = new PictureBox();
            groupBox1.SuspendLayout();
            ((ISupportInitialize) (scrollZoom)).BeginInit();
            imagePanel.SuspendLayout();
            ((ISupportInitialize) (imgBox)).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((((AnchorStyles.Top | AnchorStyles.Left)
                                  | AnchorStyles.Right)));
            groupBox1.Controls.Add(lblMax);
            groupBox1.Controls.Add(lblMin);
            groupBox1.Controls.Add(lblCenter);
            groupBox1.Controls.Add(scrollZoom);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular,
                                      GraphicsUnit.Point, ((0)));
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(318, 63);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Zoom Comic";
            // 
            // lblMax
            // 
            lblMax.Anchor = (((AnchorStyles.Top | AnchorStyles.Right)));
            lblMax.Location = new Point(237, 38);
            lblMax.Name = "lblMax";
            lblMax.Size = new Size(72, 23);
            lblMax.TabIndex = 3;
            lblMax.Text = "300%";
            lblMax.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMin
            // 
            lblMin.Location = new Point(16, 38);
            lblMin.Name = "lblMin";
            lblMin.Size = new Size(56, 23);
            lblMin.TabIndex = 2;
            lblMin.Text = "25%";
            lblMin.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCenter
            // 
            lblCenter.Anchor = AnchorStyles.Top;
            lblCenter.Location = new Point(131, 38);
            lblCenter.Name = "lblCenter";
            lblCenter.Size = new Size(64, 23);
            lblCenter.TabIndex = 1;
            lblCenter.Text = "100%";
            lblCenter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // scrollZoom
            // 
            scrollZoom.Anchor = ((((AnchorStyles.Top | AnchorStyles.Left)
                                   | AnchorStyles.Right)));
            scrollZoom.Enabled = false;
            scrollZoom.LargeChange = 1;
            scrollZoom.Location = new Point(16, 13);
            scrollZoom.Name = "scrollZoom";
            scrollZoom.Size = new Size(293, 42);
            scrollZoom.TabIndex = 0;
            scrollZoom.Value = 5;
            scrollZoom.Scroll += scrollZoom_Scroll;
            // 
            // imagePanel
            // 
            imagePanel.Anchor = (((((AnchorStyles.Top |
                                     AnchorStyles.Bottom)
                                    | AnchorStyles.Left)
                                   | AnchorStyles.Right)));
            imagePanel.AutoScroll = true;
            imagePanel.Controls.Add(imgBox);
            imagePanel.Location = new Point(0, 72);
            imagePanel.Name = "imagePanel";
            imagePanel.Size = new Size(816, 459);
            imagePanel.TabIndex = 1;
            // 
            // imgBox
            // 
            imgBox.Location = new Point(0, 0);
            imgBox.Name = "imgBox";
            imgBox.Size = new Size(200, 200);
            imgBox.SizeMode = PictureBoxSizeMode.StretchImage;
            imgBox.TabIndex = 6;
            imgBox.TabStop = false;
            // 
            // ZoomPanImageBox
            // 
            Controls.Add(groupBox1);
            Controls.Add(imagePanel);
            Name = "ZoomPanImageBox";
            Size = new Size(824, 555);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((ISupportInitialize) (scrollZoom)).EndInit();
            imagePanel.ResumeLayout(false);
            ((ISupportInitialize) (imgBox)).EndInit();
            ResumeLayout(false);
        }

        /// <summary>
        /// Initialization code goes here.
        /// </summary>
        private void init()
        {
            // Add keydown event handler to check if this is a Ctrl+ or Ctrl-
            // If so, then it will change the zoom scroll.
            KeyDown += ImageBoxPanZoom_KeyDown;
        }

        private void ImageBoxPanZoom_KeyDown(object sender, KeyEventArgs e)
        {
            // Was the key combination that was pressed Ctrl+ or Ctrl-?
            // If so, then change the zoom level (but only if the zoom
            // is enabled)
            if (scrollZoom.Enabled)
            {
                // Note: The e.KeyData is the combination of all the
                // keys currently pressed down.  To find out if this is
                // the Ctrl key *and* the + key, you "or" the Keys 
                // together. This is a bitwise "or" rather than the 
                // || symbol used for boolean logic.
                if ((e.KeyData == (Keys.Oemplus | Keys.Control)) &&
                    (scrollZoom.Value != scrollZoom.Maximum))
                {
                    scrollZoom.Value++;
                    setZoom();
                }
                else if ((e.KeyData == (Keys.OemMinus | Keys.Control)) &&
                         (scrollZoom.Value != scrollZoom.Minimum))
                {
                    scrollZoom.Value--;
                    setZoom();
                }
            }
        }

        private void scrollZoom_Scroll(object sender, EventArgs e)
        {
            setZoom();
        }

        private void setZoom()
        {
            // The scrollZoom changed so reset the zoom factor
            // based on the scrollZoom TrackBar position.
            double newZoom = zoomFactor[scrollZoom.Value];
            // Set the ImageBox width and height to the new zoom
            // factor by multiplying the Image inside the Imagebox
            // by the new zoom factor.
            imgBox.Width = Convert.ToInt32(imgBox.Image.Width*newZoom);
            imgBox.Height = Convert.ToInt32(imgBox.Image.Height*newZoom);
        }
    }

// end class
}

// end namespace