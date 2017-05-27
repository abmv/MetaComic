namespace MetaComics.Client.UI
{
    partial class Plugins
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plugins));
            this.AvailableHandlers = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.SelectedHandlers = new System.Windows.Forms.ListBox();
            this.SelectOne = new System.Windows.Forms.Button();
            this.SelectAll = new System.Windows.Forms.Button();
            this.Deselect = new System.Windows.Forms.Button();
            this.DeselectAll = new System.Windows.Forms.Button();
            this.Description = new System.Windows.Forms.Label();
            this.lblEnabledComicPlugins = new System.Windows.Forms.Label();
            this.lblDisabledComicPlugins = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AvailableHandlers
            // 
            this.AvailableHandlers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AvailableHandlers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailableHandlers.FormattingEnabled = true;
            this.AvailableHandlers.ItemHeight = 16;
            this.AvailableHandlers.Location = new System.Drawing.Point(12, 26);
            this.AvailableHandlers.Name = "AvailableHandlers";
            this.AvailableHandlers.Size = new System.Drawing.Size(237, 208);
            this.AvailableHandlers.TabIndex = 0;
            this.AvailableHandlers.SelectedIndexChanged += new System.EventHandler(this.AvailableHandlers_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(505, 265);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSet
            // 
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSet.Location = new System.Drawing.Point(424, 265);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 7;
            this.btnSet.Text = "&Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // SelectedHandlers
            // 
            this.SelectedHandlers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelectedHandlers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedHandlers.FormattingEnabled = true;
            this.SelectedHandlers.ItemHeight = 16;
            this.SelectedHandlers.Location = new System.Drawing.Point(337, 26);
            this.SelectedHandlers.Name = "SelectedHandlers";
            this.SelectedHandlers.Size = new System.Drawing.Size(237, 208);
            this.SelectedHandlers.TabIndex = 5;
            this.SelectedHandlers.SelectedIndexChanged += new System.EventHandler(this.SelectedHandlers_SelectedIndexChanged);
            // 
            // SelectOne
            // 
            this.SelectOne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SelectOne.Location = new System.Drawing.Point(255, 55);
            this.SelectOne.Name = "SelectOne";
            this.SelectOne.Size = new System.Drawing.Size(75, 23);
            this.SelectOne.TabIndex = 1;
            this.SelectOne.Text = ">";
            this.SelectOne.UseVisualStyleBackColor = true;
            this.SelectOne.Click += new System.EventHandler(this.SelectOne_Click);
            // 
            // SelectAll
            // 
            this.SelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SelectAll.Location = new System.Drawing.Point(256, 85);
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(75, 23);
            this.SelectAll.TabIndex = 2;
            this.SelectAll.Text = ">>";
            this.SelectAll.UseVisualStyleBackColor = true;
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // Deselect
            // 
            this.Deselect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Deselect.Location = new System.Drawing.Point(256, 114);
            this.Deselect.Name = "Deselect";
            this.Deselect.Size = new System.Drawing.Size(75, 23);
            this.Deselect.TabIndex = 3;
            this.Deselect.Text = "<";
            this.Deselect.UseVisualStyleBackColor = true;
            this.Deselect.Click += new System.EventHandler(this.Deselect_Click);
            // 
            // DeselectAll
            // 
            this.DeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeselectAll.Location = new System.Drawing.Point(256, 143);
            this.DeselectAll.Name = "DeselectAll";
            this.DeselectAll.Size = new System.Drawing.Size(75, 23);
            this.DeselectAll.TabIndex = 4;
            this.DeselectAll.Text = "<<";
            this.DeselectAll.UseVisualStyleBackColor = true;
            this.DeselectAll.Click += new System.EventHandler(this.DeselectAll_Click);
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(9, 275);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(190, 13);
            this.Description.TabIndex = 6;
            this.Description.Text = "Click a handler to get more information.";
            // 
            // lblEnabledComicPlugins
            // 
            this.lblEnabledComicPlugins.AutoSize = true;
            this.lblEnabledComicPlugins.Location = new System.Drawing.Point(334, 10);
            this.lblEnabledComicPlugins.Name = "lblEnabledComicPlugins";
            this.lblEnabledComicPlugins.Size = new System.Drawing.Size(121, 13);
            this.lblEnabledComicPlugins.TabIndex = 9;
            this.lblEnabledComicPlugins.Text = "Enabled  Comic Plugins:";
            // 
            // lblDisabledComicPlugins
            // 
            this.lblDisabledComicPlugins.AutoSize = true;
            this.lblDisabledComicPlugins.Location = new System.Drawing.Point(9, 10);
            this.lblDisabledComicPlugins.Name = "lblDisabledComicPlugins";
            this.lblDisabledComicPlugins.Size = new System.Drawing.Size(120, 13);
            this.lblDisabledComicPlugins.TabIndex = 10;
            this.lblDisabledComicPlugins.Text = "Disabled Comic Plugins:";
            // 
            // Plugins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(584, 288);
            this.Controls.Add(this.lblDisabledComicPlugins);
            this.Controls.Add(this.lblEnabledComicPlugins);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.DeselectAll);
            this.Controls.Add(this.Deselect);
            this.Controls.Add(this.SelectAll);
            this.Controls.Add(this.SelectOne);
            this.Controls.Add(this.SelectedHandlers);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.AvailableHandlers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Plugins";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MetaComic Plugins";
            this.Load += new System.EventHandler(this.Plugins_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        private System.Windows.Forms.ListBox AvailableHandlers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.ListBox SelectedHandlers;
        private System.Windows.Forms.Button SelectOne;
        private System.Windows.Forms.Button SelectAll;
        private System.Windows.Forms.Button Deselect;
        private System.Windows.Forms.Button DeselectAll;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Label lblEnabledComicPlugins;
        private System.Windows.Forms.Label lblDisabledComicPlugins;
    }
}