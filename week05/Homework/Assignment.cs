using System;

public class Assignment
{
    // Protected so derived classes can access
    protected string _studentName;
    protected string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to return a summary
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}