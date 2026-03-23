using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;

namespace _423_Prasolova
{
    /// <summary>
    /// Страница 3: Циклический алгоритм.
    /// Табулирует функцию y = ax³ + cos²(x³ - b) и строит график.
    /// </summary>
    public partial class Page3 : Page
    {
        /// <summary>
        /// Инициализация компонентов страницы.
        /// </summary>
        public Page3()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия кнопки «Рассчитать».
        /// Табулирует функцию от x0 до xk с шагом dx и строит график.
        /// </summary>
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
                    double y = Formuler.Formula3(a, x, b);
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