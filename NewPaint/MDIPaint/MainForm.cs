﻿using System;
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
        public static int Width { get; set; }
        public static Tool Tool { get; set; }
        // Список плагинов для изменения изображения
        private Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();


        public MainForm()
        {
            // Выставление базовых настроек
            InitializeComponent();
            Color = Color.Black;
            Width = 3;

            // Проверка подлючения плагинов
            if (PluginDispatcher.Plugins.Count() != 0) ShowLoadedPlugins();
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


        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            var textBox = sender as ToolStripTextBox;

            if (textBox != null)
            {
                bool isNum = Interface.TakeInt(textBox.Text, out int num);
                Width = isNum ? num : Width;
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
    }
}