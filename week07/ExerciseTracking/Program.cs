using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");

        List<Activity> activities = new List<Activity>()
        {
            new Running(new DateTime(2026, 2, 16), 30, 4.8),
            new Cycling(new DateTime(2026, 2, 16), 45, 20.0),
            new Swimming(new DateTime(2026, 2, 16), 30, 40)
        };

        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}