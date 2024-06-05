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
    public partial class LoadingForm : Form
    {
        public CancellationTokenSource CancellationTokenSource { get; private set; }

        public LoadingForm()
        {
            InitializeComponent();
            CancellationTokenSource = new CancellationTokenSource();

            // Обработчик кнопки отмены
            button1.Click += (s, e) => CancellationTokenSource.Cancel();

            // Обработчик кнопки начала работы
            button2.Click += (s, e) => this.Close();
        }

        public void UpdateProgress(int percent)
        {
            progressBar1.Value = percent;
            if (percent == 100)
            {
                button2.Enabled = true;
                button1.Enabled = false;
            }
        }
    }
}
