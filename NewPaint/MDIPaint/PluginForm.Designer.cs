namespace NewPaint.MDIPaint
{
    partial class PluginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView1 = new ListView();
            name = new ColumnHeader();
            author = new ColumnHeader();
            version = new ColumnHeader();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            status = new ColumnHeader();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { name, author, version, status });
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(529, 201);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // name
            // 
            name.Text = "Название";
            name.Width = 240;
            // 
            // author
            // 
            author.Text = "Автор";
            author.Width = 120;
            // 
            // version
            // 
            version.Text = "Версия";
            // 
            // button1
            // 
            button1.Location = new Point(12, 233);
            button1.Name = "button1";
            button1.Size = new Size(204, 23);
            button1.TabIndex = 1;
            button1.Text = "Убрать/Добавить загрузку";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(368, 233);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Удалить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(466, 233);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Загрузить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // status
            // 
            status.Text = "Загружать";
            status.Width = 90;
            // 
            // PluginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 279);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView1);
            Name = "PluginForm";
            Text = "Настройка плагинов";
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ColumnHeader name;
        private ColumnHeader author;
        private ColumnHeader version;
        private Button button1;
        private Button button2;
        private Button button3;
        private ColumnHeader status;
    }
}