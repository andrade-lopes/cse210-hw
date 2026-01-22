using System;

namespace ScriptureMemorizer
{
    // Represents a scripture reference like "John 3:16" or "Proverbs 3:5-6"
    public class Reference
    {
        public string Book { get; private set; }
        public int Chapter { get; private set; }
        public int VerseStart { get; private set; }
        public int? VerseEnd { get; private set; }

        // Constructor for a single verse
        public Reference(string book, int chapter, int verse)
        {
            Book = book;
            Chapter = chapter;
            VerseStart = verse;
            VerseEnd = null;
        }

        // Constructor for a verse range
        public Reference(string book, int chapter, int verseStart, int verseEnd)
        {
            if (verseEnd < verseStart)
                throw new ArgumentException("Verse end must be greater than or equal to verse start.");

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
}