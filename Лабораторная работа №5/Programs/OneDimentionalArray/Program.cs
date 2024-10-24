using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Resources;
using MyArrays;
using System.Security.Cryptography;

namespace OneDimentionalArray
{
    internal class Program
    {
        /// <summary> Настраивает окно консоли программы. </summary>
        static void ConfigureProgramConsole()
        {
            Console.Title = "Работа с одномерным массивом int";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.InputEncoding = Encoding.Unicode;
            Console.Clear();
        }

        /// <summary> Даёт время пользователю прочитать отклик программы. </summary>
        static void SetPause()
        {
            Console.Write("\nПоставлена пауза. Нажмите любую клавишу, чтобы продолжить.");
            Console.ReadKey();
            Console.Clear();
        }

        static MyOneDimensionalArray<int> CreateRandomData(int arrayLength)
        {
            Random randomizer = new Random();
            int[] data = new int[arrayLength];
            for (int index = 0; index < arrayLength; index++)
            {
                int newNumber = randomizer.Next(10);
                if (newNumber != 0)
                {
                    bool isNegativeNumber = false;
                    if (randomizer.Next(2) == 0)
                    {
                        isNegativeNumber = true;
                    }
                    if (isNegativeNumber)
                    {
                        newNumber = -newNumber;
                    }
                }
                data[index] = newNumber;
            }
            return new MyOneDimensionalArray<int>(data);
        }

        static MyOneDimensionalArray<int> GetRandomArray()
        {
            Random randomizer = new Random();
            int arrayLength = randomizer.Next(3, 17);
            MyOneDimensionalArray<int> myArray = CreateRandomData(arrayLength);
            return myArray;
        }

        /// <summary> Используется как служебная часть для методов подбора спряжения существительного к соответствующему числительному. </summary>
        static int SimplificationNumeral(int number)
        {
            if (number > 19 && number < 100)
                return number % 10;
            if (number > 99)
            {
                number = number % 100;
                if (number > 19 && number < 100)
                    return number % 10;
            }
            return number;
        }


        /// <summary> Спрягает слово "элемент". В качестве параметра берётся числительное. </summary>
        static string MatchingWordElementWithNumeral(int number)
        {
            number = SimplificationNumeral(number);
            string foundation = "элемент";
            if (number == 0 || number > 4)
            {
                return foundation + "ов";
            }
            if (number == 1)
            {
                return foundation;
            }
            return foundation + "а";
        }

        static void PrintArrayDataIntoConsole(in MyOneDimensionalArray<int> numbers)
        {
            int quantity = numbers.GetLength();
            if (quantity == 0)
            {
                Console.WriteLine("Массив не содержит ни одного элемента.");
                return;
            }
            Console.WriteLine($"Массив содержит {quantity} {MatchingWordElementWithNumeral(quantity)}:");
            string result = "[";
            int index = 0;
            while (index < quantity)
            {
                result += numbers[index];
                index++;
                if (index != quantity)
                {
                    result += ", ";
                }
            }
            result += "]";
            Console.WriteLine(result);
        }

        static int ReadIntNumberFromUserInput()
        {
            Console.Write("Введите число int: ");
            int number;
            bool isSuitableValue = int.TryParse(Console.ReadLine(), out number);
            if (!isSuitableValue) {
                throw new Exception("Введённые данные не могут быть преобразованы в ожидаемый тип!");
            }
            return number;
        }

        /// <summary> Просматривает массив слева-направо в поиске отрицательного числа. </summary>
        /// <returns> Если -1, то отрицательных чисел не найдено, иначе индекс такого числа. </returns>
        static int FindIndexOfFirstNegativeNumber(in MyOneDimensionalArray<int> numbers)
        {
            for (int index = 0; index < numbers.GetLength(); index++)
            {
                if (numbers[index] < 0)
                {
                    return index;
                }
            }
            return -1;
        }

        static void PrintErrorIntoConsole(string errorContent)
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorContent);
            Console.ForegroundColor = foregroundColor;
        }
        static void Main(string[] args)
        {
            ConfigureProgramConsole();
            // Создаётся пустой массив, с которым можно в дальнейшем работать.
            MyOneDimensionalArray<int> numbers = new MyOneDimensionalArray<int>();
        UserInterface:
            try
            {
                bool continueRunningProgram = true;
                while (continueRunningProgram)
                {
                    Console.WriteLine("1. Завершить работу консольного приложения.");
                    Console.WriteLine("2. Узнать информацию о массиве.");
                    Console.WriteLine("3. Сгенерировать новый случайный массив.");
                    Console.WriteLine("4. Добавить новый элемент в конец массива.");
                    Console.WriteLine("5. Вставить новый элемент по индексу уже существующего.");
                    Console.WriteLine("6. Удалить элемент по индексу.");
                    Console.WriteLine("7. Сделать массив пустым.");
                    Console.WriteLine("8. Удалить первый отрицательный элемент.");
                    Console.Write("Введите кодовое слово опции работы с программой: ");
                    string codeWord = Console.ReadLine();
                    int index, number, quantity = numbers.GetLength();
                    Console.WriteLine();
                    switch (codeWord)
                    {
                        case "":
                            PrintErrorIntoConsole("Ошибка пустого ввода!");
                            break;
                        case "1":
                            continueRunningProgram = false;
                            Console.WriteLine("Работа с программой завершена.");
                            break;
                        case "2":
                            PrintArrayDataIntoConsole(numbers);
                            break;
                        case "3":
                            numbers = GetRandomArray();
                            Console.WriteLine("Сгенерирован новый массив.");
                            PrintArrayDataIntoConsole(numbers);
                            break;
                        case "4":
                            Console.WriteLine("Массив на данный момент времени:");
                            PrintArrayDataIntoConsole(numbers);
                            Console.WriteLine("Запрос значения числа.");
                            number = ReadIntNumberFromUserInput();
                            numbers.AddElementToEnd(number);
                            Console.WriteLine("Успешно добавлен новый элемент в конец массива.");
                            Console.WriteLine("Массив на данный момент времени:");
                            PrintArrayDataIntoConsole(numbers);
                            break;
                        case "5":
                            if (quantity == 0)
                            {
                                Console.WriteLine("Массив не содержит ни одного элемента.");
                            }
                            else
                            {
                                Console.WriteLine("Массив на данный момент времени:");
                                PrintArrayDataIntoConsole(numbers);
                                Console.WriteLine("Запрос индекса уже существующего элемента массива.");
                                index = ReadIntNumberFromUserInput();
                                Console.WriteLine("Запрос значения числа.");
                                number = ReadIntNumberFromUserInput();
                                numbers.InsertElement(index, number);
                                Console.WriteLine("Новый элемент успешно вставлен по индексу в массив.");
                                Console.WriteLine("Массив на данный момент времени:");
                                PrintArrayDataIntoConsole(numbers);
                            }
                            break;
                        case "6":
                            if (quantity == 0)
                            {
                                Console.WriteLine("Массив не содержит ни одного элемента.");
                            }
                            else
                            {
                                Console.WriteLine("Массив на данный момент времени:");
                                PrintArrayDataIntoConsole(numbers);
                                Console.WriteLine("Запрос индекса уже существующего элемента массива.");
                                index = ReadIntNumberFromUserInput();
                                numbers.RemoveElement(index);
                                Console.WriteLine("Элемент под указанным индексом удалён из массива успешно.");
                                Console.WriteLine("Массив на данный момент времени:");
                                PrintArrayDataIntoConsole(numbers);
                            }
                            break;
                        case "7":
                            numbers.MakeEmpty();
                            Console.WriteLine("Массив был успешно очищен до пустого.");
                            break;
                        case "8":
                            if (quantity == 0)
                            {
                                Console.WriteLine("Массив не содержит ни одного элемента.");
                            }
                            else
                            {
                                Console.WriteLine("Массив на данный момент времени:");
                                PrintArrayDataIntoConsole(numbers);
                                index = FindIndexOfFirstNegativeNumber(numbers);
                                if (index == -1)
                                {
                                    Console.WriteLine("Массив не содержит отрицательных чисел.");
                                }
                                else
                                {
                                    Console.WriteLine($"Было найдено число {numbers[index]} под элементом массива с индексом {index}.");
                                    numbers.RemoveElement(index);
                                    Console.WriteLine("Отрицательное число было успешно удалено.");
                                    Console.WriteLine("Массив на данный момент времени:");
                                    PrintArrayDataIntoConsole(numbers);
                                }
                            }
                            break;
                        default:
                            PrintErrorIntoConsole("В списке отсутствует вариант с указанным кодовым словом!");
                            break;
                    }
                    SetPause();
                }
                return;
            }
            catch (Exception error)
            {
                PrintErrorIntoConsole(error.Message);
                SetPause();
                goto UserInterface;
            }
        }
    }
}