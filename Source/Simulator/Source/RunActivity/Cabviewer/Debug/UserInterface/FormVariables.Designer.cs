namespace Orts.Cabviewer.Debug
{
    partial class FormVariables
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
            this.components = new System.ComponentModel.Container();
            this.listviewVariables = new CabViewerSDK.UI.Controls.DarkListView();
            this.timerRefreshVars = new System.Windows.Forms.Timer(this.components);
            this.buttonAdd = new CabViewerSDK.UI.Controls.DarkButton();
            this.buttonLess = new CabViewerSDK.UI.Controls.DarkButton();
            this.SuspendLayout();
            // 
            // listviewVariables
            // 
            this.listviewVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listviewVariables.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listviewVariables.Location = new System.Drawing.Point(12, 12);
            this.listviewVariables.Name = "listviewVariables";
            this.listviewVariables.Size = new System.Drawing.Size(440, 474);
            this.listviewVariables.TabIndex = 0;
            this.listviewVariables.Text = "darkListView1";
            // 
            // timerRefreshVars
            // 
            this.timerRefreshVars.Enabled = true;
            this.timerRefreshVars.Interval = 200;
            this.timerRefreshVars.Tick += new System.EventHandler(this.timerRefreshVars_Tick);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(377, 492);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Padding = new System.Windows.Forms.Padding(5);
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "+ 0.1";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonLess
            // 
            this.buttonLess.Location = new System.Drawing.Point(296, 492);
            this.buttonLess.Name = "buttonLess";
            this.buttonLess.Padding = new System.Windows.Forms.Padding(5);
            this.buttonLess.Size = new System.Drawing.Size(75, 23);
            this.buttonLess.TabIndex = 2;
            this.buttonLess.Text = "- 0.1";
            this.buttonLess.Click += new System.EventHandler(this.buttonLess_Click);
            // 
            // FormVariables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 521);
            this.Controls.Add(this.buttonLess);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listviewVariables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormVariables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "核心变量监视器";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormSimDebug_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CabViewerSDK.UI.Controls.DarkListView listviewVariables;
        private System.Windows.Forms.Timer timerRefreshVars;
        private CabViewerSDK.UI.Controls.DarkButton buttonAdd;
        private CabViewerSDK.UI.Controls.DarkButton buttonLess;
    }
}