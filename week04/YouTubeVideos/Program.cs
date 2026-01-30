//VideoPlayer
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Playlist playlist = new Playlist("My Favorites");

        YouTubeVideo video1 = new YouTubeVideo(
            "C# tutorial for beginners", 600, "Bro Code",
            "https://www.youtube.com/watch?v=r3CExhZgZV8&list=PLZPZq0r_RZOPNy28FDBys3GVP2LiaIyP_", 1200, 300);

        YouTubeVideo video2 = new YouTubeVideo(
            "OOP in C#", 900, "Programming School",
            "https://youtube.com/video2", 2500, 500);

        playlist.AddVideo(video1);
        playlist.AddVideo(video2);

        playlist.PlayAll();
    }
}