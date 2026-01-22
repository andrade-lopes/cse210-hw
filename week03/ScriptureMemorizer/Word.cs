using System.Linq;
using System.Text;

namespace ScriptureMemorizer
{
    // Represents a single word (or token) in the scripture text
    public class Word
    {
        private readonly string _originalText;
        private bool _isHidden;

        public Word(string text)
        {
            _originalText = text ?? string.Empty;
            _isHidden = false;
        }

        public bool IsHidden => _isHidden;

        // Checks if this word contains any letters
        public bool HasLetters => _originalText.Any(char.IsLetter);

        // Hides this word by replacing letters with underscores
        public void Hide()
        {
            if (HasLetters)
                _isHidden = true;
        }

        // Returns the text to display (hidden or original)
        public string GetDisplayText()
        {
            if (!_isHidden)
                return _originalText;

            StringBuilder sb = new StringBuilder();

            foreach (char c in _originalText)
            {
                sb.Append(char.IsLetter(c) ? '_' : c);
            }

            return sb.ToString();
        }
    }
}