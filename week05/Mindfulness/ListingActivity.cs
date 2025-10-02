// ListingActivity.cs
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
        : base("Listing", "This activity will help you list positive things in your life.", 30)
    {
        _prompts = new List<string>();
    }

    public void Run() { }
    public string GetRandomPrompt() { return ""; }
    public List<string> GetListFromUser() { return new List<string>(); }
}