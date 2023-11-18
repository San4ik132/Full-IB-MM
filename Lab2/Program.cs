using System;
using System.Threading;

namespace Lab2
{
    public class HeapSort
    {
        public void sort(int[] arr)
        {
            int n = arr.Length;

            // Построение кучи (перегруппируем массив)
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);

            // Один за другим извлекаем элементы из кучи
            for (int i = n - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // вызываем процедуру heapify на уменьшенной куче
                heapify(arr, i, 0);
            }
        }

        // Процедура для преобразования в двоичную кучу поддерева с корневым узлом i, что является
        // индексом в arr[]. n - размер кучи

        void heapify(int[] arr, int n, int i)
        {
            int largest = i;
            // Инициализируем наибольший элемент как корень
            int l = 2 * i + 1; // left = 2*i + 1
            int r = 2 * i + 2; // right = 2*i + 2

            // Если левый дочерний элемент больше корня
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // Если самый большой элемент не корень
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                heapify(arr, n, largest);
            }
        }
    }

        internal class Program
        {
            static int Barrier(int[] array, int target, out int comparisons)
            {
                int n = array.Length;
                int lastElement = array[n - 1];
                array[n - 1] = target;

                int i = 0;
                comparisons = 0;

                while (array[i] != target)
                {
                    i++;
                    comparisons++;
                }

                array[n - 1] = lastElement;

                if (i < n - 1 || array[n - 1] == target)
                {
                    return i;
                }
                else
                {
                    return -1;
                }
            }

        static int FibonacciSearch(int[] arr, int Key, int n)
        {
            // Инициализация чисел Фибоначчи
            int fibMMm2 = 0;        // (m-2)-ое число Фибоначчи
            int fibMMm1 = 1;        // (m-1)-ое число Фибоначчи
            int fibM = fibMMm2 + fibMMm1;    // m-ое число Фибоначчи

            // fibM должно хранить наименьшие числа Фибоначчи, большие или равные n
            while (fibM < n)
            {
                fibMMm2 = fibMMm1;
                fibMMm1 = fibM;
                fibM = fibMMm2 + fibMMm1;
            }

            // Отмечаем удаленный диапазон спереди
            int offset = -1;

            // Пока есть элементы для проверки
            // Обратите внимание, что мы сравниваем arr[fibMMm2] с Key.
            // Когда fibM становится 1, fibMMm2 становится 0.
            while (fibM > 1)
            {
                // Проверяем, является ли fibMMm2 действительным местоположением
                int i = Math.Min(offset + fibMMm2, n - 1);

                // Если Key больше значения в индексе fibMMm2, сокращаем массив до подмассива со смещением на i
                if (arr[i] < Key)
                {
                    fibM = fibMMm1;
                    fibMMm1 = fibMMm2;
                    fibMMm2 = fibM - fibMMm1;
                    offset = i;
                }
                // Если Key больше значения в индексе fibMMm2,
                // сокращаем подмассив после i + 1
                else if (arr[i] > Key)
                {
                    fibM = fibMMm2;
                    fibMMm1 = fibMMm1 - fibMMm2;
                    fibMMm2 = fibM - fibMMm1;
                }
                // Элемент найден. Возвращаем индекс
                else
                    return i;
            }

            // Сравниваем последний элемент с Key
            if (fibMMm1 == 1 && arr[offset + 1] == Key)
                return offset + 1;

            // Элемент не найден. Возвращаем -1
            return -1;
        }




        static void PrintArray(int[] array)
            {
                int n = array.Length;
                for (int i = 0; i < n; ++i)
                {
                    Console.Write(array[i] + " ");
                    Thread.Sleep(1);
                }
                Console.WriteLine();
            }

            static void Main(string[] args)
            {
                int[] array = new int[10];
                Random rand = new Random();
                for (int i = 0; i < array.Length; i++)
                    array[i] = rand.Next(200);

                Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("Исходный массив:");
            PrintArray(array);


            Console.Write("Барьер поиска: ");
            int target = Convert.ToInt32(Console.ReadLine());

                int comparisons;

                int result = Barrier(array, target, out comparisons);

                if (result != -1)
                {
                    Console.WriteLine("Элемент найден на позиции: " + result);
                }
                else
                {
                    Console.WriteLine("Элемент не найден");
                }

                Console.WriteLine("Количество сравнений: " + comparisons);

                HeapSort s = new HeapSort();
                s.sort(array);

                Console.WriteLine("Отсортированный массив:");
                PrintArray(array);


            int p = FibonacciSearch(array, target, array.Length);

            if (p != -1)
            {
                Console.WriteLine("Элемент найден на позиции: " + p);
            }
            else
            {
                Console.WriteLine("Элемент не найден");
            }

            Console.WriteLine("Количество сравнений: " + p);

            }
        }
    
}
