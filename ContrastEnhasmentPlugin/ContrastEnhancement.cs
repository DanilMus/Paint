using System.Drawing;
using PluginInterface;

namespace ContrastEnhasmentPlugin
{
    /// <summary>
    /// Плагин для увелечения контрастности изображения
    /// </summary>
    [Version(1, 0)]
    public class ContrastEnhancement : IPlugin
    {
        public string Name => "Увеличение контраста";

        public string Author => "Мусихин Данил";

        // Метод для применения эффекта увеличения контраста к переданному изображению
        public void Transform(Bitmap bitmap)
        {
            // Получение гистограммы яркости изображения
            int[] histogram = GetHistogram(bitmap);

            // Нахождение минимальной яркости, которая фактически присутствует на изображении
            int minBrightness = 0;
            for (int i = 0; i < 256; i++)
            {
                if (histogram[i] > 0)
                {
                    minBrightness = i;
                    break;
                }
            }

            // Коэффициент увеличения контрастности
            double a = 2.0;
            // Рассчитываем смещение, чтобы увеличение контраста начиналось от минимальной яркости
            double с = -a * minBrightness;

            // Проход по всем пикселям изображения для изменения контраста
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);

                    // Применяем линейное преобразование для увеличения контрастности каждого цветового канала
                    int r = (int)(a * pixelColor.R + с);
                    int g = (int)(a * pixelColor.G + с);
                    int b = (int)(a * pixelColor.B + с);

                    // Ограничение значений цветовых каналов в пределах [0, 255]
                    r = Math.Min(255, Math.Max(0, r));
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    // Запись измененного цвета обратно в пиксель
                    bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
        }

        // Метод для создания гистограммы яркости изображения
        private int[] GetHistogram(Bitmap bitmap)
        {
            int[] histogram = new int[256];
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    int brightness = (int)(pixelColor.GetBrightness() * 255);
                    histogram[brightness]++;
                }
            }
            return histogram;
        }
    }

}