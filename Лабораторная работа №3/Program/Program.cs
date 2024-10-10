using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal static class Program
    {
        /// <summary> Вычисляет шаг для равномерного распределения элементов по указанному диапазону. </summary>
        /// <remarks>
        /// Сначала указывается левая граница диапазона, затем правая и только потом количество элементов.
        /// Обе границы должны входить в заданный диапазон.
        /// </remarks>
        /// <param name="left"> Начало диапазона. </param>
        /// <param name="right"> Конец диапазона. </param>
        /// <param name="quantity"> Количество элементов. </param>
        /// <returns> Шаг между элементами диапазона. </returns>
        static double CalculateStep(double left, double right, int quantity)
        {
            return (right - left) / quantity;
        }



        /// <summary> Вычисляет значение члена ряда по формуле общего члена. </summary>
        /// <param name="argument"> Аргумент для функций члена ряда. </param>
        /// <param name="elementOrder"> Порядковый номер члена ряда. </param>
        /// <returns> Значение члена ряда. </returns>
        static double CalculateSeriesTerm(double argument, int elementOrder)
        {
            return Math.Cos(elementOrder * argument) / elementOrder;
        }



        /// <summary> Вычисляет сумму для указанного количества членов ряда. </summary>
        /// <remarks> Чем больше будет указано членов ряда, тем точнее вычисление общей суммы ряда. </remarks>
        /// <param name="argument"> Аргумент для функций члена ряда. </param>
        /// <param name="quantity"> Заданное количество первых членов ряда. </param>
        /// <returns> Приближённая общая сумма ряда (с погрешностью). </returns>
        static double CalculateTremsSum(double argument, int quantity)
        {
            double result = 0;
            for (int elementOrder = 1; elementOrder <= quantity; elementOrder++)
            {
                result += CalculateSeriesTerm(argument, elementOrder);
            }
            return result;
        }



        /// <summary> Находит сумму ряда, используя заданную точность. </summary>
        /// <remarks>
        /// Вычисление происходит до тех пор, пока разница между
        /// двумя соседними членами ряда не будет меньше заданной точности.
        /// </remarks>
        /// <param name="argument"> Аргумент для функций члена ряда. </param>
        /// <param name="precision"> Заданная точность. </param>
        /// <returns> Приближённая общая сумма ряда (с погрешностью). </returns>
        static double CalculateNumericalSeriesSumUsingPrecision(double argument, double precision)
        {
            // Для старата берутся два первых члена ряда
            double previous = CalculateSeriesTerm(argument, 1);
            double current = CalculateSeriesTerm(argument, 2);

            double result = previous + current;

            /* Итерации происходят до тех пор, пока абсолютная разница между соседними членами ряда
            не будет меньше, чем заданная точность для приближённого вычисления суммы ряда */
            for (int elementOrder = 3; Math.Abs(current - previous) > precision; elementOrder++)
            {
                previous = current;
                current = CalculateSeriesTerm(argument, elementOrder);
                result += current;
            }
            return result;
        }



        /// <summary> Вычисление точного значения функции. </summary>
        /// <param name="argument"> Аргумент функции. </param>
        /// <returns> Значение функции (наиболее точная общая сумма ряда). </returns>
        static double Function(double argument)
        {
            return -Math.Log(Math.Abs(2 * Math.Sin(argument / 2)));
        }



        /// <summary> Выводит в консоль исходные и полученные значения. </summary>
        /// <param name="argument"> Аргумент функции. </param>
        /// <param name="arithmetic"> Значение, полученное после арифметического цикла для указанного количества элементов. </param>
        /// <param name="iterative"> Значение, полученное через итерационный цикл, выход из которого проверяется заданной точностью. </param>
        /// <param name="result"> Значение, вычисленное через математические функции. </param>
        static void PrintData(double argument, double arithmetic, double iterative, double result)
        {
            Console.WriteLine($"X = {argument}; SN = {arithmetic}; SE = {iterative}; Y = {result}.");
        }



        static void Main(string[] args)
        {
            Console.Title = "Вычисление функций с использованием их разложения в степенной ряд";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.InputEncoding = Encoding.Unicode;
            Console.Clear();

            // Границы диапазона
            double left = Math.PI / 5;
            double right = 9 * left;

            double step = CalculateStep(left, right, 10);
            double epsilon = Math.Pow(10, -4); // Заданная точность вычислений
            int termsQuantity = 40; // Заданное количество первых членов ряда

            // Внешний цикл по изменению аргумента
            for (double x = left; x <= right; x += step)
            {
                double y = Function(x);
                double resultSN = CalculateTremsSum(x, termsQuantity);
                double resultSE = CalculateNumericalSeriesSumUsingPrecision(x, epsilon);
                PrintData(x, resultSN, resultSE, y);
            }

            Console.Write("\nНажмите любую клавишу, чтобы закрыть консоль.");
            Console.ReadKey();
        }
    }
}