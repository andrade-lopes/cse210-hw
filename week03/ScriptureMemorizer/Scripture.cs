using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(' ');

        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < numberToHide && !IsCompletelyHidden())
        {
            int index = random.Next(_words.Count);

            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();

        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()}\n\n{string.Join(" ", displayWords)}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}