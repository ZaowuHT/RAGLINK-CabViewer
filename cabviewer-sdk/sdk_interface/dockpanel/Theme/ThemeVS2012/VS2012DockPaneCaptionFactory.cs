using CabViewerSDK.Docking;

namespace CabViewerSDK.DockingTheme.ThemeVS2012
{
    internal class VS2012DockPaneCaptionFactory : DockPanelExtender.IDockPaneCaptionFactory
    {
        public DockPaneCaptionBase CreateDockPaneCaption(DockPane pane)
        {
            return new VS2012DockPaneCaption(pane);
        }
    }
}
