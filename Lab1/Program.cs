using System;

namespace Lab1
{
    internal class Program
    {
        static double Function(double x)
        {
            return Math.Pow(x - 1, 2) * Math.Pow(x + 1, 4) * Math.Pow(x - 2, 3);
        }

        static (double, double) Function_Sfen(double x, double h)
        {
            double x0 = x - h, x1 = x + h;
            if (Function(x0) > Function(x) && Function(x) > Function(x1))
            {

            }
            else
            {
                if (Function(x0) < Function(x) && Function(x) < Function(x1))
                {
                    h = -h;
                    (x0, x1) = (x1, x0);
                }
                else return (x0, x1);
            }

            while (Function(x0) > Function(x1))
            {
                x0 = x1;
                x1 = x1 + 2 * h;
            }

            if (h > 0) return (x0, x1);
            else return (x1, x0);

        }
        public static double GoldenSectionSearch(Func<double, double> function, double a, double b, double epsilon)
        {
            double phi = (1 + Math.Sqrt(5)) / 2; // Золотое сечение
            double x1 = b - (b - a) / phi;
            double x2 = a + (b - a) / phi;

            while (Math.Abs(b - a) > epsilon)
            {
                if (function(x1) < function(x2))
                {
                    b = x2;
                    x2 = x1;
                    x1 = b - (b - a) / phi;
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    x2 = a + (b - a) / phi;
                }
            }

            return (a + b) / 2;
        }
        static void Main()
        {
            Console.WriteLine("Приблезительный отрезок: " + Function_Sfen(2.5, 0.01));
            (double a, double b) = Function_Sfen(2.5, 0.01);
            double t = a;
            double c = b;
            double minimum = GoldenSectionSearch(Function, t, c, 0.0001);
            Console.WriteLine("F(x): " + Function(minimum));
            Console.WriteLine("Минимум функции: " + minimum);
        }
    }

}
