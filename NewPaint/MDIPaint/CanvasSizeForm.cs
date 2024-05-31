using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIPaint
{
    // 
    // Форма для изменения размера изображения
    //
    public partial class CanvasSizeForm : Form
    {
        int Width;
        int Height;
        DocumentForm file;


        public CanvasSizeForm(DocumentForm file)
        {
            InitializeComponent();

            this.file = file;
            // Width = file.Width;
            // Height = file.Height;

            // При нажатии на enter будет срабатывать кнопка OK
            this.AcceptButton = OkButton;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox != null)
            {
                bool isNum = Interface.TakeInt(textBox.Text, out int num);
                Width = isNum ? num: Width;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox != null)
            {
                bool isNum = Interface.TakeInt(textBox.Text, out int num);
                Height = isNum ? num : Height;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (Width != null && Height != null)
            {
                file.UpdateSize(Width, Height);
                Close();
            }
            else
                MessageBox.Show(
                    "Пожалуйста, укажите ширину и высоту",
                    "Ошибка");
        }
    }
}
