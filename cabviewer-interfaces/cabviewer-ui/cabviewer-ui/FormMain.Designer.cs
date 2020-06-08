namespace CabViewerUI
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainDockPanel = new CabViewerSDK.Docking.DockPanel();
            this.dockTheme = new CabViewerSDK.Docking.DockTheme();
            this.SuspendLayout();
            // 
            // mainDockPanel
            // 
            this.mainDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDockPanel.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.mainDockPanel.Location = new System.Drawing.Point(0, 0);
            this.mainDockPanel.Name = "mainDockPanel";
            this.mainDockPanel.Padding = new System.Windows.Forms.Padding(6);
            this.mainDockPanel.ShowAutoHideContentOnHover = false;
            this.mainDockPanel.Size = new System.Drawing.Size(1106, 641);
            this.mainDockPanel.TabIndex = 1;
            this.mainDockPanel.Theme = this.dockTheme;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 641);
            this.Controls.Add(this.mainDockPanel);
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{local:cabviewer-ui-form-main-title}";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CabViewerSDK.Docking.DockPanel mainDockPanel;
        private CabViewerSDK.Docking.DockTheme dockTheme;
    }
}