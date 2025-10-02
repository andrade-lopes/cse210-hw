using System;

public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    // Constructor
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)  // calls base constructor
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Method specific to MathAssignment
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}