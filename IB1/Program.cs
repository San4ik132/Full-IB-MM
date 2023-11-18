using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IB1
{
    internal class Program
    {
            Dictionary<string, List<string>> MftEA = new Dictionary<string, List<string>>()
            {
                { "A", new List<string> {"f", "*", "k", "f", "*", "R", "f", "*", "k", "f", "*", "k"}},
                { "B", new List<string> {"N"}},
                { "C", new List<string> {"Q"}},
                { "D", new List<string> {".", "b", "i", ".", "b", "i", ".", "b", "i", ".", "b", "i"}},
                { "E", new List<string> {"G", "+", "]", "I", "G", "+", "]", "I", "G", "+", "]", "I"}},
                { "F", new List<string> {"т", "[", "w", "т", "[", "w", "т", "[", "w", "т", "[", "w"}},
                { "G", new List<string> {"D"}},
                { "H", new List<string> {",", "p", "r", ",", "p", "r", ",", "p", "r", ",", "p", "r"}},
                { "I", new List<string> {"А", ")", "q", "А", ")", "q", "А", ")", "q", "А", ")", "q"}},
                { "J", new List<string> {"e"}},
                { "K", new List<string> {"L"}},
                { "L", new List<string> {"-", "O", "и", "A", "O", "и", "A", "O", "и", "O", "A", "и"}},
                { "M", new List<string> {"R"}},
                { "N", new List<string> {"(", "y", "(", "y", "(", "y", "(", "y", "(", "y", "(", "y"}},
                { "O", new List<string> {"С", "/", "#", "п", "С", "/", "#", "п", "С", "/", "#", "п"}},
                { "P", new List<string> {"x"}},
                { "Q", new List<string> {"I"}},
                { "R", new List<string> {"Z", "=", "a", "Z", "=", "a", "Z", "=", "a", "Z", "=", "a"}},
                { "S", new List<string> {"V", "$", "d", "V", "$", "d", "V", "$", "d", "V", "$", "d"}},
                { "T", new List<string> {"⸺", "j", ":", "C", "⸺", "j", ":", "C", "⸺", "j", ":", "C"}},
                { "U", new List<string> {"W"}},
                { "V", new List<string> {"S"}},
                { "W", new List<string> {"h"}},
                { "X", new List<string> {"u"}},
                { "Y", new List<string> {"K"}},
                { "Z", new List<string> {"t"}}
            };
        static void Main()
        {
            string fileOut = "Out.txt";
            string fileInput = "Input.txt";
            string fileResult = "Result.txt";
           
            string text = File.ReadAllText(fileInput);

            string encryptedText = EncryptText(text);
            
            File.WriteAllText(fileOut, encryptedText);

            string Decrypte = Decryptedtext(File.ReadAllText(fileOut));

            File.WriteAllText(fileResult, Decrypte);

            Console.WriteLine($"Исходный текст\n{File.ReadAllText(fileInput)}\n");
            Console.WriteLine($"Зашифрованный текст\n{File.ReadAllText(fileOut)}\n");
            Console.WriteLine($"Результат дешифровки\n{File.ReadAllText(fileResult)}\n");
        }
        static string Decryptedtext(string text)
        {
            var P = new Program();
            StringBuilder decryptedText = new StringBuilder();

            foreach (char character in text)
            {
                string decryptedCharacter = string.Empty;
                bool characterFound = false;

                foreach (var entry in P.MftEA)
                {
                    if (entry.Value[0] == character.ToString())
                    {
                        decryptedCharacter = entry.Key;
                        string temp = entry.Value[0];
                        entry.Value.RemoveAt(0);
                        entry.Value.Add(temp);
                        
                        characterFound = true;
                        break;
                    }
                 
                }

                if (characterFound) decryptedText.Append(decryptedCharacter);
                else decryptedText.Append(character);
                

            }

            return decryptedText.ToString();
        }

        static string EncryptText(string text)
        {
            var P = new Program();
            StringBuilder encryptedText = new StringBuilder();
           

            foreach (char character in text)
            {
                string encryptedCharacter = string.Empty;
                bool characterFound = false;

                foreach (var K in P.MftEA)
                {
                    if (K.Key.Contains(character.ToString()))
                    {
                        encryptedCharacter = K.Value[0];
                        string temp = K.Value[0];
                        K.Value.RemoveAt(0);
                        K.Value.Add(temp);
                        characterFound = true;
                        break;
                    }
                }

                if (characterFound)
                {
                    encryptedText.Append(encryptedCharacter);
                }
                else
                {
                    encryptedText.Append(character);
                }
            }

            return encryptedText.ToString();
        }
    }
}
