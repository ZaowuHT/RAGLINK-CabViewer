namespace CabViewerStudio
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
            this.darkTextBox1 = new CabViewerSDK.UI.Controls.DarkTextBox();
            this.darkTextBox2 = new CabViewerSDK.UI.Controls.DarkTextBox();
            this.darkButton1 = new CabViewerSDK.UI.Controls.DarkButton();
            this.darkButton2 = new CabViewerSDK.UI.Controls.DarkButton();
            this.darkButton3 = new CabViewerSDK.UI.Controls.DarkButton();
            this.darkButton4 = new CabViewerSDK.UI.Controls.DarkButton();
            this.SuspendLayout();
            // 
            // darkTextBox1
            // 
            this.darkTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkTextBox1.Location = new System.Drawing.Point(12, 27);
            this.darkTextBox1.Name = "darkTextBox1";
            this.darkTextBox1.Size = new System.Drawing.Size(100, 21);
            this.darkTextBox1.TabIndex = 0;
            // 
            // darkTextBox2
            // 
            this.darkTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkTextBox2.Location = new System.Drawing.Point(12, 54);
            this.darkTextBox2.Name = "darkTextBox2";
            this.darkTextBox2.Size = new System.Drawing.Size(100, 21);
            this.darkTextBox2.TabIndex = 1;
            // 
            // darkButton1
            // 
            this.darkButton1.Location = new System.Drawing.Point(118, 27);
            this.darkButton1.Name = "darkButton1";
            this.darkButton1.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton1.Size = new System.Drawing.Size(75, 23);
            this.darkButton1.TabIndex = 2;
            this.darkButton1.Text = "darkButton1";
            this.darkButton1.Click += new System.EventHandler(this.darkButton1_Click);
            // 
            // darkButton2
            // 
            this.darkButton2.Location = new System.Drawing.Point(199, 27);
            this.darkButton2.Name = "darkButton2";
            this.darkButton2.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton2.Size = new System.Drawing.Size(75, 23);
            this.darkButton2.TabIndex = 3;
            this.darkButton2.Text = "darkButton2";
            this.darkButton2.Click += new System.EventHandler(this.darkButton2_Click);
            // 
            // darkButton3
            // 
            this.darkButton3.Location = new System.Drawing.Point(118, 54);
            this.darkButton3.Name = "darkButton3";
            this.darkButton3.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton3.Size = new System.Drawing.Size(75, 23);
            this.darkButton3.TabIndex = 4;
            this.darkButton3.Text = "darkButton3";
            this.darkButton3.Click += new System.EventHandler(this.darkButton3_Click);
            // 
            // darkButton4
            // 
            this.darkButton4.Location = new System.Drawing.Point(199, 54);
            this.darkButton4.Name = "darkButton4";
            this.darkButton4.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton4.Size = new System.Drawing.Size(75, 23);
            this.darkButton4.TabIndex = 5;
            this.darkButton4.Text = "darkButton4";
            this.darkButton4.Click += new System.EventHandler(this.darkButton4_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 641);
            this.Controls.Add(this.darkButton4);
            this.Controls.Add(this.darkButton3);
            this.Controls.Add(this.darkButton2);
            this.Controls.Add(this.darkButton1);
            this.Controls.Add(this.darkTextBox2);
            this.Controls.Add(this.darkTextBox1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{local-form-main-title}";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CabViewerSDK.UI.Controls.DarkTextBox darkTextBox1;
        private CabViewerSDK.UI.Controls.DarkTextBox darkTextBox2;
        private CabViewerSDK.UI.Controls.DarkButton darkButton1;
        private CabViewerSDK.UI.Controls.DarkButton darkButton2;
        private CabViewerSDK.UI.Controls.DarkButton darkButton3;
        private CabViewerSDK.UI.Controls.DarkButton darkButton4;
    }
}