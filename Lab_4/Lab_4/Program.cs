using System;

namespace Lab_4
{
    using System;
    using System.IO;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string filePath = "text.txt";

            // Отримання масиву символів з файлу
            try
            {
                char[] characters = File.ReadAllText(filePath).ToCharArray();
                int wordCountUsingArray = GetWordCountUsingArray(characters);
                Console.WriteLine("Кiлькість слiв (за допомогою масиву символiв): " + wordCountUsingArray);

            // Обчислення кількість слів за допомогою колекції List<T>
                int wordCountUsingList = GetWordCountUsingList(characters);
                Console.WriteLine("Кiлькість слiв (за допомогою колекцiї List<T>): " + wordCountUsingList);
            // Обчислення кількості слів за допомогою колекції List<T> 
                int wordCountUsingExper = GetWordCountUsingExperimental(characters);
                Console.WriteLine("Кiлькість слiв (за допомогою колекцiї List<T>): " + wordCountUsingList);
            }
            catch
            {
                Console.WriteLine("Такий файл не знайдено");
            }
            

            // Обчислити кількість слів за допомогою масиву символів
            
        }

        static int GetWordCountUsingArray(char[] characters)
        {
            int wordCount = 0;
            bool isWord = false;

            foreach (char c in characters)
            {
                if (char.IsLetter(c))
                {
                    if (!isWord)
                    {
                        wordCount++;
                        isWord = true;
                    }
                }
                else
                {
                    isWord = false;
                }
            }

            return wordCount;
        }

        static int GetWordCountUsingList(char[] characters)
        {
            List<char> wordCharacters = new List<char>();
            int wordCount = 0;

            foreach (char c in characters)
            {
                if (char.IsLetter(c))
                {
                    wordCharacters.Add(c);
                }
                else if (wordCharacters.Count > 1)//вищитує з двох букви і більше
                {
                    wordCount++;
                    wordCharacters.Clear();
                }
            }

            if (wordCharacters.Count > 1)
            {
                wordCount++;
            }

            return wordCount;
        }
        static int GetWordCountUsingExperimental(char[] characters)
        {
            List<char> wordCharacters = new List<char>();
            int wordCount = 0;

            foreach (char c in characters)
            {
                if (IsLetter1(c))
                {
                    wordCharacters.Add(c);
                }
                else if (wordCharacters.Count > 1) //вираховує з однією літерою і більше
                {
                    wordCount++;
                    wordCharacters.Clear();
                }
            }

            if (wordCharacters.Count > 1)
            {
                wordCount++;
            }

            return wordCount;
        }
        public static bool IsLetter1(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }
    }
}
