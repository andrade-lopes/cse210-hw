using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public int GetMinutes() => _minutes;
    public DateTime GetDate() => _date;

    public abstract double GetDistance(); // km
    public abstract double GetSpeed();    // kph
    public abstract double GetPace();     // min per km

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_minutes} min): " +
               $"Distance {GetDistance():F1} km, Speed {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
}