namespace MetaComics.Client.UI
{
    partial class Statistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistics));
            this.ctlComicStatiticsInfo = new System.Windows.Forms.GroupBox();
            this.lblTotalComicStripFolders = new System.Windows.Forms.Label();
            this.lblEnabledPlugins = new System.Windows.Forms.Label();
            this.lblYesterdayUpdateStatus = new System.Windows.Forms.Label();
            this.lblTodayUpdateStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblComicStripCountValue = new System.Windows.Forms.Label();
            this.lblComicsName = new System.Windows.Forms.Label();
            this.ctlComicsList = new System.Windows.Forms.ListBox();
            this.lblTotalDatabaseSizeInfoValue = new System.Windows.Forms.Label();
            this.lblTotalDatabaseSizeInfo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctlComicStatiticsInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctlComicStatiticsInfo
            // 
            this.ctlComicStatiticsInfo.Controls.Add(this.lblTotalComicStripFolders);
            this.ctlComicStatiticsInfo.Controls.Add(this.lblEnabledPlugins);
            this.ctlComicStatiticsInfo.Controls.Add(this.lblYesterdayUpdateStatus);
            this.ctlComicStatiticsInfo.Controls.Add(this.lblTodayUpdateStatus);
            this.ctlComicStatiticsInfo.Controls.Add(this.pictureBox1);
            this.ctlComicStatiticsInfo.Controls.Add(this.lblComicStripCountValue);
            this.ctlComicStatiticsInfo.Controls.Add(this.lblComicsName);
            this.ctlComicStatiticsInfo.Controls.Add(this.ctlComicsList);
            this.ctlComicStatiticsInfo.Controls.Add(this.lblTotalDatabaseSizeInfoValue);
            this.ctlComicStatiticsInfo.Controls.Add(this.lblTotalDatabaseSizeInfo);
            this.ctlComicStatiticsInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ctlComicStatiticsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlComicStatiticsInfo.Location = new System.Drawing.Point(12, 3);
            this.ctlComicStatiticsInfo.Name = "ctlComicStatiticsInfo";
            this.ctlComicStatiticsInfo.Size = new System.Drawing.Size(299, 232);
            this.ctlComicStatiticsInfo.TabIndex = 0;
            this.ctlComicStatiticsInfo.TabStop = false;
            this.ctlComicStatiticsInfo.Text = "Comic Database Information";
            // 
            // lblTotalComicStripFolders
            // 
            this.lblTotalComicStripFolders.AutoSize = true;
            this.lblTotalComicStripFolders.Location = new System.Drawing.Point(16, 160);
            this.lblTotalComicStripFolders.Name = "lblTotalComicStripFolders";
            this.lblTotalComicStripFolders.Size = new System.Drawing.Size(12, 16);
            this.lblTotalComicStripFolders.TabIndex = 10;
            this.lblTotalComicStripFolders.Text = "-";
            // 
            // lblEnabledPlugins
            // 
            this.lblEnabledPlugins.AutoSize = true;
            this.lblEnabledPlugins.Location = new System.Drawing.Point(17, 28);
            this.lblEnabledPlugins.Name = "lblEnabledPlugins";
            this.lblEnabledPlugins.Size = new System.Drawing.Size(12, 16);
            this.lblEnabledPlugins.TabIndex = 9;
            this.lblEnabledPlugins.Text = "-";
            // 
            // lblYesterdayUpdateStatus
            // 
            this.lblYesterdayUpdateStatus.AutoSize = true;
            this.lblYesterdayUpdateStatus.Location = new System.Drawing.Point(16, 207);
            this.lblYesterdayUpdateStatus.Name = "lblYesterdayUpdateStatus";
            this.lblYesterdayUpdateStatus.Size = new System.Drawing.Size(12, 16);
            this.lblYesterdayUpdateStatus.TabIndex = 8;
            this.lblYesterdayUpdateStatus.Text = "-";
            // 
            // lblTodayUpdateStatus
            // 
            this.lblTodayUpdateStatus.AutoSize = true;
            this.lblTodayUpdateStatus.Location = new System.Drawing.Point(17, 182);
            this.lblTodayUpdateStatus.Name = "lblTodayUpdateStatus";
            this.lblTodayUpdateStatus.Size = new System.Drawing.Size(12, 16);
            this.lblTodayUpdateStatus.TabIndex = 7;
            this.lblTodayUpdateStatus.Text = "-";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(221, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // lblComicStripCountValue
            // 
            this.lblComicStripCountValue.AutoSize = true;
            this.lblComicStripCountValue.Location = new System.Drawing.Point(73, 144);
            this.lblComicStripCountValue.Name = "lblComicStripCountValue";
            this.lblComicStripCountValue.Size = new System.Drawing.Size(12, 16);
            this.lblComicStripCountValue.TabIndex = 5;
            this.lblComicStripCountValue.Text = "-";
            // 
            // lblComicsName
            // 
            this.lblComicsName.AutoSize = true;
            this.lblComicsName.Location = new System.Drawing.Point(14, 93);
            this.lblComicsName.Name = "lblComicsName";
            this.lblComicsName.Size = new System.Drawing.Size(56, 16);
            this.lblComicsName.TabIndex = 3;
            this.lblComicsName.Text = "Comics:";
            // 
            // ctlComicsList
            // 
            this.ctlComicsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctlComicsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlComicsList.FormattingEnabled = true;
            this.ctlComicsList.ItemHeight = 16;
            this.ctlComicsList.Location = new System.Drawing.Point(76, 93);
            this.ctlComicsList.Name = "ctlComicsList";
            this.ctlComicsList.Size = new System.Drawing.Size(182, 48);
            this.ctlComicsList.TabIndex = 2;
            this.ctlComicsList.SelectedIndexChanged += new System.EventHandler(this.ctlComicsList_SelectedIndexChanged);
            // 
            // lblTotalDatabaseSizeInfoValue
            // 
            this.lblTotalDatabaseSizeInfoValue.AutoSize = true;
            this.lblTotalDatabaseSizeInfoValue.Location = new System.Drawing.Point(155, 61);
            this.lblTotalDatabaseSizeInfoValue.Name = "lblTotalDatabaseSizeInfoValue";
            this.lblTotalDatabaseSizeInfoValue.Size = new System.Drawing.Size(12, 16);
            this.lblTotalDatabaseSizeInfoValue.TabIndex = 1;
            this.lblTotalDatabaseSizeInfoValue.Text = "-";
            // 
            // lblTotalDatabaseSizeInfo
            // 
            this.lblTotalDatabaseSizeInfo.AutoSize = true;
            this.lblTotalDatabaseSizeInfo.Location = new System.Drawing.Point(14, 61);
            this.lblTotalDatabaseSizeInfo.Name = "lblTotalDatabaseSizeInfo";
            this.lblTotalDatabaseSizeInfo.Size = new System.Drawing.Size(134, 16);
            this.lblTotalDatabaseSizeInfo.TabIndex = 0;
            this.lblTotalDatabaseSizeInfo.Text = "Total Database Size:";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(233, 241);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(332, 266);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctlComicStatiticsInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Statistics";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MetaComic Statitics";
            this.ctlComicStatiticsInfo.ResumeLayout(false);
            this.ctlComicStatiticsInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

      

        private System.Windows.Forms.GroupBox ctlComicStatiticsInfo;
        private System.Windows.Forms.Label lblTotalDatabaseSizeInfoValue;
        private System.Windows.Forms.Label lblTotalDatabaseSizeInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox ctlComicsList;
        private System.Windows.Forms.Label lblComicsName;
        private System.Windows.Forms.Label lblComicStripCountValue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTodayUpdateStatus;
        private System.Windows.Forms.Label lblYesterdayUpdateStatus;
        private System.Windows.Forms.Label lblEnabledPlugins;
        private System.Windows.Forms.Label lblTotalComicStripFolders;
    }
}