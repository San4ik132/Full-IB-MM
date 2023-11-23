using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Program
    {
        static bool[,] SerZap(int[] a, int[] b, int[,] c)
        {
            bool[,] zapol = new bool[3, 5];
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (b[j] != 0)
                    {
                        zapol[i,j] = true;
                        c[i, j] = Math.Min(a[i], b[j]);
                        a[i] -= c[i, j];
                        b[j] -= c[i, j];

                        if (a[i] == 0)
                            break;
                    }
                }
            }
            return zapol;
        }



        static int Sum(int[,] A, int[,] B)
        {
            if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1))
            {
                // Проверяем, что размеры матриц совпадают
                throw new ArgumentException("Матрицы A и B должны иметь одинаковый размер");
            }

            int rows = A.GetLength(0);
            int columns = A.GetLength(1);

            int[,] result = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = A[i, j] * B[i, j];
                }
            }


            // Вычисление суммы всех элементов в полученной матрице
            int sum = 0;
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    sum += result[i, j];
                }
            }

            return sum;
        }


        static (int[], int[]) Potencial(int[] supply, int[] demand, int[,] cost, bool[,] zapol)
        {
            int n = supply.Length;
            int m = demand.Length;

            int[] alfa = new int[n];
            int[] beta = new int[m];

            for (int i = 0; i < n; i++)
                alfa[i] = Int32.MinValue;

            for (int j = 0; j < m; j++)
                beta[j] = Int32.MinValue;

            alfa[0] = 0;

            bool f;
            do
            {
                f = false;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        
                        if (zapol[i,j])
                        {
                            if (alfa[i] == Int32.MinValue && beta[j] != Int32.MinValue)
                                alfa[i] = cost[i, j] - beta[j];
                            else if (alfa[i] != Int32.MinValue && beta[j] == Int32.MinValue)
                                beta[j] = cost[i, j] - alfa[i];
                        }
                    }
                }

                for (int i = 0; i < n; i++)
                    if (alfa[i] == Int32.MinValue)
                        f = true;

                for (int j = 0; j < m; j++)
                    if (beta[j] == Int32.MinValue)
                        f = true;

            } while (f);

            return (alfa, beta);
        }

        static int[,] Ozenka(int n, int m, bool[,] zapol, int[] alfa, int[] beta, int[,] cost)
        {
            int[,] delta = new int[3, 5];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (!zapol[i, j])
                        delta[i, j] = beta[j] + alfa[i] - cost[i, j];
                    else
                        delta[i, j] = 0;
                }
            }
            return delta;
        }
        static bool Optim(bool[,] zapol, int[,] delta)
        { 
            bool f = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!(zapol[i, j]) && (delta[i, j] > 0))
                    {
                        f = false;
                    }
                }
            }
            return f;
        }

       



        static void Main(string[] args)
        {
            int[] a = { 310, 250, 240 };
            int[] b = { 290, 110, 170, 130, 100 };
            int[,] c1 = {{ 7, 9, 5, 6, 3 },
                         { 4, 6, 8, 6, 7 },
                         { 6, 4, 9, 5, 2 }
            };

            int[,] c = new int[3, 5];

            bool[,] zapol = SerZap(a, b, c);


            for (int i = 0; i < c.GetLength(0); ++i)
            {
                for (int j = 0; j < c.GetLength(1); ++j)
                {
                    
                    Console.Write("{0,4}", c[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(Sum(c,c1));
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", Potencial(a, b, c1, zapol).Item1));
            Console.WriteLine(string.Join(" ", Potencial(a, b, c1, zapol).Item2));

            int[,] d =  Ozenka(3, 5, zapol, Potencial(a, b, c1, zapol).Item1, Potencial(a, b, c1, zapol).Item2, c1);

            for (int i = 0; i < d.GetLength(0); ++i)
            {
                for (int j = 0; j < d.GetLength(1); ++j)
                {

                    Console.Write("{0,4}", d[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine(Optim(zapol, Ozenka(3, 5, zapol, Potencial(a, b, c1, zapol).Item1, Potencial(a, b, c1, zapol).Item2, c1)));


            
        }
    }
}
