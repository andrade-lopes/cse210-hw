using System;
using System.Collections.Generic;
using System.IO;

namespace Journal
{
    public class Journal
    {
        private List<Entry> _entries;

        public Journal()
        {
            _entries = new List<Entry>();
        }

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No journal entries yet.");
            }
            else
            {
                foreach (Entry entry in _entries)
                {
                    entry.Display();
                }
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.GetAsFileLine());
                }
            }
            Console.WriteLine($"Journal saved to {filename}");
        }

        public void LoadFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                _entries.Clear();
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    _entries.Add(Entry.FromFileLine(line));
                }
                Console.WriteLine($"Journal loaded from {filename}");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}