/*////////////////////////////////////////////////////////////////////////
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 *////////////////////////////////////////////////////////////////////////

namespace Game10003;

/// <summary>
///     Represents a sound file (audio 10s or less).
/// </summary>
/// <remarks>
///     Wrapper around Raylib.Sound
/// </remarks>
public readonly record struct Sound
{
    public Raylib_cs.Sound RaylibSound { get; init; }

    public static implicit operator Sound(Raylib_cs.Sound raylibSound)
    {
        var font = new Sound()
        {
            RaylibSound = raylibSound,
        };
        return font;
    }
    public static implicit operator Raylib_cs.Sound(Sound sound)
    {
        var raylibSound = sound.RaylibSound;
        return raylibSound;
    }
}