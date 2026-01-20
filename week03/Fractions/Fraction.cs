using System;

public class Fraction
{
    // Private attributes (Encapsulation)
    private int _top;
    private int _bottom;

    // Constructors
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom != 0 ? bottom : 1; // Avoid division by zero
    }

    // Getters e Setters
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int value)
    {
        _top = value;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int value)
    {
        if (value != 0)
            _bottom = value;
        else
            Console.WriteLine("Denominator cannot be zero. Value not changed.");
    }

    // Representation Methods
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}