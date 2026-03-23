using System;
using System.Windows;
using System.Windows.Controls;

namespace _423_Prasolova
{
    /// <summary>
    /// Страница 2: Разветвляющийся алгоритм.
    /// Вычисляет d в зависимости от f(x) и соотношения x и y.
    /// </summary>
    public partial class Page2 : Page
    {
        /// <summary>
        /// Инициализация компонентов страницы.
        /// </summary>
        public Page2() => InitializeComponent();

        /// <summary>
        /// Обработчик нажатия кнопки «Рассчитать».
        /// Определяет тип функции по RadioButton и вычисляет результат.
        /// </summary>
        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtX.Text, out double x) &&
                double.TryParse(txtY.Text, out double y))
            {
                int funcType = rbSh.IsChecked == true ? 1 :
                               (rbSquare.IsChecked == true ? 2 : 3);

                double d = Formuler.Formula2(funcType, x, y);
                txtRes.Text = d.ToString("F4");
            }
            else
            {
                MessageBox.Show("Некорректный ввод!");
            }
        }
    }
}
