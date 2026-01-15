using System;

namespace Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is the Journal Project.");
            Journal journal = new Journal();
            PromptGenerator promptGenerator = new PromptGenerator();

            string choice = "";
            while (choice != "5")
            {
                Console.WriteLine("\nJournal Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Quit");
                Console.Write("Select an option (1-5): ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"\nPrompt: {prompt}");
                        Console.Write("Your response: ");
                        string response = Console.ReadLine();
                        string date = DateTime.Now.ToShortDateString();

                        Entry newEntry = new Entry(date, prompt, response);
                        journal.AddEntry(newEntry);
                        break;

                    case "2":
                        journal.DisplayAll();
                        break;

                    case "3":
                        Console.Write("Enter filename to save: ");
                        string saveFile = Console.ReadLine();
                        journal.SaveToFile(saveFile);
                        break;

                    case "4":
                        Console.Write("Enter filename to load: ");
                        string loadFile = Console.ReadLine();
                        journal.LoadFromFile(loadFile);
                        break;

                    case "5":
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}