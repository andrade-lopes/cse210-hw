using System;
using System.Collections.Generic;

public class Resume
{
    public string _personName;
    public List<Job> _jobs = new List<Job>();

    // Method for displaying the resume
    public void Display()
    {
        Console.WriteLine($"Name: {_personName}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display(); // calls the Display of the Job class
        }
    }
}