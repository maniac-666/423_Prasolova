using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _423_Prasolova
{
    /// <summary>
    /// Класс, содержащий математические функции для вычислений.
    /// Используется на страницах WPF-приложения для расчётов по трём алгоритмам.
    /// </summary>
    public static class Formuler
    {
        /// <summary>
        /// Линейный алгоритм (Страница 1).
        /// Вычисляет: w = |cos(x) - cos(y)|^(1 + 2*sin²(y)) * (1 + z + z²/2 + z³/3 + z⁴/4)
        /// </summary>
        /// <param name="x">Значение переменной x</param>
        /// <param name="y">Значение переменной y</param>
        /// <param name="z">Значение переменной z</param>
        /// <returns>Результат вычисления функции w</returns>
        public static double Formula1(double x, double y, double z)
        {
            double part1 = Math.Pow(Math.Abs(Math.Cos(x) - Math.Cos(y)),
                           1 + 2 * Math.Pow(Math.Sin(y), 2));
            double part2 = 1 + z + Math.Pow(z, 2) / 2
                             + Math.Pow(z, 3) / 3
                             + Math.Pow(z, 4) / 4;
            return part1 * part2;
        }

        /// <summary>
        /// Вычисляет значение выбранной функции f(x).
        /// </summary>
        /// <param name="funcType">Тип функции: 1 — sh(x), 2 — x², 3 — e^x</param>
        /// <param name="x">Значение аргумента</param>
        /// <returns>Значение f(x)</returns>
        public static double CalcFx(int funcType, double x)
        {
            switch (funcType)
            {
                case 1: return Math.Sinh(x);
                case 2: return x * x;
                case 3: return Math.Exp(x);
                default: throw new ArgumentException("Некорректный тип функции.");
            }
        }

        /// <summary>
        /// Разветвляющийся алгоритм (Страница 2).
        /// Вычисляет d в зависимости от f(x) и соотношения x и y:
        /// если x > y, то d = (f(x) - y)³ + arctg(f(x));
        /// если y > x, то d = (y - f(x))³ + arctg(f(x));
        /// если x = y, то d = (y + f(x))³ + 0.5.
        /// </summary>
        /// <param name="funcType">Тип функции: 1 — sh(x), 2 — x², 3 — e^x</param>
        /// <param name="x">Значение переменной x</param>
        /// <param name="y">Значение переменной y</param>
        /// <returns>Результат вычисления d</returns>
        public static double Formula2(int funcType, double x, double y)
        {
            double fx = CalcFx(funcType, x);
            double d;

            if (x > y)
                d = Math.Pow(fx - y, 3) + Math.Atan(fx);
            else if (y > x)
                d = Math.Pow(y - fx, 3) + Math.Atan(fx);
            else
                d = Math.Pow(y + fx, 3) + 0.5;

            return d;
        }

        /// <summary>
        /// Циклический алгоритм (Страница 3).
        /// Вычисляет: y = a*x³ + cos²(x³ - b)
        /// </summary>
        /// <param name="a">Коэффициент a</param>
        /// <param name="x">Значение переменной x</param>
        /// <param name="b">Коэффициент b</param>
        /// <returns>Результат вычисления функции y</returns>
        public static double Formula3(double a, double x, double b)
        {
            return a * Math.Pow(x, 3) + Math.Pow(Math.Cos(Math.Pow(x, 3) - b), 2);
        }
    }
}