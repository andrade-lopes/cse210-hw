using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        Reference reference = new Reference("Proverbs", 3, 5, 6);

        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths";

        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("All words have been hidden. Program complete.");
                break;
            }
        }
    }
}