// Program.cs
/*
Scripture Memorizer
Author: José António Andrade Lopes

EXTRAS and notes on exceeding requirements (also required to be included in comments per assignment):
- This implementation includes a small built-in library of scriptures and selects one at random each run.
- When hiding words it selects only words that are not already hidden (stretch improvement).
- Words preserve punctuation: only letters are replaced by underscores; punctuation like commas, semicolons, and periods remain in place.
- ScriptureReference supports both single-verse and verse-range constructors (e.g., "Proverbs 3:5" and "Proverbs 3:5-6").
- The code follows encapsulation: private fields with public properties/methods; separate classes for ScriptureReference, Word, Scripture.
- It's straightforward to extend: loading scriptures from a file or adding a UI would be simple additions.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptureMemorizer
{
    // Represents a scripture reference like "John 3:16" or "Proverbs 3:5-6"
    public class ScriptureReference
    {
        public string Book { get; private set; }
        public int Chapter { get; private set; }
        public int VerseStart { get; private set; }
        public int? VerseEnd { get; private set; } // null when single verse

        // Single verse constructor
        public ScriptureReference(string book, int chapter, int verse)
        {
            Book = book;
            Chapter = chapter;
            VerseStart = verse;
            VerseEnd = null;
        }

        // Range constructor
        public ScriptureReference(string book, int chapter, int verseStart, int verseEnd)
        {
            if (verseEnd < verseStart)
                throw new ArgumentException("verseEnd must be >= verseStart");

            Book = book;
            Chapter = chapter;
            VerseStart = verseStart;
            VerseEnd = verseEnd;
        }

        public override string ToString()
        {
            if (VerseEnd.HasValue)
                return $"{Book} {Chapter}:{VerseStart}-{VerseEnd.Value}";
            else
                return $"{Book} {Chapter}:{VerseStart}";
        }
    }

    // Represents a single token (word plus attached punctuation) in the scripture text
    public class Word
    {
        private readonly string _originalToken;
        private bool _hidden;

        public Word(string token)
        {
            _originalToken = token ?? string.Empty;
            _hidden = false;
        }

        // Expose if the word is completely hidden (all letters replaced)
        public bool IsHidden => _hidden;

        // Does this token contain any letters at all?
        public bool HasLetters => _originalToken.Any(char.IsLetter);

        // Hide the word (replace letters with underscores)
        public void Hide()
        {
            if (HasLetters)
                _hidden = true;
        }

        // Return the display form: either the original token, or underscores for letters + original punctuation
        public string Display()
        {
            if (!_hidden)
                return _originalToken;

            var sb = new StringBuilder(_originalToken.Length);
            foreach (char c in _originalToken)
            {
                sb.Append(char.IsLetter(c) ? '_' : c);
            }
            return sb.ToString();
        }
    }

    // Represents the full scripture: reference + list of words/tokens
    public class Scripture
    {
        private readonly ScriptureReference _reference;
        private readonly List<Word> _words;
        private readonly Random _random = new Random();

        public Scripture(ScriptureReference reference, string text)
        {
            _reference = reference ?? throw new ArgumentNullException(nameof(reference));
            if (text == null) throw new ArgumentNullException(nameof(text));

            // Simple tokenization by whitespace; punctuation stays attached to tokens (desired behavior)
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            _words = tokens.Select(tok => new Word(tok)).ToList();
        }

        // Show the scripture as a full string with hidden words replaced appropriately
        public string GetDisplayText()
        {
            var sb = new StringBuilder();
            sb.Append(_reference.ToString());
            sb.Append(" - ");
            sb.Append(string.Join(" ", _words.Select(w => w.Display())));
            return sb.ToString();
        }

        // Return true when all words that contain letters are hidden
        public bool AllWordsHidden()
        {
            return _words.Where(w => w.HasLetters).All(w => w.IsHidden);
        }

        // Hide up to 'count' random words that are still visible (letters remain)
        // Returns number of words actually hidden this call
        public int HideRandomVisibleWords(int count)
        {
            if (count <= 0) return 0;

            var visibleIndices = _words
                .Select((w, idx) => new { Word = w, Index = idx })
                .Where(x => x.Word.HasLetters && !x.Word.IsHidden)
                .Select(x => x.Index)
                .ToList();

            if (!visibleIndices.Any())
                return 0;

            // Shuffle visibleIndices and take up to count
            int toHide = Math.Min(count, visibleIndices.Count);
            // Fisher-Yates shuffle partial
            for (int i = visibleIndices.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                var tmp = visibleIndices[i];
                visibleIndices[i] = visibleIndices[j];
                visibleIndices[j] = tmp;
            }

            var chosen = visibleIndices.Take(toHide);
            foreach (int idx in chosen)
            {
                _words[idx].Hide();
            }

            return chosen.Count();
        }

        // Count of visible (non-hidden) words that contain letters (useful for UI or deciding how many to hide next)
        public int VisibleWordCount()
        {
            return _words.Count(w => w.HasLetters && !w.IsHidden);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
            // Build a small library of scriptures (could be loaded from file as an extension)
            var scriptures = new List<Scripture>
            {
                new Scripture(new ScriptureReference("John", 3, 16),
                    "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish but have everlasting life."),
                new Scripture(new ScriptureReference("Proverbs", 3, 5, 6),
                    "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
                new Scripture(new ScriptureReference("Philippians", 4, 13),
                    "I can do all things through Christ which strengtheneth me."),
                new Scripture(new ScriptureReference("Psalm", 23, 1, 6),
                    "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: he leadeth me beside the still waters."),
                new Scripture(new ScriptureReference("1 Nephi", 3, 7),
                    "I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.")
            };

            var rand = new Random();
            var scripture = scriptures[rand.Next(scriptures.Count)];

            Console.Clear();
            Console.WriteLine("Scripture Memorizer");
            Console.WriteLine("-------------------");
            Console.WriteLine();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide a few words, or type 'quit' and press Enter to exit.");

            // We'll hide up to 3 words each Enter (this is a reasonable 'few'); adjust if you want a different pace.
            const int hidePerStep = 3;

            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                if (input != null && input.Trim().ToLower() == "quit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                // Hide some words
                int hidden = scripture.HideRandomVisibleWords(hidePerStep);

                // Clear and show updated scripture
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

                if (hidden == 0)
                {
                    // No visible words to hide; finish.
                    Console.WriteLine("All hideable words are now hidden. Press Enter to finish or type 'quit' to exit.");
                }
                else
                {
                    Console.WriteLine($"Hidden {hidden} word(s). {scripture.VisibleWordCount()} visible word(s) remain.");
                    Console.WriteLine("Press Enter to hide more, or type 'quit' to exit.");
                }
            }

            // Final display (showing all hidden state)
            Console.WriteLine();
            Console.WriteLine("Final state:");
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}