using System;
using MyArrays;

namespace RaggedArray
{
    internal class Program
    {
        static Random randomizer = new Random();

        static void ConfigureProgramConsole()
        {
            Console.Title = "Работа с рваным массивом int";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.Clear();
        }

        static void SetPause()
        {
            Console.Write("\nПоставлена пауза. Нажмите любую клавишу, чтобы продолжить.");
            Console.ReadKey();
            Console.Clear();
        }

        static void PrintErrorIntoConsole(string errorContent)
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorContent);
            Console.ForegroundColor = foregroundColor;
        }

        static int ReadIntNumberFromUserInput()
        {
            Console.Write("Введите число int: ");
            int number;
            bool isSuitableValue = int.TryParse(Console.ReadLine(), out number);
            if (!isSuitableValue)
            {
                throw new Exception("Введённые данные не могут быть преобразованы в ожидаемый тип!");
            }
            return number;
        }

        static MyOneDimensionalArray<int> CreateRandomData(int arrayLength)
        {
            int[] data = new int[arrayLength];
            for (int index = 0; index < arrayLength; index++)
            {
                int newNumber = randomizer.Next(10);
                if (newNumber != 0)
                {
                    bool isNegativeNumber = randomizer.Next(2) == 0;
                    if (isNegativeNumber)
                    {
                        newNumber = -newNumber;
                    }
                }
                data[index] = newNumber;
            }
            return new MyOneDimensionalArray<int>(data);
        }

        static MyRaggedArray<int> GetRandomRaggedArray()
        {
            int numberOfRows = randomizer.Next(3, 17);
            MyRaggedArray<int> raggedArray = new MyRaggedArray<int>();
            for (int i = 0; i < numberOfRows; i++)
            {
                int rowLength = randomizer.Next(3, 17);
                raggedArray.AddRowToEnd(CreateRandomData(rowLength));
            }
            return raggedArray;
        }

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

        static void PrintRaggedArray(in MyRaggedArray<int> raggedArray)
        {
            int quantity = raggedArray.CountElements();
            if (quantity == 0)
            {
                Console.WriteLine("Рваный массив не содержит ни одного элемента.");
                return;
            }
            Console.WriteLine($"Рваный массив содержит {quantity} {MatchingWordElementWithNumeral(quantity)}:");
            for (int rowIndex = 0; rowIndex < raggedArray.CountRows(); rowIndex++)
            {
                PrintArrayDataIntoConsole(raggedArray.GetRow(rowIndex));
            }
        }

        static MyOneDimensionalArray<int> InputArrayThroughConsole()
        {
            Console.WriteLine("Запрос ввода длины нового массива.");
            int arrayLength = ReadIntNumberFromUserInput();
            if (arrayLength <= 0)
            {
                throw new Exception("Пожалуйста, укажите корректную длину для массива, чтобы можно было в него добавить хоть что-то!");
            }
            int[] numbers = new int[arrayLength];
            for (int index = 0; index < arrayLength; index++)
            {
                Console.WriteLine($"Запрос числа для массива под индексом {index}.");
                numbers[index] = ReadIntNumberFromUserInput();
            }
            MyOneDimensionalArray<int> result = new MyOneDimensionalArray<int>(numbers);
            return result;
        }

        static int GetIndexOfShortestRow(MyRaggedArray<int> raggedArray)
        {
            if (raggedArray.CountRows() == 0)
            {
                throw new Exception("Массив пуст!");
            }

            int indexOfShortestRow = 0;
            int minLength = raggedArray.GetRow(0).GetLength();

            for (int rowIndex = 1; rowIndex < raggedArray.CountRows(); rowIndex++)
            {
                int currentRowLength = raggedArray.GetRow(rowIndex).GetLength();
                if (currentRowLength < minLength)
                {
                    minLength = currentRowLength;
                    indexOfShortestRow = rowIndex;
                }
            }

            return indexOfShortestRow;
        }

        static void Main(string[] args)
        {
            ConfigureProgramConsole();
            MyRaggedArray<int> raggedArray = new MyRaggedArray<int>();
        UserInterface:
            try
            {
                bool continueRunningProgram = true;
                while (continueRunningProgram)
                {
                    Console.WriteLine("1. Завершить работу консольного приложения.");
                    Console.WriteLine("2. Узнать информацию о рваном массиве.");
                    Console.WriteLine("3. Сгенерировать новый случайный рваный массив.");
                    Console.WriteLine("4. Добавить новую строку в конец рваного массива.");
                    Console.WriteLine("5. Вставить новую строку по индексу уже существующей.");
                    Console.WriteLine("6. Удалить строку по индексу.");
                    Console.WriteLine("7. Сделать рваный массив пустым.");
                    Console.WriteLine("8. Удалить самую короткую строку.");
                    Console.Write("Введите кодовое слово опции работы с программой: ");
                    string codeWord = Console.ReadLine();
                    int index, quantity = raggedArray.CountElements();
                    MyOneDimensionalArray<int> myArray;
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
                            PrintRaggedArray(raggedArray);
                            break;
                        case "3":
                            raggedArray = GetRandomRaggedArray();
                            Console.WriteLine("Сгенерирована новый рваный массив.");
                            PrintRaggedArray(raggedArray);
                            break;
                        case "4":
                            Console.WriteLine("Рваный массив на данный момент времени:");
                            PrintRaggedArray(raggedArray);
                            myArray = InputArrayThroughConsole();
                            raggedArray.AddRowToEnd(myArray);
                            Console.WriteLine("Успешно добавлена новая строка в конец матрицы.");
                            Console.WriteLine("Рваный массив на данный момент времени:");
                            PrintRaggedArray(raggedArray);
                            break;
                        case "5":
                            if (quantity == 0)
                            {
                                Console.WriteLine("Рваный массив не содержит ни одного элемента.");
                            }
                            else
                            {
                                Console.WriteLine("Рваный массив на данный момент времени:");
                                PrintRaggedArray(raggedArray);
                                Console.WriteLine("Запрос индекса уже существующей строки.");
                                index = ReadIntNumberFromUserInput();
                                myArray = InputArrayThroughConsole();
                                raggedArray.InsertRow(index, myArray);
                                Console.WriteLine("Новая строка успешно вставлена по индексу в рваный массив.");
                                Console.WriteLine("Рваный массив на данный момент времени:");
                                PrintRaggedArray(raggedArray);
                            }
                            break;
                        case "6":
                            if (quantity == 0)
                            {
                                Console.WriteLine("Рваный массив не содержит ни одного элемента.");
                            }
                            else
                            {
                                Console.WriteLine("Рваный массив на данный момент времени:");
                                PrintRaggedArray(raggedArray);
                                Console.WriteLine("Запрос индекса уже существующей строки.");
                                index = ReadIntNumberFromUserInput();
                                raggedArray.RemoveRow(index);
                                Console.WriteLine("Строка под указанным индексом успешно удалена из рваного массива.");
                                Console.WriteLine("Рваный массив на данный момент времени:");
                                PrintRaggedArray(raggedArray);
                            }
                            break;
                        case "7":
                            raggedArray.MakeEmpty();
                            Console.WriteLine("Рваный массив был успешно очищен до пустого.");
                            break;
                        case "8":
                            if (quantity == 0)
                            {
                                Console.WriteLine("Рваный массив не содержит ни одного элемента.");
                            }
                            else
                            {
                                Console.WriteLine("Рваный массив на данный момент времени:");
                                PrintRaggedArray(raggedArray);
                                index = GetIndexOfShortestRow(raggedArray);
                                raggedArray.RemoveRow(index);
                                Console.WriteLine($"Была удалена строка с индексом {index}.");
                                Console.WriteLine("Рваный массив на данный момент времени:");
                                PrintRaggedArray(raggedArray);
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
