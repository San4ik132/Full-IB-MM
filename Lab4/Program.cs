using System;

namespace LinearProgramming
{
    class Program
    {
        static float F(float x, float y)
        {
            return 2 * x + y;
        }

        static void Main()
        {
            int n = 4;
            float[,] a = new float[20, 2];
            float[] b = new float[20];
            float x, y, x1 = 0, x2 = 0, max = -100;

            a[0, 0] = 5; a[0, 1] = -2; b[0] = 4;
            a[1, 0] = -1; a[1, 1] = 2; b[1] = 4;
            a[2, 0] = 1; a[2, 1] = 1; b[2] = 4;
            a[3, 0] = 1; a[3, 1] = 0; b[3] = 4 / 3;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Math.Abs(a[i, 0] * a[j, 1] - a[i, 1] * a[j, 0]) > 0.001)
                    {
                        x = (b[i] * a[j, 1] - a[i, 1] * b[j]) / (a[i, 0] * a[j, 1] - a[i, 1] * a[j, 0]);
                        y = (a[i, 0] * b[j] - b[i] * a[j, 0]) / (a[i, 0] * a[j, 1] - a[i, 1] * a[j, 0]);
                        int t = 1;

                        Console.WriteLine($"{x} = {y} {i} {j}");

                        for (int k = 0; k < n; k++)
                        {
                            switch (k)
                            {
                                case 0:
                                    if (a[k, 0] * x + a[k, 1] * y > b[k]) t = 0;
                                    break;
                                case 1:
                                    if (a[k, 0] * x + a[k, 1] * y > b[k]) t = 0;
                                    break;
                                case 2:
                                    if (a[k, 0] * x + a[k, 1] * y < b[k]) t = 0;
                                    break;
                                case 3:
                                    if (a[k, 0] * x + a[k, 1] * y < b[k]) t = 0;
                                    break;
                            }
                            Console.WriteLine(t);
                        }

                        if (t == 1 && F(x, y) > max)
                        {
                            max = F(x, y);
                            x1 = x;
                            x2 = y;
                        }
                    }
                }
            }

            Console.WriteLine($"{x1} {x2} {max}");
            Console.ReadLine();
        }
    }
}
