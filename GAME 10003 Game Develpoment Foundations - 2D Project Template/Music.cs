/// <summary>
///     Represents a music file (audio over 10s long).
/// </summary>
/// <remarks>
///     Wrapper around Raylib.Music
/// </remarks>
public readonly record struct Music
{
    public Raylib_cs.Music RaylibMusic { get; init; }

    public static implicit operator Music(Raylib_cs.Music raylibMusic)
    {
        var font = new Music()
        {
            RaylibMusic = raylibMusic,
        };
        return font;
    }
    public static implicit operator Raylib_cs.Music(Music music)
    {
        var raylibMusic = music.RaylibMusic;
        return raylibMusic;
    }
}