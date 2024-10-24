using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyArrays;

namespace Matrix
{
    internal class Program
    {
        static Random randomizer = new Random();

        /// <summary> Настраивает окно консоли программы. </summary>
        static void ConfigureProgramConsole()
        {
            Console.Title = "Работа с матрицей int";
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

        static MyOneDimensionalArray<int> CreateRandomData(int arrayLength)
        {
            int[] data = new int[arrayLength];
            for (int index = 0; index < arrayLength; index++)
            {
                int newNumber = randomizer.Next(10); // Используем уже инициализированный randomizer
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

        static MyMatrix<int> GetRandomMatrix()
        {
            int arrayLength = randomizer.Next(3, 17);
            int quantityOfRows = randomizer.Next(3, 17);
            MyMatrix<int> matrix = new MyMatrix<int>();
            for (int i = 0; i < quantityOfRows; i++)
            {
                matrix.AddRowToEnd(CreateRandomData(arrayLength));
            }
            return matrix;
        }

        static void PrintMatrix(in MyMatrix<int> matrix)
        {
            if (matrix.GetQuantityOfRows() == 0 || matrix.GetQuantityOfColumns() == 0)
            {
                Console.WriteLine("Матрица пуста.");
                return;
            }

            int quantity = matrix.GetQuantityOfCells();
            Console.WriteLine($"Матрица содержит {quantity} {MatchingWordElementWithNumeral(quantity)}:");

            int rows = matrix.GetQuantityOfRows();
            int columns = matrix.GetQuantityOfColumns();

            // Массив для хранения максимальной длины строкового представления каждого столбца
            int[] columnWidths = new int[columns];

            // Определение максимальной длины для каждого столбца
            for (int col = 0; col < columns; col++)
            {
                int maxWidth = 0;
                for (int row = 0; row < rows; row++)
                {
                    string elementString = matrix[row, col].ToString();
                    if (elementString.Length > maxWidth)
                    {
                        maxWidth = elementString.Length;
                    }
                }
                columnWidths[col] = maxWidth;
            }

            // Вывод матрицы с учётом выравнивания столбцов
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    string elementString = matrix[row, col].ToString();
                    string completedString = CompleteString(elementString, columnWidths[col]);
                    Console.Write(completedString + " ");
                }
                Console.WriteLine(); // Переход на следующую строку
            }
        }

        /// <summary>
        /// Метод для добавления недостающих пробелов справа и слева для выравнивания.
        /// </summary>
        /// <param name="stringValue">Строковое представление элемента.</param>
        /// <param name="symbolsAmount">Желаемая общая длина строки.</param>
        /// <returns>Строка с добавленными пробелами.</returns>
        static string CompleteString(string stringValue, int symbolsAmount)
        {
            if (stringValue.Length < symbolsAmount)
            {
                int lengthDifference = symbolsAmount - stringValue.Length;
                // Добавление недостающих пробелов справа и слева
                while (lengthDifference > 0)
                {
                    if (lengthDifference % 2 == 1)
                    {
                        stringValue = ' ' + stringValue;
                    }
                    else
                    {
                        stringValue += ' ';
                    }
                    lengthDifference--;
                }
            }
            return stringValue;
        }

        static MyOneDimensionalArray<int> InputArrayThroughConsole(int arrayLength)
        {
            if (arrayLength == 0)
            {
                Console.WriteLine("Запрос ввода длины нового массива.");
                arrayLength = ReadIntNumberFromUserInput();
                if (arrayLength <= 0)
                {
                    throw new Exception("Пожалуйста, укажите корректную длину для массива, чтобы можно было в него добавить хоть что-то!");
                }
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

        static void Main(string[] args)
        {
            ConfigureProgramConsole();
            // Создаётся пустая матрица, с которой можно в дальнейшем работать.
            MyMatrix<int> matrix = new MyMatrix<int>();
        UserInterface:
            try
            {
                bool continueRunningProgram = true;
                while (continueRunningProgram)
                {
                    Console.WriteLine("1. Завершить работу консольного приложения.");
                    Console.WriteLine("2. Напечатать матрицу в консоль.");
                    Console.WriteLine("3. Сгенерировать новую случайную матрицу.");
                    Console.WriteLine("4. Добавить новую строку в конец матрицы.");
                    Console.WriteLine("5. Вставить новую строку по индексу уже существующей.");
                    Console.WriteLine("6. Удалить строку по индексу.");
                    Console.WriteLine("7. Сделать матрицу пустой.");
                    Console.WriteLine("8. Добавить новый столбец в конец матрицы.");
                    Console.WriteLine("9. Вставить новый столбец по индексу уже существующего.");
                    Console.WriteLine("10. Удалить столбец по индексу.");

                    Console.Write("Введите кодовое слово опции работы с программой: ");
                    string codeWord = Console.ReadLine();
                    int index, quantity = matrix.GetQuantityOfCells();
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
                            PrintMatrix(matrix);
                            break;
                        case "3":
                            matrix = GetRandomMatrix();
                            Console.WriteLine("Сгенерирована новая матрица.");
                            PrintMatrix(matrix);
                            break;
                        case "4":
                            Console.WriteLine("Матрица на данный момент времени:");
                            PrintMatrix(matrix);
                            myArray = InputArrayThroughConsole(matrix.GetQuantityOfColumns());
                            matrix.AddRowToEnd(myArray);
                            Console.WriteLine("Успешно добавлена новая строка в конец матрицы.");
                            Console.WriteLine("Матрица на данный момент времени:");
                            PrintMatrix(matrix);
                            break;
                        case "5":
                            if (quantity == 0)
                            {
                                Console.WriteLine("Матрица не содержит ни одного элемента.");
                            }
                            else
                            {
                                Console.WriteLine("Матрица на данный момент времени:");
                                PrintMatrix(matrix);
                                Console.WriteLine("Запрос индекса уже существующей строки.");
                                index = ReadIntNumberFromUserInput();
                                myArray = InputArrayThroughConsole(matrix.GetQuantityOfColumns());
                                matrix.InsertRow(index, myArray);
                                Console.WriteLine("Новая строка успешно вставлена по индексу в матрицу.");
                                Console.WriteLine("Матрица на данный момент времени:");
                                PrintMatrix(matrix);
                            }
                            break;
                        case "6":
                            if (quantity == 0)
                            {
                                Console.WriteLine("Матрица не содержит ни одного элемента.");
                            }
                            else
                            {
                                Console.WriteLine("Матрица на данный момент времени:");
                                PrintMatrix(matrix);
                                Console.WriteLine("Запрос индекса уже существующей строки.");
                                index = ReadIntNumberFromUserInput();
                                matrix.RemoveRow(index);
                                Console.WriteLine("Строка под указанным индексом успешно удалена из матрицы.");
                                Console.WriteLine("Матрица на данный момент времени:");
                                PrintMatrix(matrix);
                            }
                            break;
                        case "7":
                            matrix.MakeEmpty();
                            Console.WriteLine("Матрица была успешно очищена до пустой.");
                            break;
                        case "8":
                            if (quantity == 0)
                            {
                                Console.WriteLine("Невозможно добавить столбец в пустую матрицу. Добавьте хотя бы одну строку.");
                            }
                            else
                            {
                                Console.WriteLine("Матрица на данный момент времени:");
                                PrintMatrix(matrix);
                                myArray = InputArrayThroughConsole(matrix.GetQuantityOfRows());
                                matrix.AddColumnToEnd(myArray);
                                Console.WriteLine("Успешно добавлен новый столбец в конец матрицы.");
                                Console.WriteLine("Матрица на данный момент времени:");
                                PrintMatrix(matrix);
                            }
                            break;
                        case "9":
                            if (quantity == 0)
                            {
                                Console.WriteLine("Матрица не содержит ни одного элемента.");
                            }
                            else
                            {
                                Console.WriteLine("Матрица на данный момент времени:");
                                PrintMatrix(matrix);
                                Console.WriteLine("Запрос индекса уже существующего столбца.");
                                index = ReadIntNumberFromUserInput();
                                myArray = InputArrayThroughConsole(matrix.GetQuantityOfRows());
                                matrix.InsertColumn(index, myArray);
                                Console.WriteLine("Новый столбец успешно вставлен по индексу в матрицу.");
                                Console.WriteLine("Матрица на данный момент времени:");
                                PrintMatrix(matrix);
                            }
                            break;
                        case "10":
                            if (quantity == 0)
                            {
                                Console.WriteLine("Матрица не содержит ни одного элемента.");
                            }
                            else
                            {
                                Console.WriteLine("Матрица на данный момент времени:");
                                PrintMatrix(matrix);
                                Console.WriteLine("Запрос индекса уже существующего столбца.");
                                index = ReadIntNumberFromUserInput();
                                matrix.RemoveColumn(index);
                                Console.WriteLine("Столбец под указанным индексом успешно удален из матрицы.");
                                Console.WriteLine("Матрица на данный момент времени:");
                                PrintMatrix(matrix);
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
