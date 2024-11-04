using System;
// Подключение интерфейса IEnumerator для Array из пространства имён обобщённых коллекций с целью поддержки функционала foreach. 
using System.Collections.Generic;

namespace MyGenericCollections
{
    namespace MyArray
    {
        /// <summary>
        /// Представляет собой параметризованный массив.
        /// Есть методы добавления, вставки и удаления по индексу, которые могут изменять длину массива.
        /// Для удобства использования есть свойства и метод-индексатор.
        /// Кроме всего этого, перегружены многие методы базового класса Object и доступны операторы равенства.
        /// </summary>
        public class MyArray<T>
        {
            /// <summary> Параметризованный одномерный массив в качестве внутреннего скрытого хранилища данных. </summary>
            protected T[] storage;

            /// <summary> Свойство для получения длины массива. </summary>
            public int Length => storage.Length;

            /// <summary> Делает массив пустым. </summary>
            public void MakeEmpty() => storage = new T[0];

            /// <summary> Конструктор без параметров инициализирует объект пустым массивом. </summary>
            public MyArray() => MakeEmpty();

            /// <summary> Конструктор копирования. </summary>
            public MyArray(in MyArray<T> otherObject)
            {
                if (otherObject == null)
                {
                    throw new ArgumentNullException("value", "Нельзя инициализировать новый объект по пустой ссылке!");
                }
                storage = new T[otherObject.Length];
                Array.Copy(otherObject.storage, storage, otherObject.Length);
            }

            /// <summary> Свойство для проверки на пустой массив. </summary>
            public bool IsEmpty => Length == 0;

            /// <summary> Метод-индексатор. Доступен get и set для элементов внутреннего хранилища данных. </summary>
            public virtual T this[int elementIndex]
            {
                get
                {
                    if (IsEmpty)
                    {
                        throw new InvalidOperationException("Массив не содержит ни одного элемента!");
                    }
                    if (elementIndex < 0)
                    {
                        throw new IndexOutOfRangeException("Индексация с помощью отрицательных чисел не доступна!");
                    }
                    if (elementIndex >= Length)
                    {
                        throw new ArgumentOutOfRangeException("index", "Элемента с указанным индексом не существует в массиве!");
                    }
                    return storage[elementIndex];
                }

                set
                {
                    if (IsEmpty)
                    {
                        throw new InvalidOperationException("Массив не содержит ни одного элемента!");
                    }
                    if (elementIndex < 0)
                    {
                        throw new IndexOutOfRangeException("Индексация с помощью отрицательных чисел не доступна!");
                    }
                    if (elementIndex >= Length)
                    {
                        throw new ArgumentOutOfRangeException("index", "Элемента с указанным индексом не существует в массиве!");
                    }
                    storage[elementIndex] = value;
                }
            }

            /// <summary> Удаляет элемент, уменьшая длину массива. </summary>
            /// <remarks> Все элементы, идущие после удалённого смещаются влево. </remarks>
            /// <param name="elementIndex"> Индекс элемента, который должен быть удалён. </param>
            public void RemoveElement(int elementIndex)
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Массив не содержит ни одного элемента!");
                }
                if (elementIndex < 0)
                {
                    throw new IndexOutOfRangeException("Индексация с помощью отрицательных чисел не доступна!");
                }
                if (elementIndex >= Length)
                {
                    throw new ArgumentOutOfRangeException("index", "Элемента с указанным индексом не существует в массиве!");
                }

                T[] newStorage = new T[Length - 1];
                // Копирование элементов до указанного индекса.
                Array.Copy(storage, 0, newStorage, 0, elementIndex);
                // Копирование элементов после указанного индекса.
                Array.Copy(storage, elementIndex + 1, newStorage, elementIndex, Length - elementIndex - 1);
                storage = newStorage;
            }

            /// <summary> Вставляет элемент, увеличивая длину массива. </summary>
            /// <remarks> Новый элемент встаёт на позицию уже существующего, сдвигая его и все последующие элементы вправо. </remarks>
            /// <param name="elementIndex"> Индекс, на который должен встать новый элемент. </param>
            /// <param name="value"> Значение нового элемента. </param>
            public virtual void InsertElement(int elementIndex, T value)
            {
                if (Length == int.MaxValue)
                {
                    throw new OverflowException("Включение нового элемента приведёт к слишком большой длине массива!");
                }
                if (elementIndex < 0)
                {
                    throw new IndexOutOfRangeException("Индексация с помощью отрицательных чисел не доступна!");
                }
                if (elementIndex >= Length)
                {
                    throw new ArgumentOutOfRangeException("index", "Элемента с указанным индексом не существует в массиве!");
                }

                T[] newStorage = new T[Length + 1];
                // Копирование элементов до указанного индекса.
                Array.Copy(storage, 0, newStorage, 0, elementIndex);
                // В элементе нового массива под указанным индексом будет записано переданное значение.
                newStorage[elementIndex] = value;
                // Копирование элементов после указанного индекса.
                Array.Copy(storage, elementIndex, newStorage, elementIndex + 1, Length - elementIndex);
                storage = newStorage;
            }

            /// <summary> Добавляет элемент, увеличивая длину массива. </summary>
            /// <remarks> Новый элемент будет являться новым концом массива. </remarks>
            /// <param name="value"> Значение нового элемента. </param>
            public virtual void AddElementToEnd(T value)
            {
                if (Length == int.MaxValue)
                {
                    throw new OverflowException("Включение нового элемента приведёт к слишком большой длине массива!");
                }

                T[] newStorage = new T[Length + 1];
                // Копирование всех элементов в новый массив.
                Array.Copy(storage, newStorage, Length);
                newStorage[Length] = value;
                storage = newStorage;
            }

            /// <summary> Глубокая проверка на равенство коллекций. </summary>
            /// <remarks>
            /// Чтобы проверка могла корректно сравнить элементы массивов,
            /// у них должен быть переопределён метод Equals для глубокой проверки на равенство.
            /// </remarks>
            /// <returns> Значение true, если указанный объект равен текущему объекту, в противном случае — значение false. </returns>
            public override bool Equals(object otherObject)
            {
                // Оператор is проверяет, является ли объект экземпляром указанного типа.
                /* Использование is вместе с условным присваиванием.
                В этом случае, если otherObject действительно является экземпляром MyArray<T>,
                то оператор is создает переменную otherMyArray, которая ссылается на тот же объект.
                После создания ссылки с типом MyArray<T> можно обращаться к полям, характерным для этого класса. */
                if (otherObject is MyArray<T> otherMyArray)
                {
                    if (Length != otherMyArray.Length)
                    {
                        return false;
                    }
                    for (int index = 0; index < Length; index++)
                    {
                        if (!this[index].Equals(otherMyArray[index]))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }

            /// <summary> Используется для перебора коллекции с помощью цикла foreach. </summary>
            public IEnumerator<T> GetEnumerator()
            {
                for (int index = 0; index < Length; index++)
                {
                    yield return this[index];
                }
            }

            /// <summary> Служит для получения хэш-кода этой коллекции. </summary>
            /// <remarks> Важно, чтобы у объектов коллекции был переопределён метод GetHashCode. </remarks>
            /// <returns> Хэш-код для текущего объекта как значение int. </returns>
            public override int GetHashCode()
            {
                int hash = 17;
                foreach (var item in storage)
                {
                    // Оператор ?. позволяет безопасно вызывать методы или доступ к свойствам на объекте, который может быть null.
                    // Оператор ?? используется для задания значения по умолчанию, если выражение слева равно null.
                    hash = hash * 31 + (item?.GetHashCode() ?? 0);
                }
                return hash;
            }

            /// <summary> Общая проверка на равенство коллекций. </summary>
            /// <remarks>
            /// Сперва используется сравнение по ссылкам.
            /// Если ссылки разные, они проверяются на null.
            /// Если ссылки на объекты не null, происходит глубокое сравнивание объектов.
            /// </remarks>
            /// <returns> Значение true, когда оба объекта имеют одинаковые ссылки или равны по правилам метода Equals; иначе false. </returns>
            public static bool operator ==(MyArray<T> left, MyArray<T> right)
            {
                if (ReferenceEquals(left, right)) return true;
                if (left is null || right is null) return false;
                return left.Equals(right);
            }

            /// <summary> Общая проверка на неравенство коллекций. </summary>
            /// <remarks> Использует функционал оператора ==. </remarks>
            public static bool operator !=(MyArray<T> left, MyArray<T> right)
            {
                return !(left == right);
            }

            /// <summary>
            /// Применяет метод ToString к элементам массива,
            /// чтобы получить строку с перечислением строковых представлений объектов,
            /// обрамлённую квадратными скобками.
            /// </summary>
            /// <remarks> Работает корректно только если метод ToString переопределён у объектов коллекции. </remarks>
            public override string ToString()
            {
                if (IsEmpty)
                {
                    return "[]";
                }

                string result = "[";
                for (int index = 0; index < Length; index++)
                {
                    // Если элемент равен null, его представление отображается как "null".
                    result += this[index]?.ToString() ?? "null";
                    if (index < Length - 1)
                    {
                        result += ", ";
                    }
                }
                return result + "]";
            }

            /// <summary> Находит индекс указанного элемента в массиве. </summary>
            /// <remarks>
            /// Проходит по элементам коллекции слева-направо.
            /// Работает корректно только, если у класса элементов коллекции переопределён метод Equals для глубокой проверки на равенство.
            /// </remarks>
            /// <param name="value"> Значение для поиска. </param>
            /// <returns> Индекс элемента, если он найден; иначе -1. </returns>
            public int GetIndexOfFirstMatch(T value)
            {
                for (int index = 0; index < Length; index++)
                {
                    if (value.Equals(this[index]))
                    {
                        return index;
                    }
                }
                return -1;
            }

            /// <summary> Сортирует коллекцию, используя логику метода Sort из класса Array. </summary>
            public void Sort() => Array.Sort(storage);
        }
    }
}