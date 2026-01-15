using System;

namespace Journal
{
    public class Entry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        public Entry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }

        public void Display()
        {
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Prompt: {Prompt}");
            Console.WriteLine($"Response: {Response}");
            Console.WriteLine("----------------------");
        }

        public string GetAsFileLine()
        {
            return $"{Date}|{Prompt}|{Response}";
        }

        public static Entry FromFileLine(string line)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                return new Entry(parts[0], parts[1], parts[2]);
            }
            else
            {
                throw new FormatException("Invalid line format in journal file.");
            }
        }
    }
}