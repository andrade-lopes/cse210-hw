using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} Activity ---");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration in seconds: ");

        // Allow user to set duration dynamically
        if (int.TryParse(Console.ReadLine(), out int input))
        {
            _duration = input;
        }
        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        Console.WriteLine($"You have completed {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(200);
            Console.Write("\b \b"); // erase last character
            i = (i + 1) % spinner.Length;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}