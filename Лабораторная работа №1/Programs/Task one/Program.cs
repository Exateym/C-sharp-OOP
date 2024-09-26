using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_one
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String messageConversionError = "\nНевозможно преобразовать входные данные в указанный тип.";
            String messageCloseConsole = "Нажмите любую клавишу, чтобы закрыть консоль.";
            
            Console.Write("Введите число m типа Int32: ");
            Int32 m;
            Boolean isSuitableValue = Int32.TryParse(Console.ReadLine(), out m);
            if (!isSuitableValue)
            {
                Console.WriteLine(messageConversionError);
                Console.WriteLine(messageCloseConsole);
                Console.ReadKey();
                return;
            }

            Console.Write("Введите число n типа Int32: ");
            Int32 n;
            isSuitableValue = Int32.TryParse(Console.ReadLine(), out n);
            if (!isSuitableValue)
            {
                Console.WriteLine(messageConversionError);
                Console.WriteLine(messageCloseConsole);
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nВыполнение операций над m и n:");
            Console.WriteLine($"1. ++n * ++m = {++n * ++m}");
            Console.WriteLine($"Новые значения: m = {m}, n = {n}");
            Console.WriteLine($"2. m++ < n = {m++ < n}");
            Console.WriteLine($"Новые значения: m = {m}, n = {n}");
            Console.WriteLine($"3. n++ > m = {n++ > m}");
            Console.WriteLine($"Новые значения: m = {m}, n = {n}");

            Console.Write("\nВведите число x типа Double: ");
            Double x;
            isSuitableValue = Double.TryParse(Console.ReadLine(), out x);
            if (!isSuitableValue)
            {
                Console.WriteLine(messageConversionError);
                Console.WriteLine(messageCloseConsole);
                Console.ReadKey();
                return;
            }
            if (x == -1 || x == 0 || x == 1)
            {
                Console.WriteLine("\nДанное число не входит в ОДЗ.");
                Console.WriteLine(messageCloseConsole);
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nВычисление значения выражения:");
            Console.WriteLine($"4. x + 1 / (x^3 - x) - 2 = {x + 1 / (Math.Pow(x, 3) - x) - 2}");
            Console.WriteLine(messageCloseConsole);
            Console.ReadKey();
        }
    }
}
