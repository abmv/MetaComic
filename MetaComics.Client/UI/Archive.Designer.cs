namespace MetaComics.Client.UI
{
    partial class Archive
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //#region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Archive));
            this.cbxArchiveStrip = new System.Windows.Forms.ComboBox();
            this.btnViewComicStrip = new System.Windows.Forms.Button();
            this.ctlComicFormatGroup = new System.Windows.Forms.GroupBox();
            this.ctlCBZComicFormat = new System.Windows.Forms.RadioButton();
            this.ctlPDFComicFormat = new System.Windows.Forms.RadioButton();
            this.btnGenerateComic = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ctlInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.ctlTotalComics = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.btnTags = new System.Windows.Forms.Button();
            this.ctlTagList = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeleteTag = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddToFavourite = new System.Windows.Forms.Button();
            this.cbxComic = new System.Windows.Forms.ComboBox();
            this.btnOpenFileinExplorer = new System.Windows.Forms.Button();
            this.btnSlideShow = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.ArchiveStripPictureBox = new Smallwisdom.Windows.Forms.ZoomPanImageBox();
            this.ctlComicFormatGroup.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxArchiveStrip
            // 
            this.cbxArchiveStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxArchiveStrip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxArchiveStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxArchiveStrip.FormattingEnabled = true;
            this.cbxArchiveStrip.Location = new System.Drawing.Point(183, 13);
            this.cbxArchiveStrip.Name = "cbxArchiveStrip";
            this.cbxArchiveStrip.Size = new System.Drawing.Size(450, 24);
            this.cbxArchiveStrip.TabIndex = 1;
            this.cbxArchiveStrip.SelectedIndexChanged += new System.EventHandler(this.cbxArchiveStrip_SelectedIndexChanged);
            // 
            // btnViewComicStrip
            // 
            this.btnViewComicStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewComicStrip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewComicStrip.Location = new System.Drawing.Point(670, 13);
            this.btnViewComicStrip.Name = "btnViewComicStrip";
            this.btnViewComicStrip.Size = new System.Drawing.Size(89, 23);
            this.btnViewComicStrip.TabIndex = 2;
            this.btnViewComicStrip.Text = "View Comic Strip";
            this.btnViewComicStrip.UseVisualStyleBackColor = true;
            this.btnViewComicStrip.Click += new System.EventHandler(this.btnViewComicStrip_Click);
            // 
            // ctlComicFormatGroup
            // 
            this.ctlComicFormatGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlComicFormatGroup.Controls.Add(this.ctlCBZComicFormat);
            this.ctlComicFormatGroup.Controls.Add(this.ctlPDFComicFormat);
            this.ctlComicFormatGroup.Location = new System.Drawing.Point(670, 383);
            this.ctlComicFormatGroup.Name = "ctlComicFormatGroup";
            this.ctlComicFormatGroup.Size = new System.Drawing.Size(170, 104);
            this.ctlComicFormatGroup.TabIndex = 9;
            this.ctlComicFormatGroup.TabStop = false;
            this.ctlComicFormatGroup.Text = "Select Comic Format";
            // 
            // ctlCBZComicFormat
            // 
            this.ctlCBZComicFormat.AutoSize = true;
            this.ctlCBZComicFormat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ctlCBZComicFormat.Location = new System.Drawing.Point(19, 44);
            this.ctlCBZComicFormat.Name = "ctlCBZComicFormat";
            this.ctlCBZComicFormat.Size = new System.Drawing.Size(45, 17);
            this.ctlCBZComicFormat.TabIndex = 1;
            this.ctlCBZComicFormat.TabStop = true;
            this.ctlCBZComicFormat.Text = "CBZ";
            this.toolTip.SetToolTip(this.ctlCBZComicFormat, "Comic Book Archive file");
            this.ctlCBZComicFormat.UseVisualStyleBackColor = true;
            // 
            // ctlPDFComicFormat
            // 
            this.ctlPDFComicFormat.AutoSize = true;
            this.ctlPDFComicFormat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ctlPDFComicFormat.Location = new System.Drawing.Point(19, 20);
            this.ctlPDFComicFormat.Name = "ctlPDFComicFormat";
            this.ctlPDFComicFormat.Size = new System.Drawing.Size(45, 17);
            this.ctlPDFComicFormat.TabIndex = 0;
            this.ctlPDFComicFormat.TabStop = true;
            this.ctlPDFComicFormat.Text = "PDF";
            this.toolTip.SetToolTip(this.ctlPDFComicFormat, "Portable Document Format");
            this.ctlPDFComicFormat.UseVisualStyleBackColor = true;
            // 
            // btnGenerateComic
            // 
            this.btnGenerateComic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateComic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerateComic.Location = new System.Drawing.Point(670, 493);
            this.btnGenerateComic.Name = "btnGenerateComic";
            this.btnGenerateComic.Size = new System.Drawing.Size(170, 27);
            this.btnGenerateComic.TabIndex = 10;
            this.btnGenerateComic.Text = "Generate Comic";
            this.btnGenerateComic.UseVisualStyleBackColor = true;
            this.btnGenerateComic.Click += new System.EventHandler(this.btnGenerateComic_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ctlInfo,
            this.ctlTotalComics});
            this.statusStrip1.Location = new System.Drawing.Point(0, 532);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(846, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabel1.Text = "-";
            // 
            // ctlInfo
            // 
            this.ctlInfo.Name = "ctlInfo";
            this.ctlInfo.Size = new System.Drawing.Size(10, 17);
            this.ctlInfo.Text = "-";
            // 
            // ctlTotalComics
            // 
            this.ctlTotalComics.Name = "ctlTotalComics";
            this.ctlTotalComics.Size = new System.Drawing.Size(10, 17);
            this.ctlTotalComics.Text = "-";
            // 
            // txtTag
            // 
            this.txtTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTag.Location = new System.Drawing.Point(670, 46);
            this.txtTag.Multiline = true;
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(89, 23);
            this.txtTag.TabIndex = 5;
            // 
            // btnTags
            // 
            this.btnTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTags.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTags.Location = new System.Drawing.Point(765, 45);
            this.btnTags.Name = "btnTags";
            this.btnTags.Size = new System.Drawing.Size(75, 23);
            this.btnTags.TabIndex = 6;
            this.btnTags.Text = "Tag";
            this.btnTags.UseVisualStyleBackColor = true;
            this.btnTags.Click += new System.EventHandler(this.btnTags_Click);
            // 
            // ctlTagList
            // 
            this.ctlTagList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlTagList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctlTagList.FormattingEnabled = true;
            this.ctlTagList.Location = new System.Drawing.Point(670, 106);
            this.ctlTagList.Name = "ctlTagList";
            this.ctlTagList.Size = new System.Drawing.Size(170, 262);
            this.ctlTagList.TabIndex = 8;
            this.ctlTagList.SelectedIndexChanged += new System.EventHandler(this.ctlTagList_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(765, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteTag
            // 
            this.btnDeleteTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTag.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTag.Location = new System.Drawing.Point(765, 73);
            this.btnDeleteTag.Name = "btnDeleteTag";
            this.btnDeleteTag.Size = new System.Drawing.Size(75, 28);
            this.btnDeleteTag.TabIndex = 7;
            this.btnDeleteTag.Text = "Delete Tag";
            this.btnDeleteTag.UseVisualStyleBackColor = true;
            this.btnDeleteTag.Click += new System.EventHandler(this.btnDeleteTag_Click);
            // 
            // btnAddToFavourite
            // 
            this.btnAddToFavourite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToFavourite.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddToFavourite.Image = ((System.Drawing.Image)(resources.GetObject("btnAddToFavourite.Image")));
            this.btnAddToFavourite.Location = new System.Drawing.Point(669, 74);
            this.btnAddToFavourite.Name = "btnAddToFavourite";
            this.btnAddToFavourite.Size = new System.Drawing.Size(29, 26);
            this.btnAddToFavourite.TabIndex = 12;
            this.toolTip.SetToolTip(this.btnAddToFavourite, "Click here to add current comic to favourites");
            this.btnAddToFavourite.UseVisualStyleBackColor = true;
            this.btnAddToFavourite.Click += new System.EventHandler(this.btnAddToFavourite_Click);
            // 
            // cbxComic
            // 
            this.cbxComic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxComic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxComic.FormattingEnabled = true;
            this.cbxComic.Location = new System.Drawing.Point(13, 13);
            this.cbxComic.Name = "cbxComic";
            this.cbxComic.Size = new System.Drawing.Size(164, 24);
            this.cbxComic.TabIndex = 0;
            this.cbxComic.SelectedIndexChanged += new System.EventHandler(this.cbxComic_SelectedIndexChanged);
            // 
            // btnOpenFileinExplorer
            // 
            this.btnOpenFileinExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFileinExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenFileinExplorer.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFileinExplorer.Image")));
            this.btnOpenFileinExplorer.Location = new System.Drawing.Point(700, 74);
            this.btnOpenFileinExplorer.Name = "btnOpenFileinExplorer";
            this.btnOpenFileinExplorer.Size = new System.Drawing.Size(29, 27);
            this.btnOpenFileinExplorer.TabIndex = 13;
            this.btnOpenFileinExplorer.UseVisualStyleBackColor = true;
            this.btnOpenFileinExplorer.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSlideShow
            // 
            this.btnSlideShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSlideShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSlideShow.Image = ((System.Drawing.Image)(resources.GetObject("btnSlideShow.Image")));
            this.btnSlideShow.Location = new System.Drawing.Point(731, 74);
            this.btnSlideShow.Name = "btnSlideShow";
            this.btnSlideShow.Size = new System.Drawing.Size(29, 27);
            this.btnSlideShow.TabIndex = 14;
            this.btnSlideShow.UseVisualStyleBackColor = true;
            this.btnSlideShow.Click += new System.EventHandler(this.btnSlideShow_Click);
            // 
            // timer
            // 
            this.timer.Interval = 7000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ArchiveStripPictureBox
            // 
            this.ArchiveStripPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ArchiveStripPictureBox.AutoScroll = true;
            this.ArchiveStripPictureBox.Image = null;
            this.ArchiveStripPictureBox.Location = new System.Drawing.Point(12, 40);
            this.ArchiveStripPictureBox.Name = "ArchiveStripPictureBox";
            this.ArchiveStripPictureBox.Size = new System.Drawing.Size(649, 489);
            this.ArchiveStripPictureBox.TabIndex = 4;
            this.ArchiveStripPictureBox.Click += new System.EventHandler(this.ArchiveStripPictureBox_Click);
            // 
            // Archive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(846, 554);
            this.Controls.Add(this.btnSlideShow);
            this.Controls.Add(this.btnOpenFileinExplorer);
            this.Controls.Add(this.btnAddToFavourite);
            this.Controls.Add(this.ArchiveStripPictureBox);
            this.Controls.Add(this.cbxComic);
            this.Controls.Add(this.btnDeleteTag);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctlTagList);
            this.Controls.Add(this.btnTags);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnGenerateComic);
            this.Controls.Add(this.ctlComicFormatGroup);
            this.Controls.Add(this.btnViewComicStrip);
            this.Controls.Add(this.cbxArchiveStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Archive";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MetaComic Archive Viewer";
            this.Load += new System.EventHandler(this.Archive_Load);
            this.Click += new System.EventHandler(this.Archive_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Archive_KeyDown);
            this.ctlComicFormatGroup.ResumeLayout(false);
            this.ctlComicFormatGroup.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        private System.Windows.Forms.ComboBox cbxArchiveStrip;
        private System.Windows.Forms.Button btnViewComicStrip;
        private System.Windows.Forms.GroupBox ctlComicFormatGroup;
        private System.Windows.Forms.RadioButton ctlCBZComicFormat;
        private System.Windows.Forms.RadioButton ctlPDFComicFormat;
        private System.Windows.Forms.Button btnGenerateComic;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Button btnTags;
        private System.Windows.Forms.ListBox ctlTagList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDeleteTag;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox cbxComic;
        private System.Windows.Forms.ToolStripStatusLabel ctlInfo;
        private Smallwisdom.Windows.Forms.ZoomPanImageBox ArchiveStripPictureBox;
        private System.Windows.Forms.ToolStripStatusLabel ctlTotalComics;
        private System.Windows.Forms.Button btnAddToFavourite;
        private System.Windows.Forms.Button btnOpenFileinExplorer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnSlideShow;
        private System.Windows.Forms.Timer timer;
    }
}