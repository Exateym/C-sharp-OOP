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

    public class MyMatrix<T>
    {
        /// <summary> Внутреннее хранилище данных - массив из объектов класса MyOneDimensionalArray. </summary>
        MyOneDimensionalArray<T>[] data;

        /// <summary> Конструктор пустого массива. </summary>
        public MyMatrix() { data = new MyOneDimensionalArray<T>[0]; }

        /// <summary> Конструктор может использовать как массив, так и несколько отдельных значений, передаваемых в качестве параметров. </summary>
        public MyMatrix(params MyOneDimensionalArray<T>[] items) { data = items; }

        /// <summary> Конструктор копирования. </summary>
        public MyMatrix(MyMatrix<T> otherObject)
        {
            data = new MyOneDimensionalArray<T>[otherObject.GetQuantityOfRows()];
            for (int i = 0; i < otherObject.GetQuantityOfRows(); i++)
            {
                data[i] = new MyOneDimensionalArray<T>(otherObject.GetRow(i).GetData());
            }
        }

        /// <summary> Используется для получения копии хранилища данных. </summary>
        /// <returns> Массив из объектов класса MyOneDimensionalArray. </returns>
        public MyOneDimensionalArray<T>[] GetData() { return data; }

        /// <summary> Узнать количество строк в матрице. </summary>
        public int GetQuantityOfRows() { return data.Length; }

        /// <summary> Узнать количество столбцов в матрице. </summary>
        public int GetQuantityOfColumns()
        {
            if (data.Length == 0)
            {
                return 0;
            }
            else
            {
                // Берётся только самая первая строка матрицы, так как все остальные, если они есть, имеют ту же длину.
                return data[0].GetLength();
            }
        }

        /// <summary> Найти количество ячеек матрицы. </summary>
        public int GetQuantityOfCells() { return GetQuantityOfRows() * GetQuantityOfColumns(); }

        /// <summary> Делает массив пустым. </summary>
        public void MakeEmpty() { data = new MyOneDimensionalArray<T>[0]; }

        /// <summary> Для локализации сообщений исключительных ситуаций. </summary>
        private static ResourceManager resourceManager = new ResourceManager("MyArrays.DebugMessages", typeof(MyOneDimensionalArray<T>).Assembly);

        /// <summary> Метод-индексатор для доступа к элементам матрицы. </summary>
        public T this[int rowIndex, int columnIndex]
        {
            get
            {
                if (data.Length == 0)
                {
                    throw new Exception(resourceManager.GetString("emptyArray", CultureInfo.CurrentCulture));
                }
                if (rowIndex < 0 || columnIndex < 0)
                {
                    throw new Exception(resourceManager.GetString("negativeIndexing", CultureInfo.CurrentCulture));
                }
                if (rowIndex >= GetQuantityOfRows() || columnIndex >= GetQuantityOfColumns())
                {
                    throw new Exception(resourceManager.GetString("outOfRange", CultureInfo.CurrentCulture));
                }
                return data[rowIndex][columnIndex];
            }

            set
            {
                if (data.Length == 0)
                {
                    throw new Exception(resourceManager.GetString("emptyArray", CultureInfo.CurrentCulture));
                }
                if (rowIndex < 0 || columnIndex < 0)
                {
                    throw new Exception(resourceManager.GetString("negativeIndexing", CultureInfo.CurrentCulture));
                }
                if (rowIndex >= GetQuantityOfRows() || columnIndex >= GetQuantityOfColumns())
                {
                    throw new Exception(resourceManager.GetString("outOfRange", CultureInfo.CurrentCulture));
                }
                data[rowIndex][columnIndex] = value;
            }
        }

        /// <summary> Получение строки матрицы. </summary>
        public MyOneDimensionalArray<T> GetRow(int rowIndex)
        {
            if (rowIndex < 0)
            {
                throw new Exception(resourceManager.GetString("negativeIndexing", CultureInfo.CurrentCulture));
            }
            if (rowIndex >= GetQuantityOfRows())
            {
                throw new Exception(resourceManager.GetString("outOfRange", CultureInfo.CurrentCulture));
            }
            return data[rowIndex];
        }

        public void RemoveRow(int rowIndex)
        {
            if (data.Length == 0)
            {
                throw new Exception(resourceManager.GetString("negativeLength", CultureInfo.CurrentCulture));
            }
            if (rowIndex < 0)
            {
                throw new Exception(resourceManager.GetString("negativeIndexing", CultureInfo.CurrentCulture));
            }
            if (rowIndex >= GetQuantityOfRows())
            {
                throw new Exception(resourceManager.GetString("outOfRange", CultureInfo.CurrentCulture));
            }

            MyOneDimensionalArray<T>[] newData = new MyOneDimensionalArray<T>[data.Length - 1];
            int index = 0;

            // Копируем строки до указанного индекса
            while (index < rowIndex)
            {
                newData[index] = data[index];
                index++;
            }

            // Пропускаем удаляемую строку и копируем оставшиеся строки
            index++;
            while (index < data.Length)
            {
                newData[index - 1] = data[index];
                index++;
            }

            data = newData;
        }

        /// <summary> Добавляет строку в конец матрицы. </summary>
        /// <param name="newRow"> Новая строка, которая будет добавлена. </param>
        public void AddRowToEnd(MyOneDimensionalArray<T> newRow)
        {
            if (data.Length > 0 && newRow.GetLength() != GetQuantityOfColumns())
            {
                throw new Exception(resourceManager.GetString("inconsistentColumnLength", CultureInfo.CurrentCulture));
            }

            MyOneDimensionalArray<T>[] newData = new MyOneDimensionalArray<T>[data.Length + 1];

            // Копируем все существующие строки.
            for (int i = 0; i < data.Length; i++)
            {
                newData[i] = data[i];
            }

            // Добавляем новую строку в конец.
            newData[data.Length] = newRow;

            data = newData;
        }

        /// <summary> Вставляет строку на указанный индекс в матрице. </summary>
        /// <param name="rowIndex"> Индекс, на который нужно вставить новую строку. </param>
        /// <param name="newRow"> Новая строка, которая будет вставлена. </param>
        public void InsertRow(int rowIndex, MyOneDimensionalArray<T> newRow)
        {
            if (rowIndex < 0 || rowIndex > data.Length)
            {
                throw new Exception(resourceManager.GetString("outOfRange", CultureInfo.CurrentCulture));
            }
            if (data.Length > 0 && newRow.GetLength() != GetQuantityOfColumns())
            {
                throw new Exception(resourceManager.GetString("inconsistentColumnLength", CultureInfo.CurrentCulture));
            }

            MyOneDimensionalArray<T>[] newData = new MyOneDimensionalArray<T>[data.Length + 1];

            // Копируем строки до указанного индекса.
            for (int i = 0; i < rowIndex; i++)
            {
                newData[i] = data[i];
            }

            // Вставляем новую строку на указанный индекс.
            newData[rowIndex] = newRow;

            // Копируем оставшиеся строки после указанного индекса.
            for (int i = rowIndex; i < data.Length; i++)
            {
                newData[i + 1] = data[i];
            }

            data = newData;
        }

        /// <summary> Удаляет столбец по индексу. </summary>
        public void RemoveColumn(int columnIndex)
        {
            if (GetQuantityOfColumns() == 0)
            {
                throw new Exception(resourceManager.GetString("negativeLength", CultureInfo.CurrentCulture));
            }
            if (columnIndex < 0)
            {
                throw new Exception(resourceManager.GetString("negativeIndexing", CultureInfo.CurrentCulture));
            }
            if (columnIndex >= GetQuantityOfColumns())
            {
                throw new Exception(resourceManager.GetString("outOfRange", CultureInfo.CurrentCulture));
            }

            foreach (var row in data)
            {
                row.RemoveElement(columnIndex); // Удаляем элемент из каждой строки по указанному индексу
            }
        }

        /// <summary> Добавляет новый столбец в конец матрицы. </summary>
        /// <param name="newColumnData"> Массив элементов, который станет новым столбцом. </param>
        public void AddColumnToEnd(MyOneDimensionalArray<T> newColumn)
        {
            // Проверка на наличие строк в матрице
            if (data.Length == 0)
            {
                throw new Exception("Невозможно добавить столбец в пустую матрицу! Добавьте хотя бы одну строку!");
            }

            // Проверка соответствия количества элементов в новом столбце количеству строк
            if (newColumn.GetLength() != GetQuantityOfRows())
            {
                throw new Exception("Количество элементов в новом столбце должно совпадать с количеством строк в матрице!");
            }

            // Добавление элемента в конец каждой строки
            for (int i = 0; i < GetQuantityOfRows(); i++)
            {
                data[i].AddElementToEnd(newColumn[i]);
            }
        }

        /// <summary> Вставляет новый столбец по указанному индексу. </summary>
        /// <param name="columnIndex"> Индекс, по которому будет вставлен новый столбец. </param>
        /// <param name="newColumnData"> Массив элементов, который станет новым столбцом. </param>
        public void InsertColumn(int columnIndex, MyOneDimensionalArray<T> newColumnData)
        {
            if (newColumnData.GetLength() != GetQuantityOfRows())
            {
                throw new Exception(resourceManager.GetString("mismatchRows", CultureInfo.CurrentCulture));
            }
            if (columnIndex < 0)
            {
                throw new Exception(resourceManager.GetString("negativeIndexing", CultureInfo.CurrentCulture));
            }
            if (columnIndex > GetQuantityOfColumns())
            {
                throw new Exception(resourceManager.GetString("outOfRange", CultureInfo.CurrentCulture));
            }

            for (int rowIndex = 0; rowIndex < GetQuantityOfRows(); rowIndex++)
            {
                data[rowIndex].InsertElement(columnIndex, newColumnData[rowIndex]); // Вставляем элемент в каждую строку по индексу
            }
        }
    }

    public class MyRaggedArray<T>
    {
        private MyOneDimensionalArray<T>[] data;

        public MyRaggedArray(params MyOneDimensionalArray<T>[] rows)
        {
            data = rows;
        }

        public MyRaggedArray(MyRaggedArray<T> otherObject)
        {
            data = otherObject.data;
        }

        public MyOneDimensionalArray<T>[] GetData()
        {
            return data;
        }

        public int CountRows()
        {
            return data.Length;
        }

        public int CountElements()
        {
            int totalCount = 0;
            for (int rowIndex = 0; rowIndex < data.Length; rowIndex++)
            {
                totalCount += data[rowIndex].GetLength();
            }
            return totalCount;
        }

        public void MakeEmpty()
        {
            data = new MyOneDimensionalArray<T>[0];
        }

        public MyOneDimensionalArray<T> GetRow(int rowIndex)
        {
            if (data.Length == 0)
            {
                throw new Exception("В массиве нет ни одного элемента!");
            }
            if (rowIndex < 0)
            {
                throw new Exception("Нельзя применить отрицательную индексацию!");
            }
            if (rowIndex >= data.Length)
            {
                throw new Exception("В массиве нет элемента с указанным индексом!");
            }
            return data[rowIndex];
        }

        public T this[int rowIndex, int elementIndex]
        {
            get
            {
                if (data.Length == 0)
                {
                    throw new Exception("В массиве нет ни одного элемента!");
                }
                if (rowIndex < 0 || elementIndex < 0)
                {
                    throw new Exception("Нельзя применить отрицательную индексацию!");
                }
                if (data[rowIndex].GetLength() >= elementIndex)
                {
                    throw new Exception("В массиве по строке нет элемента с указанным индексом!");
                }
                return data[rowIndex][elementIndex];
            }

            set
            {
                if (data.Length == 0)
                {
                    throw new Exception("В массиве нет ни одного элемента!");
                }
                if (rowIndex < 0 || elementIndex < 0)
                {
                    throw new Exception("Нельзя применить отрицательную индексацию!");
                }
                if (data[rowIndex].GetLength() >= elementIndex)
                {
                    throw new Exception("В массиве по строке нет элемента с указанным индексом!");
                }
                data[rowIndex][elementIndex] = value;
            }
        }

        public void RemoveRow(int rowIndex)
        {
            if (data.Length == 0)
            {
                throw new Exception("Нельзя создать массив отрицательной длины!");
            }
            if (rowIndex < 0)
            {
                throw new Exception("Нельзя применить отрицательную индексацию!");
            }
            if (rowIndex >= data.Length)
            {
                throw new Exception("В массиве нет элемента с указанным индексом!");
            }

            MyOneDimensionalArray<T>[] newData = new MyOneDimensionalArray<T>[data.Length - 1];
            int index = 0;
            while (index < rowIndex)
            {
                newData[index] = data[index];
                index++;
            }
            index++;
            while (index < data.Length)
            {
                newData[index - 1] = data[index];
                index++;
            }
            data = newData;
        }

        public void AddRowToEnd(MyOneDimensionalArray<T> newRow)
        {
            if (data.Length == int.MaxValue)
            {
                throw new Exception("Нельзя создать массив длиной больше, чем int.MaxValue!");
            }

            MyOneDimensionalArray<T>[] newData = new MyOneDimensionalArray<T>[data.Length + 1];
            for (int index = 0; index < data.Length; index++)
            {
                newData[index] = data[index];
            }
            newData[data.Length] = newRow;
            data = newData;
        }

        public void InsertRow(int rowIndex, MyOneDimensionalArray<T> newRow)
        {
            if (rowIndex < 0)
            {
                throw new Exception("Нельзя применить отрицательную индексацию!");
            }
            if (rowIndex >= data.Length)
            {
                throw new Exception("В массиве нет элемента с указанным индексом!");
            }

            MyOneDimensionalArray<T>[] newData = new MyOneDimensionalArray<T>[data.Length + 1];
            for (int index = 0; index < rowIndex; index++)
            {
                newData[index] = data[index];
            }
            newData[rowIndex] = newRow;
            for (int index = rowIndex; index < data.Length; index++)
            {
                newData[index + 1] = data[index];
            }
            data = newData;
        }
    }
}
