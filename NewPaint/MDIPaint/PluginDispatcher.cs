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

        // Загрузка всех плагинов
        public static void LoadPlugins()
        {
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings.Count != 0)
                LoadPluginsFromConfig(appSettings);
            else
                LoadPluginsAndCreateConfigFile();
        }

        // Метод загружает плагины из конфигурационного файла.
        private static void LoadPluginsFromConfig(NameValueCollection? appSettings)
        {
            // Проходимся по всем ключам в коллекции настроек приложения.
            foreach (string? key in appSettings.AllKeys)
            {
                // Проверяем, что ключ не равен null и заканчивается на "Library.dll".
                if (key != null && key.EndsWith("Library.dll"))
                {
                    // Сохраняем имя файла плагина.
                    string name = key;

                    // Преобразуем значение настройки (включен ли плагин) в логическое значение.
                    bool enabled = Convert.ToBoolean(appSettings[key]);

                    // Получаем путь к текущему рабочему каталогу приложения.
                    string folder = System.AppDomain.CurrentDomain.BaseDirectory;

                    // Создаем полный путь к файлу плагина, объединяя рабочий каталог и имя файла.
                    string pluginPath = Path.Combine(folder, name);

                    // Загружаем плагин, передавая путь к файлу и флаг включения.
                    LoadPlugin(pluginPath, enabled);
                }
            }
        }

        // Метод загружает плагин из указанного пути и устанавливает его статус.
        private static IPlugin? LoadPlugin(string pluginPath, bool status)
        {
            // Загружаем сборку (DLL) из указанного пути.
            Assembly assembly = Assembly.LoadFile(pluginPath);

            // Перебираем все типы, определенные в загруженной сборке.
            foreach (Type type in assembly.GetTypes())
            {
                // Проверяем, реализует ли тип интерфейс IPlugin.
                Type? iface = type.GetInterface("PluginInterface.IPlugin");

                // Если тип реализует интерфейс IPlugin.
                if (iface != null)
                {
                    // Создаем экземпляр плагина с использованием рефлексии.
                    IPlugin? plugin = (IPlugin)Activator.CreateInstance(type);

                    // Добавляем плагин в коллекцию плагинов с его именем в качестве ключа.
                    Plugins.Add(plugin.Name, plugin);

                    // Добавляем статус плагина в коллекцию статусов с его именем в качестве ключа.
                    Statuses.Add(plugin.Name, status);

                    // Возвращаем загруженный плагин.
                    return plugin;
                }
            }

            // Если ни один из типов не реализует интерфейс IPlugin, возвращаем null.
            return null;
        }


        // Метод загружает плагины и создает конфигурационный файл с информацией о них.
        private static void LoadPluginsAndCreateConfigFile()
        {
            // Имя конфигурационного файла.
            var configFile = "App.config";

            // Действия нужны для использования файла конфигурации отличного от стандартного
            var map = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
            var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

            // Получаем раздел appSettings из конфигурационного файла.
            var newAppSettings = config.AppSettings.Settings;

            // Получаем путь к текущему рабочему каталогу приложения.
            string folder = AppDomain.CurrentDomain.BaseDirectory;

            // Получаем все файлы в рабочем каталоге, которые заканчиваются на "Plugin.dll".
            string[] files = Directory.GetFiles(folder, "*Plugin.dll");

            // Перебираем все найденные файлы плагинов.
            foreach (string pluginFile in files)
            {
                // Получаем имя файла плагина.
                string pluginName = Path.GetFileName(pluginFile);

                // Добавляем запись о плагине в раздел appSettings с значением "true" (включен).
                newAppSettings.Add(pluginName, "true");

                // Загружаем плагин, передавая путь к файлу и флаг включения.
                LoadPlugin(pluginFile, true);
            }

            // Сохраняем изменения в конфигурационном файле.
            config.Save(ConfigurationSaveMode.Modified);
        }

    }
}
