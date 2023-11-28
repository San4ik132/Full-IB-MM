using System;
using System.Linq;

namespace Lab8
{
    class Program
    {
        static void Main()
        {
            int[] value = { 74, 85, 62, 66, 22, 17, 78, 99, 76, 90 };
            int[] weight = { 2 ,4,4,8,7,5,7,1, 10, 6 };

            int maxValue = Problem(15, weight, value, value.Length) ;
            Console.WriteLine($"Максимальная полезность: {maxValue}");
        }

        static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        static int Problem(int maxWeight, int[] weights, int[] values, int n)
        {
            int[,] Kot = new int[n + 1, maxWeight + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= maxWeight; w++)
                {
                    if (i == 0 || w == 0)
                        Kot[i, w] = 0;
                    else if (weights[i - 1] <= w)
                        Kot[i, w] = Max(values[i - 1] + Kot[i - 1, w - weights[i - 1]], Kot[i - 1, w]);
                    else
                        Kot[i, w] = Kot[i - 1, w];
                }
            }

            // Вывод матрицы
            Console.WriteLine("Матрица: ");
            for (int i = 0; i <= n; i++)
            {
                string rowValues = string.Join(" ", Enumerable.Range(0, maxWeight + 1).Select(w => Kot[i, w]));
                Console.WriteLine(rowValues);
            }

            return Kot[n, maxWeight];
        }

    }
}
