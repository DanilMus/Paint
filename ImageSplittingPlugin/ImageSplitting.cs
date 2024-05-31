using PluginInterface;
using System.Drawing;

namespace ImageSplittingPlugin
{
    /// <summary>
    /// Плагин для разбиения изображения.
    /// </summary>
    [Version(1, 0)]
    public class ImageSplitting : IPlugin
    {
        public string Name => "Разбиение изображения";
        public string Author => "Мусихин Данил";

        // Метод для разделения переданного изображения на части и их перемешивания
        public void Transform(Bitmap bitmap)
        {
            // Определяем ширину и высоту частей изображения
            int partWidth = bitmap.Width / 3;
            int partHeight = bitmap.Height / 3;

            // Создаем список для хранения частей изображения
            List<Bitmap> parts = new List<Bitmap>();

            // Разбиваем изображение на части и добавляем их в список
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Определяем прямоугольник источника для текущей части
                    Rectangle sourceRectangle = new Rectangle(j * partWidth, i * partHeight, partWidth, partHeight);
                    // Создаем новое изображение для текущей части
                    Bitmap part = new Bitmap(partWidth, partHeight);
                    // Используем Graphics для копирования части изображения в новое изображение
                    using (Graphics g = Graphics.FromImage(part))
                    {
                        g.DrawImage(bitmap, 0, 0, sourceRectangle, GraphicsUnit.Pixel);
                    }
                    // Добавляем часть в список
                    parts.Add(part);
                }
            }

            // Перемешиваем части изображения
            Random rand = new Random();
            for (int i = parts.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                Bitmap temp = parts[i];
                parts[i] = parts[j];
                parts[j] = temp;
            }

            // Используем Graphics для отрисовки перемешанных частей на исходном изображении
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Очищаем изображение
                g.Clear(Color.White);
                // Рисуем перемешанные части на изображении
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        g.DrawImage(parts[i * 3 + j], j * partWidth, i * partHeight);
                    }
                }
            }
        }
    }

}