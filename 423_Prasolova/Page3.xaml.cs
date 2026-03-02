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
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting; 
namespace _423_Prasolova
{
    public partial class Page3 : Window
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x0 = double.Parse(txtX0.Text);
                double xk = double.Parse(txtXk.Text);
                double dx = double.Parse(txtDx.Text);
                double a = double.Parse(txtA.Text);
                double b = double.Parse(txtB.Text);

                txtLog.Clear();
                MyChart.Series.Clear();

                Series series = new Series("y = ax^3 + cos^2(x^3 - b)")
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3
                };

                for (double x = x0; (dx > 0 ? x <= xk : x >= xk); x += dx)
                {
                    double y = a * Math.Pow(x, 3) + Math.Pow(Math.Cos(Math.Pow(x, 3) - b), 2);

                    txtLog.AppendText($"x={x:F2}; y={y:F4}\n");
                    series.Points.AddXY(x, y);
                }

                MyChart.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода: " + ex.Message);
            }
        }
    }
}