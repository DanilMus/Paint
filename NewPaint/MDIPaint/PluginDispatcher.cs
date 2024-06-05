using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PluginInterface;
using System.IO;

namespace MDIPaint
{
    //
    // Диспетчер загрузок плагинов
    //
    public static class PluginDispatcher
    {
        // Атрибуты, думаю, говорят сами за себя
        public static Dictionary<string, IPlugin> Plugins = new Dictionary<string, IPlugin>();
        public static Dictionary<string, bool> Statuses = new Dictionary<string, bool>();

        // Асинхронная загрузка всех плагинов с поддержкой прогресса
        public static async Task LoadPluginsAsync(IProgress<int> progress, CancellationToken cancellationToken)
        {
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings.Count != 0)
                await LoadPluginsFromConfigAsync(appSettings, progress, cancellationToken);
            else
                await LoadPluginsAndCreateConfigFileAsync(progress, cancellationToken);
        }

        private static async Task LoadPluginsFromConfigAsync(NameValueCollection? appSettings, IProgress<int> progress, CancellationToken cancellationToken)
        {
            int totalPlugins = appSettings.AllKeys.Count(key => key != null && key.EndsWith("Plugin.dll"));
            int loadedPlugins = 0;

            foreach (string? key in appSettings.AllKeys)
            {
                if (key != null && key.EndsWith("Plugin.dll"))
                {
                    string name = key;
                    bool enabled = Convert.ToBoolean(appSettings[key]);
                    string folder = System.AppDomain.CurrentDomain.BaseDirectory;
                    string pluginPath = Path.Combine(folder, name);

                    cancellationToken.ThrowIfCancellationRequested();
                    await Task.Run(() => LoadPlugin(pluginPath, enabled), cancellationToken);

                    loadedPlugins++;
                    progress.Report((loadedPlugins * 100) / totalPlugins);
                }
            }
        }

        private static async Task LoadPluginsAndCreateConfigFileAsync(IProgress<int> progress, CancellationToken cancellationToken)
        {
            var configFile = "App.config";
            var map = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
            var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var newAppSettings = config.AppSettings.Settings;
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            string[] files = Directory.GetFiles(folder, "*Plugin.dll");

            int totalPlugins = files.Length;
            int loadedPlugins = 0;

            foreach (string pluginFile in files)
            {
                string pluginName = Path.GetFileName(pluginFile);
                newAppSettings.Add(pluginName, "true");

                cancellationToken.ThrowIfCancellationRequested();
                await Task.Run(() => LoadPlugin(pluginFile, true), cancellationToken);

                loadedPlugins++;
                progress.Report((loadedPlugins * 100) / totalPlugins);
            }

            config.Save(ConfigurationSaveMode.Modified);
        }

        private static IPlugin? LoadPlugin(string pluginPath, bool status)
        {
            Assembly assembly = Assembly.LoadFile(pluginPath);
            foreach (Type type in assembly.GetTypes())
            {
                Type? iface = type.GetInterface("PluginInterface.IPlugin");
                if (iface != null)
                {
                    IPlugin? plugin = (IPlugin)Activator.CreateInstance(type);
                    Plugins.Add(plugin.Name, plugin);
                    Statuses.Add(plugin.Name, status);
                    return plugin;
                }
            }
            return null;
        }


        // Изменения статуса активности плагина
        public static void ChangePluginStatus(string name)
        {
            // Открываем конфигурацию приложения
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Получаем тип плагина
            Type pluginType = Plugins[name].GetType();

            // Получаем сборку, в которой определен тип плагина
            Assembly assembly = pluginType.Assembly;

            // Получаем имя сборки
            string assemblyName = assembly.GetName().Name;

            // Проверяем, есть ли настройка для данной сборки в конфигурации
            if (config.AppSettings.Settings[$"{assemblyName}.dll"] != null)
            {
                // Меняем значение настройки на противоположное
                config.AppSettings.Settings[$"{assemblyName}.dll"].Value =
                    config.AppSettings.Settings[$"{assemblyName}.dll"].Value == "true" ? "false" : "true";

                // Меняем статус плагина на противоположный
                Statuses[name] = !Statuses[name];

                // Сохраняем изменения в конфигурации
                config.Save(ConfigurationSaveMode.Modified);

                // Обновляем секцию "appSettings" в конфигурации
                ConfigurationManager.RefreshSection("appSettings");
            }
        }


        // Удаление плагина
        public static void DeletePlugin(string name)
        {
            // Открываем конфигурацию приложения
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Получаем тип плагина
            Type pluginType = Plugins[name].GetType();

            // Получаем сборку, в которой определен тип плагина
            Assembly assembly = pluginType.Assembly;

            // Получаем имя сборки
            string assemblyName = assembly.GetName().Name;

            // Проверяем, есть ли настройка для данной сборки в конфигурации
            if (config.AppSettings.Settings[$"{assemblyName}.dll"] != null)
            {
                // Удаляем настройку из конфигурации
                config.AppSettings.Settings.Remove($"{assemblyName}.dll");

                // Удаляем статус плагина
                Statuses.Remove(name);

                // Удаляем плагин
                Plugins.Remove(name);

                // Сохраняем изменения в конфигурации
                config.Save(ConfigurationSaveMode.Modified);

                // Обновляем секцию "appSettings" в конфигурации
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        // Добавление плагина
        public static IPlugin? AddPlugin(string pluginPath)
        {
            // Получаем имя файла без расширения из пути к плагину
            string pluginName = Path.GetFileNameWithoutExtension(pluginPath);

            // Открываем конфигурацию приложения
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Добавляем в настройки приложения информацию о плагине
            config.AppSettings.Settings.Add(pluginName + ".dll", "true");

            // Сохраняем изменения в конфигурации
            config.Save(ConfigurationSaveMode.Modified);

            // Обновляем раздел настроек приложения
            ConfigurationManager.RefreshSection("appSettings");

            // Загружаем плагин
            return LoadPlugin(pluginPath, true);
        }
    }
}
