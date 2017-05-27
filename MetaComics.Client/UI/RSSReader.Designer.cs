namespace MetaComics.Client.UI
{
    partial class RSSReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RSSReader));
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.lstNews = new System.Windows.Forms.ListView();
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlInput = new System.Windows.Forms.Panel();
            this.pnlFeedInfo = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlInput.SuspendLayout();
            this.pnlFeedInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUrl.Location = new System.Drawing.Point(73, 12);
            this.txtUrl.Multiline = true;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(337, 20);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "http://topics.nytimes.com/topics/reference/timestopics/subjects/c/comic_books_and" +
                "_strips/index.html?rss=1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Feed URL:";
            // 
            // btnRead
            // 
            this.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRead.Location = new System.Drawing.Point(416, 9);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 2;
            this.btnRead.Text = "Read Feed";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // lstNews
            // 
            this.lstNews.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstNews.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitle});
            this.lstNews.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstNews.FullRowSelect = true;
            this.lstNews.Location = new System.Drawing.Point(0, 91);
            this.lstNews.MultiSelect = false;
            this.lstNews.Name = "lstNews";
            this.lstNews.Size = new System.Drawing.Size(503, 209);
            this.lstNews.TabIndex = 3;
            this.lstNews.UseCompatibleStateImageBehavior = false;
            this.lstNews.View = System.Windows.Forms.View.Details;
            this.lstNews.SelectedIndexChanged += new System.EventHandler(this.lstNews_SelectedIndexChanged);
            this.lstNews.DoubleClick += new System.EventHandler(this.lstNews_DoubleClick);
            // 
            // colTitle
            // 
            this.colTitle.Text = "Title";
            this.colTitle.Width = 494;
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.txtUrl);
            this.pnlInput.Controls.Add(this.label1);
            this.pnlInput.Controls.Add(this.btnRead);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(503, 44);
            this.pnlInput.TabIndex = 5;
            // 
            // pnlFeedInfo
            // 
            this.pnlFeedInfo.Controls.Add(this.lblDescription);
            this.pnlFeedInfo.Controls.Add(this.lblTitle);
            this.pnlFeedInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFeedInfo.Location = new System.Drawing.Point(0, 44);
            this.pnlFeedInfo.Name = "pnlFeedInfo";
            this.pnlFeedInfo.Size = new System.Drawing.Size(503, 47);
            this.pnlFeedInfo.TabIndex = 8;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(12, 16);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(488, 31);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // 
            // RSSReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 297);
            this.Controls.Add(this.lstNews);
            this.Controls.Add(this.pnlFeedInfo);
            this.Controls.Add(this.pnlInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RSSReader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MetaComic Comic News";
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.pnlFeedInfo.ResumeLayout(false);
            this.pnlFeedInfo.PerformLayout();
            this.ResumeLayout(false);

        }

      

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.ListView lstNews;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.Panel pnlFeedInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
    }
}

