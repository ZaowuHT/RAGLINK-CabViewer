using CabViewerSDK;
using System;
using System.Collections.Generic;

namespace CR400SeriesController
{
    public class Plugin
    {
        // Plugin Summary Info
        static public CabViewerSDK.PluginInterface.PluginInfo pluginInfo =
            new CabViewerSDK.PluginInterface.PluginInfo(
                "e1007c23-324b-4abe-bb2a-e6d4aa881ca3",
                "CR400 Series EMU Cab Controller",
                "1.0.10000",
                "CR400 Series EMU Cab Controller, includes all of hardware supports and control logics of the cab controller of CR400 Series EMU.",
                "Code & Thing LAB",
                "https://github.com/ZaowuHT/raglink-cabviewer-openrails",
                "CR400SeriesController.dll",
                "CR400SeriesController",
                CabViewerSDK.PluginInterface.PluginRunMode.NATIVE,
                CabViewerSDK.PluginInterface.PluginType.CONTROLLER,
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
