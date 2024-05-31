using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIPaint
{
    internal static class Interface
    {
        public static bool TakeInt(string text, out int n)
        {
            if (text != null && text != "")
            {
                bool isNum = int.TryParse(text, out n);

                if (isNum && n > 0)
                    return true;
                else
                {
                    MessageBox.Show(
                        "Пожалуйста, введите натуральное число",
                        "Ошибка");
                }
            }

            n = 0;
            return false;
        }

        public static bool TakeFloat(string text, out float n)
        {
            if (text != null && text != "")
            {
                bool isNum = float.TryParse(text, out n);

                if (isNum && n > 0)
                    return true;
                else
                {
                    MessageBox.Show(
                        "Пожалуйста, введите число (больше 0)",
                        "Ошибка");
                }
            }

            n = 0;
            return false;
        }
    }
}
