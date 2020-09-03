namespace CabViewerSDK.Docking
{
    using CabViewerSDK.sdk_interface.dockpanel.Theme.ThemeVS2015;
    using DockingTheme.ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class DockTheme : VS2015ThemeBase
    {
        public DockTheme()
            : base(Resources.docktheme)
        {
        }
    }
}
