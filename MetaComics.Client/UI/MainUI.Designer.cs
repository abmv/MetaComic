namespace MetaComics.Client.UI
{
    partial class MainUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnArchives = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToFavouriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToSystemTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slideshowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comicCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openComicStripDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comicNewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportABugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedbackOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disclaimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxComic = new System.Windows.Forms.ComboBox();
            this.listboxResults = new System.Windows.Forms.ListBox();
            this.stripPictureBox = new MetaComics.Client.PictureBoxAR();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stripPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Location = new System.Drawing.Point(302, 292);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnArchives
            // 
            this.btnArchives.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArchives.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnArchives.Location = new System.Drawing.Point(383, 292);
            this.btnArchives.Name = "btnArchives";
            this.btnArchives.Size = new System.Drawing.Size(75, 23);
            this.btnArchives.TabIndex = 3;
            this.btnArchives.Text = "Archive";
            this.btnArchives.UseVisualStyleBackColor = true;
            this.btnArchives.Click += new System.EventHandler(this.btnArchives_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinimize.Location = new System.Drawing.Point(464, 292);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(75, 23);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.Text = "Minimize";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip.Location = new System.Drawing.Point(0, 362);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 21);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(26, 16);
            this.toolStripStatusLabel1.Text = "-";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToFavouriteToolStripMenuItem,
            this.minimizeToSystemTrayToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(35, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // addToFavouriteToolStripMenuItem
            // 
            this.addToFavouriteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addToFavouriteToolStripMenuItem.Image")));
            this.addToFavouriteToolStripMenuItem.Name = "addToFavouriteToolStripMenuItem";
            this.addToFavouriteToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.addToFavouriteToolStripMenuItem.Text = "Add To Favourite";
            this.addToFavouriteToolStripMenuItem.Click += new System.EventHandler(this.addToFavouriteToolStripMenuItem_Click);
            // 
            // minimizeToSystemTrayToolStripMenuItem
            // 
            this.minimizeToSystemTrayToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("minimizeToSystemTrayToolStripMenuItem.Image")));
            this.minimizeToSystemTrayToolStripMenuItem.Name = "minimizeToSystemTrayToolStripMenuItem";
            this.minimizeToSystemTrayToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.minimizeToSystemTrayToolStripMenuItem.Text = "Minimize to System Tray";
            this.minimizeToSystemTrayToolStripMenuItem.Click += new System.EventHandler(this.minimizeToSystemTrayToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenToolStripMenuItem,
            this.slideshowToolStripMenuItem,
            this.archiveToolStripMenuItem,
            this.comicCollectorToolStripMenuItem,
            this.pluginsToolStripMenuItem,
            this.openComicStripDatabaseToolStripMenuItem,
            this.comicNewsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(42, 20);
            this.toolStripMenuItem2.Text = "View";
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fullScreenToolStripMenuItem.Image")));
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.fullScreenToolStripMenuItem.Text = "Full Screen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // slideshowToolStripMenuItem
            // 
            this.slideshowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("slideshowToolStripMenuItem.Image")));
            this.slideshowToolStripMenuItem.Name = "slideshowToolStripMenuItem";
            this.slideshowToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.slideshowToolStripMenuItem.Text = "Slideshow";
            this.slideshowToolStripMenuItem.Click += new System.EventHandler(this.slideshowToolStripMenuItem_Click);
            // 
            // archiveToolStripMenuItem
            // 
            this.archiveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("archiveToolStripMenuItem.Image")));
            this.archiveToolStripMenuItem.Name = "archiveToolStripMenuItem";
            this.archiveToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.archiveToolStripMenuItem.Text = "Archive";
            this.archiveToolStripMenuItem.Click += new System.EventHandler(this.archiverToolStripMenuItem_Click);
            // 
            // comicCollectorToolStripMenuItem
            // 
            this.comicCollectorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("comicCollectorToolStripMenuItem.Image")));
            this.comicCollectorToolStripMenuItem.Name = "comicCollectorToolStripMenuItem";
            this.comicCollectorToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.comicCollectorToolStripMenuItem.Text = "Comic Collector";
            this.comicCollectorToolStripMenuItem.Click += new System.EventHandler(this.comicCollectorToolStripMenuItem_Click);
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pluginsToolStripMenuItem.Image")));
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.pluginsToolStripMenuItem.Text = "Plugins";
            this.pluginsToolStripMenuItem.Click += new System.EventHandler(this.pluginsToolStripMenuItem_Click);
            // 
            // openComicStripDatabaseToolStripMenuItem
            // 
            this.openComicStripDatabaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openComicStripDatabaseToolStripMenuItem.Image")));
            this.openComicStripDatabaseToolStripMenuItem.Name = "openComicStripDatabaseToolStripMenuItem";
            this.openComicStripDatabaseToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.openComicStripDatabaseToolStripMenuItem.Text = "Open Comic Strip Database";
            this.openComicStripDatabaseToolStripMenuItem.Click += new System.EventHandler(this.openComicStripDatabaseToolStripMenuItem_Click);
            // 
            // comicNewsToolStripMenuItem
            // 
            this.comicNewsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("comicNewsToolStripMenuItem.Image")));
            this.comicNewsToolStripMenuItem.Name = "comicNewsToolStripMenuItem";
            this.comicNewsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.comicNewsToolStripMenuItem.Text = "Comic News";
            this.comicNewsToolStripMenuItem.Click += new System.EventHandler(this.comicNewsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("optionsToolStripMenuItem.Image")));
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.onlineHelpToolStripMenuItem,
            this.visitWebsiteToolStripMenuItem,
            this.reportABugToolStripMenuItem,
            this.feedbackOptionsToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem,
            this.statisticsToolStripMenuItem,
            this.disclaimerToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem1.Image")));
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
            this.helpToolStripMenuItem1.Text = "View Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // onlineHelpToolStripMenuItem
            // 
            this.onlineHelpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("onlineHelpToolStripMenuItem.Image")));
            this.onlineHelpToolStripMenuItem.Name = "onlineHelpToolStripMenuItem";
            this.onlineHelpToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.onlineHelpToolStripMenuItem.Text = "Online Help";
            this.onlineHelpToolStripMenuItem.Click += new System.EventHandler(this.onlineHelpToolStripMenuItem_Click);
            // 
            // visitWebsiteToolStripMenuItem
            // 
            this.visitWebsiteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("visitWebsiteToolStripMenuItem.Image")));
            this.visitWebsiteToolStripMenuItem.Name = "visitWebsiteToolStripMenuItem";
            this.visitWebsiteToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.visitWebsiteToolStripMenuItem.Text = "Visit Website";
            this.visitWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visitWebsiteToolStripMenuItem_Click);
            // 
            // reportABugToolStripMenuItem
            // 
            this.reportABugToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportABugToolStripMenuItem.Image")));
            this.reportABugToolStripMenuItem.Name = "reportABugToolStripMenuItem";
            this.reportABugToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.reportABugToolStripMenuItem.Text = "Report a bug";
            this.reportABugToolStripMenuItem.Click += new System.EventHandler(this.reportABugToolStripMenuItem_Click);
            // 
            // feedbackOptionsToolStripMenuItem
            // 
            this.feedbackOptionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("feedbackOptionsToolStripMenuItem.Image")));
            this.feedbackOptionsToolStripMenuItem.Name = "feedbackOptionsToolStripMenuItem";
            this.feedbackOptionsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.feedbackOptionsToolStripMenuItem.Text = "Feedback Options...";
            this.feedbackOptionsToolStripMenuItem.Click += new System.EventHandler(this.feedbackOptionsToolStripMenuItem_Click);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkForUpdateToolStripMenuItem.Image")));
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check for Updates";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("statisticsToolStripMenuItem.Image")));
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.statisticsToolStripMenuItem.Text = "Statistics";
            this.statisticsToolStripMenuItem.Click += new System.EventHandler(this.statisticsToolStripMenuItem_Click);
            // 
            // disclaimerToolStripMenuItem
            // 
            this.disclaimerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("disclaimerToolStripMenuItem.Image")));
            this.disclaimerToolStripMenuItem.Name = "disclaimerToolStripMenuItem";
            this.disclaimerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.disclaimerToolStripMenuItem.Text = "Disclaimer";
            this.disclaimerToolStripMenuItem.Click += new System.EventHandler(this.disclaimerToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.aboutToolStripMenuItem.Text = "About MetaComics Client";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(546, 292);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "MetaComics Client Ver 2.3";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click_1);
            //this.notifyIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDown_1);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(92, 26);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(91, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // cbxComic
            // 
            this.cbxComic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxComic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxComic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxComic.FormattingEnabled = true;
            this.cbxComic.Location = new System.Drawing.Point(10, 292);
            this.cbxComic.Name = "cbxComic";
            this.cbxComic.Size = new System.Drawing.Size(286, 24);
            this.cbxComic.TabIndex = 1;
            this.cbxComic.SelectedIndexChanged += new System.EventHandler(this.cbxComic_SelectedIndexChanged);
            // 
            // listboxResults
            // 
            this.listboxResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listboxResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listboxResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listboxResults.FormattingEnabled = true;
            this.listboxResults.HorizontalScrollbar = true;
            this.listboxResults.ItemHeight = 16;
            this.listboxResults.Location = new System.Drawing.Point(10, 319);
            this.listboxResults.Name = "listboxResults";
            this.listboxResults.Size = new System.Drawing.Size(611, 32);
            this.listboxResults.TabIndex = 6;
            // 
            // stripPictureBox
            // 
            this.stripPictureBox.Image = null;
            this.stripPictureBox.Location = new System.Drawing.Point(0, 24);
            this.stripPictureBox.Name = "stripPictureBox";
            this.stripPictureBox.Size = new System.Drawing.Size(632, 262);
            this.stripPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.stripPictureBox.TabIndex = 8;
            this.stripPictureBox.TabStop = false;
            this.stripPictureBox.Click += new System.EventHandler(this.stripPictureBox_Click);
            this.stripPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.stripPictureBox_MouseDown);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(632, 383);
            this.Controls.Add(this.stripPictureBox);
            this.Controls.Add(this.listboxResults);
            this.Controls.Add(this.cbxComic);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnArchives);
            this.Controls.Add(this.btnUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MetaComic Client Ver 2.3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainUI_FormClosing);
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.Click += new System.EventHandler(this.MainUI_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainUI_MouseDown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stripPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnArchives;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem archiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbxComic;
        private System.Windows.Forms.ListBox listboxResults;
        private System.Windows.Forms.ToolStripMenuItem openComicStripDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineHelpToolStripMenuItem;
        private PictureBoxAR stripPictureBox;
        private System.Windows.Forms.ToolStripMenuItem minimizeToSystemTrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disclaimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comicCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportABugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feedbackOptionsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem comicNewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slideshowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToFavouriteToolStripMenuItem;
    }
}