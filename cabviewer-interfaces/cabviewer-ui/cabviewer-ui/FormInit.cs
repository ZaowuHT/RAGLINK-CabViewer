using CabViewerResources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabViewerUI
{
    public partial class FormInit : Form
    {
        public FormInit()
        {
            InitializeComponent();
        }

        private void FormInit_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = (Image)CabViewerResourcesManager.GetResourceByName("Image_CabViewer_UI_Init_Background");
        }
    }
}
