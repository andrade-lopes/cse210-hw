using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
        : base("Reflecting", "This activity will help you reflect on meaningful experiences.", 30)
    {
        _prompts = new List<string>()
        {
            "Think of a time when you felt truly at peace.",
            "Recall an experience where you helped someone in need.",
            "Think about a challenge you overcame."
        };

        _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "What did you learn about yourself?",
            "How can you apply this lesson in the future?",
            "What feelings did you have during this experience?"
        };
    }

    public void Run()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine($"\nPrompt: {prompt}");
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine($"\n{question}");
            ShowSpinner(5);
        }
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
    }

    public void DisplayQuestions()
    {
        Console.WriteLine(GetRandomQuestion());
    }
}