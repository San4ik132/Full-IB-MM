using System;
using System.IO;

namespace IB4
{
    internal class Program
    {
        static void Main()
        {
            string inputText = File.ReadAllText("Input.txt");
            string gamma = GenerateGamma(); // Генерируем гамму длиной 8 символов

            string encryptedText = ED(inputText, gamma);
            File.WriteAllText("Out.txt", encryptedText);
            Console.WriteLine("Зашифрованный текст: " + encryptedText);

            string encryptedText1 = File.ReadAllText("Out.txt");
          
            string decryptedText = ED(encryptedText1, gamma);
            File.WriteAllText("Result.txt", decryptedText);
            Console.WriteLine("Расшифрованный текст: " + decryptedText);
        }
        static string GenerateGamma()
        {
            string piDigits = "31415926"; // Первые 8 цифр числа π
            string gamma = RepeatToLength(piDigits, 8);
            return gamma;
        }
        static string RepeatToLength(string source, int length)
        {
            int sourceLength = source.Length;
            return source.Substring(0, length % sourceLength) + source.Substring(0, length / sourceLength);
        }
        static string ED(string input, string gamma)
        {
            char[] inputArray = input.ToCharArray();
            for (int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] = (char)(inputArray[i] ^ gamma[i % gamma.Length]); // Используем побитовое XOR для шифрования
            }
            return new string(inputArray);
        }
    }
}
