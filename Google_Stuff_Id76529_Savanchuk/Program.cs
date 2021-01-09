using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Google_Stuff_Id76529_Savanchuk_Pavel_Project_2985
{
    /// Класс, описывающий элемент связного списка.
    public class Item<T>
    {
        /// Хранимые данные.
        public T Data { get; set; }

        /// Следующий элемент связного списка.
        public Item<T> Next { get; set; }

        /// Приведение объекта к строке.
        public override string ToString()
        {
            return Data.ToString();
        }

        /// Создаем новый экземпляр связного списка.
        public Item(T data)
        {
            // Проверяем входные аргументы на null.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            Data = data;
        }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        /// Первый элемент списка.
        private Item<T> _head = null;

        /// Крайний элемент списка. 
        private Item<T> _tail = null;

        /// Количество элементов списка.
        private int _count = 0;

        /// Количество элементов списка.
        public int Count
        {
            get => _count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            /// Перебираем все элементы связного списка, для представления в виде коллекции элементов.
            var current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            /// Возвращаем перечислитель, определенный выше для реализации интерфейса IEnumerable
            /// чтобы была возможность перебирать элементы связного списка операцией foreach.
            return ((IEnumerable)this).GetEnumerator();
        }

        /// Добавить данные в связный список.
        public void Add(T data)
        {
            /// Проверяем входные аргументы на null.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            /// Создаем новый элемент связного списка.
            var item = new Item<T>(data);

            /// Если связный список пуст, то добавляем созданный элемент в начало,
            /// иначе добавляем этот элемент как следующий за крайним элементом.
            if (_head == null)
            {
                _head = item;
            }
            else
            {
                _tail.Next = item;
            }

            /// Устанавливаем этот элемент последним.
            _tail = item;

            /// Увеличиваем счетчик количества элементов.
            _count++;
        }

        ///Отсортировать список по возрастанию.
        public int[] Sort(int count)
        {
            /// Перебираем все элементы связного списка, для представления в виде коллекции элементов.
            var current = _head;
            /// Инициализируем массив для использования операций сортировки.
            int[] sortedList = new int[count];
            int ind = 0;

            /// Перебираем все элементы списка с записью в массив.
            while (current != null)
            {
                current = _head;
                /// Также не забываем про проверку исключений, или их избежание.
                if (_head != null) sortedList[ind] = Convert.ToInt32(_head.Data);
                if (_head != null) _head = _head.Next;
                ind++;
            }

            /// Инициализируем временную переменную для сортировки массива.
            /// Циклическим перебором сортируем массив по возрастанию.
            int temp;
            for (int i = 0; i < sortedList.Length - 1; i++)
            {
                for (int j = i + 1; j < sortedList.Length; j++)
                {
                    /// В случае если массив от j больше i, присваиваем его временной переменной.
                    /// А затем переписываем массив на больший, делая сортировку по возрастанию.
                    if (sortedList[i] > sortedList[j])
                    {
                        temp = sortedList[i];
                        sortedList[i] = sortedList[j];
                        sortedList[j] = temp;
                    }
                }
            }

            /// Возвращаем значение отсортированного массива.
            return sortedList;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /// Создаем первый связный список.
            var list_1 = new LinkedList<int>();

            /// Добавляем элементы, определяя количество элементов первого списка.
            Console.WriteLine("Введите количество чисел первого списка: ");
            int count = int.Parse(Console.ReadLine());
            /// Инициализируем сами переменные считыванием из строки консоли.
            /// С дальнейшей записью сразу в первый список.
            Console.WriteLine("Введите числа первого списка: ");
            for (int i = 1; i <= count; i++)
                list_1.Add(int.Parse(Console.ReadLine()));

            /// Сортируем первый список по возрастанию.
            int[] firstList = list_1.Sort(count);

            /// Перезаписываем элементы списка на новые, чтобы избежать дублей.
            for (int i = 0; i < count; i++)
            {
                if (firstList[i].ToString() != null)
                    list_1.Add(int.Parse(firstList[i].ToString()));
            }

            /// Выведем на консоль результат сортировки первого списка.
            Console.Write("Выведем первый список: ");
            foreach (var item in list_1)
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();

            /// Создаем второй связный список.
            var list_2 = new LinkedList<int>();


            /// Добавляем элементы, определяя количество элементов второго списка.
            Console.WriteLine("Введите количество чисел второго списка: ");
            count = int.Parse(Console.ReadLine());
            /// Инициализируем сами переменные считыванием из строки консоли.
            /// С дальнейшей записью сразу во второй список.
            Console.WriteLine("Введите числа второго списка: ");
            for (int i = 1; i <= count; i++)
                list_2.Add(int.Parse(Console.ReadLine()));

            /// Сортируем второй список по возрастанию.
            int[] secondList = list_2.Sort(count);

            /// Перезаписываем элементы списка на новые, чтобы избежать дублей.
            for (int i = 0; i < count; i++)
            {
                if (secondList[i].ToString() != null)
                    list_2.Add(int.Parse(secondList[i].ToString()));
            }

            /// Выведем на консоль результат сортировки второго списка.
            Console.Write("Выведем второй список: ");
            foreach (var item in list_2)
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();

            ///Вычислим третий список.
            var list_3 = new LinkedList<int>();

            /// Определим количество элементов двух списков, чтобы избежать .
            /// Исключения Out of range.
            count = firstList.Length + secondList.Length;

            /// Функцией Distinct уберем дубли в первом массиве.
            int[] finalArray = firstList.Distinct().ToArray();

            /// Запишем результат первого списка без дублей в список.
            for (int i = 0; i < finalArray.Length; i++)
            {
                if (finalArray[i].ToString() != null)
                    list_3.Add(int.Parse(finalArray[i].ToString()));
            }

            /// Функцией Distinct уберем дубли во втором массиве.
            finalArray = secondList.Distinct().ToArray();

            /// Запишем результат второго списка без дублей в список.
            for (int i = 0; i < finalArray.Length; i++)
            {
                if (finalArray[i].ToString() != null)
                    list_3.Add(int.Parse(finalArray[i].ToString()));
            }

            /// Отсортируем по возрастанию оба списка, которые добавили в третий список.
            finalArray = list_3.Sort(count);

            /// Избавимся от дублирующихся записей.
            finalArray = finalArray.Distinct().ToArray();

            /// Перезапишем результаты сортировки и удаления дублей в третий список.
            for (int i = 0; i < finalArray.Length; i++)
            {
                if (finalArray[i].ToString() != null)
                    list_3.Add(int.Parse(finalArray[i].ToString()));
            }

            /// Выведем на консоль результат сортировки третьего списка.
            Console.Write("Выведем третий список: ");
            foreach (var item in list_3)
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();
        }
    }
}
