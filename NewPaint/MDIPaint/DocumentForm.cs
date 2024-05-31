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

namespace MDIPaint
{
    /// <summary>
    /// Форма для рисования
    /// </summary>
    public partial class DocumentForm : Form
    {
        // Для сохранения
        public string filePath;
        public ImageFormat format;
        // Поддерживаемые форматы
        private ImageFormat[] ff = { ImageFormat.Bmp, ImageFormat.Jpeg };

        // Для рисования
        private int x, y;
        private Bitmap bitmap;
        private Pen pen;
        private bool isMouseDown = false;
        // Для рисования звезды
        public float outerRadius = 10f;
        public float innerRadius = 5f;
        public int numPoints = 5;


        // Для индетификации
        private static int count = 0;
        private int ID;

        
        

        public DocumentForm()
        {
            InitializeComponent();

            // Создаем индетификацию, так как этих форм у нас будет несколько
            // и нужно как-то в них ориентироваться
            count += 1;
            ID = count;

            // Инициализируем поле, по которому будем рисовать и устанавливаем фон белым
            bitmap = new Bitmap(this.Width, this.Height);
            this.BackColor = Color.White;
            using (Graphics g = Graphics.FromImage(bitmap))
                g.Clear(this.BackColor);


            pen = new Pen(MainForm.Color, MainForm.Width);
            // Делаем линию непрерывистой
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }


        // Изменение размера изображения, с которым работаем
        public void UpdateSize(int Width, int Height)
        {
            // Создаем новую битмапу
            Bitmap newBitmap = new Bitmap(Width, Height);

            // Копируем данные старой битмапы
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.Clear(this.BackColor); // Не забываем установить фон 
                g.DrawImage(bitmap, 0, 0);
            }

            // Уничтожаем старую битмапу и заменяем новой
            bitmap.Dispose();
            bitmap = newBitmap;

            // Обновляем размеры формы
            this.Width = Width;
            this.Height = Height;
        }


        // Увеличение/Уменьшение изображения
        public void Zoom(float scale)
        {
            Bitmap zoomedBitmap = new Bitmap((int)(bitmap.Width * scale), (int)(bitmap.Height*scale));

            using (Graphics g = Graphics.FromImage(zoomedBitmap))
            {
                // Устанавливаем мастаб
                g.ScaleTransform(scale, scale);

                // Рисуем старый битмап в новом формате
                g.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            }

            // Заменяем
            bitmap = zoomedBitmap;

            // Изменяем размер формы
            this.Width = bitmap.Width;
            this.Height = bitmap.Height;

            // И перерисовываем ее
            this.Invalidate();
        }


        // Открытие уже существующего файла-изображения
        public bool Open(OpenFileDialog openFileDialog)
        {
            if (!this.isExist())
                return false;

            // Добавляем путь и формат
            filePath = openFileDialog.FileName;
            format = ff[openFileDialog.FilterIndex - 1];
            using (var bmpTemp = new Bitmap(openFileDialog.FileName)) 
                bitmap = new Bitmap(bmpTemp);

            // Обновляем размеры формы
            this.Width = bitmap.Width;
            this.Height = bitmap.Height;

            return true;
        }


        // Сохранения изменений с указанием пути
        public bool SaveAs()
        {
            if (!this.isExist())
                return false;

            // Используем внутрений класс для выбора пути
            // Класс открывает проводник и там уже происходит выбор пути 
            // и формата в котором будем сохранять
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpg)|*.jpg";


            // Когда пользователь нажмет кнопку ОК в проводнике,
            // тогда начинаем наше изображение
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.filePath = dlg.FileName;
                this.format = ff[dlg.FilterIndex - 1];

                this.bitmap.Save(this.filePath, this.format);
            }
            else
                return false;

            return true;
        }


        // Сохранение в уже существующий футь
        public bool Save()
        {
            if (!this.isExist())
                return false;

            // Если есть, куда сохранять, то сохраняем
            if (filePath != null && format != null)
                this.bitmap.Save(this.filePath, this.format);
            // Если нет, то просто вызываем ранее показанный вариант
            else
                return SaveAs();

            return true;
        }


        // Когда пользователь закрывает окно, то мы говорим ему, что не так
        public bool isExist()
        {
            if (this == null)
            {
                MessageBox.Show(
                        "Пожалуйста, создайте или откройте файл",
                        "Ошибка");
                return false;
            }
            return true;
        }


        // Нажал ли пользователь мышку
        // Есть связь со специальным событием в форме
        private void DocumentForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Нажал на левую кнопку мыши,
            // тогда обновляем координаты рисования
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
                isMouseDown = true;
            }
        }


        // Пользователь передвигает мышь
        private void DocumentForm_MouseMove(object sender, MouseEventArgs e)
        {
            // Если левоя кнопка мыши 
            if (isMouseDown && (MainForm.Tool == Tool.Pen || MainForm.Tool == Tool.Eraser))
            {
                // Берем "картинку"
                Graphics g = Graphics.FromImage(bitmap);

                // и начинаем ее изменять в зависимости от параметров и инструментов,
                // которые выбираем
                pen.Width = MainForm.Width;
                if (MainForm.Tool == Tool.Pen)
                {
                    pen.Color = MainForm.Color;
                }
                else if (MainForm.Tool == Tool.Eraser)
                {
                    pen.Color = this.BackColor;
                }
                g.DrawLine(pen, x, y, e.X, e.Y);
                Invalidate();
                x = e.X;
                y = e.Y;
            }
        }


        // Кнопка отжимается
        private void DocumentForm_MouseUp(object sender, MouseEventArgs e)
        {
            // Действия производим только с инструментами, которые рисуют фигуры
            if (isMouseDown && MainForm.Tool != Tool.Pen && MainForm.Tool != Tool.Eraser)
            {
                // Берем "картинку"
                Graphics g = Graphics.FromImage(bitmap);

                // и начинаем ее изменять в зависимости от параметров и инструментов,
                // которые выбираем
                pen.Color = MainForm.Color;
                pen.Width = MainForm.Width;
                if (MainForm.Tool == Tool.Line)
                {
                    g.DrawLine(pen, x, y, e.X, e.Y);
                }
                else if (MainForm.Tool == Tool.Ellipse)
                {
                    g.DrawEllipse(pen, x, y, e.X - x, e.Y - y);
                }
                else if (MainForm.Tool == Tool.Star)
                {
                    DrawStar(x, y);
                }

                Invalidate();
                x = e.X;
                y = e.Y;
            }
            isMouseDown = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(bitmap, 0, 0);
        }


        // Закрытие документа и предложение его сохранить перед выходом
        private void DocumentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show($"Вы хотите сохранить эту форму({ID}) перед закрытием?", "Подтверждение", MessageBoxButtons.YesNoCancel);
            
            if (result == DialogResult.Yes)
                Save();
            else if (result == DialogResult.Cancel)
                // Если пользователь передумал закрывать форму, отменяем закрытие
                e.Cancel = true;
        }


        // Отдлельная функция для рисования фигуры "Звезда"
        private void DrawStar(float cx, float cy)
        {
            // Создаем массив точек
            PointF[] points = new PointF[numPoints * 2];

            // Вычисляем углы для каждой точки
            double angleStep = Math.PI / numPoints;

            // Создаем точки
            for (int i = 0; i < numPoints * 2; i++)
            {
                // Вычисляем радиус для этой точки
                float radius = (i % 2 == 0) ? outerRadius : innerRadius;

                // Вычисляем угол этой точки
                double angle = i * angleStep;

                // Вычисляем ее координаты
                float x = cx + radius * (float)Math.Cos(angle);
                float y = cy + radius * (float)Math.Sin(angle);

                // Добаляем точку в массив
                points[i] = new PointF(x, y);
            }

            // Ну и рисуем это дело
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawPolygon(pen, points);
        }
    }
}
