namespace MetaComics.Client.UI
{
    partial class Disclaimer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Disclaimer));
            this.btnDisagree = new System.Windows.Forms.Button();
            this.btnAgree = new System.Windows.Forms.Button();
            this.txtDisclaimer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDisagree
            // 
            this.btnDisagree.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDisagree.Location = new System.Drawing.Point(572, 339);
            this.btnDisagree.Name = "btnDisagree";
            this.btnDisagree.Size = new System.Drawing.Size(75, 23);
            this.btnDisagree.TabIndex = 0;
            this.btnDisagree.Text = "&Disagree";
            this.btnDisagree.UseVisualStyleBackColor = true;
            this.btnDisagree.Click += new System.EventHandler(this.btnDisagree_Click);
            // 
            // btnAgree
            // 
            this.btnAgree.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgree.Location = new System.Drawing.Point(491, 339);
            this.btnAgree.Name = "btnAgree";
            this.btnAgree.Size = new System.Drawing.Size(75, 23);
            this.btnAgree.TabIndex = 1;
            this.btnAgree.Text = "&Agree";
            this.btnAgree.UseVisualStyleBackColor = true;
            this.btnAgree.Click += new System.EventHandler(this.btnAgree_Click);
            // 
            // txtDisclaimer
            // 
            this.txtDisclaimer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDisclaimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDisclaimer.Location = new System.Drawing.Point(12, 12);
            this.txtDisclaimer.Multiline = true;
            this.txtDisclaimer.Name = "txtDisclaimer";
            this.txtDisclaimer.ReadOnly = true;
            this.txtDisclaimer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDisclaimer.Size = new System.Drawing.Size(628, 321);
            this.txtDisclaimer.TabIndex = 2;
            // 
            // Disclaimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 365);
            this.Controls.Add(this.txtDisclaimer);
            this.Controls.Add(this.btnAgree);
            this.Controls.Add(this.btnDisagree);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Disclaimer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MetaComic Disclaimer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        private System.Windows.Forms.Button btnDisagree;
        private System.Windows.Forms.Button btnAgree;
        private System.Windows.Forms.TextBox txtDisclaimer;
    }
}