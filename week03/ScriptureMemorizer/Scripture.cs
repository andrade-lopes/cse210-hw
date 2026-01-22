using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptureMemorizer
{
    // Represents a scripture made of a reference and a list of words
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();

            string[] tokens = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens)
            {
                _words.Add(new Word(token));
            }
        }

        // Returns the full scripture text with hidden words
        public string GetDisplayText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(_reference.ToString());
            sb.Append(" - ");

            sb.Append(string.Join(" ", _words.Select(w => w.GetDisplayText())));

            return sb.ToString();
        }

        // Returns true if all words with letters are hidden
        public bool AllWordsHidden()
        {
            return _words
                .Where(w => w.HasLetters)
                .All(w => w.IsHidden);
        }

        // Hides a random set of visible words
        public void HideRandomVisibleWords(int count)
        {
            List<Word> visibleWords = _words
                .Where(w => w.HasLetters && !w.IsHidden)
                .ToList();

            for (int i = 0; i < count && visibleWords.Count > 0; i++)
            {
                int index = _random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }
    }
}