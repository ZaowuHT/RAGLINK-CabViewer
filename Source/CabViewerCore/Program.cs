using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabViewerCore
{
    class Program
    {
        static void Main(string[] args)
        {
            CabViewerSDK.PluginInterface.Plugin pluginStudio =
                new CabViewerSDK.PluginInterface.Plugin(
                    @"C:\Documents\raglink-simulator-openrails\Program\Plugin\CabViewerStudio\Plugin.rex");
            pluginStudio.InitializePluginAssembly();
            pluginStudio.LaunchPlugin("");
            Console.WriteLine("Plugin Studio Started.");

            CabViewerSDK.PluginInterface.Plugin pluginCR400Controller =
                new CabViewerSDK.PluginInterface.Plugin(
                    @"C:\Documents\raglink-simulator-openrails\Program\Plugin\CR400SeriesController\Plugin.rex");
            pluginCR400Controller.InitializePluginAssembly();
            pluginCR400Controller.LaunchPlugin("");
            Console.WriteLine("Plugin CR400 Controller Started.");
        }
    }
}
