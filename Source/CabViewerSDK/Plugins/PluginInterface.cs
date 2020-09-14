using CabViewerSDK.Notation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using System.Threading;

namespace CabViewerSDK
{
    public class PluginInterface
    {
        public enum PluginState
        { STOP = 0, RUNNING = 1, PAUSE = 2, ERROR = 3, BUSY = 4, WAIT_FOR_RESP = 5 };
        public enum PluginEvent
        { EVENT_SIM_LAUNCH = 0, EVENT_SIM_START = 1, EVENT_SIM_PAUSE = 2, EVENT_SIM_STOP = 3,
          EVENT_PLUGIN_PAUSE = 4, EVENT_PLUGIN_QUIT = 5, EVENT_PLUGIN_CONTINUE = 6,
          EVENT_PLUGIN_HEARTBEAT = 7, EVENT_CRITICAL_DATA = 8, };
        public enum PluginEventResponse
        { EVENT_RESP_OK = 0, EVENT_RESP_NOT_READY = 1, EVENT_RESP_ERROR = 2 };

        public interface IPluginEntry
        {
            void Launch(string _pluginPath, string _parameters, string _settingsPathJSON);
            void SendMesssage(string _messageJSON, bool _forceReload);
            int MesssageQueueLength();
            List<string> GetAllMessage();
            string PopMessage();
            string PeekMessage();
            void ClearMessageQueue();
        };

        public enum PluginRunMode 
        { NATIVE = 0, EXTERN = 1 };
        public enum PluginType 
        { IDE = 0, SIMULATOR = 1, CONTROLLER = 2, HMI_DEVICE = 3, INTERACTIVE_DEVICE = 4, 
            FILE_EDITOR = 5, OTHER = 6 };

        public class PluginInfo
        {
            public string pluginGUID;
            public string pluginName;
            public string pluginVersion;
            public string pluginDescribe;
            public string pluginAuthor;
            public string pluginWebsite;
            public string pluginBinayAssembly;
            public string pluginAssemblyName;
            public PluginRunMode pluginRunMode;
            public PluginType pluginType;
            public bool pluginNecessary;
            public List<string> pluginDependenciesGUID;

            public PluginInfo()
            {
                pluginDependenciesGUID = new List<string>();
                pluginDependenciesGUID.Clear();
            }

            public PluginInfo(string _pluginGUID, string _pluginName, string _pluginVersion,
                string _pluginDescribe, string _pluginAuthor, string _pluginWebsite,
                string _pluginBinayAssembly, string _pluginAssemblyName, PluginRunMode _pluginRunMode, 
                PluginType _pluginType,  bool _pluginNecessary, string[] _pluginDependenciesGUID)
            {
                pluginDependenciesGUID = new List<string>();
                pluginDependenciesGUID.Clear();
                pluginGUID = _pluginGUID;
                pluginName = _pluginName;
                pluginVersion = _pluginVersion;
                pluginDescribe = _pluginDescribe;
                pluginAuthor = _pluginAuthor;
                pluginWebsite = _pluginWebsite;
                pluginBinayAssembly = _pluginBinayAssembly;
                pluginAssemblyName = _pluginAssemblyName;
                pluginRunMode = _pluginRunMode;
                pluginType = _pluginType;
                pluginNecessary = _pluginNecessary;
                pluginDependenciesGUID.AddRange(_pluginDependenciesGUID);
            }
        };

        public class Plugin
        {
            public string pluginPath;
            public string pluginSummaryFileFullPath;
            public string pluginSettingsFileFullPath;
            public string pluginBinaryAssemblyFullPath;
            public string pluginLaunchArgs;
            public PluginInfo pluginInfo;
            public IPluginEntry pluginEntry;
            private ThreadStart pluginThreadStart;
            private Thread pluginWorkThread;

            public Plugin(string _pluginSummaryFileFullPath)
            {
                if (File.Exists(_pluginSummaryFileFullPath))
                {
                    pluginSummaryFileFullPath = _pluginSummaryFileFullPath;
                    pluginPath = Path.GetDirectoryName(_pluginSummaryFileFullPath);
                    pluginSettingsFileFullPath = Path.GetFullPath(pluginPath
                        + "\\" + CabViewerResources.CabViewerResourcesManager.GetResourceByName("pluginSettingsFileName").ToString());
                    pluginInfo = JsonManager.GetObjectFromJsonFile<PluginInfo>(pluginSummaryFileFullPath);
                    if (pluginInfo != null)
                        pluginBinaryAssemblyFullPath = Path.GetFullPath(pluginPath
                            + "\\" + pluginInfo.pluginBinayAssembly);
                }
            }

            private Assembly AssemblyResolve(object sender, ResolveEventArgs args)
            {
                Assembly retValue = null;
                try
                {
                    AssemblyName assemblyName = new AssemblyName(args.Name.Split(',')[0]);
                    retValue = Assembly.LoadFrom(Path.Combine(pluginPath, assemblyName.Name + ".dll"));
                }
                catch (Exception) { };
                return retValue;
            }

            public bool InitializePluginAssembly()
            {
                bool retValue = false;
                try
                {
                    if (pluginInfo.pluginRunMode == PluginRunMode.NATIVE)
                    {
                        Assembly _assembly = Assembly.LoadFile(pluginBinaryAssemblyFullPath);
                        Type _type = _assembly.GetType(pluginInfo.pluginAssemblyName + ".Plugin+PluginEntry");
                        IPluginEntry _obj = Activator.CreateInstance(_type) as IPluginEntry;
                        pluginEntry = _obj;
                        AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
                    }
                }
                catch (Exception) { };
                return retValue;
            }

            private void StartThread()
            {
                pluginEntry.Launch(pluginPath, pluginLaunchArgs, pluginSettingsFileFullPath);
            }

            public void LaunchPlugin(string _pluginLaunchArgs)
            {
                pluginLaunchArgs = _pluginLaunchArgs;

                if (pluginInfo.pluginRunMode == PluginRunMode.NATIVE)
                {
                    if (pluginEntry != null)
                    {
                        pluginThreadStart = new ThreadStart(StartThread);
                        pluginWorkThread = new Thread(pluginThreadStart);
                        pluginWorkThread.Start();
                    }
                }
            }
        };
    }
}
