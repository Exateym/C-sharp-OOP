using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_two
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String messageConversionError = "\nНевозможно преобразовать входные данные в указанный тип.";
            String messageCloseConsole = "Нажмите любую клавишу, чтобы закрыть консоль.";

            Console.WriteLine("Область на плоскости задана неравенствами:");
            Console.WriteLine("1. y <= 0;");
            Console.WriteLine("2. y >= -2;");
            Console.WriteLine("3. x >= -7;");
            Console.WriteLine("4. x <= 0.");

            Console.WriteLine("\nВведите координаты точки, чтобы определить её принадлежность плоскости.");

            Console.Write("Введите x типа Double: ");
            Double x;
            Boolean isSuitableValue = Double.TryParse(Console.ReadLine(), out x);
            if (!isSuitableValue)
            {
                Console.WriteLine(messageConversionError);
                Console.WriteLine(messageCloseConsole);
                Console.ReadKey();
                return;
            }

            Console.Write("Введите y типа Double: ");
            Double y;
            isSuitableValue = Double.TryParse(Console.ReadLine(), out y);
            if (!isSuitableValue)
            {
                Console.WriteLine(messageConversionError);
                Console.WriteLine(messageCloseConsole);
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nВыполнения условий:");
            bool conditionOne = y <= 0;
            Console.WriteLine($"1. y <= 0 = {conditionOne}");
            bool conditionTwo = y >= -2;
            Console.WriteLine($"2. y >= -2 = {conditionTwo}");
            bool conditionThree = x >= -7;
            Console.WriteLine($"3. x >= -7 = {conditionThree}");
            bool conditionFour = x <= 0;
            Console.WriteLine($"4. x <= 0 = {conditionFour}");

            bool isBelong = conditionOne && conditionTwo && conditionThree && conditionFour;
            Console.WriteLine($"\nОтвет: {isBelong}");
            
            Console.WriteLine(messageCloseConsole);
            Console.ReadKey();
        }
    }
}
