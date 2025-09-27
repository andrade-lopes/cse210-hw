using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        // Create video
        var video1 = new Video("Learning C#", "José Lopes", 600);
        video1.AddComment(new Comment("Mary", "Very good!"));
        video1.AddComment(new Comment("Paul", "I liked the content."));
        video1.AddComment(new Comment("Hannah", "Clear explanation!"));

        var video2 = new Video("Trip to Italy", "Bernard Johnson", 1200);
        video2.AddComment(new Comment("John", "I want to go too!"));
        video2.AddComment(new Comment("Luke", "Well-produced video."));
        video2.AddComment(new Comment("Nataly", "What an incredible trip!"));

        var video3 = new Video("Cake recipe", "Joanna Lopes", 300);
        video3.AddComment(new Comment("Joseph", "Looks delicious!"));
        video3.AddComment(new Comment("Laura", "I'll try to do it."));
        video3.AddComment(new Comment("James", "Thanks for the recipe."));

        // List of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Show informations
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Duration: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.AuthorName}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 50));
        }
    }
}