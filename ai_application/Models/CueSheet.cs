using System.Collections.Generic;

public class CueSheet
{
    public string Title { get; set; }
    public List<MusicEntry> MusicEntries { get; set; } = new();
}

public class MusicEntry
{
    public string CueTitle { get; set; }
    public List<Contributor> Contributors { get; set; } = new();
    public List<Publisher> Publishers { get; set; } = new();
}

public class Contributor
{
    public string Name { get; set; }
    public string Role { get; set; }
    public double SplitShare { get; set; }
}

public class Publisher
{
    public string Name { get; set; }
    public double SplitShare { get; set; }
}
