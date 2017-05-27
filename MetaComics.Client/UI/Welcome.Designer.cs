namespace MetaComics.Client.UI
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.txtDisclaimer = new System.Windows.Forms.TextBox();
            this.chkDoNotShowAtStartUp = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDisclaimer
            // 
            this.txtDisclaimer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDisclaimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDisclaimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisclaimer.Location = new System.Drawing.Point(12, 12);
            this.txtDisclaimer.Multiline = true;
            this.txtDisclaimer.Name = "txtDisclaimer";
            this.txtDisclaimer.ReadOnly = true;
            this.txtDisclaimer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDisclaimer.Size = new System.Drawing.Size(375, 168);
            this.txtDisclaimer.TabIndex = 0;
            this.txtDisclaimer.Text = resources.GetString("txtDisclaimer.Text");
            // 
            // chkDoNotShowAtStartUp
            // 
            this.chkDoNotShowAtStartUp.AutoSize = true;
            this.chkDoNotShowAtStartUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDoNotShowAtStartUp.Location = new System.Drawing.Point(13, 184);
            this.chkDoNotShowAtStartUp.Name = "chkDoNotShowAtStartUp";
            this.chkDoNotShowAtStartUp.Size = new System.Drawing.Size(137, 17);
            this.chkDoNotShowAtStartUp.TabIndex = 1;
            this.chkDoNotShowAtStartUp.Text = "Do not show at start up.";
            this.chkDoNotShowAtStartUp.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(312, 186);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 212);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkDoNotShowAtStartUp);
            this.Controls.Add(this.txtDisclaimer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to MetaComic...";
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        private System.Windows.Forms.TextBox txtDisclaimer;
        private System.Windows.Forms.CheckBox chkDoNotShowAtStartUp;
        private System.Windows.Forms.Button btnOK;
    }
}