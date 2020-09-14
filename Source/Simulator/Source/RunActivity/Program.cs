// COPYRIGHT 2013 by the Open Rails project.
// 
// This file is part of Open Rails.
// 
// Open Rails is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Open Rails is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Open Rails.  If not, see <http://www.gnu.org/licenses/>.

using Orts.Cabviewer.Debug;
using Orts.Cabviewer.Proxy;
using Orts.Common;
using Orts.Simulation;
using Orts.Viewer3D;
using Orts.Viewer3D.Debugging;
using Orts.Viewer3D.Processes;
using ORTS.Common;
using ORTS.Settings;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Orts
{
    static class Program
    {
        public static Simulator Simulator;
        public static Viewer Viewer;
        public static DispatchViewer DebugViewer;
        public static SoundDebugForm SoundDebugForm;
        public static ORTraceListener ORTraceListener;
        public static string logFileName = "";

        static Program()
        {
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
        }

        static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        {
            Assembly retValue = null;
            try
            {
                AssemblyName assemblyName = new AssemblyName(args.Name.Split(',')[0]);
                DirectoryInfo _dir = new DirectoryInfo(
                    string.Format(@"{0}..\..\", AppDomain.CurrentDomain.BaseDirectory));
                retValue = Assembly.LoadFrom(
                    Path.Combine(_dir.FullName, assemblyName + ".dll"));
            }
            catch (Exception) { };
            return retValue;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [ThreadName("Render")]
        static public void Main(string[] args)
        {
            // CabViewer Area
            new System.Threading.Thread((System.Threading.ThreadStart)delegate
            {
                Application.Run(new FormVariables());
            }).Start();

            var options = args.Where(a => a.StartsWith("-") || a.StartsWith("/")).Select(a => a.Substring(1));
            var settings = new UserSettings(options);

            var game = new Game(settings);
            game.PushState(new GameStateRunActivity(args));
            game.Run();
        }
    }
}
