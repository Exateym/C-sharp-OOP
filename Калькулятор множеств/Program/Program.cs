using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        public StringSet(StringSet reference)
        {
            Name = reference.Name;
            Elements = new List<string>(reference.Elements);
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
        string RequestNameForNewSet()
        {
            string newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName))
            {
                Console.WriteLine("Название должно быть корректным!");
                return null;
            }
            for (int index = 0; index < manuallyMadeStringSets.Count; ++index)
            {
                if (newName == manuallyMadeStringSets[index].Name)
                {
                    Console.WriteLine("Множество с указанным именем уже существует!");
                    return null;
                }
            }
            return newName;
        }
        void CreateNewStringSet()
        {
            Console.Write("Введите название нового множетсва: ");
            string newName = RequestNameForNewSet();
            if (newName == null)
            {
                return;
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
        // Функция теперь возвращает значение, чтобы её можно было внедрить в другие места
        StringSet PrintSetContentFromCustoms()
        {
            Console.Write("\nВведите номер множества из списка: ");
            int number;
            bool isSuitableValue = int.TryParse(Console.ReadLine(), out number);
            if (!isSuitableValue)
            {
                Console.WriteLine("Входные данные не могут быть преобразованы в ожидаемый тип!");
                return null;
            }
            int index = number - 1;
            if (index < 0 || index > manuallyMadeStringSets.Count - 1)
            {
                Console.WriteLine("В списке отсутствует набор под указанным номером!");
                return null;
            }
            StringSet stringSet = manuallyMadeStringSets[index];
            Console.Write('\n');
            PrintSetContent(stringSet);
            return stringSet;
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
                int difference = simbolsAmount - len;
                // Добавление недостающих пробелов справа и слева
                while (difference > 0)
                {
                    if (difference % 2 == 1)
                    {
                        str = ' ' + str;
                    }
                    else
                    {
                        str += ' ';
                    }
                    difference--;
                }
            }
            return str;
        }
        void PrintBelongingTable()
        {
            /* Поиск наибольшей длины строки. Сначала все строки, которые будут выведены в таблицу,
            записываются в strings (экземпляр класса List). Затем происходит поиск наибольшей длины среди них */
            List<String> strings = new List<string>();
            strings.Add("Все элементы");
            strings.Add("Универсальное множество");
            strings.Add("Пустое элементы");
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

            // Вывод таблицы в консоль

            // Вывод названий всех элементов из универсума
            Console.Write(CompleteString("Все элементы", maximalLength));
            Console.Write(' ');
            for (int index = 0; index < universum.Elements.Count; ++index)
            {
                Console.Write(CompleteString(universum.Elements[index].ToString(), maximalLength));
                if (index + 1 != universum.Elements.Count)
                {
                    Console.Write(' ');
                }
            }
            Console.Write('\n');

            // Вывод столбцов, которые показывают принадлежность элементов универсума множествам
            for (int number = 1; number <= columns.Count; ++number)
            {
                BelongingColumn currentColumn = columns[number - 1];
                Console.Write(CompleteString(currentColumn.Name, maximalLength));
                for (int index = 0; index < currentColumn.Elements.Count; ++index)
                {
                    Console.Write(CompleteString(currentColumn.Elements[index].ToString(), maximalLength));
                    if (index + 1 != currentColumn.Elements.Count)
                    {
                        Console.Write(' ');
                    }
                }
                Console.Write('\n');
            }
        }
        BelongingColumn FindColumnByName(string name)
        {
            BelongingColumn column = null;
            int amount = columns.Count;
            bool wasFound = false;
            for (int index = 0; index < amount && !wasFound; ++index)
            {
                if (columns[index].Name == name)
                {
                    column = columns[index];
                    wasFound = true;
                }
            }
            return column;
        }
        BelongingColumn RequestForColumn()
        {
            StringSet selectedSet = PrintSetContentFromCustoms();
            if (selectedSet == null)
            {
                Console.WriteLine("Ссылка на объект не найдена!");
                return null;
            }
            return FindColumnByName(selectedSet.Name);
        }
        List<BelongingColumn> RequestForBinaryOperation()
        {
            if (manuallyMadeStringSets.Count < 2)
            {
                Console.WriteLine("Выполнение этого действия подразумевает наличие хотя бы двух созданных множеств!");
                return null;
            }
            PrintManuallyMadeStringSets();
            BelongingColumn firstColumn = RequestForColumn();
            if (firstColumn == null)
            {
                Console.WriteLine("Ошибка при получении ссылки на первый объект операции!");
                return null;
            }
            BelongingColumn secondColumn = RequestForColumn();
            if (secondColumn == null)
            {
                Console.WriteLine("Ошибка при получении ссылки на второй объект операции!");
                return null;
            }
            List<BelongingColumn> columns = new List<BelongingColumn>
            {
                firstColumn,
                secondColumn
            };
            return columns;
        }
        void Amalgamation(BelongingColumn firstCollumn, BelongingColumn secondColumn, string newStringSetName)
        {
            List<bool> values = new List<bool>();
            for (int index = 0; index < universum.Elements.Count; index++)
            {
                values.Add(firstCollumn.Elements[index] || secondColumn.Elements[index]);
            }
            List<string> elementNames = new List<string>();
            for (int index = 0; index < universum.Elements.Count; index++)
            {
                if (values[index])
                {
                    elementNames.Add(universum.Elements[index]);
                }
            }
            StringSet newSet = new StringSet(newStringSetName, elementNames);
            manuallyMadeStringSets.Add(newSet);
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
                Console.WriteLine("7. Произвести операцию объединения множеств.");
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
                            // Переставил повторяющиеся вызовы методов после появления нового множества
                            program.CreateNewStringSet();
                            program.SortCustomSets();
                            program.CalculateUniversum();
                            program.CreateColumns();
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
                                program.PrintBelongingTable();
                            }
                            break;
                        case 7:
                            List<BelongingColumn> columns = program.RequestForBinaryOperation();
                            if (columns == null)
                            {
                                Console.WriteLine("Ошибка при выполнении операции объединения!");
                            }
                            else
                            {
                                Console.Write("Введите уникальное название для нового множества - результата объединения: ");
                                string newName = program.RequestNameForNewSet();
                                if (newName == null)
                                {
                                    Console.WriteLine("Ошибка с именем результата операции!");
                                }
                                else
                                {
                                    BelongingColumn firstColumn = columns[0];
                                    BelongingColumn secondColumn = columns[1];
                                    program.Amalgamation(firstColumn, secondColumn, newName);
                                    Console.WriteLine("\nУспешно создан результат объединениения двух множеств:");
                                    Console.WriteLine($"{firstColumn.Name} и {firstColumn.Name} в {newName}");
                                    program.SortCustomSets();
                                    program.CalculateUniversum();
                                    program.CreateColumns();
                                }
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