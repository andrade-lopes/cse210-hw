// ReflectingActivity.cs
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
        : base("Reflecting", "This activity will help you reflect on meaningful experiences.", 30)
    {
        _prompts = new List<string>();
        _questions = new List<string>();
    }

    public void Run() { }
    public string GetRandomPrompt() { return ""; }
    public string GetRandomQuestion() { return ""; }
    public void DisplayPrompt() { }
    public void DisplayQuestions() { }
}