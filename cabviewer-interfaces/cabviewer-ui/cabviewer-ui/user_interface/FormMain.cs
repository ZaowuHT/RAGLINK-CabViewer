using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabViewerUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FormPlugInsTreeView formStructureViewer = new FormPlugInsTreeView();
            formStructureViewer.Show(this.dockPanel);
            formStructureViewer.DockTo(this.dockPanel, DockStyle.Left);
            dockTheme.ApplyTo(mainMenu);
            dockTheme.ApplyTo(mainToolStrip);
        }
    }
}
