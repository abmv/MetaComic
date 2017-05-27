namespace MetaComics.Client.UI
{
    partial class ComicCollector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComicCollector));
            this.lblURL = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.ctlComicList = new System.Windows.Forms.ListBox();
            this.btnCollect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblComicsInfo = new System.Windows.Forms.Label();
            this.btnGO = new System.Windows.Forms.Button();
            this.lblPattern = new System.Windows.Forms.Label();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.lblComicName = new System.Windows.Forms.Label();
            this.txtComicName = new System.Windows.Forms.TextBox();
            this.btnSetCollectionFolder = new System.Windows.Forms.Button();
            this.txtCollectionFolder = new System.Windows.Forms.TextBox();
            this.lblSetCollectionFolder = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(2, 45);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(29, 13);
            this.lblURL.TabIndex = 0;
            this.lblURL.Text = "URL";
            // 
            // txtURL
            // 
            this.txtURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtURL.Location = new System.Drawing.Point(33, 41);
            this.txtURL.Multiline = true;
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(518, 20);
            this.txtURL.TabIndex = 1;
            // 
            // ctlComicList
            // 
            this.ctlComicList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctlComicList.FormattingEnabled = true;
            this.ctlComicList.Location = new System.Drawing.Point(33, 100);
            this.ctlComicList.Name = "ctlComicList";
            this.ctlComicList.Size = new System.Drawing.Size(518, 234);
            this.ctlComicList.TabIndex = 2;
            // 
            // btnCollect
            // 
            this.btnCollect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCollect.Location = new System.Drawing.Point(395, 344);
            this.btnCollect.Name = "btnCollect";
            this.btnCollect.Size = new System.Drawing.Size(75, 23);
            this.btnCollect.TabIndex = 3;
            this.btnCollect.Text = "C&ollect";
            this.btnCollect.UseVisualStyleBackColor = true;
            this.btnCollect.Click += new System.EventHandler(this.btnCollect_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(476, 344);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblComicsInfo
            // 
            this.lblComicsInfo.AutoSize = true;
            this.lblComicsInfo.Location = new System.Drawing.Point(30, 349);
            this.lblComicsInfo.Name = "lblComicsInfo";
            this.lblComicsInfo.Size = new System.Drawing.Size(10, 13);
            this.lblComicsInfo.TabIndex = 5;
            this.lblComicsInfo.Text = "-";
            // 
            // btnGO
            // 
            this.btnGO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGO.Location = new System.Drawing.Point(558, 41);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(39, 20);
            this.btnGO.TabIndex = 6;
            this.btnGO.Text = "&GO";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // lblPattern
            // 
            this.lblPattern.AutoSize = true;
            this.lblPattern.Location = new System.Drawing.Point(28, 368);
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Size = new System.Drawing.Size(48, 13);
            this.lblPattern.TabIndex = 7;
            this.lblPattern.Text = "Exclude:";
            // 
            // txtPattern
            // 
            this.txtPattern.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPattern.Location = new System.Drawing.Point(82, 368);
            this.txtPattern.Multiline = true;
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(302, 39);
            this.txtPattern.TabIndex = 8;
            // 
            // lblComicName
            // 
            this.lblComicName.AutoSize = true;
            this.lblComicName.Location = new System.Drawing.Point(2, 13);
            this.lblComicName.Name = "lblComicName";
            this.lblComicName.Size = new System.Drawing.Size(70, 13);
            this.lblComicName.TabIndex = 9;
            this.lblComicName.Text = "Comic Name:";
            // 
            // txtComicName
            // 
            this.txtComicName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComicName.Location = new System.Drawing.Point(82, 13);
            this.txtComicName.Multiline = true;
            this.txtComicName.Name = "txtComicName";
            this.txtComicName.Size = new System.Drawing.Size(469, 20);
            this.txtComicName.TabIndex = 10;
            // 
            // btnSetCollectionFolder
            // 
            this.btnSetCollectionFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetCollectionFolder.Location = new System.Drawing.Point(557, 72);
            this.btnSetCollectionFolder.Name = "btnSetCollectionFolder";
            this.btnSetCollectionFolder.Size = new System.Drawing.Size(39, 19);
            this.btnSetCollectionFolder.TabIndex = 11;
            this.btnSetCollectionFolder.Text = "....";
            this.btnSetCollectionFolder.UseVisualStyleBackColor = true;
            this.btnSetCollectionFolder.Click += new System.EventHandler(this.btnSetCollectionFolder_Click);
            // 
            // txtCollectionFolder
            // 
            this.txtCollectionFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCollectionFolder.Location = new System.Drawing.Point(118, 70);
            this.txtCollectionFolder.Multiline = true;
            this.txtCollectionFolder.Name = "txtCollectionFolder";
            this.txtCollectionFolder.Size = new System.Drawing.Size(433, 20);
            this.txtCollectionFolder.TabIndex = 12;
            // 
            // lblSetCollectionFolder
            // 
            this.lblSetCollectionFolder.AutoSize = true;
            this.lblSetCollectionFolder.Location = new System.Drawing.Point(5, 72);
            this.lblSetCollectionFolder.Name = "lblSetCollectionFolder";
            this.lblSetCollectionFolder.Size = new System.Drawing.Size(107, 13);
            this.lblSetCollectionFolder.TabIndex = 13;
            this.lblSetCollectionFolder.Text = "Set Collection Folder:";
            // 
            // ComicCollector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(601, 412);
            this.Controls.Add(this.lblSetCollectionFolder);
            this.Controls.Add(this.txtCollectionFolder);
            this.Controls.Add(this.btnSetCollectionFolder);
            this.Controls.Add(this.txtComicName);
            this.Controls.Add(this.lblComicName);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.lblPattern);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.lblComicsInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCollect);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.ctlComicList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComicCollector";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MetaComic Comic Collector";
            this.Load += new System.EventHandler(this.ComicCollector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.ListBox ctlComicList;
        private System.Windows.Forms.Button btnCollect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblComicsInfo;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.Label lblPattern;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Label lblComicName;
        private System.Windows.Forms.TextBox txtComicName;
        private System.Windows.Forms.Button btnSetCollectionFolder;
        private System.Windows.Forms.TextBox txtCollectionFolder;
        private System.Windows.Forms.Label lblSetCollectionFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}