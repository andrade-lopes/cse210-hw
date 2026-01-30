//VideoPlayer
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Playlist playlist = new Playlist("My Favorites");

        YouTubeVideo video1 = new YouTubeVideo(
            "Learn C# Basics", 600, "Code Academy",
            "https://youtube.com/video1", 1200, 300);

        YouTubeVideo video2 = new YouTubeVideo(
            "OOP in C#", 900, "Programming School",
            "https://youtube.com/video2", 2500, 500);

        playlist.AddVideo(video1);
        playlist.AddVideo(video2);

        playlist.PlayAll();
    }
}