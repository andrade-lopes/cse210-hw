using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string ShortName
    {
        get { return _shortName; }
    }

    // Called when an event (progress) is recorded for this goal
    public abstract int RecordEvent();

    // Indicates whether the goal is fully completed
    public abstract bool IsComplete();

    // Returns a formatted description of the goal for display
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    // Returns a string representation for saving to a file
    public abstract string GetStringRepresentation();
}