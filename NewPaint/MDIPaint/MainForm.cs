using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PluginInterface;
using NewPaint.MDIPaint;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using NewPaint;

//
// Основная форма, где происходит взаимодействие
//
namespace MDIPaint
{
    // Перечисление названий инструментов для работы с изображением
    public enum Tool
    {
        Pen,
        Eraser,
        Line,
        Ellipse,
        Star
    }


    public partial class MainForm : Form
    {
        // Аргументы для выранного инструмента
        public static Color Color { get; set; }
        public static int ToolWidth { get; set; }
        public static Tool Tool { get; set; }
        // Список плагинов для изменения изображения
        private Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();



        public MainForm()
        {
            InitializeComponent();
            Color = Color.Black;
            ToolWidth = 3;

            // Запуск асинхронной загрузки плагинов с прогрессом
            LoadPluginsAsync();
        }

        private async void LoadPluginsAsync()
        {
            var loadingForm = new LoadingForm();
            var progress = new Progress<int>(percent =>
            {
                loadingForm.UpdateProgress(percent);
            });

            // Центрирование формы загрузки внутри MainForm
            loadingForm.StartPosition = FormStartPosition.Manual;
            loadingForm.Location = new Point(this.Location.X + (this.Width) / 2,
                                             this.Location.Y + (this.Height) / 2);

            loadingForm.Show(this); // Отображение LoadingForm внутри MainForm

            try
            {
                await PluginDispatcher.LoadPluginsAsync(progress, loadingForm.CancellationTokenSource.Token);
                CreatePluginsMenu();
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Загрузка плагинов была отменена", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Вывод плагинов, которые загрузились
        public static void ShowLoadedPlugins()
        {
            string message = "Загруженные плагины:\n\n";
            foreach (var pluginName in PluginDispatcher.Plugins.Keys)
            {
                message += $"{pluginName}\n";
            }

            MessageBox.Show(message, "Загруженные плагины", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Добавление фильтров (т.е. плагинов для работы)
        private void CreatePluginsMenu()
        {
            // Переходим по всем плагинам
            foreach (var p in PluginDispatcher.Plugins)
            {
                // Добавляем вниз меню фильров фильтр (плагин)
                var item = фильтрыToolStripMenuItem.DropDownItems.Add(p.Value.Name);
                // Добавляем возможность кликать
                item.Click += OnPluginClick;
                // Проверяем возможность показа кнопки
                item.Visible = PluginDispatcher.Statuses[p.Key] ? true : false;
            }
        }


        // Возможность кликать по кнопки фильтра (плагина)
        public void OnPluginClick(object sender, EventArgs e)
        {
            IPlugin plugin = PluginDispatcher.Plugins[((ToolStripMenuItem)sender).Text];
            if (ActiveMdiChild != null)
            {
                var activeDocumentForm = (DocumentForm)ActiveMdiChild;
                // Запускаем каждый плагин асинхронно
                ExecutePluginAsync(plugin, activeDocumentForm);
            }
        }


        private async void ExecutePluginAsync(IPlugin plugin, DocumentForm documentForm)
        {
            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                var pluginProcessingForm = new PluginProcessingForm(plugin.Name, cancellationTokenSource);
                bool formClosed = false;
                pluginProcessingForm.FormClosed += (s, e) => formClosed = true;
                pluginProcessingForm.Show();

                // Создаем копию Bitmap для каждого плагина
                Bitmap bitmapCopy = (Bitmap)documentForm.Bitmap.Clone();

                try
                {
                    await Task.Run(() => plugin.Transform(bitmapCopy, new Progress<int>(percent =>
                    {
                        if (!formClosed)
                        {
                            pluginProcessingForm.UpdateProgress(percent);
                        }
                    }), cancellationTokenSource.Token));

                    // Обновляем оригинальный Bitmap после завершения плагина
                    using (Graphics g = Graphics.FromImage(documentForm.Bitmap))
                    {
                        g.DrawImage(bitmapCopy, 0, 0);
                    }
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show("Операция плагина была отменена", "Операция отмены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Собрана ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (!formClosed)
                    {
                        pluginProcessingForm.Close();
                    }
                    documentForm.Refresh();
                    bitmapCopy.Dispose();
                }
            }
        }




        // Выход из приложения
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Нажатие кнопки Справка/О программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Загрузка специально подготовленной формы
            var frmAbout = new AboutForm();
            frmAbout.ShowDialog();
        }

        // Создание нового файла для взаимодействия
        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Загрузка специально сделанной формы для этого
            var file = new DocumentForm();
            file.MdiParent = this;
            file.Show();

            // Не забываем активировать возможности для сохранения
            saveButton.Enabled = true;
            saveAsButton.Enabled = true;
        }


        // Изменения цвета рисовки: Красный, Синий, Зеленый и любой другой на выбор
        private void красныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color = Color.Red;
        }
        private void синийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color = Color.Blue;
        }
        private void зеленыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color = Color.Green;
        }
        private void другойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                Color = cd.Color;
        }


        // Нажатие кнопок "Сохранить" и "Сохранить как..."
        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var file = this.ActiveMdiChild as DocumentForm;
            file.Save();

        }
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = this.ActiveMdiChild as DocumentForm;
            file.SaveAs();
        }


        // Изменение ширины рисования инструмента
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            var textBox = sender as ToolStripTextBox;

            if (textBox != null)
            {
                bool isNum = Interface.TakeInt(textBox.Text, out int num);
                ToolWidth = isNum ? num : ToolWidth;
            }
        }


        // Изменение размеров холста
        private void размерХолстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = this.ActiveMdiChild as DocumentForm;
            if (this.ActiveMdiChild != null)
            {
                var canvasSizeForm = new CanvasSizeForm(file);
                canvasSizeForm.Show();
            }
        }


        // В приложении можно работать сразу с несколькими изображениями
        // Поэтому на выбор дается несколько видов распололожения окон изображений
        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        private void слеваНаправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        private void сверхуВнизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void упорядочитьЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }


        // Добавление или Удаление возможности сохранять изображение
        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверяем есть ли открытые DocumentForm, чтобы иметь возможность их сохранить
            if (this.ActiveMdiChild != null)
            {
                // Активируем кнопки сохранения
                saveButton.Enabled = true;
                saveAsButton.Enabled = true;
            }
            else
            {
                // Диактивируем кнопки сохранения
                saveButton.Enabled = false;
                saveAsButton.Enabled = false;
            }
        }


        // Открытие уже существующего изображения
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpg)|*.jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Создаем новую форму и открываем в ней файл
                var file = new DocumentForm();
                file.Open(openFileDialog);

                // Отображаем форму
                file.MdiParent = this;
                file.Show();
            }
        }


        // Использование разных инструментов для работы с изображением
        private void линияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tool = Tool.Line;
        }
        private void эллипсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tool = Tool.Ellipse;
        }
        private void кистьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tool = Tool.Pen;
        }
        private void ластикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tool = Tool.Eraser;
        }
        private void звездаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tool = Tool.Star;

            var file = this.ActiveMdiChild as DocumentForm;
            if (this.ActiveMdiChild != null)
            {
                var starForm = new StarForm(file);
                starForm.Show();
            }
        }

        // Изменение масштаба
        private void масштабToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = ActiveMdiChild as DocumentForm;
            file.Zoom(1.2f);
        }
        private void масштабToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var file = ActiveMdiChild as DocumentForm;
            file.Zoom(0.8f);
        }


        // Открытие окна настроек плагинов
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PluginForm(this);
            form.ShowDialog();
        }
    }
}
