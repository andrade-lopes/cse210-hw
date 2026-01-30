public class YouTubeVideo : Video
{
    private string _url;
    private int _views;
    private int _likes;

    public YouTubeVideo(string title, int lengthSeconds, string channelName,
                         string url, int views, int likes)
        : base(title, lengthSeconds, channelName)
    {
        _url = url;
        _views = views;
        _likes = likes;
    }

    public override void Play()
    {
        Console.WriteLine($"Now playing: {_title}");
        Console.WriteLine($"Channel: {_channelName}");
        Console.WriteLine($"URL: {_url}");
        Console.WriteLine($"Views: {_views} | Likes: {_likes}");
        Console.WriteLine("----------------------------");
    }
}