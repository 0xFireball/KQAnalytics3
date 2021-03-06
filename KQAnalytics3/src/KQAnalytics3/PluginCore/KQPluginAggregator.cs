﻿using Iridium.PluginCore;
using Iridium.PluginEngine;
using Iridium.PluginEngine.Types;

namespace KQAnalytics3.PluginCore
{
    public static class KQPluginAggregator
    {
        public static void LoadAllPlugins()
        {
            var pluginLoader = new PluginLoader<IPlatinumComponent>();
            foreach (var pluginPath in KQRegistry.ServerConfiguration.PluginPaths)
            {
                var loadedPlugins = pluginLoader.Factory.LoadPlugin(pluginPath);
            }
            pluginLoader.RegisterAll();
        }
    }
}