using System;
using System.IO;
using System.Text;
using MyGenericCollections.MyArray;

namespace MyProgramTemplates
{
    namespace MyConsoleApplication
    {
        /// <summary> Реализует базовые методы для удобной разработки консольного приложения. </summary>
        public static class MyConsoleApplication
        {
            /// <summary> Настраивает окно консоли программы. </summary>
            /// <remarks>
            /// Меняет название окна консоли по умолчанию, задаёт цветовую схему и меняет кодировку на UTF-16,
            /// чтобы не было проблем со стандартным строковым типом данных. Всё, кроме кодировки можно инициализировать своими значениями.
            /// </remarks>
            /// <param name="consoleTitle"> Необязательный параметр. Название окна консоли. </param>
            /// <param name="backgroundColor"> Необязательный параметр. Цвет фона консоли. </param>
            /// <param name="foregroundColor"> Необязательный параметр. Цвет текста консоли. </param>
            public static void ConfigureProgramConsole(
                string consoleTitle = "Консольное приложение",
                ConsoleColor backgroundColor = ConsoleColor.Black,
                ConsoleColor foregroundColor = ConsoleColor.White)
            {
                Console.Title = consoleTitle;
                Console.BackgroundColor = backgroundColor;
                Console.ForegroundColor = foregroundColor;
                Console.InputEncoding = Encoding.Unicode;
                Console.OutputEncoding = Encoding.Unicode;
                Console.Clear();
            }

            /// <summary> Выводит сообщение в консоль. </summary>
            /// <param name="message"> Текст сообщения. </param>
            /// <param name="textColor"> Цвет текста. Можно передавать значение Console.ForegroundColor для сообщений по умолчанию. </param>
            public static void PrintMessageIntoConsole(string message, ConsoleColor textColor)
            {
                if (!string.IsNullOrEmpty(message) && !string.IsNullOrWhiteSpace(message))
                {
                    ConsoleColor foregroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = textColor;
                    Console.Write(message);
                    Console.ForegroundColor = foregroundColor;
                }
            }

            /// <summary> Даёт время пользователю прочитать отклик программы. </summary>
            public static void SetPause()
            {
                PrintMessageIntoConsole("Поставлена пауза. Нажмите любую клавишу, чтобы продолжить.", ConsoleColor.Yellow);
                Console.ReadKey();
            }

            /// <summary> Используется как служебная функция для MatchingWordWithNumeral. </summary>
            private static int SimplificationNumeral(int number)
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

            /// <summary> Спрягает существительное с числительным. </summary>
            /// <param name="number"> Число, с которым будет спрягаться существительное. </param>
            /// <param name="foundation"> Неизменяемая часть слова. </param>
            /// <param name="additionOne"> Продолжение слова, которое будет использовано, когда число равно 0 или больше 4. </param>
            /// <param name="additionTwo"> Продолжение слова, которое будет использовано, когда число равно 1. </param>
            /// <param name="additionThree"> Продолжение слова, которое будет использовано, когда число равно 2, 3 или 4. </param>
            public static string MatchingWordWithNumeral(int number, string foundation, string additionOne, string additionTwo, string additionThree)
            {
                number = SimplificationNumeral(number);
                if (number == 0 || number > 4)
                {
                    return foundation + additionOne;
                }
                if (number == 1)
                {
                    return foundation + additionTwo;
                }
                return foundation + additionThree;
            }

            /// <summary> Получает данные от пользователя и записывает их в строку. </summary>
            /// <param name="requestMessage"> Запрос пользователю. </param>
            /// <param name="textColor"> Цвет текста. </param>
            /// <returns> Строковые данные, введённые пользователем. </returns>
            public static string RequestForUserInput(string requestMessage, ConsoleColor textColor)
            {
                PrintMessageIntoConsole(requestMessage, textColor);
                string userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput))
                {
                    throw new Exception("Ввод не должен быть пустым или состоять только из символов-разделителей!");
                }
                return userInput;
            }

            /// <summary> Считывает пользовательский ввод и преобразует его в число int. </summary>
            /// <returns> Удачное преобразование к числу int. </returns>
            public static int ReadIntNumberFromUserInput(string requestMessage = "Введите число int: ")
            {
                int number;
                bool isSuitableValue = int.TryParse(RequestForUserInput(requestMessage, ConsoleColor.Yellow), out number);
                if (!isSuitableValue)
                {
                    throw new InvalidCastException("Введённые данные не могут быть преобразованы в ожидаемый тип!");
                }
                return number;
            }

            public static MyArray<string> RequestForCreateMyArray()
            {
                PrintMessageIntoConsole("Инициализация нового массива MyArray<string>.\n", Console.ForegroundColor);
                MyArray<string> myArray = new MyArray<string>();
                int elementsQuantity = ReadIntNumberFromUserInput("Введите количество элементов: ");
                if (elementsQuantity < 0)
                {
                    throw new Exception("Нельзя указать количество элементов отрицательным числом!");
                }
                if (elementsQuantity == 0)
                {
                    PrintMessageIntoConsole("Успешно создан пустой массив.\n", ConsoleColor.Green);
                    return myArray;
                }
                PrintMessageIntoConsole("Процедура заполнения значений массива.\n", Console.ForegroundColor);
                for (int elementNumber = 1; elementNumber <= elementsQuantity; elementNumber++)
                {
                    string userInput = RequestForUserInput($"Введите элемент номер {elementNumber}: ", ConsoleColor.Yellow);
                    myArray.AddElementToEnd(userInput);
                }
                string wordElement = MatchingWordWithNumeral(myArray.Length, "элемент", "ов", "", "а");
                PrintMessageIntoConsole($"Успешно создан новый массив, который содержит {myArray.Length} {wordElement}.\n", ConsoleColor.Green);
                PrintMessageIntoConsole(myArray.ToString() + '\n', Console.ForegroundColor);
                return myArray;
            }

            public static void TryToCreateDirectory(string directoryPath)
            {
                string fullDirectoryPath = Path.GetFullPath(directoryPath);
                string rootDirectoryPath = Path.GetDirectoryName(fullDirectoryPath);
                PrintMessageIntoConsole($"Запрос создания каталога каталога по пути \"{rootDirectoryPath}\".\n", Console.ForegroundColor);
                if (Directory.Exists(fullDirectoryPath))
                {
                    throw new Exception("Указанная директория уже существует!");
                }
                Directory.CreateDirectory(fullDirectoryPath);
                PrintMessageIntoConsole("Новая директория успешно создана.\n", ConsoleColor.Green);
            }
        }
    }
}