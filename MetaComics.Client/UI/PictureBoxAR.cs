using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MetaComics.Client
{
    /// <summary>
    /// AutoResizePictureBox keeps the aspect ratio of an image when displayed.
    /// </summary>
    public class PictureBoxAR : PictureBox
    {
        //#region Attributes
        private bool autoChangeMaxSize;
        private bool centerImage = true;
        private Size imageSize;
        private int left;
        private int maxBmpHeight;
        private int maxBmpWidth;
        private int top;

        /// <summary>
        /// Creates a new instance of the component PictureBoxAR (Constructor used by fashion designer in VS)
        /// </summary>
        public PictureBoxAR()
        {
            ImageChanged += PictureBoxEx_ImageChanged;
            Resize += PictureBoxAR_Resize;
            autoChangeMaxSize = true;
        }

        /// <summary>
        ///Creates a new instance of the component PictureBoxAR.The maximum size of the image is specified, 
        /// it will not be recalculated automatically when resize component
        /// </summary>
        /// <param name="maximumWidth">Specifies the maximum width of the image</param>
        /// <param name="maximumHeight">Specifies the maximum height of the image</param>
        public PictureBoxAR(int maximumWidth, int maximumHeight)
        {
            ImageChanged += PictureBoxEx_ImageChanged;
            maxBmpHeight = maximumHeight;
            maxBmpWidth = maximumWidth;
            autoChangeMaxSize = false;
        }

        //#region Accessors
        [Category("Behavior"),
         Description("Détermine si le composant doit recalculer la taille de l'image lorsqu'il a été redimmensionné"),
         DefaultValue(true)]
        public bool AutoChangeMaxSize
        {
            get { return autoChangeMaxSize; }
            set
            {
                autoChangeMaxSize = value;
                Refresh();
            }
        }

        [Category("Behavior"), Description("Détermine si le composant doit center l'image"), DefaultValue(true)]
        public bool CenterImage
        {
            get { return centerImage; }
            set
            {
                centerImage = value;
                Refresh();
            }
        }

        public new Image Image
        {
            get { return base.Image; }
            set
            {
                base.Image = value;
                ImageChanged(this, new EventArgs());
            }
        }

        [Category("Property Changed"),
         Description("Evènement déclenché quand la valeur de la propriété Image est changée sur le composant")]
        public event EventHandler ImageChanged;

        //#region #Constructors
        //#region Private methods
        private void ComputeSizeAndInitialPosition()
        {
            ComputeImageSize();
            ComputeInitialPosition();
        }

        private void ComputeInitialPosition()
        {
            try
            {
                if (centerImage == false)
                    left = top = 0;
                else
                {
                    left = (Width - imageSize.Width)/2;
                    top = (Height - imageSize.Height)/2;
                }
            }
            catch (Exception)
            {
                left = 0;
                top = 0;
            }
        }

        private void ComputeImageSize()
        {
            if (Image != null)
            {
                if (Image.Height > Image.Width)
                    imageSize = new Size(((Image.Width*maxBmpHeight)/Image.Height), maxBmpHeight);
                else
                    imageSize = new Size(maxBmpWidth, ((Image.Height*maxBmpWidth)/Image.Width));
            }
            else
                imageSize = Size.Empty;
        }

        private void ChangeMaxSize()
        {
            if (autoChangeMaxSize)
            {
                maxBmpHeight = ClientRectangle.Height;
                maxBmpWidth = ClientRectangle.Width;
            }
        }

        //#region Methods overrideable
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image != null)
            {
                Graphics g = e.Graphics;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(Image, new Rectangle(left, top, imageSize.Width, imageSize.Height),
                            new Rectangle(0, 0, Image.Width, Image.Height),
                            GraphicsUnit.Pixel);
            }
        }

        public override void Refresh()
        {
            ChangeMaxSize();
            ComputeSizeAndInitialPosition();
            base.Refresh();
        }

        //#region Events
        private void PictureBoxEx_ImageChanged(object sender, EventArgs e)
        {
            ComputeSizeAndInitialPosition();
        }

        private void PictureBoxAR_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}