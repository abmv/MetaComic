namespace MetaComics.Client.UI
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.ctlPDFOptionsInfo = new System.Windows.Forms.GroupBox();
            this.chkEnableAlternatePageBackroundColour = new System.Windows.Forms.CheckBox();
            this.lblNextPageColor = new System.Windows.Forms.Label();
            this.lblPageColor = new System.Windows.Forms.Label();
            this.ctlAltPageColor = new BlackBeltCoder.ColorPicker();
            this.ctlPageColor = new BlackBeltCoder.ColorPicker();
            this.chkConfirmExit = new System.Windows.Forms.CheckBox();
            this.chkStartMinimized = new System.Windows.Forms.CheckBox();
            this.chkLoadWindowsOnStart = new System.Windows.Forms.CheckBox();
            this.tabFolders = new System.Windows.Forms.TabPage();
            this.btnComicArchiveFolder = new System.Windows.Forms.Button();
            this.txtComicArchiveFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabLogging = new System.Windows.Forms.TabPage();
            this.lblOpenFolder = new System.Windows.Forms.Label();
            this.btnOpenLogFolder = new System.Windows.Forms.Button();
            this.chkVerboseLogging = new System.Windows.Forms.CheckBox();
            this.chkEnableLogging = new System.Windows.Forms.CheckBox();
            this.tabPageSchedule = new System.Windows.Forms.TabPage();
            this.chkEnableScheduling = new System.Windows.Forms.CheckBox();
            this.ctlPeriodGrp = new System.Windows.Forms.GroupBox();
            this.ctlHoursCheck = new System.Windows.Forms.RadioButton();
            this.ctlSeconds = new System.Windows.Forms.RadioButton();
            this.ctlMinutesCheck = new System.Windows.Forms.RadioButton();
            this.txtComicFetchInterval = new System.Windows.Forms.TextBox();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.tabPageRSSOptions = new System.Windows.Forms.TabPage();
            this.txtComicComRSSFeed = new System.Windows.Forms.TextBox();
            this.lblComicComRSS = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabSettings.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.ctlPDFOptionsInfo.SuspendLayout();
            this.tabFolders.SuspendLayout();
            this.tabLogging.SuspendLayout();
            this.tabPageSchedule.SuspendLayout();
            this.ctlPeriodGrp.SuspendLayout();
            this.tabPageRSSOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabSettings.Controls.Add(this.tabGeneral);
            this.tabSettings.Controls.Add(this.tabFolders);
            this.tabSettings.Controls.Add(this.tabLogging);
            this.tabSettings.Controls.Add(this.tabPageSchedule);
            this.tabSettings.Controls.Add(this.tabPageRSSOptions);
            this.tabSettings.Location = new System.Drawing.Point(12, 23);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(439, 297);
            this.tabSettings.TabIndex = 2;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.ctlPDFOptionsInfo);
            this.tabGeneral.Controls.Add(this.chkConfirmExit);
            this.tabGeneral.Controls.Add(this.chkStartMinimized);
            this.tabGeneral.Controls.Add(this.chkLoadWindowsOnStart);
            this.tabGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(431, 268);
            this.tabGeneral.TabIndex = 4;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // ctlPDFOptionsInfo
            // 
            this.ctlPDFOptionsInfo.Controls.Add(this.chkEnableAlternatePageBackroundColour);
            this.ctlPDFOptionsInfo.Controls.Add(this.lblNextPageColor);
            this.ctlPDFOptionsInfo.Controls.Add(this.lblPageColor);
            this.ctlPDFOptionsInfo.Controls.Add(this.ctlAltPageColor);
            this.ctlPDFOptionsInfo.Controls.Add(this.ctlPageColor);
            this.ctlPDFOptionsInfo.Location = new System.Drawing.Point(18, 106);
            this.ctlPDFOptionsInfo.Name = "ctlPDFOptionsInfo";
            this.ctlPDFOptionsInfo.Size = new System.Drawing.Size(253, 105);
            this.ctlPDFOptionsInfo.TabIndex = 4;
            this.ctlPDFOptionsInfo.TabStop = false;
            this.ctlPDFOptionsInfo.Text = "PDF Comic Generation Options";
            // 
            // chkEnableAlternatePageBackroundColour
            // 
            this.chkEnableAlternatePageBackroundColour.AutoSize = true;
            this.chkEnableAlternatePageBackroundColour.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkEnableAlternatePageBackroundColour.Location = new System.Drawing.Point(9, 51);
            this.chkEnableAlternatePageBackroundColour.Name = "chkEnableAlternatePageBackroundColour";
            this.chkEnableAlternatePageBackroundColour.Size = new System.Drawing.Size(57, 17);
            this.chkEnableAlternatePageBackroundColour.TabIndex = 7;
            this.chkEnableAlternatePageBackroundColour.Text = "Enable";
            this.chkEnableAlternatePageBackroundColour.UseVisualStyleBackColor = true;
            this.chkEnableAlternatePageBackroundColour.CheckedChanged += new System.EventHandler(this.chkEnableAlternatePageBackroundColour_CheckedChanged);
            // 
            // lblNextPageColor
            // 
            this.lblNextPageColor.AutoSize = true;
            this.lblNextPageColor.Location = new System.Drawing.Point(6, 74);
            this.lblNextPageColor.Name = "lblNextPageColor";
            this.lblNextPageColor.Size = new System.Drawing.Size(174, 13);
            this.lblNextPageColor.TabIndex = 6;
            this.lblNextPageColor.Text = "Alternate Page Background Colour:";
            // 
            // lblPageColor
            // 
            this.lblPageColor.AutoSize = true;
            this.lblPageColor.Location = new System.Drawing.Point(6, 27);
            this.lblPageColor.Name = "lblPageColor";
            this.lblPageColor.Size = new System.Drawing.Size(129, 13);
            this.lblPageColor.TabIndex = 5;
            this.lblPageColor.Text = "Page Background Colour:";
            // 
            // ctlAltPageColor
            // 
            this.ctlAltPageColor.Location = new System.Drawing.Point(186, 67);
            this.ctlAltPageColor.Name = "ctlAltPageColor";
            this.ctlAltPageColor.Size = new System.Drawing.Size(51, 26);
            this.ctlAltPageColor.TabIndex = 4;
            this.ctlAltPageColor.Text = "colorPicker2";
            this.ctlAltPageColor.Value = System.Drawing.Color.White;
            // 
            // ctlPageColor
            // 
            this.ctlPageColor.Location = new System.Drawing.Point(186, 19);
            this.ctlPageColor.Name = "ctlPageColor";
            this.ctlPageColor.Size = new System.Drawing.Size(51, 26);
            this.ctlPageColor.TabIndex = 3;
            this.ctlPageColor.Text = "colorPicker1";
            this.ctlPageColor.Value = System.Drawing.Color.White;
            // 
            // chkConfirmExit
            // 
            this.chkConfirmExit.AutoSize = true;
            this.chkConfirmExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkConfirmExit.Location = new System.Drawing.Point(18, 74);
            this.chkConfirmExit.Name = "chkConfirmExit";
            this.chkConfirmExit.Size = new System.Drawing.Size(137, 17);
            this.chkConfirmExit.TabIndex = 2;
            this.chkConfirmExit.Text = "Confirm Application Exit.";
            this.chkConfirmExit.UseVisualStyleBackColor = true;
            // 
            // chkStartMinimized
            // 
            this.chkStartMinimized.AutoSize = true;
            this.chkStartMinimized.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkStartMinimized.Location = new System.Drawing.Point(18, 51);
            this.chkStartMinimized.Name = "chkStartMinimized";
            this.chkStartMinimized.Size = new System.Drawing.Size(95, 17);
            this.chkStartMinimized.TabIndex = 1;
            this.chkStartMinimized.Text = "Start Minimized";
            this.chkStartMinimized.UseVisualStyleBackColor = true;
            // 
            // chkLoadWindowsOnStart
            // 
            this.chkLoadWindowsOnStart.AutoSize = true;
            this.chkLoadWindowsOnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkLoadWindowsOnStart.Location = new System.Drawing.Point(18, 28);
            this.chkLoadWindowsOnStart.Name = "chkLoadWindowsOnStart";
            this.chkLoadWindowsOnStart.Size = new System.Drawing.Size(338, 17);
            this.chkLoadWindowsOnStart.TabIndex = 0;
            this.chkLoadWindowsOnStart.Text = "Automatically run MetaComic Client each time I log on to Windows.";
            this.chkLoadWindowsOnStart.UseVisualStyleBackColor = true;
            this.chkLoadWindowsOnStart.CheckedChanged += new System.EventHandler(this.chkLoadWindowsOnStart_CheckedChanged);
            // 
            // tabFolders
            // 
            this.tabFolders.Controls.Add(this.btnComicArchiveFolder);
            this.tabFolders.Controls.Add(this.txtComicArchiveFolder);
            this.tabFolders.Controls.Add(this.label1);
            this.tabFolders.Location = new System.Drawing.Point(4, 25);
            this.tabFolders.Name = "tabFolders";
            this.tabFolders.Padding = new System.Windows.Forms.Padding(3);
            this.tabFolders.Size = new System.Drawing.Size(431, 268);
            this.tabFolders.TabIndex = 3;
            this.tabFolders.Text = "Folders";
            this.tabFolders.UseVisualStyleBackColor = true;
            // 
            // btnComicArchiveFolder
            // 
            this.btnComicArchiveFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnComicArchiveFolder.Location = new System.Drawing.Point(397, 24);
            this.btnComicArchiveFolder.Name = "btnComicArchiveFolder";
            this.btnComicArchiveFolder.Size = new System.Drawing.Size(28, 23);
            this.btnComicArchiveFolder.TabIndex = 2;
            this.btnComicArchiveFolder.Text = "...";
            this.btnComicArchiveFolder.UseVisualStyleBackColor = true;
            this.btnComicArchiveFolder.Click += new System.EventHandler(this.btnTempImageFolder_Click);
            // 
            // txtComicArchiveFolder
            // 
            this.txtComicArchiveFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComicArchiveFolder.Location = new System.Drawing.Point(124, 26);
            this.txtComicArchiveFolder.Multiline = true;
            this.txtComicArchiveFolder.Name = "txtComicArchiveFolder";
            this.txtComicArchiveFolder.Size = new System.Drawing.Size(267, 76);
            this.txtComicArchiveFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comics Archive Folder";
            // 
            // tabLogging
            // 
            this.tabLogging.Controls.Add(this.lblOpenFolder);
            this.tabLogging.Controls.Add(this.btnOpenLogFolder);
            this.tabLogging.Controls.Add(this.chkVerboseLogging);
            this.tabLogging.Controls.Add(this.chkEnableLogging);
            this.tabLogging.Location = new System.Drawing.Point(4, 25);
            this.tabLogging.Name = "tabLogging";
            this.tabLogging.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogging.Size = new System.Drawing.Size(431, 268);
            this.tabLogging.TabIndex = 2;
            this.tabLogging.Text = "Logging";
            this.tabLogging.UseVisualStyleBackColor = true;
            // 
            // lblOpenFolder
            // 
            this.lblOpenFolder.AutoSize = true;
            this.lblOpenFolder.Location = new System.Drawing.Point(18, 97);
            this.lblOpenFolder.Name = "lblOpenFolder";
            this.lblOpenFolder.Size = new System.Drawing.Size(86, 13);
            this.lblOpenFolder.TabIndex = 3;
            this.lblOpenFolder.Text = "Open Log Folder";
            // 
            // btnOpenLogFolder
            // 
            this.btnOpenLogFolder.Location = new System.Drawing.Point(110, 87);
            this.btnOpenLogFolder.Name = "btnOpenLogFolder";
            this.btnOpenLogFolder.Size = new System.Drawing.Size(35, 23);
            this.btnOpenLogFolder.TabIndex = 2;
            this.btnOpenLogFolder.Text = "....";
            this.btnOpenLogFolder.UseVisualStyleBackColor = true;
            this.btnOpenLogFolder.Click += new System.EventHandler(this.btnOpenLogFolder_Click);
            // 
            // chkVerboseLogging
            // 
            this.chkVerboseLogging.AutoSize = true;
            this.chkVerboseLogging.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVerboseLogging.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkVerboseLogging.Location = new System.Drawing.Point(21, 60);
            this.chkVerboseLogging.Name = "chkVerboseLogging";
            this.chkVerboseLogging.Size = new System.Drawing.Size(63, 17);
            this.chkVerboseLogging.TabIndex = 1;
            this.chkVerboseLogging.Text = "Verbose";
            this.chkVerboseLogging.UseVisualStyleBackColor = true;
            // 
            // chkEnableLogging
            // 
            this.chkEnableLogging.AutoSize = true;
            this.chkEnableLogging.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnableLogging.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkEnableLogging.Location = new System.Drawing.Point(21, 26);
            this.chkEnableLogging.Name = "chkEnableLogging";
            this.chkEnableLogging.Size = new System.Drawing.Size(62, 17);
            this.chkEnableLogging.TabIndex = 0;
            this.chkEnableLogging.Text = "Logging";
            this.chkEnableLogging.UseVisualStyleBackColor = true;
            this.chkEnableLogging.CheckedChanged += new System.EventHandler(this.chkEnableLogging_CheckedChanged);
            this.chkEnableLogging.CheckStateChanged += new System.EventHandler(this.chkEnableLogging_CheckStateChanged);
            // 
            // tabPageSchedule
            // 
            this.tabPageSchedule.Controls.Add(this.chkEnableScheduling);
            this.tabPageSchedule.Controls.Add(this.ctlPeriodGrp);
            this.tabPageSchedule.Controls.Add(this.txtComicFetchInterval);
            this.tabPageSchedule.Controls.Add(this.lblSchedule);
            this.tabPageSchedule.Location = new System.Drawing.Point(4, 25);
            this.tabPageSchedule.Name = "tabPageSchedule";
            this.tabPageSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSchedule.Size = new System.Drawing.Size(431, 268);
            this.tabPageSchedule.TabIndex = 5;
            this.tabPageSchedule.Text = "Schedule";
            this.tabPageSchedule.UseVisualStyleBackColor = true;
            // 
            // chkEnableScheduling
            // 
            this.chkEnableScheduling.AutoSize = true;
            this.chkEnableScheduling.Location = new System.Drawing.Point(6, 17);
            this.chkEnableScheduling.Name = "chkEnableScheduling";
            this.chkEnableScheduling.Size = new System.Drawing.Size(115, 17);
            this.chkEnableScheduling.TabIndex = 6;
            this.chkEnableScheduling.Text = "Enable Scheduling";
            this.chkEnableScheduling.UseVisualStyleBackColor = true;
            this.chkEnableScheduling.CheckedChanged += new System.EventHandler(this.chkEnableScheduling_CheckedChanged);
            // 
            // ctlPeriodGrp
            // 
            this.ctlPeriodGrp.Controls.Add(this.ctlHoursCheck);
            this.ctlPeriodGrp.Controls.Add(this.ctlSeconds);
            this.ctlPeriodGrp.Controls.Add(this.ctlMinutesCheck);
            this.ctlPeriodGrp.Location = new System.Drawing.Point(318, 35);
            this.ctlPeriodGrp.Name = "ctlPeriodGrp";
            this.ctlPeriodGrp.Size = new System.Drawing.Size(85, 89);
            this.ctlPeriodGrp.TabIndex = 5;
            this.ctlPeriodGrp.TabStop = false;
            this.ctlPeriodGrp.Text = "Interval";
            // 
            // ctlHoursCheck
            // 
            this.ctlHoursCheck.AutoSize = true;
            this.ctlHoursCheck.Location = new System.Drawing.Point(6, 19);
            this.ctlHoursCheck.Name = "ctlHoursCheck";
            this.ctlHoursCheck.Size = new System.Drawing.Size(53, 17);
            this.ctlHoursCheck.TabIndex = 3;
            this.ctlHoursCheck.TabStop = true;
            this.ctlHoursCheck.Text = "Hours";
            this.ctlHoursCheck.UseVisualStyleBackColor = true;
            this.ctlHoursCheck.CheckedChanged += new System.EventHandler(this.ctlHoursCheck_CheckedChanged);
            // 
            // ctlSeconds
            // 
            this.ctlSeconds.AutoSize = true;
            this.ctlSeconds.Location = new System.Drawing.Point(6, 65);
            this.ctlSeconds.Name = "ctlSeconds";
            this.ctlSeconds.Size = new System.Drawing.Size(67, 17);
            this.ctlSeconds.TabIndex = 4;
            this.ctlSeconds.TabStop = true;
            this.ctlSeconds.Text = "Seconds";
            this.ctlSeconds.UseVisualStyleBackColor = true;
            this.ctlSeconds.CheckedChanged += new System.EventHandler(this.ctlSeconds_CheckedChanged);
            // 
            // ctlMinutesCheck
            // 
            this.ctlMinutesCheck.AutoSize = true;
            this.ctlMinutesCheck.Location = new System.Drawing.Point(6, 42);
            this.ctlMinutesCheck.Name = "ctlMinutesCheck";
            this.ctlMinutesCheck.Size = new System.Drawing.Size(62, 17);
            this.ctlMinutesCheck.TabIndex = 2;
            this.ctlMinutesCheck.TabStop = true;
            this.ctlMinutesCheck.Text = "Minutes";
            this.ctlMinutesCheck.UseVisualStyleBackColor = true;
            this.ctlMinutesCheck.CheckedChanged += new System.EventHandler(this.ctlMinutesCheck_CheckedChanged);
            // 
            // txtComicFetchInterval
            // 
            this.txtComicFetchInterval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComicFetchInterval.Location = new System.Drawing.Point(201, 104);
            this.txtComicFetchInterval.Multiline = true;
            this.txtComicFetchInterval.Name = "txtComicFetchInterval";
            this.txtComicFetchInterval.Size = new System.Drawing.Size(100, 20);
            this.txtComicFetchInterval.TabIndex = 1;
            // 
            // lblSchedule
            // 
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.Location = new System.Drawing.Point(15, 111);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(180, 13);
            this.lblSchedule.TabIndex = 0;
            this.lblSchedule.Text = "Check for comic strip updated every:";
            // 
            // tabPageRSSOptions
            // 
            this.tabPageRSSOptions.Controls.Add(this.txtComicComRSSFeed);
            this.tabPageRSSOptions.Controls.Add(this.lblComicComRSS);
            this.tabPageRSSOptions.Location = new System.Drawing.Point(4, 25);
            this.tabPageRSSOptions.Name = "tabPageRSSOptions";
            this.tabPageRSSOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRSSOptions.Size = new System.Drawing.Size(431, 268);
            this.tabPageRSSOptions.TabIndex = 6;
            this.tabPageRSSOptions.Text = "RSS Options";
            this.tabPageRSSOptions.UseVisualStyleBackColor = true;
            // 
            // txtComicComRSSFeed
            // 
            this.txtComicComRSSFeed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComicComRSSFeed.Location = new System.Drawing.Point(9, 24);
            this.txtComicComRSSFeed.Multiline = true;
            this.txtComicComRSSFeed.Name = "txtComicComRSSFeed";
            this.txtComicComRSSFeed.Size = new System.Drawing.Size(416, 48);
            this.txtComicComRSSFeed.TabIndex = 1;
            // 
            // lblComicComRSS
            // 
            this.lblComicComRSS.AutoSize = true;
            this.lblComicComRSS.Location = new System.Drawing.Point(6, 8);
            this.lblComicComRSS.Name = "lblComicComRSS";
            this.lblComicComRSS.Size = new System.Drawing.Size(74, 13);
            this.lblComicComRSS.TabIndex = 0;
            this.lblComicComRSS.Text = "comic.com rss";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(372, 326);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(274, 326);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog.SelectedPath = "C:\\";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(462, 361);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MetaComic Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tabSettings.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.ctlPDFOptionsInfo.ResumeLayout(false);
            this.ctlPDFOptionsInfo.PerformLayout();
            this.tabFolders.ResumeLayout(false);
            this.tabFolders.PerformLayout();
            this.tabLogging.ResumeLayout(false);
            this.tabLogging.PerformLayout();
            this.tabPageSchedule.ResumeLayout(false);
            this.tabPageSchedule.PerformLayout();
            this.ctlPeriodGrp.ResumeLayout(false);
            this.ctlPeriodGrp.PerformLayout();
            this.tabPageRSSOptions.ResumeLayout(false);
            this.tabPageRSSOptions.PerformLayout();
            this.ResumeLayout(false);

        }

      

        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabLogging;
        private System.Windows.Forms.TabPage tabFolders;
        private System.Windows.Forms.Button btnComicArchiveFolder;
        private System.Windows.Forms.TextBox txtComicArchiveFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkVerboseLogging;
        private System.Windows.Forms.CheckBox chkEnableLogging;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.CheckBox chkLoadWindowsOnStart;
        private System.Windows.Forms.CheckBox chkStartMinimized;
        private System.Windows.Forms.TabPage tabPageSchedule;
        private System.Windows.Forms.RadioButton ctlSeconds;
        private System.Windows.Forms.RadioButton ctlHoursCheck;
        private System.Windows.Forms.RadioButton ctlMinutesCheck;
        private System.Windows.Forms.TextBox txtComicFetchInterval;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.GroupBox ctlPeriodGrp;
        private System.Windows.Forms.Label lblOpenFolder;
        private System.Windows.Forms.Button btnOpenLogFolder;
        private System.Windows.Forms.CheckBox chkEnableScheduling;
        private System.Windows.Forms.TabPage tabPageRSSOptions;
        private System.Windows.Forms.TextBox txtComicComRSSFeed;
        private System.Windows.Forms.Label lblComicComRSS;
        private System.Windows.Forms.CheckBox chkConfirmExit;
        private BlackBeltCoder.ColorPicker ctlPageColor;
        private System.Windows.Forms.GroupBox ctlPDFOptionsInfo;
        private System.Windows.Forms.Label lblNextPageColor;
        private System.Windows.Forms.Label lblPageColor;
        private BlackBeltCoder.ColorPicker ctlAltPageColor;
        private System.Windows.Forms.CheckBox chkEnableAlternatePageBackroundColour;
    }
}