using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

            // Create a small library of scriptures
            List<Scripture> scriptures = new List<Scripture>
            {
                new Scripture(new Reference("John", 3, 16),
                    "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish but have everlasting life."),

                new Scripture(new Reference("Proverbs", 3, 5, 6),
                    "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),

                new Scripture(new Reference("Philippians", 4, 13),
                    "I can do all things through Christ which strengtheneth me."),

                new Scripture(new Reference("Psalm", 23, 1, 6),
                    "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: he leadeth me beside the still waters."),

                new Scripture(new Reference("1 Nephi", 3, 7),
                    "I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.")
            };

            // Choose a random scripture
            Random rand = new Random();
            Scripture scripture = scriptures[rand.Next(scriptures.Count)];

            Console.Clear();
            Console.WriteLine("Scripture Memorizer");
            Console.WriteLine("-------------------");
            Console.WriteLine();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide words, or type 'quit' to exit.");

            const int hidePerStep = 3;

            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                if (input != null && input.Trim().ToLower() == "quit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                scripture.HideRandomVisibleWords(hidePerStep);

                Console.Clear();
                Console.WriteLine("Scripture Memorizer");
                Console.WriteLine("-------------------");
                Console.WriteLine();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words have been hidden. Well done!");
                    break;
                }

                Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit.");
            }

            Console.WriteLine();
            Console.WriteLine("Final state:");
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}