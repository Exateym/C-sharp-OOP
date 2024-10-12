using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FileComparer
{
    internal class Program
    {
        /// <summary> Настраивает окно консоли программы. </summary>
        static void ConfigureProgramConsole()
        {
            Console.Title = "Сравнить имена файлов по двум спискам";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.InputEncoding = Encoding.Unicode;
            Console.Clear();
        }
        
        
        
        /// <summary> Даёт время пользователю прочитать отклик программы. </summary>
        static void SetPause()
        {
            Console.Write("Поставлена пауза. Нажмите любую клавишу, чтобы продолжить.");
            Console.ReadKey();
            Console.Clear();
        }



        /// <summary>
        /// Возвращает список строк, содержащих названия файлов.
        /// Данные берутся из файла с текстовым содержимым по указанному пути.
        /// Предполагается, что названия записаны по одному в каждой строке.
        /// Данные текстового файла должны быть записаны в кодировке UTF-8.
        /// </summary>
        /// <remarks>
        /// В получившемся списке не может быть пустых строк.
        /// Для строки, в которой предполагается содержание названия файла, дополнительно идёт проверка и удаление лишних пробелов в начале и конце.
        /// В случае, когда список пуст, файл с текстом не содержит ни одного названия.
        /// Метод возвращает null, когда произошла ошибка при выполнении операций и было вызвано исключение.
        /// </remarks>
        static List<string> GetFileNamesFromTextFile(string pathToTextFile)
        {
            try
            {
                using (StreamReader reader = new StreamReader(pathToTextFile))
                {
                    List<string> linesFromTextFile = new List<string>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            linesFromTextFile.Add(line.Trim());
                        }
                    }
                    if (linesFromTextFile.Count == 0)
                    {
                        Console.WriteLine("Текстовый файл, где предполагается список названий, пуст.");
                    }
                    Console.WriteLine($"Успешно считано содержимое файла по пути '{pathToTextFile}'.");
                    return linesFromTextFile;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return null;
            }
        }



        /// <summary>
        /// Возвращает список строк, содержащих названия файлов из указанной директории.
        /// </summary>
        /// <remarks>
        /// В получившемся списке не может быть пустых строк.
        /// Метод возвращает null, когда произошла ошибка при выполнении операций и было вызвано исключение.
        /// </remarks>
        static List<string> GetFileNamesFromDirectory(string directoryPath)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Console.WriteLine($"Директория '{directoryPath}' не найдена!");
                    return null;
                }
                string[] files = Directory.GetFiles(directoryPath);
                if (files.Length == 0)
                {
                    Console.WriteLine($"В директории '{directoryPath}' нет файлов.");
                }
                Console.WriteLine($"Успешно получены данные о содержимом директории '{directoryPath}'.");
                return files.Select(Path.GetFileName).ToList();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return null;
            }
        }



        /// <summary> Записывает список строк в текстовый файл, перезаписывая его содержимое. </summary>
        /// <remarks> Если произошла ошибка во время записи, метод возвращает false. Иначе возвращает true. </remarks>
        static bool WriteListToTextFile(string pathToTextFile, List<string> lines)
        {
            try
            {
                if (!File.Exists(pathToTextFile))
                {
                    Console.WriteLine($"Будет создан новый текстовый файл.");
                }
                using (StreamWriter writer = new StreamWriter(pathToTextFile, false))
                {
                    foreach (string line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }
                Console.WriteLine($"Успешно перезаписано содержимое файла по пути '{pathToTextFile}'.");
                return true;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return false;
            }
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


        /// <summary> Спрягает слово "различие". В качестве параметра берётся числительное. </summary>
        static string MatchingWordDifferenceWithNumeral(int number)
        {
            number = SimplificationNumeral(number);
            string foundation = "различи";
            if (number == 0 || number > 4)
            {
                return foundation + "й";
            }
            if (number == 1)
            {
                return foundation + "е";
            }
            return foundation + "я";
        }



        /// <summary>
        /// Находит симметрическую разность списка-образца и сравниваемого списка.
        /// В результате даёт подробную информацию о том, чем отличается сравниваемый список от образца.
        /// </summary>
        static void CalculateDifferenceBetweenListsAndWriteResultIntoFile(List<string> sampleList, List<string> comparingList, string pathToTextFile)
        {
            List<string> result = new List<string>();
            // Поиск элементов, которых быть не должно в сравниваемом списке.
            List<string> unnecessaryItems = comparingList.Except(sampleList).ToList();
            // Поиск элементов, которых не хватает в сравниваемом списке.
            List<string> missingItems = sampleList.Except(comparingList).ToList();
            if (unnecessaryItems.Count == 0 && missingItems.Count == 0)
            {
                Console.WriteLine("Различий между списком-образцом и сравниваемым списком не найдено.");
            }
            else
            {
                foreach (string element in unnecessaryItems)
                {
                    result.Add($"УБРАТЬ {element}");
                }
                foreach (string element in missingItems)
                {
                    result.Add($"ДОБАВИТЬ {element}");
                }
                Console.WriteLine($"Было найдено {result.Count} {MatchingWordDifferenceWithNumeral(result.Count)} между списком-образцом и сравниваемым списком.");
            }
            Console.WriteLine("Подробный результат будет записан в файл.");
            WriteListToTextFile(pathToTextFile, result);
        }



        /// <summary> Создаёт хранилище для файлов пользователя (если его нет). </summary>
        static void CheckFolderForFiles(string pathToFolderForFiles)
        {
            if (!Directory.Exists(pathToFolderForFiles))
            {
                Console.WriteLine($"Будет создано хранище файлов по пути '{pathToFolderForFiles}'.");
                Directory.CreateDirectory(pathToFolderForFiles);
            }
        }



        static void Main(string[] args)
        {
            ConfigureProgramConsole();
            string pathToListWithSamples = "list_with_samples.txt";
            string pathToListBeingCompared = "list_being_compared.txt";
            string pathToFolderForFiles = "folder_for_files";
            string pathToResultFileWithDifference = "calculated_difference.txt";
            List<string> listWithSamples = new List<string>();
            List<string> listBeingCompared = new List<string>();
            bool toFinishProgram = false;
            while (!toFinishProgram)
            {
                Console.WriteLine("1. Завершить работу консольного приложения.");
                Console.WriteLine("2. Записать названия файлов в список-образец.");
                Console.WriteLine("3. Записать названия файлов в сравниваемый список.");
                Console.WriteLine("4. Вычислить сведения о разности содержимого списков по текстовым файлам.");
                Console.Write("Введите номер опции работы с программой: ");
                int optionNumber;
                bool isSuitableValue = int.TryParse(Console.ReadLine(), out optionNumber);
                Console.Clear();
                if (!isSuitableValue)
                {
                    Console.WriteLine("Входные данные не могут быть преобразованы в ожидаемый тип!");
                }
                else
                {
                    switch (optionNumber)
                    {
                        case 1:
                            toFinishProgram = true;
                            Console.WriteLine("Работа с программой завершена.");
                            break;
                        case 2:
                            CheckFolderForFiles(pathToFolderForFiles);
                            listWithSamples = GetFileNamesFromDirectory(pathToFolderForFiles);
                            if (listWithSamples != null)
                            {
                                WriteListToTextFile(pathToListWithSamples, listWithSamples);
                            }
                            break;
                        case 3:
                            CheckFolderForFiles(pathToFolderForFiles);
                            listBeingCompared = GetFileNamesFromDirectory(pathToFolderForFiles);
                            if (listBeingCompared != null)
                            {
                                WriteListToTextFile(pathToListBeingCompared, listBeingCompared);
                            }
                            break;
                        case 4:
                            listWithSamples = GetFileNamesFromTextFile(pathToListWithSamples);
                            if (listWithSamples != null)
                            {
                                listBeingCompared = GetFileNamesFromTextFile(pathToListBeingCompared);
                                if (listBeingCompared != null)
                                {
                                    CalculateDifferenceBetweenListsAndWriteResultIntoFile(listWithSamples, listBeingCompared, pathToResultFileWithDifference);
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка при получении программой сравниваемого списка!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка при получении программой списка-образца!");
                            }
                            break;
                        default:
                            Console.WriteLine("В списке отсутствует вариант с указанным идентификатором!");
                            break;
                    }
                }
                SetPause();
            }
        }
    }
}
