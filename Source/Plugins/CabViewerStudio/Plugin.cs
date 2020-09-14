using CabViewerSDK;
using System;
using System.Collections.Generic;

namespace CabViewerStudio
{
    public class Plugin
    {
        // Plugin Summary Info
        static public CabViewerSDK.PluginInterface.PluginInfo pluginInfo =
            new CabViewerSDK.PluginInterface.PluginInfo(
                "f47917ea-e91c-8336-09ee-194470bc0ffa",
                "CabViewer Studio IDE",
                "1.0.10031",
                "RAGLINK+ CabViewer Interactive Environment IDE Tool",
                "Code & Thing LAB",
                "https://github.com/ZaowuHT/raglink-cabviewer-openrails",
                "CabViewerStudio.dll",
                "CabViewerStudio",
                CabViewerSDK.PluginInterface.PluginRunMode.NATIVE,
                CabViewerSDK.PluginInterface.PluginType.IDE,
                true, new string[0]);

        // Plugin Context
        public class PluginContext
        {
            public string pluginRunPath;
            public PluginInterface.PluginState pluginState;
            public CabViewerSDK.Communication.MessageQueue<string> recieveMessageQueue;
            public CabViewerSDK.Communication.MessageQueue<string> sendMessageQueue;

            public PluginContext()
            {
                pluginRunPath = string.Empty;
                pluginState = PluginInterface.PluginState.STOP;
                recieveMessageQueue = 
                    new CabViewerSDK.Communication.MessageQueue<string>(2048);
                sendMessageQueue =
                    new CabViewerSDK.Communication.MessageQueue<string>(2048);
            }
        };

        static public PluginContext pluginContext = new PluginContext();

        // Plugin Entry Point
        public class PluginEntry : CabViewerSDK.PluginInterface.IPluginEntry
        {
            public void Launch(string _pluginPath, string _parameters, string _settingsJSONPath)
            {
                if (pluginContext.pluginState == PluginInterface.PluginState.STOP)
                {
                    pluginContext.pluginRunPath = _pluginPath;
                    pluginContext.pluginState = PluginInterface.PluginState.RUNNING;
                    Program.Main(_parameters.Split(' '));
                }
            }

            public void SendMesssage(string _messageJSONload, bool _forceReload)
            {
                if (pluginContext.pluginState != PluginInterface.PluginState.STOP
                    && pluginContext.pluginState != PluginInterface.PluginState.ERROR)
                {
                    pluginContext.recieveMessageQueue.AddToMessageQueue(_messageJSONload, _forceReload);
                }
            }

            public int MesssageQueueLength()
            {
                return pluginContext.sendMessageQueue.GetMessageQueueLength();
            }

            public List<string> GetAllMessage()
            {
                return pluginContext.sendMessageQueue.GetAllMessage();
            }

            public string PopMessage()
            {
                return pluginContext.sendMessageQueue.PopMessage();
            }

            public string PeekMessage()
            {
                return pluginContext.sendMessageQueue.PeekMessage();
            }

            public void ClearMessageQueue()
            {
                pluginContext.sendMessageQueue.ClearMessageQueue();
            }
        };
    }
}
