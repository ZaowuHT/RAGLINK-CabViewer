using CabViewerSDK;
using CabViewerSDK.Notation;
using CabViewerSDK.UI.Forms;
using System;
using System.Threading;

namespace CabViewerStudio
{
    public partial class FormMain : DarkForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            int streamLength = JsonManager.WriteJsonToMemory(Plugin.pluginInfo, "Studio_Info", false);
            PluginInterface.PluginInfo pluginInfoTest = JsonManager.GetObjectFromMemory<PluginInterface.PluginInfo>("Studio_Info", streamLength);
        }

        private void darkButton1_Click(object sender, EventArgs e)
        {
            CabViewerSDK.UnitTest.TestVariable.variableInt = Int32.Parse(darkTextBox1.Text);
        }

        private void darkButton3_Click(object sender, EventArgs e)
        {
            CabViewerSDK.UnitTest.TestVariable.variableString = darkTextBox2.Text;
        }

        private void darkButton2_Click(object sender, EventArgs e)
        {
            DarkMessageBox.ShowInformation(CabViewerSDK.UnitTest.TestVariable.variableInt.ToString(), "Test1");
        }

        private void darkButton4_Click(object sender, EventArgs e)
        {
            DarkMessageBox.ShowInformation(CabViewerSDK.UnitTest.TestVariable.variableString, "Test2");
        }
    }
}
