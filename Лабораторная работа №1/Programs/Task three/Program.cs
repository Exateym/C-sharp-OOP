using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_three
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Double a = 1000, b = 0.0001;

            Double resultDouble = (Math.Pow((a + b), 2) - (Math.Pow(a, 2) + 2 * a * b)) / Math.Pow(b, 2);
            Console.WriteLine($"Результат вычислений точности double: {resultDouble}");

            float resultFloat = (float)resultDouble;
            Console.WriteLine($"Результат вычислений точности float: {resultFloat}");

            Console.WriteLine("\nНажмите любую клавишу, чтобы закрыть консоль.");
            Console.ReadKey();
        }
    }
}
