using System;
using System.IO;
using MyGenericCollections.MyArray;
using MyGenericCollections.MySet;
using MyProgramTemplates.MyConsoleApplication;
using MyProgramTemplates.MyFileSystemHandler;

namespace Program
{
    internal class Program
    {
        static void PrintListOfSets(string directoryPath, string extensionForFileSet)
        {
            string fullDirectoryPath = Path.GetFullPath(directoryPath);
            if (!Directory.Exists(fullDirectoryPath))
            {
                throw new Exception("Программная директория для хранения множеств отсутствует!");
            }
            MySet<string> fullPathsToFiles = MyFileSystemHandler.GetFullPathsToFilesFromDirectory(fullDirectoryPath);
            MySet<string> fullPathsToSets = MyFileSystemHandler.FilterFullPathsToFilesByExtension(fullPathsToFiles, extensionForFileSet);
            if (fullPathsToSets.IsEmpty)
            {
                MyConsoleApplication.PrintMessageIntoConsole("Каталог не содержит ни одного множества.\n", ConsoleColor.Green);
                return;
            }
            MySet<string> namesOfSets = MyFileSystemHandler.GetFileNamesFromFullPathsToFiles(fullPathsToSets);
            string wordSet = MyConsoleApplication.MatchingWordWithNumeral(fullPathsToSets.Length, "множеств", "", "о", "а");
            MyConsoleApplication.PrintMessageIntoConsole($"Каталог содержит {namesOfSets.Length} {wordSet}:\n", ConsoleColor.Green);
            MyConsoleApplication.PrintMessageIntoConsole(namesOfSets.ToString() + '\n', Console.ForegroundColor);
        }

        static void CreateNewSet(string directoryPath, string extensionForFileSet)
        {
            string fullDirectoryPath = Path.GetFullPath(directoryPath);
            if (!Directory.Exists(fullDirectoryPath))
            {
                throw new Exception("Программная директория для хранения множеств отсутствует!");
            }
            MySet<string> fullPathsToFiles = MyFileSystemHandler.GetFullPathsToFilesFromDirectory(fullDirectoryPath);
            MySet<string> fullPathsToSets = MyFileSystemHandler.FilterFullPathsToFilesByExtension(fullPathsToFiles, extensionForFileSet);
            MyConsoleApplication.PrintMessageIntoConsole("Получение имён файлов из программной директории.\n", Console.ForegroundColor);
            MySet<string> namesOfSets = MyFileSystemHandler.GetFileNamesFromFullPathsToFiles(fullPathsToSets);
            string nameOfUserSet = MyConsoleApplication.RequestForUserInput("Введите название нового множества: ", ConsoleColor.Yellow);
            string nameWithoutExtension = string.Empty;
            bool finishConversion = false;
            int index = 0;
            while (!finishConversion && index < nameOfUserSet.Length)
            {
                char nextSymbol = nameOfUserSet[index];
                if (nextSymbol != '.')
                {
                    nameWithoutExtension += nameOfUserSet[index];
                    index++;
                }
                else
                {
                    finishConversion = true;
                }
            }
            if (nameWithoutExtension == string.Empty)
            {
                throw new Exception("Введите корректное название для множества!");
            }
            string fileName = nameWithoutExtension + extensionForFileSet;
            string pathToFile = fullDirectoryPath + Path.DirectorySeparatorChar + fileName;
            if (File.Exists(pathToFile))
            {
                MyConsoleApplication.PrintMessageIntoConsole("Существующее множество будет перезаписано.\n", ConsoleColor.Yellow);
            }
            else
            {
                using (FileStream fileStream = File.Create(pathToFile)) { }
                MyConsoleApplication.PrintMessageIntoConsole($"Успешно создан файл \"{fileName}\" для хранения множества.\n", ConsoleColor.Green);
            }
            MyArray<string> elementsGivenFromUser = MyConsoleApplication.RequestForCreateMyArray();
            MyConsoleApplication.PrintMessageIntoConsole("Инициализация пустого множества.\n", Console.ForegroundColor);
            MySet<string> newSet = new MySet<string>();
            if (elementsGivenFromUser.IsEmpty)
            {
                MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} останется пустым.\n", ConsoleColor.Green);
                return;
            }
            MyConsoleApplication.PrintMessageIntoConsole("Запись элементов из массива в множество.\n", Console.ForegroundColor);
            foreach (string element in elementsGivenFromUser)
            {
                newSet.AddElementToEnd(element);
            }
            string wordElement = MyConsoleApplication.MatchingWordWithNumeral(newSet.Length, "элемент", "ов", "а", "ов");
            MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} состоит из {newSet.Length} {wordElement}:\n", ConsoleColor.Green);
            MyConsoleApplication.PrintMessageIntoConsole(newSet.ToString() + '\n', Console.ForegroundColor);
            MyConsoleApplication.PrintMessageIntoConsole($"Запись множества в файл \"{fileName}\".\n", Console.ForegroundColor);
            MyFileSystemHandler.WriteLinesToTextFileFromMyArray(pathToFile, false, newSet);
            MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} успешно записано в файл.\n", ConsoleColor.Green);
        }

        static MySet<string> GetSetContentFromFile(string directoryPath, string extensionForFileSet)
        {
            string fullDirectoryPath = Path.GetFullPath(directoryPath);
            if (!Directory.Exists(fullDirectoryPath))
            {
                throw new Exception("Программная директория для хранения множеств отсутствует!");
            }
            MySet<string> fullPathsToFiles = MyFileSystemHandler.GetFullPathsToFilesFromDirectory(fullDirectoryPath);
            MySet<string> fullPathsToSets = MyFileSystemHandler.FilterFullPathsToFilesByExtension(fullPathsToFiles, extensionForFileSet);
            MyConsoleApplication.PrintMessageIntoConsole("Получение имён файлов из программной директории.\n", Console.ForegroundColor);
            MySet<string> namesOfSets = MyFileSystemHandler.GetFileNamesFromFullPathsToFiles(fullPathsToSets);
            if (namesOfSets.IsEmpty)
            {
                throw new Exception("Каталог не содержит ни одного множества!");
            }
            string nameOfUserSet = MyConsoleApplication.RequestForUserInput("Введите название существующего множества: ", ConsoleColor.Yellow);
            string nameWithoutExtension = string.Empty;
            bool finishConversion = false;
            int index = 0;
            while (!finishConversion && index < nameOfUserSet.Length)
            {
                char nextSymbol = nameOfUserSet[index];
                if (nextSymbol != '.')
                {
                    nameWithoutExtension += nameOfUserSet[index];
                    index++;
                }
                else
                {
                    finishConversion = true;
                }
            }
            if (nameWithoutExtension == string.Empty)
            {
                throw new Exception("Введите корректное название для множества!");
            }
            string fileName = nameWithoutExtension + extensionForFileSet;
            string pathToFile = fullDirectoryPath + Path.DirectorySeparatorChar + fileName;
            if (!File.Exists(pathToFile))
            {
                throw new Exception("Множества с этим названием не существует!");
            }
            MyArray<string> myArray = MyFileSystemHandler.GetLinesFromTextFile(pathToFile);
            MySet<string> mySet = new MySet<string>();
            foreach (string element in myArray)
            {
                mySet.AddElementToEnd(element);
            }
            string wordElement = MyConsoleApplication.MatchingWordWithNumeral(mySet.Length, "элемент", "ов", "а", "ов");
            MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} состоит из {mySet.Length} {wordElement}:\n", ConsoleColor.Green);
            MyConsoleApplication.PrintMessageIntoConsole(mySet.ToString() + '\n', Console.ForegroundColor);
            return mySet;
        }

        static MySet<string> CalculateUniversum(string directoryPath, string extensionForFileSet)
        {
            string fullDirectoryPath = Path.GetFullPath(directoryPath);
            if (!Directory.Exists(fullDirectoryPath))
            {
                throw new Exception("Программная директория для хранения множеств отсутствует!");
            }
            MySet<string> fullPathsToFiles = MyFileSystemHandler.GetFullPathsToFilesFromDirectory(fullDirectoryPath);
            MySet<string> fullPathsToSets = MyFileSystemHandler.FilterFullPathsToFilesByExtension(fullPathsToFiles, extensionForFileSet);
            MyConsoleApplication.PrintMessageIntoConsole("Получение имён файлов из программной директории.\n", Console.ForegroundColor);
            MySet<string> namesOfSets = MyFileSystemHandler.GetFileNamesFromFullPathsToFiles(fullPathsToSets);
            if (namesOfSets.IsEmpty)
            {
                throw new Exception("Для вызова этой процедуры необходимо создать хотя бы одно множество!");
            }
            MyConsoleApplication.PrintMessageIntoConsole("Получение элементов из всех файлов с множествами.\n", Console.ForegroundColor);
            MySet<string> universum = new MySet<string>();
            for (int index = 0; index < fullPathsToSets.Length; index++)
            {
                MyConsoleApplication.PrintMessageIntoConsole($"Обращение к файлу {namesOfSets[index]}:\n", Console.ForegroundColor);
                MySet<string> mySet = new MySet<string>();
                MyArray<string> myArray = MyFileSystemHandler.GetLinesFromTextFile(fullPathsToSets[index]);
                foreach (string element in myArray)
                {
                    mySet.AddElementToEnd(element);
                }
                MyConsoleApplication.PrintMessageIntoConsole(mySet.ToString() + ".\n", ConsoleColor.Yellow);
                universum.Union(mySet);
            }
            return universum;
        }

        static void CreateNewUniversum(string directoryPath, string extensionForFileSet)
        {
            MySet<string> universum = CalculateUniversum(directoryPath, extensionForFileSet);
            Console.WriteLine();
            string fullDirectoryPath = Path.GetFullPath(directoryPath);
            if (!Directory.Exists(fullDirectoryPath))
            {
                throw new Exception("Программная директория для хранения множеств отсутствует!");
            }
            MySet<string> fullPathsToFiles = MyFileSystemHandler.GetFullPathsToFilesFromDirectory(fullDirectoryPath);
            MySet<string> fullPathsToSets = MyFileSystemHandler.FilterFullPathsToFilesByExtension(fullPathsToFiles, extensionForFileSet);
            MyConsoleApplication.PrintMessageIntoConsole("Получение имён файлов из программной директории.\n", Console.ForegroundColor);
            MySet<string> namesOfSets = MyFileSystemHandler.GetFileNamesFromFullPathsToFiles(fullPathsToSets);
            string nameOfUserSet = MyConsoleApplication.RequestForUserInput("Введите название нового множества: ", ConsoleColor.Yellow);
            string nameWithoutExtension = string.Empty;
            bool finishConversion = false;
            int index = 0;
            while (!finishConversion && index < nameOfUserSet.Length)
            {
                char nextSymbol = nameOfUserSet[index];
                if (nextSymbol != '.')
                {
                    nameWithoutExtension += nameOfUserSet[index];
                    index++;
                }
                else
                {
                    finishConversion = true;
                }
            }
            if (nameWithoutExtension == string.Empty)
            {
                throw new Exception("Введите корректное название для множества!");
            }
            string fileName = nameWithoutExtension + extensionForFileSet;
            string pathToFile = fullDirectoryPath + Path.DirectorySeparatorChar + fileName;
            if (File.Exists(pathToFile))
            {
                MyConsoleApplication.PrintMessageIntoConsole("Существующее множество будет перезаписано.\n", ConsoleColor.Yellow);
            }
            else
            {
                using (FileStream fileStream = File.Create(pathToFile)) { }
                MyConsoleApplication.PrintMessageIntoConsole($"Успешно создан файл \"{fileName}\" для хранения множества.\n", ConsoleColor.Green);
            }
            if (!universum.IsEmpty)
            {
                string wordElement = MyConsoleApplication.MatchingWordWithNumeral(universum.Length, "элемент", "ов", "а", "ов");
                MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} состоит из {universum.Length} {wordElement}:\n", ConsoleColor.Green);
                MyConsoleApplication.PrintMessageIntoConsole(universum.ToString() + '\n', Console.ForegroundColor);
            }
            else
            {
                MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} является пустым.\n", ConsoleColor.Green);
            }
            MyConsoleApplication.PrintMessageIntoConsole($"Запись множества в файл \"{fileName}\".\n", Console.ForegroundColor);
            MyFileSystemHandler.WriteLinesToTextFileFromMyArray(pathToFile, false, universum);
            MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} успешно записано в файл.\n", ConsoleColor.Green);
        }

        static void UnionTwoSets(string directoryPath, string extensionForFileSet)
        {
            MyConsoleApplication.PrintMessageIntoConsole("Запрос на выбор первого множества.\n", ConsoleColor.Yellow);
            MySet<string> firstSet = GetSetContentFromFile(directoryPath, extensionForFileSet);
            Console.WriteLine();
            MyConsoleApplication.PrintMessageIntoConsole("Запрос на выбор второго множества.\n", ConsoleColor.Yellow);
            MySet<string> secondSet = GetSetContentFromFile(directoryPath, extensionForFileSet);
            Console.WriteLine();
            MySet<string>  result = MySetOperations.GetUnion(firstSet, secondSet);
            string wordElement = MyConsoleApplication.MatchingWordWithNumeral(result.Length, "элемент", "ов", "а", "ов");
            MyConsoleApplication.PrintMessageIntoConsole($"Результат объединения двух множеств состоит из {result.Length} {wordElement}:\n", ConsoleColor.Green);
            MyConsoleApplication.PrintMessageIntoConsole(result.ToString() + '\n', ConsoleColor.Green);
            Console.WriteLine();
            string fullDirectoryPath = Path.GetFullPath(directoryPath);
            if (!Directory.Exists(fullDirectoryPath))
            {
                throw new Exception("Программная директория для хранения множеств отсутствует!");
            }
            MySet<string> fullPathsToFiles = MyFileSystemHandler.GetFullPathsToFilesFromDirectory(fullDirectoryPath);
            MySet<string> fullPathsToSets = MyFileSystemHandler.FilterFullPathsToFilesByExtension(fullPathsToFiles, extensionForFileSet);
            MyConsoleApplication.PrintMessageIntoConsole("Получение имён файлов из программной директории.\n", Console.ForegroundColor);
            MySet<string> namesOfSets = MyFileSystemHandler.GetFileNamesFromFullPathsToFiles(fullPathsToSets);
            string nameOfUserSet = MyConsoleApplication.RequestForUserInput("Введите название нового множества: ", ConsoleColor.Yellow);
            string nameWithoutExtension = string.Empty;
            bool finishConversion = false;
            int index = 0;
            while (!finishConversion && index < nameOfUserSet.Length)
            {
                char nextSymbol = nameOfUserSet[index];
                if (nextSymbol != '.')
                {
                    nameWithoutExtension += nameOfUserSet[index];
                    index++;
                }
                else
                {
                    finishConversion = true;
                }
            }
            if (nameWithoutExtension == string.Empty)
            {
                throw new Exception("Введите корректное название для множества!");
            }
            string fileName = nameWithoutExtension + extensionForFileSet;
            string pathToFile = fullDirectoryPath + Path.DirectorySeparatorChar + fileName;
            if (File.Exists(pathToFile))
            {
                MyConsoleApplication.PrintMessageIntoConsole("Существующее множество будет перезаписано.\n", ConsoleColor.Yellow);
            }
            else
            {
                using (FileStream fileStream = File.Create(pathToFile)) { }
                MyConsoleApplication.PrintMessageIntoConsole($"Успешно создан файл \"{fileName}\" для хранения множества.\n", ConsoleColor.Green);
            }
            if (!result.IsEmpty)
            {
                wordElement = MyConsoleApplication.MatchingWordWithNumeral(result.Length, "элемент", "ов", "а", "ов");
                MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} состоит из {result.Length} {wordElement}:\n", ConsoleColor.Green);
                MyConsoleApplication.PrintMessageIntoConsole(result.ToString() + '\n', Console.ForegroundColor);
            }
            else
            {
                MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} является пустым.\n", ConsoleColor.Green);
            }
            MyConsoleApplication.PrintMessageIntoConsole($"Запись множества в файл \"{fileName}\".\n", Console.ForegroundColor);
            MyFileSystemHandler.WriteLinesToTextFileFromMyArray(pathToFile, false, result);
            MyConsoleApplication.PrintMessageIntoConsole($"Множество \"{nameWithoutExtension}\" успешно записано в файл.\n", ConsoleColor.Green);
        }

        static void IntersectionOfTwoSets(string directoryPath, string extensionForFileSet)
        {
            MyConsoleApplication.PrintMessageIntoConsole("Запрос на выбор первого множества.\n", ConsoleColor.Yellow);
            MySet<string> firstSet = GetSetContentFromFile(directoryPath, extensionForFileSet);
            Console.WriteLine();
            MyConsoleApplication.PrintMessageIntoConsole("Запрос на выбор второго множества.\n", ConsoleColor.Yellow);
            MySet<string> secondSet = GetSetContentFromFile(directoryPath, extensionForFileSet);
            Console.WriteLine();
            MySet<string> result = MySetOperations.GetIntersection(firstSet, secondSet);
            string wordElement = MyConsoleApplication.MatchingWordWithNumeral(result.Length, "элемент", "ов", "а", "ов");
            MyConsoleApplication.PrintMessageIntoConsole($"Результат пересечения двух множеств состоит из {result.Length} {wordElement}:\n", ConsoleColor.Green);
            MyConsoleApplication.PrintMessageIntoConsole(result.ToString() + '\n', ConsoleColor.Green);
            Console.WriteLine();
            string fullDirectoryPath = Path.GetFullPath(directoryPath);
            if (!Directory.Exists(fullDirectoryPath))
            {
                throw new Exception("Программная директория для хранения множеств отсутствует!");
            }
            MySet<string> fullPathsToFiles = MyFileSystemHandler.GetFullPathsToFilesFromDirectory(fullDirectoryPath);
            MySet<string> fullPathsToSets = MyFileSystemHandler.FilterFullPathsToFilesByExtension(fullPathsToFiles, extensionForFileSet);
            MyConsoleApplication.PrintMessageIntoConsole("Получение имён файлов из программной директории.\n", Console.ForegroundColor);
            MySet<string> namesOfSets = MyFileSystemHandler.GetFileNamesFromFullPathsToFiles(fullPathsToSets);
            string nameOfUserSet = MyConsoleApplication.RequestForUserInput("Введите название нового множества: ", ConsoleColor.Yellow);
            string nameWithoutExtension = string.Empty;
            bool finishConversion = false;
            int index = 0;
            while (!finishConversion && index < nameOfUserSet.Length)
            {
                char nextSymbol = nameOfUserSet[index];
                if (nextSymbol != '.')
                {
                    nameWithoutExtension += nameOfUserSet[index];
                    index++;
                }
                else
                {
                    finishConversion = true;
                }
            }
            if (nameWithoutExtension == string.Empty)
            {
                throw new Exception("Введите корректное название для множества!");
            }
            string fileName = nameWithoutExtension + extensionForFileSet;
            string pathToFile = fullDirectoryPath + Path.DirectorySeparatorChar + fileName;
            if (File.Exists(pathToFile))
            {
                MyConsoleApplication.PrintMessageIntoConsole("Существующее множество будет перезаписано.\n", ConsoleColor.Yellow);
            }
            else
            {
                using (FileStream fileStream = File.Create(pathToFile)) { }
                MyConsoleApplication.PrintMessageIntoConsole($"Успешно создан файл \"{fileName}\" для хранения множества.\n", ConsoleColor.Green);
            }
            if (!result.IsEmpty)
            {
                wordElement = MyConsoleApplication.MatchingWordWithNumeral(result.Length, "элемент", "ов", "а", "ов");
                MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} состоит из {result.Length} {wordElement}:\n", ConsoleColor.Green);
                MyConsoleApplication.PrintMessageIntoConsole(result.ToString() + '\n', Console.ForegroundColor);
            }
            else
            {
                MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} является пустым.\n", ConsoleColor.Green);
            }
            MyConsoleApplication.PrintMessageIntoConsole($"Запись множества в файл \"{fileName}\".\n", Console.ForegroundColor);
            MyFileSystemHandler.WriteLinesToTextFileFromMyArray(pathToFile, false, result);
            MyConsoleApplication.PrintMessageIntoConsole($"Множество \"{nameWithoutExtension}\" успешно записано в файл.\n", ConsoleColor.Green);
        }

        static void DifferenceOfTwoSets(string directoryPath, string extensionForFileSet)
        {
            MyConsoleApplication.PrintMessageIntoConsole("Запрос на выбор первого множества.\n", ConsoleColor.Yellow);
            MySet<string> firstSet = GetSetContentFromFile(directoryPath, extensionForFileSet);
            Console.WriteLine();
            MyConsoleApplication.PrintMessageIntoConsole("Запрос на выбор второго множества.\n", ConsoleColor.Yellow);
            MySet<string> secondSet = GetSetContentFromFile(directoryPath, extensionForFileSet);
            Console.WriteLine();
            MySet<string> result = MySetOperations.GetDifference(firstSet, secondSet);
            string wordElement = MyConsoleApplication.MatchingWordWithNumeral(result.Length, "элемент", "ов", "а", "ов");
            MyConsoleApplication.PrintMessageIntoConsole($"Результат разности двух множеств состоит из {result.Length} {wordElement}:\n", ConsoleColor.Green);
            MyConsoleApplication.PrintMessageIntoConsole(result.ToString() + '\n', ConsoleColor.Green);
            Console.WriteLine();
            string fullDirectoryPath = Path.GetFullPath(directoryPath);
            if (!Directory.Exists(fullDirectoryPath))
            {
                throw new Exception("Программная директория для хранения множеств отсутствует!");
            }
            MySet<string> fullPathsToFiles = MyFileSystemHandler.GetFullPathsToFilesFromDirectory(fullDirectoryPath);
            MySet<string> fullPathsToSets = MyFileSystemHandler.FilterFullPathsToFilesByExtension(fullPathsToFiles, extensionForFileSet);
            MyConsoleApplication.PrintMessageIntoConsole("Получение имён файлов из программной директории.\n", Console.ForegroundColor);
            MySet<string> namesOfSets = MyFileSystemHandler.GetFileNamesFromFullPathsToFiles(fullPathsToSets);
            string nameOfUserSet = MyConsoleApplication.RequestForUserInput("Введите название нового множества: ", ConsoleColor.Yellow);
            string nameWithoutExtension = string.Empty;
            bool finishConversion = false;
            int index = 0;
            while (!finishConversion && index < nameOfUserSet.Length)
            {
                char nextSymbol = nameOfUserSet[index];
                if (nextSymbol != '.')
                {
                    nameWithoutExtension += nameOfUserSet[index];
                    index++;
                }
                else
                {
                    finishConversion = true;
                }
            }
            if (nameWithoutExtension == string.Empty)
            {
                throw new Exception("Введите корректное название для множества!");
            }
            string fileName = nameWithoutExtension + extensionForFileSet;
            string pathToFile = fullDirectoryPath + Path.DirectorySeparatorChar + fileName;
            if (File.Exists(pathToFile))
            {
                MyConsoleApplication.PrintMessageIntoConsole("Существующее множество будет перезаписано.\n", ConsoleColor.Yellow);
            }
            else
            {
                using (FileStream fileStream = File.Create(pathToFile)) { }
                MyConsoleApplication.PrintMessageIntoConsole($"Успешно создан файл \"{fileName}\" для хранения множества.\n", ConsoleColor.Green);
            }
            if (!result.IsEmpty)
            {
                wordElement = MyConsoleApplication.MatchingWordWithNumeral(result.Length, "элемент", "ов", "а", "ов");
                MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} состоит из {result.Length} {wordElement}:\n", ConsoleColor.Green);
                MyConsoleApplication.PrintMessageIntoConsole(result.ToString() + '\n', Console.ForegroundColor);
            }
            else
            {
                MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} является пустым.\n", ConsoleColor.Green);
            }
            MyConsoleApplication.PrintMessageIntoConsole($"Запись множества в файл \"{fileName}\".\n", Console.ForegroundColor);
            MyFileSystemHandler.WriteLinesToTextFileFromMyArray(pathToFile, false, result);
            MyConsoleApplication.PrintMessageIntoConsole($"Множество \"{nameWithoutExtension}\" успешно записано в файл.\n", ConsoleColor.Green);
        }

        static void SymmetricDifferenceOfTwoSets(string directoryPath, string extensionForFileSet)
        {
            MyConsoleApplication.PrintMessageIntoConsole("Запрос на выбор первого множества.\n", ConsoleColor.Yellow);
            MySet<string> firstSet = GetSetContentFromFile(directoryPath, extensionForFileSet);
            Console.WriteLine();
            MyConsoleApplication.PrintMessageIntoConsole("Запрос на выбор второго множества.\n", ConsoleColor.Yellow);
            MySet<string> secondSet = GetSetContentFromFile(directoryPath, extensionForFileSet);
            Console.WriteLine();
            MySet<string> result = MySetOperations.GetSymmetricDifference(firstSet, secondSet);
            string wordElement = MyConsoleApplication.MatchingWordWithNumeral(result.Length, "элемент", "ов", "а", "ов");
            MyConsoleApplication.PrintMessageIntoConsole($"Результат симметрической разности двух множеств состоит из {result.Length} {wordElement}:\n", ConsoleColor.Green);
            MyConsoleApplication.PrintMessageIntoConsole(result.ToString() + '\n', ConsoleColor.Green);
            Console.WriteLine();
            string fullDirectoryPath = Path.GetFullPath(directoryPath);
            if (!Directory.Exists(fullDirectoryPath))
            {
                throw new Exception("Программная директория для хранения множеств отсутствует!");
            }
            MySet<string> fullPathsToFiles = MyFileSystemHandler.GetFullPathsToFilesFromDirectory(fullDirectoryPath);
            MySet<string> fullPathsToSets = MyFileSystemHandler.FilterFullPathsToFilesByExtension(fullPathsToFiles, extensionForFileSet);
            MyConsoleApplication.PrintMessageIntoConsole("Получение имён файлов из программной директории.\n", Console.ForegroundColor);
            MySet<string> namesOfSets = MyFileSystemHandler.GetFileNamesFromFullPathsToFiles(fullPathsToSets);
            string nameOfUserSet = MyConsoleApplication.RequestForUserInput("Введите название нового множества: ", ConsoleColor.Yellow);
            string nameWithoutExtension = string.Empty;
            bool finishConversion = false;
            int index = 0;
            while (!finishConversion && index < nameOfUserSet.Length)
            {
                char nextSymbol = nameOfUserSet[index];
                if (nextSymbol != '.')
                {
                    nameWithoutExtension += nameOfUserSet[index];
                    index++;
                }
                else
                {
                    finishConversion = true;
                }
            }
            if (nameWithoutExtension == string.Empty)
            {
                throw new Exception("Введите корректное название для множества!");
            }
            string fileName = nameWithoutExtension + extensionForFileSet;
            string pathToFile = fullDirectoryPath + Path.DirectorySeparatorChar + fileName;
            if (File.Exists(pathToFile))
            {
                MyConsoleApplication.PrintMessageIntoConsole("Существующее множество будет перезаписано.\n", ConsoleColor.Yellow);
            }
            else
            {
                using (FileStream fileStream = File.Create(pathToFile)) { }
                MyConsoleApplication.PrintMessageIntoConsole($"Успешно создан файл \"{fileName}\" для хранения множества.\n", ConsoleColor.Green);
            }
            if (!result.IsEmpty)
            {
                wordElement = MyConsoleApplication.MatchingWordWithNumeral(result.Length, "элемент", "ов", "а", "ов");
                MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} состоит из {result.Length} {wordElement}:\n", ConsoleColor.Green);
                MyConsoleApplication.PrintMessageIntoConsole(result.ToString() + '\n', Console.ForegroundColor);
            }
            else
            {
                MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} является пустым.\n", ConsoleColor.Green);
            }
            MyConsoleApplication.PrintMessageIntoConsole($"Запись множества в файл \"{fileName}\".\n", Console.ForegroundColor);
            MyFileSystemHandler.WriteLinesToTextFileFromMyArray(pathToFile, false, result);
            MyConsoleApplication.PrintMessageIntoConsole($"Множество \"{nameWithoutExtension}\" успешно записано в файл.\n", ConsoleColor.Green);
        }

        static void FindAdditionOfSet(string directoryPath, string extensionForFileSet)
        {
            MySet<string> mySet = GetSetContentFromFile(directoryPath, extensionForFileSet);
            Console.WriteLine();
            MySet<string> universum = CalculateUniversum(directoryPath, extensionForFileSet);
            Console.WriteLine();
            MyConsoleApplication.PrintMessageIntoConsole("Вычисление дополнения множества как разность универсума к выбранному множеству.\n", ConsoleColor.Yellow);
            MyArray<string> result = MySetOperations.GetDifference(universum, mySet);
            string wordElement = MyConsoleApplication.MatchingWordWithNumeral(result.Length, "элемент", "ов", "а", "ов");
            MyConsoleApplication.PrintMessageIntoConsole($"Результат разности двух множеств состоит из {result.Length} {wordElement}:\n", ConsoleColor.Green);
            MyConsoleApplication.PrintMessageIntoConsole(result.ToString() + '\n', ConsoleColor.Green);
            Console.WriteLine();
            string fullDirectoryPath = Path.GetFullPath(directoryPath);
            if (!Directory.Exists(fullDirectoryPath))
            {
                throw new Exception("Программная директория для хранения множеств отсутствует!");
            }
            MySet<string> fullPathsToFiles = MyFileSystemHandler.GetFullPathsToFilesFromDirectory(fullDirectoryPath);
            MySet<string> fullPathsToSets = MyFileSystemHandler.FilterFullPathsToFilesByExtension(fullPathsToFiles, extensionForFileSet);
            MyConsoleApplication.PrintMessageIntoConsole("Получение имён файлов из программной директории.\n", Console.ForegroundColor);
            MySet<string> namesOfSets = MyFileSystemHandler.GetFileNamesFromFullPathsToFiles(fullPathsToSets);
            string nameOfUserSet = MyConsoleApplication.RequestForUserInput("Введите название нового множества: ", ConsoleColor.Yellow);
            string nameWithoutExtension = string.Empty;
            bool finishConversion = false;
            int index = 0;
            while (!finishConversion && index < nameOfUserSet.Length)
            {
                char nextSymbol = nameOfUserSet[index];
                if (nextSymbol != '.')
                {
                    nameWithoutExtension += nameOfUserSet[index];
                    index++;
                }
                else
                {
                    finishConversion = true;
                }
            }
            if (nameWithoutExtension == string.Empty)
            {
                throw new Exception("Введите корректное название для множества!");
            }
            string fileName = nameWithoutExtension + extensionForFileSet;
            string pathToFile = fullDirectoryPath + Path.DirectorySeparatorChar + fileName;
            if (File.Exists(pathToFile))
            {
                MyConsoleApplication.PrintMessageIntoConsole("Существующее множество будет перезаписано.\n", ConsoleColor.Yellow);
            }
            else
            {
                using (FileStream fileStream = File.Create(pathToFile)) { }
                MyConsoleApplication.PrintMessageIntoConsole($"Успешно создан файл \"{fileName}\" для хранения множества.\n", ConsoleColor.Green);
            }
            if (!result.IsEmpty)
            {
                wordElement = MyConsoleApplication.MatchingWordWithNumeral(result.Length, "элемент", "ов", "а", "ов");
                MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} состоит из {result.Length} {wordElement}:\n", ConsoleColor.Green);
                MyConsoleApplication.PrintMessageIntoConsole(result.ToString() + '\n', Console.ForegroundColor);
            }
            else
            {
                MyConsoleApplication.PrintMessageIntoConsole($"Множество {nameWithoutExtension} является пустым.\n", ConsoleColor.Green);
            }
            MyConsoleApplication.PrintMessageIntoConsole($"Запись множества в файл \"{fileName}\".\n", Console.ForegroundColor);
            MyFileSystemHandler.WriteLinesToTextFileFromMyArray(pathToFile, false, result);
            MyConsoleApplication.PrintMessageIntoConsole($"Множество \"{nameWithoutExtension}\" успешно записано в файл.\n", ConsoleColor.Green);
        }

        static void DeleteExistenceSet(string directoryPath, string extensionForFileSet)
        {
            string fullDirectoryPath = Path.GetFullPath(directoryPath);
            if (!Directory.Exists(fullDirectoryPath))
            {
                throw new Exception("Программная директория для хранения множеств отсутствует!");
            }
            MySet<string> fullPathsToFiles = MyFileSystemHandler.GetFullPathsToFilesFromDirectory(fullDirectoryPath);
            MySet<string> fullPathsToSets = MyFileSystemHandler.FilterFullPathsToFilesByExtension(fullPathsToFiles, extensionForFileSet);
            MyConsoleApplication.PrintMessageIntoConsole("Получение имён файлов из программной директории.\n", Console.ForegroundColor);
            MySet<string> namesOfSets = MyFileSystemHandler.GetFileNamesFromFullPathsToFiles(fullPathsToSets);
            if (namesOfSets.IsEmpty)
            {
                throw new Exception("Каталог не содержит ни одного множества!");
            }
            string nameOfUserSet = MyConsoleApplication.RequestForUserInput("Введите название существующего множества: ", ConsoleColor.Yellow);
            string nameWithoutExtension = string.Empty;
            bool finishConversion = false;
            int index = 0;
            while (!finishConversion && index < nameOfUserSet.Length)
            {
                char nextSymbol = nameOfUserSet[index];
                if (nextSymbol != '.')
                {
                    nameWithoutExtension += nameOfUserSet[index];
                    index++;
                }
                else
                {
                    finishConversion = true;
                }
            }
            if (nameWithoutExtension == string.Empty)
            {
                throw new Exception("Введите корректное название для множества!");
            }
            string fileName = nameWithoutExtension + extensionForFileSet;
            string pathToFile = fullDirectoryPath + Path.DirectorySeparatorChar + fileName;
            if (!File.Exists(pathToFile))
            {
                throw new Exception("Множества с этим названием не существует!");
            }
            File.Delete(pathToFile);
            MyConsoleApplication.PrintMessageIntoConsole($"Был успешно удалён файл \"{fileName}\" из хранилища программы.\n", ConsoleColor.Green);
        }

        static void Main(string[] args)
        {
            MyConsoleApplication.ConfigureProgramConsole("Калькулятор множеств");
            string programDirectoryName = "Sets";
            string extensionForFileSet = ".myset";
            bool finishProgram = false;
            while (!finishProgram)
            {
                try
                {
                    MyConsoleApplication.PrintMessageIntoConsole("1. Завершить работу консольного приложения.\n", Console.ForegroundColor);
                    MyConsoleApplication.PrintMessageIntoConsole($"2. Создать каталог \"{programDirectoryName}\" для хранения и работы с множествами.\n", Console.ForegroundColor);
                    MyConsoleApplication.PrintMessageIntoConsole("3. Вывести список всех доступных множеств.\n", Console.ForegroundColor);
                    MyConsoleApplication.PrintMessageIntoConsole("4. Создать новое множество или перезаписать существующее.\n", Console.ForegroundColor);
                    MyConsoleApplication.PrintMessageIntoConsole("5. Получить содержимое множества.\n", Console.ForegroundColor);
                    MyConsoleApplication.PrintMessageIntoConsole("6. Вычислить универсальное множество и записать его в файл.\n", Console.ForegroundColor);
                    MyConsoleApplication.PrintMessageIntoConsole("7. Объединить два множества и записать результат в файл.\n", Console.ForegroundColor);
                    MyConsoleApplication.PrintMessageIntoConsole("8. Вычислить пересечение двух множеств и записать результат в файл.\n", Console.ForegroundColor);
                    MyConsoleApplication.PrintMessageIntoConsole("9. Исключить элементы второго множества из первого и записать результат в файл.\n", Console.ForegroundColor);
                    MyConsoleApplication.PrintMessageIntoConsole("10. Выполнить симметрическую разность двух множеств и записать результат в файл.\n", Console.ForegroundColor);
                    MyConsoleApplication.PrintMessageIntoConsole("11. Найти дополнение множества и записать результат в файл.\n", Console.ForegroundColor);
                    MyConsoleApplication.PrintMessageIntoConsole("12. Удалить файл существующего множества.\n", Console.ForegroundColor);
                    int optionNumber = MyConsoleApplication.ReadIntNumberFromUserInput("Введите номер опции работы с программой: ");
                    Console.WriteLine();
                    switch (optionNumber)
                    {
                        case 1:
                            MyConsoleApplication.PrintMessageIntoConsole("Работа с программой завершена.\n", ConsoleColor.Green);
                            finishProgram = true;
                            break;
                        case 2:
                            MyConsoleApplication.TryToCreateDirectory(programDirectoryName);
                            break;
                        case 3:
                            PrintListOfSets(programDirectoryName, extensionForFileSet);
                            break;
                        case 4:
                            CreateNewSet(programDirectoryName, extensionForFileSet);
                            break;
                        case 5:
                            GetSetContentFromFile(programDirectoryName, extensionForFileSet);
                            break;
                        case 6:
                            CreateNewUniversum(programDirectoryName, extensionForFileSet);
                            break;
                        case 7:
                            UnionTwoSets(programDirectoryName, extensionForFileSet);
                            break;
                        case 8:
                            IntersectionOfTwoSets(programDirectoryName, extensionForFileSet);
                            break;
                        case 9:
                            DifferenceOfTwoSets(programDirectoryName, extensionForFileSet);
                            break;
                        case 10:
                            SymmetricDifferenceOfTwoSets(programDirectoryName, extensionForFileSet);
                            break;
                        case 11:
                            FindAdditionOfSet(programDirectoryName, extensionForFileSet);
                            break;
                        case 12:
                            DeleteExistenceSet(programDirectoryName, extensionForFileSet);
                            break;
                        default:
                            throw new Exception("В списке отсутствует действие под указанным номером!");
                    }
                }
                catch (Exception exception)
                {
                    MyConsoleApplication.PrintMessageIntoConsole(exception.Message + '\n', ConsoleColor.Red);
                }
                Console.WriteLine();
                MyConsoleApplication.SetPause();
                Console.Clear();
            }
        }
    }
}