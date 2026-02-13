using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // Regular constructor (used when creating a new goal from scratch)
    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // Constructor used when loading from file (includes saved progress)
    public ChecklistGoal(string name, string description, int points, int amountCompleted, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    // Records an event (progress). Returns earned points.
    public override int RecordEvent()
    {
        int prev = _amountCompleted;
        _amountCompleted++;

        if (prev < _target && _amountCompleted >= _target)
        {
            // Just completed the checklist goal → award points + bonus
            return _points + _bonus;
        }

        // Otherwise, only return regular points
        return _points;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        // Format: ChecklistGoal:Name,Description,Points,AmountCompleted,Target,Bonus
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonus}";
    }
}