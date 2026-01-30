public abstract class Video
{
    protected string _title;
    protected int _lengthSeconds;
    protected string _channelName;

    public Video(string title, int lengthSeconds, string channelName)
    {
        _title = title;
        _lengthSeconds = lengthSeconds;
        _channelName = channelName;
    }

    public abstract void Play();

    public string GetTitle()
    {
        return _title;
    }
}