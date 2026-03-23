using System;
using System.Windows;
using System.Windows.Controls;

namespace _423_Prasolova
{
    /// <summary>
    /// Страница 1: Линейный алгоритм.
    /// Вычисляет w = |cos(x)-cos(y)|^(1+2sin²y) * (1+z+z²/2+z³/3+z⁴/4)
    /// </summary>
    public partial class Page1 : Page
    {
        /// <summary>
        /// Инициализация компонентов страницы.
        /// </summary>
        public Page1() => InitializeComponent();

        /// <summary>
        /// Обработчик нажатия кнопки «Рассчитать».
        /// Считывает x, y, z и выводит результат формулы 1.
        /// </summary>
        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtX.Text, out double x) &&
                double.TryParse(txtY.Text, out double y) &&
                double.TryParse(txtZ.Text, out double z))
            {
                double result = Formuler.Formula1(x, y, z);
                txtRes.Text = result.ToString("F4");
            }
            else
            {
                MessageBox.Show("Проверьте правильность ввода данных!");
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки «Очистить».
        /// </summary>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear(); txtY.Clear(); txtZ.Clear(); txtRes.Clear();
        }
    }
}

