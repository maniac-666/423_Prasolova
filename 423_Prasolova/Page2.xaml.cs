using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _423_Prasolova
{
    public partial class Page2 : Page
    {
        public Page2() => InitializeComponent();

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtX.Text, out double x) && double.TryParse(txtY.Text, out double y))
            {
                double fx = rbSh.IsChecked == true ? Math.Sinh(x) : (rbSquare.IsChecked == true ? x * x : Math.Exp(x));
                double d;

                if (x > y) d = Math.Pow(fx - y, 3) + Math.Atan(fx); 
                else if (y > x) d = Math.Pow(y - fx, 3) + Math.Atan(fx);
                else d = Math.Pow(y + fx, 3) + 0.5;

                txtRes.Text = d.ToString("F4");
            }
            else MessageBox.Show("Некорректный ввод!");
        }
    }
}
