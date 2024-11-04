using System;
using System.Text;

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
                if (message != string.Empty)
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
            /// <param name="foundation"> Основа слова (всё, кроме окончания). </param>
            /// <param name="additionOne"> Окончание слова, которое будет использовано, когда число равно 0 или больше 4. </param>
            /// <param name="additionTwo"> Окончание слова, которое будет использовано, когда число равно 1. </param>
            /// <param name="additionThree"> Окончание слова, которое будет использовано, когда число равно 2, 3 или 4. </param>
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
                return Console.ReadLine() ?? string.Empty;
            }

            /// <summary> Считывает пользовательский ввод и преобразует его в число int. </summary>
            /// <returns> Удачное преобразование к числу int. </returns>
            public static int ReadIntNumberFromUserInput()
            {
                int number;
                bool isSuitableValue = int.TryParse(RequestForUserInput("Введите число int: ", ConsoleColor.Yellow), out number);
                if (!isSuitableValue)
                {
                    throw new InvalidCastException("Введённые данные не могут быть преобразованы в ожидаемый тип!");
                }
                return number;
            }
        }
    }
}