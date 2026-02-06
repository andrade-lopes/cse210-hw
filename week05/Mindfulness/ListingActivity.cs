using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
        : base("Listing", "This activity will help you list positive things in your life.", 30)
    {
        _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are your personal strengths?",
            "When have you felt peace this week?",
            "What are things you are grateful for?"
        };
    }

    public void Run()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("Start listing... You have a few seconds!");
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        _count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                _count++;
            }
        }

        Console.WriteLine($"\nYou listed {_count} items. Great job!");
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    public List<string> GetListFromUser()
    {
        return new List<string>(); // Already handled in Run()
    }
}