/*////////////////////////////////////////////////////////////////////////
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 *////////////////////////////////////////////////////////////////////////

/// <summary>
///     Represents a music file (audio over 10s long).
/// </summary>
/// <remarks>
///     Wrapper around Raylib.Music
/// </remarks>
public record struct Music
{
    /// <summary>
    ///     Whether or not this music loops.
    /// </summary>
    public bool Looping
    {
        readonly get => RaylibMusic.Looping;
        set
        {
            var local = RaylibMusic;
            local.Looping = value;
            RaylibMusic = local;
        }
    }

    [GeneratorTools.OmitFromDocumentation]
    public Raylib_cs.Music RaylibMusic { get; private set; }

    [GeneratorTools.OmitFromDocumentation]
    public static implicit operator Music(Raylib_cs.Music raylibMusic)
    {
        var font = new Music()
        {
            RaylibMusic = raylibMusic,
        };
        return font;
    }

    [GeneratorTools.OmitFromDocumentation]
    public static implicit operator Raylib_cs.Music(Music music)
    {
        var raylibMusic = music.RaylibMusic;
        return raylibMusic;
    }
}