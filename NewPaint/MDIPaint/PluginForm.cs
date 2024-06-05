using MDIPaint;
using PluginInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace NewPaint.MDIPaint
{
    public partial class PluginForm : Form
    {
        public MainForm ParentForm { get; set; }

        public PluginForm(MainForm parentForm)
        {
            InitializeComponent();
            ParentForm = parentForm;
            LoadPluginsToListView();
        }

        // Загрузка плагинов для просмотра
        private void LoadPluginsToListView()
        {
            // Проходимся по всем плагинам в менеджере плагинов
            foreach (var plugin in PluginDispatcher.Plugins)
            {
                // Создаем новый элемент списка для каждого плагина
                ListViewItem item = new ListViewItem(plugin.Key);

                // Добавляем автора плагина в подэлементы элемента списка
                item.SubItems.Add(plugin.Value.Author);

                // Получаем тип плагина
                Type pluginType = plugin.Value.GetType();

                // Получаем версию плагина с помощью пользовательского атрибута VersionAttribute
                VersionAttribute? version = (VersionAttribute)Attribute.GetCustomAttribute(pluginType, typeof(VersionAttribute));

                // Добавляем версию плагина в подэлементы элемента списка
                item.SubItems.Add($"{version.Major}.{version.Minor}");

                // Добавляем статус плагина в подэлементы элемента списка
                item.SubItems.Add(PluginDispatcher.Statuses[plugin.Key] ? "Да" : "Нет");

                // Добавляем элемент списка в ListView
                listView1.Items.Add(item);
            }
        }


        // Изменение статуса плагина
        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем выбранные элементы в ListView
            SelectedListViewItemCollection selectedItems = listView1.SelectedItems;

            // Проходимся по всем выбранным элементам
            foreach (ListViewItem selectedItem in selectedItems)
            {
                try
                {
                    // Ищем соответствующий пункт меню для выбранного плагина
                    ToolStripMenuItem? foundItem = ParentForm.фильтрыToolStripMenuItem.DropDownItems
                    .OfType<ToolStripMenuItem>()
                    .FirstOrDefault(item => item.Text == selectedItem.Text);

                    // Если пункт меню найден
                    if (foundItem != null)
                    {
                        // Меняем статус плагина
                        PluginDispatcher.ChangePluginStatus(foundItem.Text);

                        // Обновляем видимость пункта меню в соответствии со статусом плагина
                        foundItem.Visible = PluginDispatcher.Statuses[foundItem.Text];

                        // Обновляем статус плагина в ListView
                        selectedItem.SubItems[3].Text = selectedItem.SubItems[3].Text == "Да" ? "Нет" : "Да";

                        // Обновляем меню
                        foundItem.Owner.Refresh();
                    }
                }
                catch (Exception ex)
                {
                    // Выводим сообщение об ошибке, если что-то пошло не так
                    MessageBox.Show("Ошибка смены статуса плагина: " + ex.Message);
                }
            }
        }

        // Удаление плагина
        private void button2_Click(object sender, EventArgs e)
        {
            // Получаем выбранные элементы из списка плагинов
            SelectedListViewItemCollection selectedItems = listView1.SelectedItems;

            // Проходим по всем выбранным элементам
            foreach (ListViewItem selectedItem in selectedItems)
            {
                try
                {
                    // Удаляем плагин с помощью менеджера плагинов
                    PluginDispatcher.DeletePlugin(selectedItem.Text);

                    // Удаляем выбранный элемент из списка
                    selectedItem.Remove();

                    // Ищем соответствующий пункт меню
                    ToolStripMenuItem? foundItem = ParentForm.фильтрыToolStripMenuItem.DropDownItems
                        .OfType<ToolStripMenuItem>()
                        .FirstOrDefault(item => item.Text == selectedItem.Text);

                    // Если пункт меню найден, удаляем его
                    if (foundItem != null)
                        ParentForm.фильтрыToolStripMenuItem.DropDownItems.Remove(foundItem);
                }
                catch (Exception ex)
                {
                    // В случае ошибки выводим сообщение об ошибке
                    MessageBox.Show("Ошибка выгрузки плагина и сборки: " + ex.Message);
                }
            }
        }


        // Добавление плагина
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем диалоговое окно для выбора файла
                OpenFileDialog openFileDialog = new OpenFileDialog();

                // Устанавливаем фильтр для файлов DLL
                openFileDialog.Filter = "DLL files (*.dll)|*.dll";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = false;

                // Устанавливаем начальную директорию для диалогового окна
                openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Если пользователь выбрал файл
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Получаем путь к выбранному файлу
                    string pluginPath = openFileDialog.FileName;

                    // Добавляем плагин с помощью менеджера плагинов
                    var plugin = PluginDispatcher.AddPlugin(pluginPath);

                    // Создаем новый элемент списка для плагина
                    ListViewItem item = new ListViewItem(plugin.Name);
                    item.SubItems.Add(plugin.Author);

                    // Получаем тип плагина и версию
                    Type pluginType = plugin.GetType();
                    VersionAttribute? version = (VersionAttribute)Attribute.GetCustomAttribute(pluginType, typeof(VersionAttribute));
                    item.SubItems.Add($"{version.Major}.{version.Minor}");

                    item.SubItems.Add(PluginDispatcher.Statuses[plugin.Name] ? "Да" : "Нет");

                    // Добавляем элемент в список плагинов
                    listView1.Items.Add(item);

                    // Добавляем пункт меню для плагина
                    var menuItem = ParentForm.фильтрыToolStripMenuItem.DropDownItems.Add(plugin.Name);
                    menuItem.Click += ParentForm.OnPluginClick;
                }
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим сообщение об ошибке
                MessageBox.Show("Ошибка загрузки плагина: " + ex.Message);
            }
        }
    }
}
