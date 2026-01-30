using System.Collections.Generic;

public class Playlist
{
    private List<Video> _videos = new List<Video>();
    private string _name;

    public Playlist(string name)
    {
        _name = name;
    }

    public void AddVideo(Video video)
    {
        _videos.Add(video);
    }

    public void PlayAll()
    {
        Console.WriteLine($"Playing playlist: {_name}");
        Console.WriteLine("============================");

        foreach (Video video in _videos)
        {
            video.Play();
        }
    }
}