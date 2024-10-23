using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace MyArrays
{
    public class MyOneDimensionalArray<T>
    {
        /// <summary> Внутреннее хранилище данных - одномерный массив. </summary>
        private T[] data;

        /// <summary> Конструктор может использовать как массив, так и несколько отдельных значений, передаваемых в качестве параметров. </summary>
        public MyOneDimensionalArray(params T[] items) { data = items; }

        /// <summary> Конструктор копирования. </summary>
        public MyOneDimensionalArray(MyOneDimensionalArray<T> otherObject) { data = otherObject.data; }

        /// <summary> Используется для получения копии хранилища данных. </summary>
        /// <returns> Одномерный массив. </returns>
        public T[] GetData() { return data; }

        /// <summary> Используется для получения количества элементов массива. </summary>
        public int GetLength() { return data.Length; }

        /// <summary> Делает массив пустым. </summary>
        public void MakeEmpty() { data = new T[0]; }

        /// <summary> Для локализации сообщений исключительных ситуаций. </summary>
        private static ResourceManager resourceManager = new ResourceManager("MyArrays.DebugMessages", typeof(MyOneDimensionalArray<T>).Assembly);

        /// <summary> Метод-индексатор. Доступен get и set для элементов внутреннего хранилища данных. </summary>
        public T this[int elementIndex]
        {
            get
            {
                if (data.Length == 0)
                {
                    throw new Exception(resourceManager.GetString("emptyArray", CultureInfo.CurrentCulture));
                }
                if (elementIndex < 0)
                {
                    throw new Exception(resourceManager.GetString("negativeIndexing", CultureInfo.CurrentCulture));
                }
                if (elementIndex >= data.Length)
                {
                    throw new Exception(resourceManager.GetString("outOfRange", CultureInfo.CurrentCulture));
                }
                return data[elementIndex];
            }

            set
            {
                if (data.Length == 0)
                {
                    throw new Exception(resourceManager.GetString("emptyArray", CultureInfo.CurrentCulture));
                }
                if (elementIndex < 0)
                {
                    throw new Exception(resourceManager.GetString("negativeIndexing", CultureInfo.CurrentCulture));
                }
                if (elementIndex >= data.Length)
                {
                    throw new Exception(resourceManager.GetString("outOfRange", CultureInfo.CurrentCulture));
                }
                data[elementIndex] = value;
            }
        }

        /// <summary> Удаляет элемент, уменьшая длину массива. </summary>
        /// <remarks> Все элементы, идущие после удалённого смещаются влево. </remarks>
        /// <param name="elementIndex"> Индекс элемента, который должен быть удалён. </param>
        public void RemoveElement(int elementIndex)
        {
            if (data.Length == 0)
            {
                throw new Exception(resourceManager.GetString("negativeLength", CultureInfo.CurrentCulture));
            }
            if (elementIndex < 0)
            {
                throw new Exception(resourceManager.GetString("negativeIndexing", CultureInfo.CurrentCulture));
            }
            if (elementIndex >= data.Length)
            {
                throw new Exception(resourceManager.GetString("outOfRange", CultureInfo.CurrentCulture));
            }

            T[] newData = new T[data.Length - 1];
            int index = 0;

            // Копируем всё содержимое исходного массива в новый массив, исключая элемент под указанным индексом:

            // Увеличиваем index до тех пор, пока значение не будет соответствовать elementIndex;
            while (index < elementIndex)
            {
                newData[index] = data[index];
                index++;
            }

            // Пропускаем элемент под указанным индексом;
            index++;

            // Увеличиваем index, чтобы скопировать оставшиеся элементы исходного массива.
            while (index < data.Length)
            {
                newData[index - 1] = data[index];
                index++;
            }

            data = newData;
        }

        /// <summary> Вставляет элемент, увеличивая длину массива. </summary>
        /// <remarks> Новый элемент встаёт на позицию уже существующего, сдвигая его и все последующие элементы вправо. </remarks>
        /// <param name="elementIndex"> Индекс, на который должен встать новый элемент. </param>
        /// <param name="value"> Значение нового элемента. </param>
        public void InsertElement(int elementIndex, T value)
        {
            if (data.Length == int.MaxValue)
            {
                throw new Exception(resourceManager.GetString("tooLong", CultureInfo.CurrentCulture));
            }
            if (elementIndex < 0)
            {
                throw new Exception(resourceManager.GetString("negativeIndexing", CultureInfo.CurrentCulture));
            }
            if (elementIndex >= data.Length)
            {
                throw new Exception(resourceManager.GetString("outOfRange", CultureInfo.CurrentCulture));
            }

            T[] newData = new T[data.Length + 1];
            int index = 0;

            // Копируем всё содержимое исходного массива данных в новый массив, учитывая новый элемент для подстановки под указанный индекс:

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

            data = newData;
        }

        /// <summary> Добавляет элемент, увеличивая длину массива. </summary>
        /// <remarks> Новый элемент будет являться новым концом массива. </remarks>
        /// <param name="value"> Значение нового элемента. </param>
        public void AddElementToEnd(T value)
        {
            if (data.Length == int.MaxValue)
            {
                throw new Exception(resourceManager.GetString("tooLong", CultureInfo.CurrentCulture));
            }

            T[] newData = new T[data.Length + 1];
            int index = 0;
            while (index < data.Length)
            {
                newData[index] = data[index];
                index++;
            }
            newData[index] = value;
            data = newData;
        }
    }
}
