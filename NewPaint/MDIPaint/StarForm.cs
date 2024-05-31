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
    // Форма для заполнения параметров того, как будет выглядеть фигура "Звезда"
    //
    public partial class StarForm : Form
    {
        // Переменные, думаю, говорящие
        float outerRadius;
        float innerRadius;
        int numPoints;
        DocumentForm file;

        public StarForm(DocumentForm file)
        {
            InitializeComponent();

            this.file = file;
            // При нажатии на enter будет срабатывать кнопка OK
            this.AcceptButton = OkButton;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox != null)
            {
                bool isNum = Interface.TakeInt(textBox.Text, out int num);
                numPoints = isNum ? num : numPoints;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox != null)
            {
                bool isNum = Interface.TakeFloat(textBox.Text, out float num);
                outerRadius = isNum ? num : outerRadius;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox != null)
            {
                bool isNum = Interface.TakeFloat(textBox.Text, out float num);
                innerRadius = isNum ? num : innerRadius;
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
                file.innerRadius = innerRadius;
                file.outerRadius = outerRadius;
                file.numPoints = numPoints;
                Close();
            }
            else
                MessageBox.Show(
                    "Пожалуйста, укажите все данные",
                    "Ошибка");
        }
    }
}
