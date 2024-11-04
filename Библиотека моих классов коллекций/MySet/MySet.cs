using System;
using MyGenericCollections.MyArray;

namespace MyGenericCollections
{
    namespace MySet
    {
        /// <summary>
        /// Представляет собой параметризованный набор.
        /// Копирует многую логику со своего базового класса MyArray.
        /// Имеет те же удобства, что и базовый класс, но реализован для работы с множествами.
        /// </summary>
        /// <remarks> Не наследуется. </remarks>
        public sealed class MySet<T> : MyArray<T>
        {
            // Перезапись унаследованных методов, которые могут быть некорректно применены к множеству.

            /// <summary> Работает также как и метод базового класса, но добавляет элемент только если он ещё не существует. </summary>
            /// <remarks> Не генерирует исключение, когда добавляемый элемент уже существует в множестве. </remarks>
            public override void AddElementToEnd(T value)
            {
                if (GetIndexOfFirstMatch(value) == -1)
                {
                    base.AddElementToEnd(value);
                }
            }

            /// <summary> Работает также как и метод базового класса, но вставляет элемент только если он ещё не существует. </summary>
            /// <remarks> Не генерирует исключение, когда вставляемый элемент уже существует в множестве. </remarks>
            public override void InsertElement(int index, T value)
            {
                if (GetIndexOfFirstMatch(value) == -1)
                {
                    base.InsertElement(index, value);
                }
            }

            /// <summary> Метод-индексатор. Доступно только чтение элементов внутреннего хранилища с помощью get. </summary>
            public override T this[int elementIndex]
            {
                get
                {
                    if (IsEmpty)
                    {
                        throw new Exception("Множество не содержит ни одного элемента!");
                    }
                    if (elementIndex < 0)
                    {
                        throw new Exception("Индексация с помощью отрицательных чисел не доступна!");
                    }
                    if (elementIndex >= Length)
                    {
                        throw new Exception("Элемента с указанным индексом не существует в множестве!");
                    }
                    return storage[elementIndex];
                }
            }



            /// <summary> Конструктор без параметров инициализирует объект пустым массивом. </summary>
            public MySet() => MakeEmpty();

            /// <summary> Конструктор копирования. </summary>
            public MySet(in MySet<T> otherObject)
            {
                if (otherObject == null)
                {
                    throw new ArgumentNullException("value", "Нельзя инициализировать новый объект по пустой ссылке!");
                }
                storage = new T[otherObject.Length];
                Array.Copy(otherObject.storage, storage, otherObject.Length);
            }

            /// <summary> Объединяет текущее множество с другим. </summary>
            /// <param name="otherMySet"> Множество, с которым нужно объединить. </param>
            public void Union(in MySet<T> otherMySet)
            {
                foreach (var item in otherMySet)
                {
                    AddElementToEnd(item);
                }
            }

            /// <summary> Пересекает текущее множество с другим. </summary>
            /// <param name="otherMySet"> Множество, с которым нужно пересечь. </param>
            public void Intersection(in MySet<T> otherMySet)
            {
                MySet<T> resultSet = new MySet<T>();
                foreach (var item in this)
                {
                    // Проверка на наличие элемента в другом множестве.
                    if (otherMySet.GetIndexOfFirstMatch(item) != -1)
                    {
                        // Добавление в результирующее множество.
                        resultSet.AddElementToEnd(item);
                    }
                }
                // Очистка текущего множества и запись в него элементов из результирующего.
                MakeEmpty();
                foreach (var item in resultSet)
                {
                    AddElementToEnd(item);
                }
            }

            /// <summary> Удаляет из текущего множества все элементы, которые содержатся в другом множестве. </summary>
            /// <param name="otherMySet"> Множество, элементы которого нужно удалить из текущего множества. </param>
            public void Difference(in MySet<T> otherMySet)
            {
                MySet<T> resultSet = new MySet<T>();

                // Происходит добавление элементов, которые есть в текущем множестве, но нет в другом.
                foreach (var item in this)
                {
                    if (otherMySet.GetIndexOfFirstMatch(item) == -1)
                    {
                        resultSet.AddElementToEnd(item);
                    }
                }

                // Очистка текущего множества и запись в него элементов из результирующего множества.
                MakeEmpty();
                foreach (var item in resultSet)
                {
                    AddElementToEnd(item);
                }
            }

            /// <summary> Выполняет симметрическую разность текущего множества с другим. </summary>
            /// <param name="otherMySet"> Множество, с которым нужно выполнить симметрическую разность. </param>
            public void SymmetricDifference(in MySet<T> otherMySet)
            {
                MySet<T> resultSet = new MySet<T>();

                // Происходит добавление элементов, которые есть в текущем множестве, но нет в другом.
                foreach (var item in this)
                {
                    if (otherMySet.GetIndexOfFirstMatch(item) == -1)
                    {
                        resultSet.AddElementToEnd(item);
                    }
                }

                // Происходит добавление элементов, которые есть в другом множестве, но нет в текущем.
                foreach (var item in otherMySet)
                {
                    if (GetIndexOfFirstMatch(item) == -1)
                    {
                        resultSet.AddElementToEnd(item);
                    }
                }

                // Очистка текущего множества и запись в него элементов из результирующего множества.
                MakeEmpty();
                foreach (var item in resultSet)
                {
                    AddElementToEnd(item);
                }
            }

            public override bool Equals(object otherObject)
            {
                if (otherObject is MySet<T> otherMySet)
                {
                    // Если длина различается, множества точно не равны.
                    if (Length != otherMySet.Length)
                    {
                        return false;
                    }

                    // Проверка, что каждый элемент текущего множества есть в другом множестве.
                    foreach (var item in this)
                    {
                        if (otherMySet.GetIndexOfFirstMatch(item) == -1)
                        {
                            return false;
                        }
                    }

                    return true;
                }
                return false;
            }

            public override int GetHashCode()
            {
                int hash = 0;
                foreach (var item in this)
                {
                    /* Здесь используется XOR для накопления хэш-кодов каждого элемента.
                    Это поможет получить одинаковый хэш-код для множеств с одинаковыми элементами,
                    даже если порядок различается */
                    hash ^= item?.GetHashCode() ?? 0;
                }
                return hash;
            }

            /// <summary> Общая проверка на равенство множеств. </summary>
            /// <remarks>
            /// Если оба множества — null, они равны.
            /// Если только одно из множеств — null, они не равны.
            /// Если ни одна из ссылок на множества не является null, используется метод Equals для сравнения.
            /// </remarks>
            /// <returns> Значение true, когда оба множества — null или равны по правилам метода Equals; иначе false. </returns>
            public static bool operator ==(MySet<T> left, MySet<T> right)
            {
                // Если оба множества — null, они равны.
                if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
                {
                    return true;
                }

                // Если только одно из множеств — null, они не равны.
                if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                {
                    return false;
                }

                // Использование метода Equals для сравнения.
                return left.Equals(right);
            }

            /// <summary> Общая проверка на неравенство множеств. </summary>
            /// <remarks> Использует функционал оператора ==. </remarks>
            public static bool operator !=(MySet<T> left, MySet<T> right)
            {
                return !(left == right);
            }

            /// <summary>
            /// Применяет метод ToString к элементам множества,
            /// чтобы получить строку с перечислением строковых представлений объектов,
            /// обрамлённую фигурными скобками.
            /// </summary>
            /// <remarks> Работает корректно только если метод ToString переопределён у объектов множества. </remarks>
            public override string ToString()
            {
                if (IsEmpty)
                {
                    return "{}";
                }

                string result = "{";
                for (int index = 0; index < Length; index++)
                {
                    // Если элемент равен null, его представление отображается как "null".
                    result += this[index]?.ToString() ?? "null";
                    if (index < Length - 1)
                    {
                        result += ", ";
                    }
                }
                return result + "}";
            }
        }

        /// <summary>
        /// Статический класс, реализующий операции над двумя множествами.
        /// Любой метод возвращает новый объект класса MySet как результат одной из операций.
        /// </summary>
        public static class MySetOperations
        {
            /// <summary>
            /// Выполняет объединение двух множеств и возвращает новое множество,
            /// содержащее уникальные элементы из обоих множеств.
            /// </summary>
            /// <returns> Новое множество, содержащее все уникальные элементы из первого и второго множеств. </returns>
            public static MySet<T> GetUnion<T>(in MySet<T> firstSet, in MySet<T> secondSet)
            {
                MySet<T> resultSet = new MySet<T>();
                foreach (var item in firstSet)
                {
                    resultSet.AddElementToEnd(item);
                }
                foreach (var item in secondSet)
                {
                    resultSet.AddElementToEnd(item);
                }
                return resultSet;
            }

            /// <summary>
            /// Выполняет пересечение двух множеств и возвращает новое множество,
            /// содержащее только элементы, присутствующие в обоих множествах.
            /// </summary>
            /// <returns> Новое множество, содержащее только общие элементы из первого и второго множеств. </returns>
            public static MySet<T> GetIntersection<T>(in MySet<T> firstSet, in MySet<T> secondSet)
            {
                MySet<T> resultSet = new MySet<T>();
                foreach (var item in firstSet)
                {
                    if (secondSet.GetIndexOfFirstMatch(item) != -1)
                    {
                        resultSet.AddElementToEnd(item);
                    }
                }
                return resultSet;
            }

            /// <summary>
            /// Выполняет разность двух множеств и возвращает новое множество,
            /// содержащее элементы, присутствующие только в первом множестве и отсутствующие во втором.
            /// </summary>
            /// <param name="firstSet"> Множество, из которого будут исключены элементы, присутствующие во втором множестве. </param>
            /// <param name="secondSet"> Множество, элементы которого будут исключены из первого множества. </param>
            /// <returns> Новое множество, содержащее элементы, присутствующие только в первом множестве. </returns>
            public static MySet<T> GetDifference<T>(in MySet<T> firstSet, in MySet<T> secondSet)
            {
                MySet<T> resultSet = new MySet<T>();
                foreach (var item in firstSet)
                {
                    if (secondSet.GetIndexOfFirstMatch(item) == -1)
                    {
                        resultSet.AddElementToEnd(item);
                    }
                }
                return resultSet;
            }

            /// <summary>
            /// Выполняет симметрическую разность двух множеств и возвращает новое множество,
            /// содержащее элементы, присутствующие в одном из множеств, но не в обоих одновременно.
            /// </summary>
            /// <returns> Новое множество, содержащее элементы, присутствующие только в одном из двух множеств. </returns>
            public static MySet<T> GetSymmetricDifference<T>(in MySet<T> firstSet, in MySet<T> secondSet)
            {
                MySet<T> resultSet = new MySet<T>();

                // Добавление элементов из firstSet, которые отсутствуют во втором множестве.
                foreach (var item in firstSet)
                {
                    if (secondSet.GetIndexOfFirstMatch(item) == -1)
                    {
                        resultSet.AddElementToEnd(item);
                    }
                }

                // Добавление элементов из secondSet, которые отсутствуют в первом множестве.
                foreach (var item in secondSet)
                {
                    if (firstSet.GetIndexOfFirstMatch(item) == -1)
                    {
                        resultSet.AddElementToEnd(item);
                    }
                }

                return resultSet;
            }
        }
    }
}