using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _423_Prasolova;

namespace UnitTestProject
{
    /// <summary>
    /// Класс модульных тестов для проверки математических функций
    /// из Практической работы №4.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Тренировочный тест для изучения методов класса Assert.
        /// Assert.AreEqual — проверяет равенство двух значений.
        /// Assert.AreNotEqual — проверяет неравенство двух значений.
        /// Assert.IsFalse — проверяет, что условие ложно.
        /// Assert.IsTrue — проверяет, что условие истинно.
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            int res = 2 + 2;
            Assert.AreEqual(res, 4);
            Assert.AreNotEqual(res, 5);
            Assert.IsFalse(res > 5);
            Assert.IsTrue(res < 5);
        }

        /// <summary>
        /// Тест линейного алгоритма (Страница 1).
        /// Проверяет: w = |cos(x)-cos(y)|^(1+2sin²y) * (1+z+z²/2+z³/3+z⁴/4)
        /// </summary>
        [TestMethod]
        public void TestFormula1_Linear()
        {
            // Тест 1: x=0, y=0, z=0
            // |cos0-cos0|=0, 0^(...)=0, результат = 0
            double r1 = Formuler.Formula1(0, 0, 0);
            Assert.AreEqual(0.0, r1, 0.0001, "При x=0, y=0, z=0 результат должен быть 0");

            // Тест 2: x=1, y=2, z=1
            // Ручной расчёт:
            // |cos1 - cos2| = |0.5403 - (-0.4161)| = 0.9564
            // степень = 1 + 2*sin²(2) = 1 + 2*0.8268 = 2.6536
            // part1 = 0.9564^2.6536 ≈ 0.8868
            // part2 = 1 + 1 + 0.5 + 0.3333 + 0.25 = 3.0833
            // w ≈ 2.7330
            double r2 = Formuler.Formula1(1, 2, 1);
            double expected2 = Math.Pow(Math.Abs(Math.Cos(1) - Math.Cos(2)),
                1.0 + 2.0 * Math.Pow(Math.Sin(2), 2))
                * (1.0 + 1.0 + 0.5 + 1.0 / 3.0 + 0.25);
            Assert.AreEqual(expected2, r2, 0.0001, "Формула 1: x=1, y=2, z=1");

            // Тест 3: z=0 — вторая часть = 1, проверяем что part2 = 1
            double r3 = Formuler.Formula1(1, 2, 0);
            double expected3 = Math.Pow(Math.Abs(Math.Cos(1) - Math.Cos(2)),
                1.0 + 2.0 * Math.Pow(Math.Sin(2), 2)) * 1.0;
            Assert.AreEqual(expected3, r3, 0.0001, "При z=0 множитель part2 = 1");
        }

        /// <summary>
        /// Тест разветвляющегося алгоритма (Страница 2).
        /// Проверяет три ветви:
        /// x > y: d = (f(x)-y)³ + arctg(f(x))
        /// y > x: d = (y-f(x))³ + arctg(f(x))
        /// x = y: d = (y+f(x))³ + 0.5
        /// А также все три функции: sh(x), x², e^x.
        /// </summary>
        [TestMethod]
        public void TestFormula2_Branching()
        {
            // === Ветка 1: x > y ===
            // f(x) = sh(x), x=3, y=1 → sh(3)=10.0179
            // d = (10.0179-1)^3 + atan(10.0179) = 729.46 + 1.4711 ≈ 730.93
            double r1 = Formuler.Formula2(1, 3, 1);
            double fx1 = Math.Sinh(3);
            double exp1 = Math.Pow(fx1 - 1, 3) + Math.Atan(fx1);
            Assert.AreEqual(exp1, r1, 0.01, "Ветка x>y, f(x)=sh(x)");

            // f(x) = x², x=5, y=2 → fx=25
            // d = (25-2)^3 + atan(25) = 12167 + 1.5308 ≈ 12168.53
            double r2 = Formuler.Formula2(2, 5, 2);
            double exp2 = Math.Pow(25 - 2, 3) + Math.Atan(25);
            Assert.AreEqual(exp2, r2, 0.01, "Ветка x>y, f(x)=x²");

            // === Ветка 2: y > x ===
            // f(x) = e^x, x=1, y=5 → fx=e=2.7183
            // d = (5-2.7183)^3 + atan(2.7183) = 11.875 + 1.218 ≈ 13.09
            double r3 = Formuler.Formula2(3, 1, 5);
            double fx3 = Math.Exp(1);
            double exp3 = Math.Pow(5 - fx3, 3) + Math.Atan(fx3);
            Assert.AreEqual(exp3, r3, 0.01, "Ветка y>x, f(x)=e^x");

            // f(x) = sh(x), x=1, y=3 → sh(1)=1.1752
            // d = (3-1.1752)^3 + atan(1.1752) = 6.097 + 0.866 ≈ 6.96
            double r4 = Formuler.Formula2(1, 1, 3);
            double fx4 = Math.Sinh(1);
            double exp4 = Math.Pow(3 - fx4, 3) + Math.Atan(fx4);
            Assert.AreEqual(exp4, r4, 0.01, "Ветка y>x, f(x)=sh(x)");

            // === Ветка 3: x = y ===
            // f(x) = x², x=2, y=2 → fx=4
            // d = (2+4)^3 + 0.5 = 216 + 0.5 = 216.5
            double r5 = Formuler.Formula2(2, 2, 2);
            Assert.AreEqual(216.5, r5, 0.01, "Ветка x=y, f(x)=x²");

            // f(x) = e^x, x=0, y=0 → fx=1
            // d = (0+1)^3 + 0.5 = 1 + 0.5 = 1.5
            double r6 = Formuler.Formula2(3, 0, 0);
            Assert.AreEqual(1.5, r6, 0.01, "Ветка x=y, f(x)=e^x, x=y=0");
        }

        /// <summary>
        /// Тест циклического алгоритма (Страница 3).
        /// Проверяет: y = a*x³ + cos²(x³ - b)
        /// </summary>
        [TestMethod]
        public void TestFormula3_Cyclic()
        {
            // Тест 1: a=1, x=0, b=0 → y = 0 + cos²(0) = 1
            double r1 = Formuler.Formula3(1, 0, 0);
            Assert.AreEqual(1.0, r1, 0.0001, "a=1, x=0, b=0 → y=1");

            // Тест 2: a=1, x=1, b=1 → y = 1 + cos²(1-1) = 1 + cos²(0) = 2
            double r2 = Formuler.Formula3(1, 1, 1);
            Assert.AreEqual(2.0, r2, 0.0001, "a=1, x=1, b=1 → y=2");

            // Тест 3: a=2, x=2, b=0
            // y = 2*8 + cos²(8) = 16 + cos²(8) = 16 + 0.0206 ≈ 16.0206
            double r3 = Formuler.Formula3(2, 2, 0);
            double exp3 = 16.0 + Math.Pow(Math.Cos(8), 2);
            Assert.AreEqual(exp3, r3, 0.0001, "a=2, x=2, b=0");

            // Тест 4: a=0, x=5, b=3 — при a=0 остаётся только cos²
            double r4 = Formuler.Formula3(0, 5, 3);
            double exp4 = Math.Pow(Math.Cos(Math.Pow(5, 3) - 3), 2);
            Assert.AreEqual(exp4, r4, 0.0001, "При a=0 результат = cos²(x³-b)");
            Assert.IsTrue(r4 >= 0 && r4 <= 1, "cos² всегда в [0,1]");

            // Тест 5: отрицательный x — a=1, x=-1, b=0
            // y = 1*(-1) + cos²(-1) = -1 + cos²(-1)
            double r5 = Formuler.Formula3(1, -1, 0);
            double exp5 = -1.0 + Math.Pow(Math.Cos(-1), 2);
            Assert.AreEqual(exp5, r5, 0.0001, "a=1, x=-1, b=0");
        }
    }
}
