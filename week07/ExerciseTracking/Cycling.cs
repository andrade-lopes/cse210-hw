using System;

public class Cycling : Activity
{
    private double _speedKph;

    public Cycling(DateTime date, int minutes, double speedKph)
        : base(date, minutes)
    {
        _speedKph = speedKph;
    }

    public override double GetDistance() => (_speedKph * GetMinutes()) / 60.0;
    public override double GetSpeed() => _speedKph;
    public override double GetPace() => 60.0 / _speedKph;
}