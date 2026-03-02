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
    public partial class Page1 : Page
    {
        public Page1() => InitializeComponent();

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtX.Text, out double x) && double.TryParse(txtY.Text, out double y) && double.TryParse(txtZ.Text, out double z)) // [cite: 158]
            {
                double part1 = Math.Pow(Math.Abs(Math.Cos(x) - Math.Cos(y)), (1 + 2 * Math.Pow(Math.Sin(y), 2)));
                double part2 = 1 + z + Math.Pow(z, 2) / 2 + Math.Pow(z, 3) / 3 + Math.Pow(z, 4) / 4;
                txtRes.Text = (part1 * part2).ToString("F4"); 
            }
            else MessageBox.Show("Проверьте правильность ввода данных!");
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear(); txtY.Clear(); txtZ.Clear(); txtRes.Clear();
        }
    }
}
