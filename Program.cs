using System;
using System.Collections.Generic;
using System.IO;

namespace Jumbled
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dictionary = CreateDictionary();
            bool play = true;
            while (play)
            {
                Console.Clear();
                Console.Write("Enter a jumbled word: ");
                string jumbledWord = Console.ReadLine();
                string jumbledWordKey = GenerateWordKey(jumbledWord.ToLower());
                List<string> dictionaryWords = dictionary.ContainsKey(jumbledWordKey) ? dictionary[jumbledWordKey] : null;
                if (dictionaryWords != null)
                {
                    Console.WriteLine("\nPossible English words are: \n");
                    int i = 1;
                    foreach (string dictionaryWord in dictionaryWords)
                    {
                        Console.WriteLine(i.ToString() + ".) " + dictionaryWord);
                        i++;
                    }
                }
                else
                {
                    Console.WriteLine("No corresponding English words found! ");
                }
                Console.Write("\nAgain? (y/n): ");
                string again = Console.ReadLine();
                play = (again == "y" || again == "Y");
            }
        }

        public static Dictionary<string, List<string>> CreateDictionary()
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            string[] words = File.ReadAllLines("Resources/words_en.txt");
            foreach (string word in words)
            {
                string wordKey = GenerateWordKey(word);
                List<string> wordList = dictionary.ContainsKey(wordKey) ? dictionary[wordKey] : new List<string>();
                wordList.Add(word);
                dictionary[wordKey] = wordList;
            }
            return dictionary;
        }

        public static string GenerateWordKey(string inputString)
        {
            char[] chars = inputString.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}
