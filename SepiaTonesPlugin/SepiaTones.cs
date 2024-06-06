using PluginInterface;
using System.Drawing;

namespace SepiaTonesPlugin
{
    /// <summary>
    /// Класс для создания "Оттеков сепии".
    /// 
    /// Эффект "оттенки сепии" — это метод обработки изображений, 
    /// который придает фотографиям теплый коричневатый оттенок, 
    /// имитируя внешний вид фотографий, разработанных в растворе сепии в прошлом. 
    /// Этот эффект часто используется для придания изображениям винтажного или 
    /// старинного вида, а также для улучшения контраста и глубины изображения.
    /// </summary>
    [Version(2, 0)]
    public class SepiaTones : IPlugin
    {
        public string Name => "Оттенки сепии";
        public string Author => "Мусихин Данил";

        public void Transform(Bitmap bitmap, IProgress<int> progress, CancellationToken cancellationToken)
        {
            if (bitmap != null)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        Color pixelColor = bitmap.GetPixel(x, y);

                        int r = (int)(pixelColor.R * 0.393 + pixelColor.G * 0.769 + pixelColor.B * 0.189);
                        int g = (int)(pixelColor.R * 0.349 + pixelColor.G * 0.686 + pixelColor.B * 0.168);
                        int b = (int)(pixelColor.R * 0.272 + pixelColor.G * 0.534 + pixelColor.B * 0.131);

                        r = Math.Min(255, Math.Max(0, r));
                        g = Math.Min(255, Math.Max(0, g));
                        b = Math.Min(255, Math.Max(0, b));

                        bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                    progress.Report((int)((float)y / bitmap.Height * 100));
                }
            }
        }
    }
}