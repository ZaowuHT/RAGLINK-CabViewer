using CabViewerSDK.UI.Renderers;
using System.Windows.Forms;

namespace CabViewerSDK.UI.Controls
{
    public class DarkContextMenu : ContextMenuStrip
    {
        #region Constructor Region

        public DarkContextMenu()
        {
            Renderer = new DarkMenuRenderer();
        }

        #endregion
    }
}
