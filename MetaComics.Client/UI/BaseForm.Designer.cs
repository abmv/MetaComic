namespace MetaComics.Client.UI
{
    partial class BaseForm
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
            this.tmrFade = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.tmrFade)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrFade
            // 
            this.tmrFade.Interval = 20D;
            this.tmrFade.SynchronizingObject = this;
            this.tmrFade.Elapsed += new System.Timers.ElapsedEventHandler(this.tmrFade_Elapsed);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 382);
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.tmrFade)).EndInit();
            this.ResumeLayout(false);

        }

      

        protected internal System.Timers.Timer tmrFade;

    }
}