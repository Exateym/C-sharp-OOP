using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_three
{
    internal class Program
    {
        Double calculateDoubleResult(Double a, Double b)
        {
            Double operationOne = a - b;
            Double operationTwo = Math.Pow(operationOne, 2);

            Double operationThree = Math.Pow(a, 2);
            Double operationFour = 2 * a * b;
            Double operationFive = operationThree - operationFour;

            Double numerator = operationTwo - operationFive;
            Double denominator = Math.Pow(b, 2);

            Double result = numerator / denominator;
            return result;
        }
        /* Уменьшение точности путём перехода от входных данных типа Double,
        к выходным типа float. Переход осуществляется насколько он возможен */
        float calculateFloatResult(Double a, Double b)
        {
            Double operationOne = a - b;
            float operationTwo = (float)Math.Pow(operationOne, 2);

            float operationThree = (float)Math.Pow(a, 2);
            float operationFour = (float)(2 * a * b);
            float operationFive = operationThree - operationFour;

            float numerator = operationTwo - operationFive;
            float denominator = (float)Math.Pow(b, 2);

            float result = numerator / denominator;
            return result;
        }
        static void Main(string[] args)
        {
            Double a = 1000, b = 0.0001;
            Program program = new Program();

            Double resultDouble = program.calculateDoubleResult(a, b);
            Console.WriteLine($"Результат вычислений точности Double: {resultDouble}");

            float resultFloat = program.calculateFloatResult(a, b);
            Console.WriteLine($"Результат вычислений точности float: {resultFloat}");

            Console.WriteLine("\nНажмите любую клавишу, чтобы закрыть консоль.");
            Console.ReadKey();
        }
    }
}