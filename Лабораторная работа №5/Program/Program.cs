using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class MyOneDimensionalArray
    {
        /// <summary> Одномерный массив объекта MyOneDimensionalArray. </summary>
        private int[] data { get; set; }

        /// <summary> Сообщения ошибок, используемые для отклика в консоль при обработке исключительных ситуаций. </summary>
        private static class DebugMessages
        {
            public static class Russian
            {
                public static string negativeLength = "Выполнение метода приведёт к ошибке отрицательной длины массива!";
                public static string outOfRange = "В массиве нет элемента под указанным индексом!";
                public static string tooLong = "Выполнение метода приведёт к ошибке выхода за верхнюю границу числа int!";
                public static string negativeAbsoluteValue = "Абсолютное значение не должно быть отрицательным числом!";
                public static string absoluteValueByDefault = "В качестве абсолютного значения будет использоваться число 9!";
                public static string cautionAboutNegativeNumber = "В ходе генерации случайного числа может получится отрицательное!";
                public static string arrayBoundsByDefault = "При генерации случайной длины массива будет использоваться диапазон от 5 до 15!";
                public static string lengthLessThanMinimal = "Указанная точная длина для каждого элемента будет выбрана автоматически!";
            }
        }

        /// <summary>
        /// Конструктор объекта MyOneDimensionalArray с указанием длины.
        /// Массив объекта будет заполнен нулями.
        /// Количество нулей - указанная длина массива.
        /// </summary>
        public MyOneDimensionalArray(int size) { data = new int[size]; }

        /// <summary> Конструктор объекта MyOneDimensionalArray с использованием одномерного массива класса int. </summary>
        public MyOneDimensionalArray(int[] numbers) { data = numbers; }

        /// <summary> Конструктор копирования. </summary>
        public MyOneDimensionalArray(MyOneDimensionalArray otherArray) { data = otherArray.data; }

        /// <summary> Используется для получения копии массива data объекта MyOneDimensionalArray. </summary>
        public int[] GetData() { return data; }

        /// <summary> Используется для получения текущей длины массива объекта MyOneDimensionalArray. </summary>
        public int GetArrayLength() { return data.Length; }

        /// <summary> Метод-индексатор. Доступен get и set для элементов массива data объекта MyOneDimensionalArray. </summary>
        public int this[int elementIndex]
        {
            get
            {
                if (elementIndex < 0 || elementIndex >= data.Length)
                {
                    Console.WriteLine(DebugMessages.Russian.outOfRange);
                    return 0;
                }
                else
                {
                    return data[elementIndex];
                }
            }

            set
            {
                if (elementIndex < 0 || elementIndex >= data.Length)
                {
                    Console.WriteLine(DebugMessages.Russian.outOfRange);
                }
                else
                {
                    data[elementIndex] = value;
                }

            }
        }

        /// <summary> Удаляет элемент из массива объекта MyOneDimensionalArray, тем самым уменьшая его длину. </summary>
        /// <param name="elementIndex"> Индекс элемента, который должен быть удалён. </param>
        /// <returns> Возвращает true в случае достижения предполагаемого результата, иначе false. </returns>
        public bool RemoveElement(int elementIndex)
        {
            if (data.Length == 0)
            {
                Console.WriteLine(DebugMessages.Russian.negativeLength);
                return false;
            }
            if (elementIndex < 0 || elementIndex >= data.Length)
            {
                Console.WriteLine(DebugMessages.Russian.outOfRange);
                return false;
            }

            int[] newData = new int[data.Length - 1];
            int index = 0;

            // Копируем всё содержимое исходного массива данных в новый массив, исключая элемент под указанным индексом:

            // Увеличиваем index до тех пор, пока значение не будет соответствовать elementIndex;
            while (index < elementIndex)
            {
                newData[index] = data[index];
                index++;
            }
            // Пропускаем элемент под указанным индексом;
            index++;
            // Увеличиваем index, чтобы перебрать оставшиеся элементы исходного массива.
            while (index < data.Length)
            {
                newData[index - 1] = data[index];
                index++;
            }

            // Теперь объект класса MyOneDimensionalArray будет хранить в себе новый массив меньшей длины.
            data = newData;

            return true;
        }

        /// <summary> Вставляет элемент в массив объекта MyOneDimensionalArray, тем самым увеличивая его длину. </summary>
        /// <remarks> Грубо говоря, новый элемент встанет на указанный индекс в массиве, при этом сдвинет все остальные элементы после него вправо. </remarks>
        /// <param name="elementIndex"> Индекс элемента, на который должен встать новый элемент. </param>
        /// <returns> Возвращает true в случае достижения предполагаемого результата, иначе false. </returns>
        public bool InsertElement(int elementIndex, int value)
        {
            if (data.Length == int.MaxValue)
            {
                Console.WriteLine(DebugMessages.Russian.tooLong);
                return false;
            }
            if (elementIndex < 0 || elementIndex >= data.Length)
            {
                Console.WriteLine(DebugMessages.Russian.outOfRange);
                return false;
            }

            int[] newData = new int[data.Length + 1];
            int index = 0;

            /* Копируем всё содержимое исходного массива данных в новый массив,
            добавляя новый элемент под указанным индексом, и присваиваем ему значение: */

            // Увеличиваем index до тех пор, пока значение не будет соответствовать elementIndex;
            while (index < elementIndex)
            {
                newData[index] = data[index];
                index++;
            }
            // В элементе нового массива под указанным индексом будет записано переданное значение;
            newData[index] = value;
            // Увеличиваем index, чтобы перебрать оставшиеся элементы исходного массива.
            while (index < data.Length)
            {
                newData[index + 1] = data[index];
                index++;
            }

            // Теперь объект класса MyOneDimensionalArray будет хранить в себе новый массив большей длины.
            data = newData;

            return true;
        }

        /// <summary> Грубо говоря, добавляет новый элемент после конца массива объекта MyOneDimensionalArray, тем самым увеличивая его длину. </summary>
        public bool AddElementAfterArrayEnd(int value)
        {
            if (data.Length == int.MaxValue)
            {
                Console.WriteLine(DebugMessages.Russian.tooLong);
                return false;
            }

            int[] newData = new int[data.Length + 1];
            int index = 0;

            while (index < data.Length)
            {
                newData[index] = data[index];
                index++;
            }
            newData[index] = value;

            // Теперь объект класса MyOneDimensionalArray будет хранить в себе новый массив большей длины.
            data = newData;

            return true;
        }

        /// <summary>
        /// Перебирает все элементы массива, делая их случайными числами от 0 до maximalAbsoluteValue.
        /// Каждое новое случайное число может стать отрицательным, если оно не является нулём.
        /// </summary>
        /// <remarks>
        /// Если maximalAbsoluteValue будет отрицательным числом, метод сообщит об ошибке, но выполнит
        /// действия до конца, использовав maximalAbsoluteValue как число 9.
        /// </remarks>
        /// <param name="maximalAbsoluteValue"> Максимальное абсолютное значение для генерации чисел. </param>
        public void RandomizeData(int maximalAbsoluteValue)
        {
            if (maximalAbsoluteValue < 0)
            {
                Console.WriteLine(DebugMessages.Russian.negativeAbsoluteValue);
                Console.WriteLine(DebugMessages.Russian.absoluteValueByDefault);
                maximalAbsoluteValue = 9;
            }
            Random randomizer = new Random();
            for (int index = 0; index < data.Length; index++)
            {
                int newNumber = randomizer.Next(maximalAbsoluteValue);
                if (newNumber != 0)
                {
                    bool isNegativeNumber = false;
                    if (randomizer.Next(1) == 0)
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
        }

        /// <summary>
        /// Конструктор для создания случайного массива с указанием диапазона рандомизации длины и максимальным
        /// абсолютным значением, которое может быть использовано при генерации числа для каждого элемента массива.
        /// </summary>
        /// <remarks>
        /// Если в результате генерации случайной длины массива получится отрицательное число, обработчик сообщит ошибку,
        /// но будет дальше выполнять действия, используя leftBound как число 5 и rightBound как число 15.
        /// В дальнейших своих действиях конструктор использует метод RandomizeData(maximalAbsoluteValue).
        /// </remarks>
        /// <param name="leftBound"> Минимальная длина массива. </param>
        /// <param name="rightBound"> Максимальная длина массива. </param>
        /// <param name="maximalAbsoluteValue"> Абсолютное значение, которое использует метод RandomizeData. </param>
        public MyOneDimensionalArray(int leftBound, int rightBound, int maximalAbsoluteValue)
        {
            if (leftBound < 0 || rightBound < 0)
            {
                Console.WriteLine(DebugMessages.Russian.cautionAboutNegativeNumber);
            }
            Random randomizer = new Random();
            int arrayLength = randomizer.Next(leftBound, rightBound);
            if (arrayLength < 0)
            {
                Console.WriteLine(DebugMessages.Russian.negativeLength);
                Console.WriteLine(DebugMessages.Russian.arrayBoundsByDefault);
                arrayLength = randomizer.Next(5, 15);
            }
            data = new int[arrayLength];
            RandomizeData(maximalAbsoluteValue);
        }

        /// <summary> Конструктор без параметров для создания случайного массива, используя методы по умолчанию. </summary>
        public MyOneDimensionalArray()
        {
            Random randomizer = new Random();
            int arrayLength = randomizer.Next(5, 15);
            data = new int[arrayLength];
            RandomizeData(9);
        }

        /// <summary> Записывает все элементы массива через запятую в строку. Строка замыкается квадратными скобками. </summary>
        public override string ToString()
        {
            string result = "";
            int index = 0;
            while (index < data.Length)
            {
                result += data[index];
                index++;
                if (index != data.Length)
                {
                    result += ", ";
                }
            }
            return '[' + result + ']';
        }

        private string CompleteString(string stringValue, int preciseLength)
        {
            if (stringValue.Length < preciseLength)
            {
                int difference = preciseLength - stringValue.Length;
                // Добавление недостающих пробелов справа и слева.
                while (difference > 0)
                {
                    if (difference % 2 == 1)
                    {
                        stringValue = ' ' + stringValue;
                    }
                    else
                    {
                        stringValue += ' ';
                    }
                    difference--;
                }
            }
            return stringValue;
        }

        public void PrintDataIntoConsole(int preciseLength)
        {
            int minamalLength = 0;
            foreach (int elementValue in data)
            {
                int currentLength = elementValue.ToString().Length;
                if (currentLength > minamalLength)
                {
                    minamalLength = currentLength;
                }
            }
            int lengthForEachElement = preciseLength;
            if (preciseLength < minamalLength)
            {
                Console.WriteLine(DebugMessages.Russian.lengthLessThanMinimal);
                lengthForEachElement = minamalLength;
            }

            int index = 0;
            while (index < data.Length)
            {
                Console.Write(CompleteString(data[index].ToString(), lengthForEachElement));
                index++;
                if (index != data.Length)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("\n");
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyOneDimensionalArray numbers = new MyOneDimensionalArray(10, 20, 2000);

            Console.WriteLine(numbers.ToString());
            numbers.PrintDataIntoConsole(0);

            numbers.AddElementAfterArrayEnd(1488);
            Console.WriteLine(numbers.ToString());

            numbers.RemoveElement(0);
            Console.WriteLine(numbers.ToString());

            numbers.RandomizeData(9);
            Console.WriteLine(numbers.ToString());

            Console.ReadKey();
        }
    }
}
