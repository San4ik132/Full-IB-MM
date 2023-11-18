using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace IB3
{
    internal class Program
    {
        static char[,] FileReading()
        {
            string FileR = File.ReadAllText("Input.txt");
            char[,] matrix = new char[6, 6];
            int textIndex = 0;


            for (int col = 0; col < 6; col++)
            {
                for (int row = 0; row < 6; row++)
                {
                    while (textIndex < FileR.Length && char.IsWhiteSpace(FileR[textIndex]) || !Regex.IsMatch(FileR[textIndex].ToString(), @"[А-Я]"))
                    {
                        textIndex++;
                    }
                    if (textIndex < FileR.Length)
                    {
                        matrix[row, col] = FileR[textIndex];
                        textIndex++;
                    }
                }
            }
          
            return matrix;
        }


        static string Encryption(char[,] matrix)
        {
            
            string result = string.Empty;
            int top = 0, bottom = 5, left = 0, right = 5;
            while (top <= bottom && left <= right)
            {
                // Считываем верхнюю строку по горизонтали
                for (int i = left; i <= right; i++)
                {
                    result += matrix[top, i];
                }
                top++;

                // Считываем правый столбец по вертикали
                for (int i = top; i <= bottom; i++)
                {
                    result += matrix[i, right];
                }
                right--;

                // Считываем нижнюю строку по горизонтали (если есть)
                if (top <= bottom)
                {
                    for (int i = right; i >= left; i--)
                    {
                        result += matrix[bottom, i];
                    }
                    bottom--;
                }

                // Считываем левый столбец по вертикали (если есть)
                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        result += matrix[i, left];
                    }
                    left++;
                }
            }

            return InsertSpaces(result, 6);
        }

        static string InsertSpaces(string input, int interval)
        {
            for (int i = interval; i < input.Length; i += interval)
            {
                input = input.Insert(i, " ");
                i++;
            }
            return input;
        }


        static string Decoding()
        {
            string inputStringOut = File.ReadAllText("Out.txt");
            string inputString = string.Empty;

            foreach (var line in inputStringOut.Split())
            {
                if (line == " ") { } else inputString += line;
            }

            char[,] spiralMatrix = new char[6, 6];

            int left = 0, right = 5, top = 0, bottom = 5;
            int index = 0;

            while (left <= right && top <= bottom)
            {
                // Вправо
                for (int i = left; i <= right; i++)
                {
                    spiralMatrix[top, i] = inputString[index++];
                }
                top++;

                // Вниз
                for (int i = top; i <= bottom; i++)
                {
                    spiralMatrix[i, right] = inputString[index++];
                }
                right--;

                // Влево
                for (int i = right; i >= left; i--)
                {
                    spiralMatrix[bottom, i] = inputString[index++];
                }
                bottom--;

                // Вверх
                for (int i = bottom; i >= top; i--)
                {
                    spiralMatrix[i, left] = inputString[index++];
                }
                left++;
            }

            int rows = spiralMatrix.GetLength(0);
            int cols = spiralMatrix.GetLength(1);
            string result = string.Empty;

            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    result += spiralMatrix[i, j];
                }
            }
            return result;
        }







        static void Main()
        {
           var matrix = Program.FileReading();
            for (var i = 0; i < 6; i++)
            {
                for (var j = 0; j < 6; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            
            Console.WriteLine();

            Console.WriteLine(Program.Encryption(matrix)+"\n");
            File.WriteAllText("Out.txt", Program.Encryption(matrix));


           Console.WriteLine(Program.Decoding());
          File.WriteAllText("Result.txt", Program.Decoding()+"\n");


        }
    }
}
