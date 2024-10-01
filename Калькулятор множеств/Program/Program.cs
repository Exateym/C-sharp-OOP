using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SetCalculator
{
    class StringSet
    {
        public string Name { get; set; }
        public List<string> Elements { get; set; }
        public StringSet()
        {
            Name = "Пустое множество";
            Elements = new List<string>();
        }
        public StringSet(string name)
        {
            Name = name;
            Elements = new List<string>();
        }
        public StringSet(string name, List<string> elements)
        {
            Name = name;
            Elements = new List<string>(elements);
            if (Elements.Count > 1)
            {
                DeleteDuplicates();
            }
        }
        public void DeleteDuplicates()
        {
            if (Elements.Count > 1)
            {
                int primaryIndex = 0;
                while (primaryIndex < Elements.Count)
                {
                    int secondaryIndex = primaryIndex + 1;
                    while (secondaryIndex < Elements.Count)
                    {
                        if (Elements[primaryIndex] == Elements[secondaryIndex])
                        {
                            Elements.RemoveAt(secondaryIndex);
                        }
                        else
                        {
                            ++secondaryIndex;
                        }
                    }
                    ++primaryIndex;
                }
            }
        }
    }
    class BelongingColumn
    {
        public string Name { get; set;}
        public List<bool> Elements { get; set; }
        public BelongingColumn(StringSet primarySet, StringSet secondarySet)
        {
            Name = secondarySet.Name;
            Elements = new List<bool>();
            for (int primaryIndex = 0; primaryIndex < primarySet.Elements.Count; ++primaryIndex)
            {
                bool isBelong = false;
                for (int secondaryIndex = 0; secondaryIndex < secondarySet.Elements.Count; ++secondaryIndex)
                {
                    if (primarySet.Elements[primaryIndex] == secondarySet.Elements[secondaryIndex])
                    {
                        isBelong = true;
                    }
                }
                Elements.Add(isBelong);
            }
        }
    }
    internal class Program
    {
        List<StringSet> manuallyMadeStringSets = new List<StringSet>(); // Здесь хранятся все множества, созданные вручную
        StringSet emptySet = new StringSet();
        StringSet universum = new StringSet("Универсальное множество");
        List<BelongingColumn> columns = new List<BelongingColumn>();
        int SimplificationNumeral(int number)
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
        string MatchingWordElementWithNumeral(int number)
        {
            number = SimplificationNumeral(number);
            string foundation = "элемент";
            if (number == 0 || number > 4)
                return foundation + "ов";
            if (number == 1)
                return foundation;
            return foundation + "а";
        }
        void CreateNewStringSet()
        {
            Console.Write("Введите название нового множетсва: ");
            string newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName))
            {
                Console.WriteLine("Название должно быть корректным!");
                return;
            }
            for (int index = 0; index < manuallyMadeStringSets.Count; ++index)
            {
                if (newName == manuallyMadeStringSets[index].Name)
                {
                    Console.WriteLine("Множество с указанным именем уже существует!");
                    return;
                }
            }
            Console.Write("Укажите количество элементов, которые вы хотели бы ввести: ");
            int quantity;
            bool isSuitableValue = int.TryParse(Console.ReadLine(), out quantity);
            if (!isSuitableValue)
            {
                Console.WriteLine("Входные данные не могут быть преобразованы в ожидаемый тип!");
                return;
            }
            if (quantity < 0)
            {
                Console.WriteLine("Количество не должно выражаться отрицательным числом!");
                return;
            }
            List<string> elements = new List<string>();
            if (quantity == 0)
            {
                
            }
            for (int number = 1; number <= quantity; ++number)
            {
                Console.Write("Введите ");
                if (number == 1)
                {
                    Console.Write("первый элемент: ");
                }
                else
                {
                    if (number == quantity)
                    {
                        Console.Write("последний элемент: ");
                    }
                    else
                    {
                        Console.Write($"элемент номер {number}: ");
                    }
                }
                elements.Add(Console.ReadLine());
            }
            StringSet newStringSet = new StringSet(newName, elements);
            manuallyMadeStringSets.Add(newStringSet);
            int finalQuantity = newStringSet.Elements.Count;
            Console.WriteLine($"Создано множество с названием {newName}. Оно содержит {finalQuantity} {MatchingWordElementWithNumeral(finalQuantity)}.");
        }
        string MatchingWordSetWithNumeral(int number)
        {
            number = SimplificationNumeral(number);
            string foundation = "множеств";
            if (number == 0 || number > 4)
                return foundation;
            if (number == 1)
                return foundation + "о";
            return foundation + "а";
        }
        void PrintManuallyMadeStringSets()
        {
            int quantity = manuallyMadeStringSets.Count;
            Console.Write("Список ");
            if (quantity == 0)
            {
                Console.WriteLine("пользовательских множеств пуст!");
                return;
            }
            string word = "названи";
            if (quantity == 1)
            {
                word += "ем";
            }
            else
            {
                word += "ями";
            }
            Console.WriteLine($"содержит {quantity} {MatchingWordSetWithNumeral(quantity)} с {word}:");
            for (int number = 1; number <= quantity; ++number)
            {
                StringSet current = manuallyMadeStringSets[number - 1];
                int amount = current.Elements.Count;
                Console.WriteLine($"{number}. {current.Name}. Содержит {amount} {MatchingWordElementWithNumeral(amount)}.");
            }
        }
        void PrintSetContent(StringSet stringSet)
        {
            int quantity = stringSet.Elements.Count;
            Console.Write($"Множество {stringSet.Name}");
            if (quantity == 0)
            {
                Console.WriteLine(" является пустым!");
                return;
            }
            Console.WriteLine($" содержит {quantity} {MatchingWordElementWithNumeral(quantity)}:");
            List<string> elements = stringSet.Elements;
            for (int number = 1; number <= quantity; ++number)
            {
                Console.WriteLine($"{number}. {elements[number - 1]}");
            }
        }
        void PrintSetContentFromCustoms()
        {
            Console.Write("\nВведите номер множества из списка: ");
            int number;
            bool isSuitableValue = int.TryParse(Console.ReadLine(), out number);
            if (!isSuitableValue)
            {
                Console.WriteLine("Входные данные не могут быть преобразованы в ожидаемый тип!");
                return;
            }
            int index = number - 1;
            if (index < 0 || index > manuallyMadeStringSets.Count - 1)
            {
                Console.WriteLine("В списке отсутствует набор под указанным номером!");
                return;
            }
            StringSet stringSet = manuallyMadeStringSets[index];
            Console.Write('\n');
            PrintSetContent(stringSet);
        }
        void SortCustomSets()
        {
            for (int index = 0; index < manuallyMadeStringSets.Count; ++index)
            {
                manuallyMadeStringSets[index].Elements.Sort();
            }
        }
        void CalculateUniversum()
        {
            List<string> allElements = new List<string>();
            for (int primaryIndex = 0; primaryIndex < manuallyMadeStringSets.Count; ++primaryIndex)
            {
                List<string> currentList = manuallyMadeStringSets[primaryIndex].Elements;
                int elementsAmount = currentList.Count;
                for (int secondaryIndex = 0; secondaryIndex < elementsAmount; ++secondaryIndex)
                {
                    allElements.Add(currentList[secondaryIndex]);
                }
            }
            universum.Elements = new List<string>(allElements);
            universum.DeleteDuplicates();
        }
        void CreateColumns()
        {
            columns.Clear();
            BelongingColumn newColumn = new BelongingColumn(universum, universum);
            columns.Add(newColumn);
            newColumn = new BelongingColumn(universum, emptySet);
            columns.Add(newColumn);
            for (int index = 0; index < manuallyMadeStringSets.Count; ++index)
            {
                newColumn = new BelongingColumn(universum, manuallyMadeStringSets[index]);
                columns.Add(newColumn);
            }
        }
        string CompleteString(string str, int simbolsAmount)
        {
            int len = str.Length;
            if (len < simbolsAmount)
            {

            }
            return str;
        }
        void PrintBelongingTable()
        {
            List<String> strings = new List<string>();
            strings.Add("Все элементы");
            strings.Add("True");
            strings.Add("False");
            for (int index = 0; index < universum.Elements.Count; ++index)
            {
                strings.Add(universum.Elements[index]);
            }
            int maximalLength = 0;
            for (int index = 0; index < strings.Count; ++index)
            {
                int currentLength = strings[index].Length;
                if (currentLength > maximalLength)
                {
                    maximalLength = currentLength;
                }
            }
            Console.Write("Все элементы\t");
            for (int index = 0; index < universum.Elements.Count; ++index)
            {
                Console.Write($"{universum.Elements[index]}");
                if (index + 1 != universum.Elements.Count)
                {
                    Console.Write('\t');
                }
            }
            Console.Write('\n');
            for (int number = 1; number <= columns.Count; ++number)
            {
                BelongingColumn currentColumn = columns[number - 1];
                Console.Write($"{currentColumn.Name}\t");
                for (int index = 0; index < currentColumn.Elements.Count; ++index)
                {
                    Console.Write($"{currentColumn.Elements[index]}");
                    if (index + 1 != currentColumn.Elements.Count)
                    {
                        Console.Write('\t');
                    }
                }
                Console.Write('\n');
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.Title = "Калькулятор множеств";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.InputEncoding = Encoding.Unicode;
            Console.Clear();
            bool isMenuNeeded = true;
            while (isMenuNeeded)
            {
                Console.WriteLine("1. Завершить работу консольного приложения.");
                Console.WriteLine("2. Создать новое множество.");
                Console.WriteLine("3. Вывести список всех множеств, созданных вручную.");
                Console.WriteLine("4. Узнать содержимое пользовательского набора.");
                Console.WriteLine("5. Показать универсальное множество.");
                Console.WriteLine("6. Визуализировать таблицу принадлежности элементов множествам.");
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
                            isMenuNeeded = false;
                            Console.WriteLine("Работа с программой завершена.");
                            break;
                        case 2:
                            program.CreateNewStringSet();
                            break;
                        case 3:
                            program.PrintManuallyMadeStringSets();
                            break;
                        case 4:
                            program.PrintManuallyMadeStringSets();
                            if (program.manuallyMadeStringSets.Count > 0)
                            {
                                program.PrintSetContentFromCustoms();
                            }
                            break;
                        case 5:
                            if (program.manuallyMadeStringSets.Count == 0)
                            {
                                Console.WriteLine("Для начала нужно создать хотя бы одно множество!");
                            }
                            else
                            {
                                program.SortCustomSets();
                                program.CalculateUniversum();
                                program.PrintSetContent(program.universum);
                            }
                            break;
                        case 6:
                            if (program.manuallyMadeStringSets.Count == 0)
                            {
                                Console.WriteLine("Для начала нужно создать хотя бы одно множество!");
                            }
                            else
                            {
                                program.SortCustomSets();
                                program.CalculateUniversum();
                                program.CreateColumns();
                                program.PrintBelongingTable();
                            }
                            break;
                        default:
                            Console.WriteLine("В списке отсутствует вариант с указанным идентификатором!");
                            break;
                    }
                }
                Console.Write("\nНажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}