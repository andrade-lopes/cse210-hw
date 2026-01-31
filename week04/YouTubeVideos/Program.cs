//VideoPlayer
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Playlist playlist = new Playlist("My Favorites");

        YouTubeVideo video1 = new YouTubeVideo(
            "C# tutorial for beginners", 390, "Bro Code",
            "https://www.youtube.com/watch?v=r3CExhZgZV8&list=PLZPZq0r_RZOPNy28FDBys3GVP2LiaIyP_", 351000, 9300);

        YouTubeVideo video2 = new YouTubeVideo(
            "Object Oriented Programming In C#", 1153, "Simplilearn",
            "https://www.youtube.com/watch?v=iA0XZwFqqKI", 170000, 2000);

        playlist.AddVideo(video1);
        playlist.AddVideo(video2);

        playlist.PlayAll();
    }
}