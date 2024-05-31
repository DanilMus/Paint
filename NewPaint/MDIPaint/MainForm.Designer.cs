namespace MDIPaint
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            новыйToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripSeparator();
            saveButton = new ToolStripMenuItem();
            saveAsButton = new ToolStripMenuItem();
            выаToolStripMenuItem = new ToolStripSeparator();
            выходToolStripMenuItem = new ToolStripMenuItem();
            рисунокToolStripMenuItem = new ToolStripMenuItem();
            размерХолстаToolStripMenuItem = new ToolStripMenuItem();
            окноToolStripMenuItem = new ToolStripMenuItem();
            каскадомToolStripMenuItem = new ToolStripMenuItem();
            слеваНаправоToolStripMenuItem = new ToolStripMenuItem();
            сверхуВнизToolStripMenuItem = new ToolStripMenuItem();
            упорядочитьЗначкиToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            масштабToolStripMenuItem = new ToolStripMenuItem();
            масштабToolStripMenuItem1 = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            красныйToolStripMenuItem = new ToolStripMenuItem();
            синийToolStripMenuItem = new ToolStripMenuItem();
            зеленыйToolStripMenuItem = new ToolStripMenuItem();
            другойToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSplitButton1 = new ToolStripSplitButton();
            кистьToolStripMenuItem = new ToolStripMenuItem();
            ластикToolStripMenuItem = new ToolStripMenuItem();
            линияToolStripMenuItem = new ToolStripMenuItem();
            эллипсToolStripMenuItem = new ToolStripMenuItem();
            звездаToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            toolStripTextBox1 = new ToolStripTextBox();
            фильтрыToolStripMenuItem = new ToolStripMenuItem();
            настройкиToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, рисунокToolStripMenuItem, окноToolStripMenuItem, справкаToolStripMenuItem, фильтрыToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.MdiWindowListItem = окноToolStripMenuItem;
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(904, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { новыйToolStripMenuItem, открытьToolStripMenuItem, сохранитьToolStripMenuItem, saveButton, saveAsButton, выаToolStripMenuItem, выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            файлToolStripMenuItem.Click += файлToolStripMenuItem_Click;
            // 
            // новыйToolStripMenuItem
            // 
            новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            новыйToolStripMenuItem.Size = new Size(163, 22);
            новыйToolStripMenuItem.Text = "Новый";
            новыйToolStripMenuItem.Click += новыйToolStripMenuItem_Click;
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(163, 22);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(160, 6);
            // 
            // saveButton
            // 
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(163, 22);
            saveButton.Text = "Сохранить";
            saveButton.Click += сохранитьToolStripMenuItem1_Click;
            // 
            // saveAsButton
            // 
            saveAsButton.Name = "saveAsButton";
            saveAsButton.Size = new Size(163, 22);
            saveAsButton.Text = "Сохранить как...";
            saveAsButton.Click += сохранитьКакToolStripMenuItem_Click;
            // 
            // выаToolStripMenuItem
            // 
            выаToolStripMenuItem.Name = "выаToolStripMenuItem";
            выаToolStripMenuItem.Size = new Size(160, 6);
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(163, 22);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // рисунокToolStripMenuItem
            // 
            рисунокToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { размерХолстаToolStripMenuItem });
            рисунокToolStripMenuItem.Name = "рисунокToolStripMenuItem";
            рисунокToolStripMenuItem.Size = new Size(65, 20);
            рисунокToolStripMenuItem.Text = "Рисунок";
            // 
            // размерХолстаToolStripMenuItem
            // 
            размерХолстаToolStripMenuItem.Name = "размерХолстаToolStripMenuItem";
            размерХолстаToolStripMenuItem.Size = new Size(163, 22);
            размерХолстаToolStripMenuItem.Text = "Размер холста...";
            размерХолстаToolStripMenuItem.Click += размерХолстаToolStripMenuItem_Click;
            // 
            // окноToolStripMenuItem
            // 
            окноToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { каскадомToolStripMenuItem, слеваНаправоToolStripMenuItem, сверхуВнизToolStripMenuItem, упорядочитьЗначкиToolStripMenuItem, toolStripSeparator2, масштабToolStripMenuItem, масштабToolStripMenuItem1 });
            окноToolStripMenuItem.Name = "окноToolStripMenuItem";
            окноToolStripMenuItem.Size = new Size(48, 20);
            окноToolStripMenuItem.Text = "Окно";
            // 
            // каскадомToolStripMenuItem
            // 
            каскадомToolStripMenuItem.Name = "каскадомToolStripMenuItem";
            каскадомToolStripMenuItem.Size = new Size(187, 22);
            каскадомToolStripMenuItem.Text = "Каскадом";
            каскадомToolStripMenuItem.Click += каскадомToolStripMenuItem_Click;
            // 
            // слеваНаправоToolStripMenuItem
            // 
            слеваНаправоToolStripMenuItem.Name = "слеваНаправоToolStripMenuItem";
            слеваНаправоToolStripMenuItem.Size = new Size(187, 22);
            слеваНаправоToolStripMenuItem.Text = "Слева направо";
            слеваНаправоToolStripMenuItem.Click += слеваНаправоToolStripMenuItem_Click;
            // 
            // сверхуВнизToolStripMenuItem
            // 
            сверхуВнизToolStripMenuItem.Name = "сверхуВнизToolStripMenuItem";
            сверхуВнизToolStripMenuItem.Size = new Size(187, 22);
            сверхуВнизToolStripMenuItem.Text = "Сверху вниз";
            сверхуВнизToolStripMenuItem.Click += сверхуВнизToolStripMenuItem_Click;
            // 
            // упорядочитьЗначкиToolStripMenuItem
            // 
            упорядочитьЗначкиToolStripMenuItem.Name = "упорядочитьЗначкиToolStripMenuItem";
            упорядочитьЗначкиToolStripMenuItem.Size = new Size(187, 22);
            упорядочитьЗначкиToolStripMenuItem.Text = "Упорядочить значки";
            упорядочитьЗначкиToolStripMenuItem.Click += упорядочитьЗначкиToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(184, 6);
            // 
            // масштабToolStripMenuItem
            // 
            масштабToolStripMenuItem.Name = "масштабToolStripMenuItem";
            масштабToolStripMenuItem.Size = new Size(187, 22);
            масштабToolStripMenuItem.Text = "Масштаб+";
            масштабToolStripMenuItem.Click += масштабToolStripMenuItem_Click;
            // 
            // масштабToolStripMenuItem1
            // 
            масштабToolStripMenuItem1.Name = "масштабToolStripMenuItem1";
            масштабToolStripMenuItem1.Size = new Size(187, 22);
            масштабToolStripMenuItem1.Text = "Масштаб-";
            масштабToolStripMenuItem1.Click += масштабToolStripMenuItem1_Click;
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { оПрограммеToolStripMenuItem });
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(65, 20);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(158, 22);
            оПрограммеToolStripMenuItem.Text = "О программе...";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, toolStripSeparator1, toolStripSplitButton1, toolStripSeparator3, toolStripLabel1, toolStripTextBox1 });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(904, 25);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { красныйToolStripMenuItem, синийToolStripMenuItem, зеленыйToolStripMenuItem, другойToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(29, 22);
            toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // красныйToolStripMenuItem
            // 
            красныйToolStripMenuItem.Image = (Image)resources.GetObject("красныйToolStripMenuItem.Image");
            красныйToolStripMenuItem.Name = "красныйToolStripMenuItem";
            красныйToolStripMenuItem.Size = new Size(126, 22);
            красныйToolStripMenuItem.Text = "Красный ";
            красныйToolStripMenuItem.Click += красныйToolStripMenuItem_Click;
            // 
            // синийToolStripMenuItem
            // 
            синийToolStripMenuItem.Image = (Image)resources.GetObject("синийToolStripMenuItem.Image");
            синийToolStripMenuItem.Name = "синийToolStripMenuItem";
            синийToolStripMenuItem.Size = new Size(126, 22);
            синийToolStripMenuItem.Text = "Синий";
            синийToolStripMenuItem.Click += синийToolStripMenuItem_Click;
            // 
            // зеленыйToolStripMenuItem
            // 
            зеленыйToolStripMenuItem.Image = (Image)resources.GetObject("зеленыйToolStripMenuItem.Image");
            зеленыйToolStripMenuItem.Name = "зеленыйToolStripMenuItem";
            зеленыйToolStripMenuItem.Size = new Size(126, 22);
            зеленыйToolStripMenuItem.Text = "Зеленый";
            зеленыйToolStripMenuItem.Click += зеленыйToolStripMenuItem_Click;
            // 
            // другойToolStripMenuItem
            // 
            другойToolStripMenuItem.Name = "другойToolStripMenuItem";
            другойToolStripMenuItem.Size = new Size(126, 22);
            другойToolStripMenuItem.Text = "Другой...";
            другойToolStripMenuItem.Click += другойToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSplitButton1.DropDownItems.AddRange(new ToolStripItem[] { кистьToolStripMenuItem, ластикToolStripMenuItem, линияToolStripMenuItem, эллипсToolStripMenuItem, звездаToolStripMenuItem });
            toolStripSplitButton1.Image = (Image)resources.GetObject("toolStripSplitButton1.Image");
            toolStripSplitButton1.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Size = new Size(32, 22);
            toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // кистьToolStripMenuItem
            // 
            кистьToolStripMenuItem.Image = (Image)resources.GetObject("кистьToolStripMenuItem.Image");
            кистьToolStripMenuItem.Name = "кистьToolStripMenuItem";
            кистьToolStripMenuItem.Size = new Size(115, 22);
            кистьToolStripMenuItem.Text = "Кисть";
            кистьToolStripMenuItem.Click += кистьToolStripMenuItem_Click;
            // 
            // ластикToolStripMenuItem
            // 
            ластикToolStripMenuItem.Image = (Image)resources.GetObject("ластикToolStripMenuItem.Image");
            ластикToolStripMenuItem.Name = "ластикToolStripMenuItem";
            ластикToolStripMenuItem.Size = new Size(115, 22);
            ластикToolStripMenuItem.Text = "Ластик";
            ластикToolStripMenuItem.Click += ластикToolStripMenuItem_Click;
            // 
            // линияToolStripMenuItem
            // 
            линияToolStripMenuItem.Name = "линияToolStripMenuItem";
            линияToolStripMenuItem.Size = new Size(115, 22);
            линияToolStripMenuItem.Text = "Линия";
            линияToolStripMenuItem.Click += линияToolStripMenuItem_Click;
            // 
            // эллипсToolStripMenuItem
            // 
            эллипсToolStripMenuItem.Name = "эллипсToolStripMenuItem";
            эллипсToolStripMenuItem.Size = new Size(115, 22);
            эллипсToolStripMenuItem.Text = "Эллипс";
            эллипсToolStripMenuItem.Click += эллипсToolStripMenuItem_Click;
            // 
            // звездаToolStripMenuItem
            // 
            звездаToolStripMenuItem.Name = "звездаToolStripMenuItem";
            звездаToolStripMenuItem.Size = new Size(115, 22);
            звездаToolStripMenuItem.Text = "Звезда";
            звездаToolStripMenuItem.Click += звездаToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(53, 22);
            toolStripLabel1.Text = "Размер: ";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(116, 25);
            toolStripTextBox1.Click += toolStripTextBox1_Click;
            // 
            // фильтрыToolStripMenuItem
            // 
            фильтрыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { настройкиToolStripMenuItem });
            фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            фильтрыToolStripMenuItem.Size = new Size(69, 20);
            фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // настройкиToolStripMenuItem
            // 
            настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size = new Size(180, 22);
            настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 646);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "MainForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveButton;
        private System.Windows.Forms.ToolStripMenuItem saveAsButton;
        private System.Windows.Forms.ToolStripSeparator выаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рисунокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размерХолстаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem окноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каскадомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem слеваНаправоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сверхуВнизToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem упорядочитьЗначкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem красныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem синийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зеленыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem другойToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem линияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эллипсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кистьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ластикToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem масштабToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem масштабToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem звездаToolStripMenuItem;
        private ToolStripMenuItem фильтрыToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
    }
}

