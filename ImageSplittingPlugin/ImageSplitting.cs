using PluginInterface;
using System.Drawing;

namespace ImageSplittingPlugin
{
    /// <summary>
    /// Плагин для разбиения изображения.
    /// </summary>
    [Version(2, 0)]
    public class ImageSplitting : IPlugin
    {
        public string Name => "Разбиение изображения";
        public string Author => "Мусихин Данил";

        public void Transform(Bitmap bitmap, IProgress<int> progress, CancellationToken cancellationToken)
        {
            int partWidth = bitmap.Width / 3;
            int partHeight = bitmap.Height / 3;

            List<Bitmap> parts = new List<Bitmap>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    Rectangle sourceRectangle = new Rectangle(j * partWidth, i * partHeight, partWidth, partHeight);
                    Bitmap part = new Bitmap(partWidth, partHeight);

                    using (Graphics g = Graphics.FromImage(part))
                    {
                        g.DrawImage(bitmap, 0, 0, sourceRectangle, GraphicsUnit.Pixel);
                    }
                    parts.Add(part);
                }
                progress.Report((int)((float)(i * 3 + 3) / 9 * 100));
            }

            Random rand = new Random();
            for (int i = parts.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                Bitmap temp = parts[i];
                parts[i] = parts[j];
                parts[j] = temp;
            }

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        g.DrawImage(parts[i * 3 + j], j * partWidth, i * partHeight);
                    }
                }
            }
            progress.Report(100);
        }
    }
}