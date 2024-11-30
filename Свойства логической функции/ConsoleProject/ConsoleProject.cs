using System;
using MyProgramTemplates.MyConsoleApplication;
using MySpecificLibraries.MyLogicalFunction;

namespace ConsoleProject
{
    internal class ConsoleProject
    {
        static void Main(string[] args)
        {
            try
            {
                MyConsoleApplication.ConfigureProgramConsole("Свойства логической функции");
                MyLogicalFunction myLogicalFunction = new MyLogicalFunction("a");
                MyConsoleApplication.PrintMessageIntoConsole($"Разрешённый алфавит символов: {myLogicalFunction.AllowedAlphabet}.\n", ConsoleColor.Blue);
                string formula = MyConsoleApplication.RequestForUserInput("Введите формулу функции: ", ConsoleColor.Yellow);
                Console.WriteLine();
                formula = formula.Replace(" ", string.Empty).Replace("\t", string.Empty).Replace("\n", string.Empty);
                myLogicalFunction.RewriteData(formula);
                MyConsoleApplication.PrintMessageIntoConsole("Новый экземпляр MyLogicalFunction успешно создан.\n", ConsoleColor.DarkGreen);
                MyConsoleApplication.PrintMessageIntoConsole($"Объект содержит в себе формулу: {myLogicalFunction.Formula}.\n", ConsoleColor.Green);
                MyConsoleApplication.PrintMessageIntoConsole($"Опознанные переменные: {myLogicalFunction.DetectedVariables.ToString()}.\n", ConsoleColor.Green);
                Console.WriteLine();
                MyConsoleApplication.PrintMessageIntoConsole($"Таблица истинности:\n", ConsoleColor.DarkBlue);
                string[] rows = myLogicalFunction.GetTruthRows();
                for (int index = 0; index < rows.Length; index++)
                {
                    string message = rows[index];
                    if (index != rows.Length - 1)
                    {
                        message += ';';
                    }
                    else
                    {
                        message += '.';
                    }
                    message += '\n';
                    MyConsoleApplication.PrintMessageIntoConsole(message, ConsoleColor.Blue);
                }
                Console.WriteLine();
                MyConsoleApplication.PrintMessageIntoConsole($"СДНФ: {myLogicalFunction.GetStringPDNF()}.\n", ConsoleColor.Cyan);
                MyConsoleApplication.PrintMessageIntoConsole($"СКНФ: {myLogicalFunction.GetStringPCNF()}.\n", ConsoleColor.Cyan);
                MyConsoleApplication.PrintMessageIntoConsole($"Первая МДНФ с наименьшим количеством импликант: {myLogicalFunction.GetStringFirstShortestMDNF()}.\n", ConsoleColor.Cyan);
            }
            catch (Exception exception)
            {
                MyConsoleApplication.PrintMessageIntoConsole("Обработана исключительная ситуация:\n", ConsoleColor.DarkRed);
                MyConsoleApplication.PrintMessageIntoConsole(exception.Message + '\n', ConsoleColor.Red);
            }
            Console.WriteLine();
            MyConsoleApplication.SetPause();
        }
    }
}
