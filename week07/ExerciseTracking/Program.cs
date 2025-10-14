using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>()
        {
            new Running(new DateTime(2025, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2025, 11, 3), 45, 20.0),
            new Swimming(new DateTime(2025, 11, 3), 30, 40)
        };

        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}