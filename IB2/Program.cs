using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IB2
{
    internal class Program
    {

        static void Percentages(string NameFile)
        {
            var FileContent = NameFile.ToUpper();
            string Alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ ";
            var LetterCount = new Dictionary<char, int>();

            foreach (char c in FileContent)
            {
                char letter = c;
                if (Alphabet.Contains(letter)) // Проверим, является ли символ буквой русского алфавита
                {
                    if (LetterCount.ContainsKey(letter))
                    {
                        LetterCount[letter]++;
                    }
                    else
                    {
                        LetterCount[letter] = 1;
                    }
                }
            }

            int totalLetters = LetterCount.Sum(x => x.Value); // Подсчитаем общее количество букв

            var LetterPercentages = new Dictionary<char, double>();



            foreach (var kvp in LetterCount)
            {
                LetterPercentages[kvp.Key] = Math.Round((kvp.Value / (double)totalLetters) * 100, 2); // Вычислим процентное соотношение для каждой буквы
            }


            var sortedLetterPercentages = LetterPercentages.OrderByDescending(x => x.Value);
            foreach (var item in sortedLetterPercentages)
            {
                Console.WriteLine($"{item.Key}: {item.Value}%");
            }
            
        }


        static string DecryptionMain(string NameFile)
        {
            var FileContent = NameFile.ToUpper();
            var K = new Dictionary<char, char>
            {

                { 'В', ' ' },
                { 'Л', 'о' },
                { 'Ц', 'н' },
                { 'Ф', 'а' },
                { 'А', 'и' },
                { 'С', 'т' },
                { 'И', 'д' },
                { 'Ш', 'у' },
                { 'Ы', 'к' },
                { 'У', 'в' },
                { 'Щ', 'г' },
                { 'Е', 'э' },
                { 'Г', 'е' },
                { 'Э', 'ж' },
                { 'Ъ', 'ы' },
                { 'Ж', 'р' },
                { 'Ч', 'з' },
                { 'О', 'с' },
                { 'Я', 'п' },
                { 'Б', 'х' },
                { 'Д', 'й' },
                { 'Ь', 'л' },
                { 'З', 'м' },
                { 'Ю', 'ь' },
                { 'Н', 'б' },
                { ' ', 'ю' },
                { 'К', 'я' },
                { 'Т', 'ш' },
                { 'Х', 'щ' },
                { 'П', 'ч' },
                { 'Й', 'ц' }

            };
            StringBuilder decryptedText = new StringBuilder();
            foreach (var c in FileContent)
            {
                if (K.ContainsKey(c))
                {
                    decryptedText.Append(K[c]);
                }
                else
                {
                    decryptedText.Append(c);
                }
            }
            return decryptedText.ToString();

        }



        static string DecryptionMain4(string NameFile)
        {
            var FileContent = NameFile.ToUpper();
            var K = new Dictionary<char, char>
            {
                {'П', 'в'},
                {'Й', 'е'},
                {'С', 'д'},
                {'Ж', 'н'},
                {'Х', 'и'},
                {'З', 'о'},
                {'Б', 'с'},
                {'Ш', 'ч'},
                {'Д', 'л'},
                {'Г', 'к'},
                {'Р', 'г'},
                {'Н', 'а'},
                {'Е', 'м'},
                {'И', 'п'},
                {'Ф', 'ь'},
                {'Ь', 'ю'},
                {'В', 'т'},
                {'А', 'р'},
                {'О', 'б'},
                {'У', 'ы'},
                {'К', 'ж'},
                {'Э', 'я'},
                {'Ч', 'ц'},
                {'М', 'у'},
                {'Ы', 'э'},
                {'Ц', 'й'},
                {'Ъ', 'щ'},
                {'Щ', 'ш'},
                {'Л', 'з'},
                {'Ю', 'ф'},
                {'Я', 'х'},
                {'Т', 'ъ'},


            };

            StringBuilder decryptedText = new StringBuilder();
            foreach (var c in FileContent)
            {
                if (K.ContainsKey(c))
                {
                    decryptedText.Append(K[c]);
                }
                else
                {
                    decryptedText.Append(c);
                }
            }
            return decryptedText.ToString();
        }

        static void Main()
        {
            Console.WriteLine("---------------------- Таблица процентов первого текста ----------------------");
            Program.Percentages(File.ReadAllText("Зашифрованный текст.txt"));
            Console.WriteLine("---------------------- Расшифрованный первый текст ----------------------");
            Console.WriteLine(Program.DecryptionMain(File.ReadAllText("Зашифрованный текст.txt")));




            Console.WriteLine("--------------------- Таблица процентов текста варианта 4 ----------------------");
            Program.Percentages(File.ReadAllText("input.txt"));
            Console.WriteLine("--------------------- Расшифрованный текст Вариант 4 ----------------------");
            Console.WriteLine(Program.DecryptionMain4(File.ReadAllText("input.txt")));

        }
    }
}
