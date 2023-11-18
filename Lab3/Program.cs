using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Program
    {
        public class Find
        {
            static int[] GetPrefix(string s)
            {
                int[] result = new int[s.Length];
                result[0] = 0;

                for (int i = 1; i < s.Length; i++)
                {
                    int k = result[i - 1];
                    while (s[k] != s[i] && k > 0) k = result[k - 1];

                    if (s[k] == s[i]) result[i] = k + 1;
                    else result[i] = 0;
                }
                return result;
            }

            static int FindSubstring(string pattern, string text)
            {
                int[] pf = GetPrefix(pattern);
                int index = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    while (index > 0 && pattern[index] != text[i]) index = pf[index - 1];

                    if (pattern[index] == text[i]) index++;
                    if (index == pattern.Length) return i - index + 1;
                }

                return -1;
            }


            private static int Boyer(string text, string pattern)
            {
                int N = text.Length;
                int M = pattern.Length;
                int[] D = new int[2048];

                for (int j = 0; j < D.Length; j++)
                    D[j] = M;
                for (int j = 0; j < M - 1; j++)
                    D[pattern[j]] = M - j - 1;

                // поиск
                int i = M - 1;

                while (i < N)
                {
                    int j = M - 1;
                    int k = i;
                    while (j >= 0 && pattern[j] == text[k])
                    {
                        k--;
                        j--;
                    }
                    if (j < 0)
                    {
                        return k + 1; // совпадение найдено
                    }

                    i += D[text[i]]; // сдвиг
                }

                return -1; // совпадение не найдено
            }



            static void Main(string[] args)
            { 

                string text = File.ReadAllText("Input.txt");
                string word = "кто";

                int index = Find.FindSubstring(word, text);

                if (index != -1) Console.WriteLine($"Первое вхождение слова ({word}) найдено на позиции {index}") ;
                else Console.WriteLine($"Слово ({word}) не найдено в тексте");


                string text2 = File.ReadAllText("Input.txt");
                string word2 = "кто";

                int index2 = Find.Boyer(text2, word2);

                if (index2 != -1) Console.WriteLine($"Первое вхождение слова ({word2}) найдено на позиции {index2}");
                else Console.WriteLine($"Слово ({word2}) не найдено в тексте");



            }
        }
    }
}
