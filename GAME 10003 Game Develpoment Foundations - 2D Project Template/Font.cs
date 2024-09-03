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
