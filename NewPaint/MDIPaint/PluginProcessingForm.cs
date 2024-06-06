using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPaint
{
    public partial class PluginProcessingForm : Form
    {
        private readonly CancellationTokenSource _cancellationTokenSource;

        public PluginProcessingForm(string pluginName, CancellationTokenSource cancellationTokenSource)
        {
            InitializeComponent();
            _cancellationTokenSource = cancellationTokenSource;
            label1.Text = $"Обработка: {pluginName}";
            button1.Click += (s, e) => _cancellationTokenSource.Cancel();
        }

        public void UpdateProgress(int percent)
        {
            if (IsHandleCreated && !IsDisposed)
            {
                if (InvokeRequired)
                {
                    try
                    {
                        Invoke(new Action<int>(UpdateProgress), percent);
                    }
                    catch (ObjectDisposedException)
                    {
                        // Обработай случай, когда форма расположена между проверкой и вызовом.
                    }
                }
                else
                {
                    progressBar1.Value = percent;
                }
            }
        }
    }
}
