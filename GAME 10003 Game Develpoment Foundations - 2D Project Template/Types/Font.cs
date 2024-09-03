/*////////////////////////////////////////////////////////////////////////
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 *////////////////////////////////////////////////////////////////////////

/// <summary>
///     Represents a font.
/// </summary>
/// <remarks>
///     Wrapper around Raylib.Font
/// </remarks>
public readonly record struct Font
{
    public Raylib_cs.Font RaylibFont { get; init; }

    public static implicit operator Font(Raylib_cs.Font raylibFont)
    {
        var font = new Font()
        {
            RaylibFont = raylibFont,
        };
        return font;
    }
    public static implicit operator Raylib_cs.Font(Font font)
    {
        var raylibFont = font.RaylibFont;
        return raylibFont;
    }
}
