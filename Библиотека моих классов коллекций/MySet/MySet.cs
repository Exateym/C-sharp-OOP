using System;
using MyGenericCollections.MyArray;

namespace MyGenericCollections
{
    namespace MySet
    {
        public class MySet<T> : MyArray<T>
        {
            // Скрытие или перезапись унаследованных методов, которые могут быть некорректно применены к множеству.
            private new void AddElementToEnd(T value) { }
            private new void InsertElement(int index, T value) { }

            /// <summary> Метод-индексатор. Доступно только чтение элементов внутреннего хранилища с помощью get. </summary>
            public new T this[int elementIndex]
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



            /// <summary> Добавляет элемент в множество, если он ещё не существует. </summary>
            /// <remarks> Не генерирует исключение, когда добавляемый элемент уже существует в множестве. </remarks>
            /// <param name="value"> Значение, которое нужно добавить. </param>
            public void AddElement(T value)
            {
                if (GetIndexOfFirstMatch(value) == -1)
                {
                    base.AddElementToEnd(value);
                }
            }

            /// <summary> Объединяет текущее множество с другим. </summary>
            /// <param name="otherSet"> Множество, с которым нужно объединить. </param>
            public void Union(in MySet<T> otherSet)
            {
                for (int index = 0; index < otherSet.Length; index++)
                {
                    AddElement(otherSet[index]);
                }
            }

            /// <summary> Пересекает текущее множество с другим. </summary>
            /// <param name="otherSet"> Множество, с которым нужно пересечь. </param>
            public void Intersection(in MySet<T> otherSet)
            {
                MySet<T> resultSet = new MySet<T>();
                for (int index = 0; index < Length; index++)
                {
                    // Проверка на наличие элемента в другом множестве.
                    if (otherSet.GetIndexOfFirstMatch(this[index]) != -1)
                    {
                        // Добавление в результирующее множество.
                        resultSet.AddElement(this[index]);
                    }
                }
                // Очистка текущего множества и запись в него элементов из результирующего.
                MakeEmpty();
                for (int index = 0; index < resultSet.Length; index++)
                {
                    AddElement(resultSet[index]);
                }
            }

            /// <summary> Удаляет из текущего множества все элементы, которые содержатся в другом множестве. </summary>
            /// <param name="otherSet"> Множество, элементы которого нужно удалить из текущего множества. </param>
            public void Difference(in MySet<T> otherSet)
            {
                MySet<T> resultSet = new MySet<T>();

                // Происходит добавление элементов, которые есть в текущем множестве, но нет в другом.
                for (int index = 0; index < Length; index++)
                {
                    if (otherSet.GetIndexOfFirstMatch(this[index]) == -1)
                    {
                        resultSet.AddElement(this[index]);
                    }
                }

                // Очистка текущего множества и запись в него элементов из результирующего множества.
                MakeEmpty();
                for (int index = 0; index < resultSet.Length; index++)
                {
                    AddElement(resultSet[index]);
                }
            }

            /// <summary> Выполняет симметрическую разность текущего множества с другим. </summary>
            /// <param name="otherSet"> Множество, с которым нужно выполнить симметрическую разность. </param>
            public void SymmetricDifference(in MySet<T> otherSet)
            {
                MySet<T> resultSet = new MySet<T>();

                // Происходит добавление элементов, которые есть в текущем множестве, но нет в другом.
                for (int index = 0; index < Length; index++)
                {
                    if (otherSet.GetIndexOfFirstMatch(this[index]) == -1)
                    {
                        resultSet.AddElement(this[index]);
                    }
                }

                // Происходит добавление элементов, которые есть в другом множестве, но нет в текущем.
                for (int index = 0; index < otherSet.Length; index++)
                {
                    if (GetIndexOfFirstMatch(otherSet[index]) == -1)
                    {
                        resultSet.AddElement(otherSet[index]);
                    }
                }

                // Очистка текущего множества и запись в него элементов из результирующего множества.
                MakeEmpty();
                for (int index = 0; index < resultSet.Length; index++)
                {
                    AddElement(resultSet[index]);
                }
            }

            public override bool Equals(object otherObject)
            {
                if (otherObject is MySet<T> otherSet)
                {
                    // Если длина различается, множества точно не равны.
                    if (Length != otherSet.Length)
                    {
                        return false;
                    }

                    // Проверка, что каждый элемент текущего множества есть в другом множестве.
                    for (int index = 0; index < Length; index++)
                    {
                        if (otherSet.GetIndexOfFirstMatch(this[index]) == -1)
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
                for (int index = 0; index < Length; index++)
                {
                    /* Здесь используется XOR для накопления хэш-кодов каждого элемента.
                    Это поможет получить одинаковый хэш-код для множеств с одинаковыми элементами,
                    даже если порядок различается */
                    hash ^= this[index]?.GetHashCode() ?? 0;
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
                resultSet.Union(firstSet);
                resultSet.Union(secondSet);
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
                for (int index = 0; index < firstSet.Length; index++)
                {
                    if (secondSet.GetIndexOfFirstMatch(firstSet[index]) != -1)
                    {
                        resultSet.AddElement(firstSet[index]);
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
                for (int index = 0; index < firstSet.Length; index++)
                {
                    if (secondSet.GetIndexOfFirstMatch(firstSet[index]) == -1)
                    {
                        resultSet.AddElement(firstSet[index]);
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
                for (int index = 0; index < firstSet.Length; index++)
                {
                    if (secondSet.GetIndexOfFirstMatch(firstSet[index]) == -1)
                    {
                        resultSet.AddElement(firstSet[index]);
                    }
                }
                for (int index = 0; index < secondSet.Length; index++)
                {
                    if (firstSet.GetIndexOfFirstMatch(firstSet[index]) == -1)
                    {
                        resultSet.AddElement(secondSet[index]);
                    }
                }
                return resultSet;
            }
        }
    }
}