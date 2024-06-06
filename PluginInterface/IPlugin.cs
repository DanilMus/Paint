using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PluginInterface
{
    /// <summary>
    /// Основа для создания новых плагинов
    /// </summary>
    public interface IPlugin
    {
        string Name { get; }
        string Author { get; }
        void Transform(Bitmap bitmap, IProgress<int> progress, CancellationToken cancellationToken);
    }
}
