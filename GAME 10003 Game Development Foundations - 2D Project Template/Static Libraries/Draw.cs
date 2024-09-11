/*////////////////////////////////////////////////////////////////////////
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 *////////////////////////////////////////////////////////////////////////

using Raylib_cs;
using System;
using System.Numerics;

namespace Game10003;

/// <summary>
///     Access shape drawing functions.
/// </summary>
/// <remarks>
///     A static wrapper to standardize raylib's draw API.
/// </remarks>
public static class Draw
{
    // PROPERTIES
    /// <summary>
    ///     Shape fill color.
    /// </summary>
    public static Color FillColor { get; set; } = Color.Black;

    /// <summary>
    ///     Line and outline color.
    /// </summary>
    public static Color LineColor { get; set; } = Color.Black;

    /// <summary>
    ///     Line and outline size in pixels.
    /// </summary>
    public static float LineSize { get; set; } = 1f;


    // DRAW LINE
    /// <summary>
    ///     Draw a line with sharp ends from <paramref name="start"/> to <paramref name="end"/> 
    ///     using <see cref="Draw.LineSize"/> and <see cref="Draw.LineColor"/>.
    /// </summary>
    /// <param name="start">Line start position.</param>
    /// <param name="end">Line end position.</param>
    public static void LineSharp(Vector2 start, Vector2 end)
        => LineSharp(start, end, LineSize, LineColor);
    /// <summary>
    ///     Draw a line with sharp ends from (<paramref name="x0"/>, <paramref name="y0"/>) to
    ///     (<paramref name="x1"/>, <paramref name="y1"/>) using <see cref="Draw.LineSize"/>
    ///     and <see cref="Draw.LineColor"/>.
    /// </summary>
    /// <param name="x0">Line start position X.</param>
    /// <param name="y0">Line start position Y.</param>
    /// <param name="x1">Line end position X.</param>
    /// <param name="y1">Line end position Y.</param>
    public static void LineSharp(float x0, float y0, float x1, float y1)
        => LineSharp(new(x0, y0), new(x1, y1), LineSize, LineColor);
    //
    private static void LineSharp(Vector2 start, Vector2 end, float lineSize, Color lineColor)
    {
        Raylib.DrawLineEx(start, end, lineSize, lineColor);
    }


    // DRAW POLY-LINES
    /// <summary>
    ///     Draw lines with rounded ends between all <paramref name="points"/>
    ///     using <see cref="Draw.LineSize"/> and <see cref="Draw.LineColor"/>
    /// </summary>
    /// <param name="points">The points to draw between.</param>
    public static void PolyLine(Vector2[] points)
        => PolyLine(points, LineSize, LineColor);
    //
    private static void PolyLine(Vector2[] points, float lineSize, Color lineColor)
    {
        float circleRadius = lineSize / 2f;

        for (int i = 0; i < points.Length - 1; i++)
        {
            // Endpoints
            Vector2 start = points[i + 0];
            Vector2 end = points[i + 1];
            // Draw lines
            Raylib.DrawLineEx(start, end, lineSize, lineColor);
            // Draw circles to smooth start points
            Raylib.DrawCircleV(start, circleRadius, lineColor);
        }
        // Draw circle on last line end to smooth it, too
        Raylib.DrawCircleV(points[^1], circleRadius, lineColor);

    }


    // DRAW LINE ROUNDED
    /// <summary>
    ///     Draw a line with rounded ends from <paramref name="start"/> to <paramref name="end"/> 
    ///     using <see cref="Draw.LineSize"/> and <see cref="Draw.LineColor"/>.
    /// </summary>
    /// <param name="start">Line start position.</param>
    /// <param name="end">Line end position.</param>
    public static void Line(Vector2 start, Vector2 end)
        => Line(start, end, LineSize, LineColor);
    /// <summary>
    ///     Draw a line with rounded ends from (<paramref name="x0"/>, <paramref name="y0"/>) to
    ///     (<paramref name="x1"/>, <paramref name="y1"/>) using <see cref="Draw.LineSize"/> and
    ///     <see cref="Draw.LineColor"/>.
    /// </summary>
    /// <param name="x0">Line start position X.</param>
    /// <param name="y0">Line start position Y.</param>
    /// <param name="x1">Line end position X.</param>
    /// <param name="y1">Line end position Y.</param>
    public static void Line(float x0, float y0, float x1, float y1)
        => Line(new(x0, y0), new(x1, y1), LineSize, LineColor);
    //
    private static void Line(Vector2 start, Vector2 end, float lineSize, Color lineColor)
    {
        Raylib.DrawLineEx(start, end, lineSize, lineColor);
        // Draw circles at each point to smooth ends
        float circleRadius = lineSize / 2f;
        Raylib.DrawCircleV(start, circleRadius, lineColor);
        Raylib.DrawCircleV(end, circleRadius, lineColor);
    }


    // DRAW RECTANGLE
    /// <summary>
    ///     Draw a filled and outlined rectangle at <paramref name="position"/> expanding
    ///     right and down to <paramref name="size"/> using <see cref="Draw.LineSize"/> for
    ///     the outline thickness, <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the rectangle's fill Color.
    /// </summary>
    /// <param name="position">The rectangle position, defines the upper-left corner.</param>
    /// <param name="size">The size of the rectangle.</param>
    public static void Rectangle(Vector2 position, Vector2 size)
        => Rectangle(position.X, position.Y, size.X, size.Y, FillColor, LineSize, LineColor);
    /// <summary>
    ///     Draw a filled and outlined rectangle at position (<paramref name="x"/>, 
    ///     <paramref name="y"/>) expanding right and down to size (<paramref name="w"/>, 
    ///     <paramref name="h"/>) using <see cref="Draw.LineSize"/> for
    ///     the outline thickness, <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the rectangle's fill Color.
    /// </summary>
    /// <param name="x">The rectangle's X position, defines the left edge.</param>
    /// <param name="y">The rectangle's Y position, defines the top edge.</param>
    /// <param name="w">The rectangle's width.</param>
    /// <param name="h">The rectangle's height.</param>
    public static void Rectangle(float x, float y, float w, float h)
        => Rectangle(x, y, w, h, FillColor, LineSize, LineColor);
    //
    private static void Rectangle(float x, float y, float w, float h, Color fillColor, float lineSize, Color lineColor)
    {
        Vector2 position = new(x, y);
        Vector2 size = new(w, h);
        RectangleFill(position, size, fillColor);
        RectangleOutline(position, size, lineSize, lineColor);
    }
    private static void RectangleFill(Vector2 position, Vector2 size, Color fillColor)
    {
        int ix = (int)Math.Round(position.X, MidpointRounding.ToEven);
        int iy = (int)Math.Round(position.Y, MidpointRounding.ToEven);
        int iw = (int)Math.Round(size.X, MidpointRounding.ToEven);
        int ih = (int)Math.Round(size.Y, MidpointRounding.ToEven);
        Raylib.DrawRectangle(ix, iy, iw, ih, fillColor);
    }
    private static void RectangleOutline(Vector2 position, Vector2 size, float lineSize, Color lineColor)
    {
        int x = (int)Math.Round(position.X, MidpointRounding.ToEven);
        int y = (int)Math.Round(position.Y, MidpointRounding.ToEven);
        int w = (int)Math.Round(size.X, MidpointRounding.ToEven);
        int h = (int)Math.Round(size.Y, MidpointRounding.ToEven);
        Rectangle rectangle = new(x, y, w, h);
        Raylib.DrawRectangleLinesEx(rectangle, lineSize, lineColor);
    }


    // DRAW SQUARE
    /// <summary>
    ///     Draw a filled and outlined square at <paramref name="position"/> expanding
    ///     right and down to <paramref name="size"/> using <see cref="Draw.LineSize"/> for
    ///     the outline thickness, <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the square's fill Color.
    /// </summary>
    /// <param name="position">The square position, defines the upper-left corner.</param>
    /// <param name="size">The square's width and height.</param>
    public static void Square(Vector2 position, float size)
        => Square(position.X, position.Y, size, FillColor, LineSize, LineColor);
    /// <summary>
    ///     Draw a filled and outlined square at position (<paramref name="x"/>, 
    ///     <paramref name="y"/>) expanding right and down to <paramref name="size"/>
    ///     using <see cref="Draw.LineSize"/> for the outline thickness,
    ///     <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the square's fill Color.
    /// </summary>
    /// <param name="x">The square's X position, defines the left edge.</param>
    /// <param name="y">The square's Y position, defines the top edge.</param>
    /// <param name="size">The square's width and height.</param>
    public static void Square(float x, float y, float size)
        => Square(x, y, size, FillColor, LineSize, LineColor);
    //
    private static void Square(float x, float y, float size, Color fillColor, float lineSize, Color lineColor)
        => Rectangle(x, y, size, size, fillColor, lineSize, lineColor);


    // DRAW ELLIPSE
    /// <summary>
    ///     Draw a filled and outlined ellipse at <paramref name="position"/> expanding
    ///     outward to <paramref name="size"/> using <see cref="Draw.LineSize"/> for
    ///     the outline thickness, <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the ellipse's fill Color.
    /// </summary>
    /// <param name="position">The ellipse position, defines the centre point.</param>
    /// <param name="size">The size of the ellipse.</param>
    public static void Ellipse(Vector2 position, Vector2 size)
        => Ellipse(position.X, position.Y, size.X, size.Y, FillColor, LineSize, LineColor);
    /// <summary>
    ///     Draw a filled and outlined ellipse at position (<paramref name="x"/>, 
    ///     <paramref name="y"/>) expanding outward to size (<paramref name="w"/>, 
    ///     <paramref name="h"/>) using <see cref="Draw.LineSize"/> for the
    ///     outline thickness, <see cref="Draw.LineColor"/> for the line's color,
    ///     and <see cref="Draw.FillColor"/> for the ellipse's fill Color.
    /// </summary>
    /// <param name="x">The ellipse's X position, defines the horizontal centre.</param>
    /// <param name="y">The ellipse's Y position, defines the vertical centre.</param>
    /// <param name="w">The ellipse's width.</param>
    /// <param name="h">The ellipse's height.</param>
    public static void Ellipse(float x, float y, float w, float h)
        => Ellipse(x, y, w, h, FillColor, LineSize, LineColor);
    // 
    private static void Ellipse(float x, float y, float w, float h, Color fillColor, float lineSize, Color lineColor)
    {
        EllipseFill(x, y, w, h, fillColor);
        EllipseOutline(x, y, w, h, lineSize, lineColor);
    }
    private static void EllipseFill(float x, float y, float w, float h, Color fillColor)
    {
        // Do gradeschool math rounding. Ex: 0.499f rounds down to 0, 0.500f rounds up to 1.
        int ix = (int)Math.Round(x, MidpointRounding.ToEven);
        int iy = (int)Math.Round(y, MidpointRounding.ToEven);
        float halfWidth = w / 2f;
        float halfHeight = h / 2f;
        Raylib.DrawEllipse(ix, iy, halfWidth, halfHeight, fillColor);
    }
    private static void EllipseOutline(float x, float y, float w, float h, float lineSize, Color lineColor)
    {
        int ix = (int)Math.Round(x, MidpointRounding.ToEven);
        int iy = (int)Math.Round(y, MidpointRounding.ToEven);
        float halfWidth = w / 2f;
        float halfHeight = h / 2f;
        // Draw border/outline
        // Hacky, eh?
        // Draw ellipse lines from all possible edges of rectangle to approximate outline.
        for (int i = 0; i < lineSize; i++)
        {
            for (int j = 0; j < lineSize; j++)
            {
                float borderWidth = halfWidth - i;
                float borderHeight = halfHeight - j;
                Raylib.DrawEllipseLines(ix, iy, borderWidth, borderHeight, lineColor);
            }
        }
    }


    // DRAW CIRCLE
    /// <summary>
    ///     Draw a filled and outlined circle at <paramref name="position"/> expanding
    ///     outward to <paramref name="radius"/> using <see cref="Draw.LineSize"/> for
    ///     the outline thickness, <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the circle's fill color.
    /// </summary>
    /// <param name="position">The circle position, defines the centre point.</param>
    /// <param name="radius">The circle radius.</param>
    public static void Circle(Vector2 position, float radius)
        => Circle(position, radius, FillColor, LineSize, LineColor);
    /// <summary>
    ///     Draw a filled and outlined circle at position (<paramref name="x"/>, 
    ///     <paramref name="y"/>) expanding outward to <paramref name="radius"/>
    ///     using <see cref="Draw.LineSize"/> for the outline thickness,
    ///     <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the circle's fill color.
    /// </summary>
    /// <param name="x">The circle's X position, defines the horizontal centre.</param>
    /// <param name="y">The circle's Y position, defines the vertical centre.</param>
    /// <param name="radius">The circle radius.</param>
    public static void Circle(float x, float y, float radius)
        => Circle(new Vector2(x, y), radius, FillColor, LineSize, LineColor);
    //
    private static void Circle(Vector2 position, float radius, Color fillColor, float lineSize, Color lineColor)
    {
        CircleFill(position, radius, fillColor);
        CircleOutline(position, radius, lineSize, lineColor);
    }
    private static void CircleFill(Vector2 position, float radius, Color fillColor)
    {
        Raylib.DrawCircleV(position, radius, fillColor);
    }
    private static void CircleOutline(Vector2 position, float radius, float lineSize, Color lineColor)
    {
        float innerRadius = radius - lineSize;
        float outerRadius = radius;
        int segments = (int)(radius * 4);
        Raylib.DrawRing(position, innerRadius, outerRadius, 0, 360, segments, lineColor);
    }


    // TRIANGLE
    /// <summary>
    ///     Draw a filled and outlined triangle with corners at positions
    ///     <paramref name="position1"/>, <paramref name="position2"/>,
    ///     and <paramref name="position3"/> using <see cref="Draw.LineSize"/>
    ///     for the outline thickness, <see cref="Draw.LineColor"/> for the line's
    ///     color, and <see cref="Draw.FillColor"/> for the triangle's fill color.
    /// </summary>
    /// <param name="position1">The triangle's first corner's position.</param>
    /// <param name="position2">The triangle's second corner's position.</param>
    /// <param name="position3">The triangle's third corner's position.</param>
    public static void Triangle(Vector2 position1, Vector2 position2, Vector2 position3)
        => Triangle(position1, position2, position3, FillColor, LineSize, LineColor);
    /// <summary>
    ///     Draw a filled and outlined triangle with corners at positions
    ///     (<paramref name="x1"/>, <paramref name="y1"/>),
    ///     (<paramref name="x2"/>, <paramref name="y2"/>), and
    ///     (<paramref name="x3"/>, <paramref name="y3"/>)
    ///     using <see cref="Draw.LineSize"/> for the outline thickness,
    ///     <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the triangle's fill color.
    /// </summary>
    /// <param name="x1">The triangle's first corner's X position.</param>
    /// <param name="y1">The triangle's first corner's Y position.</param>
    /// <param name="x2">The triangle's second corner's X position.</param>
    /// <param name="y2">The triangle's second corner's Y position.</param>
    /// <param name="x3">The triangle's third corner's X position.</param>
    /// <param name="y3">The triangle's third corner's Y position.</param>
    public static void Triangle(float x1, float y1, float x2, float y2, float x3, float y3)
        => Triangle(new(x1, y1), new(x2, y2), new(x3, y3), FillColor, LineSize, LineColor);
    //
    private static void Triangle(Vector2 position1, Vector2 position2, Vector2 position3, Color fillColor, float lineSize, Color lineColor)
    {
        TriangleFill(position1, position2, position3, fillColor);
        TriangleOutline(position1, position2, position3, lineSize, lineColor);
    }
    private static void TriangleFill(Vector2 position1, Vector2 position2, Vector2 position3, Color fillColor)
    {
        Raylib.DrawTriangle(position1, position2, position3, fillColor);
        Raylib.DrawTriangle(position3, position2, position1, fillColor);
    }
    private static void TriangleOutline(Vector2 position1, Vector2 position2, Vector2 position3, float lineSize, Color lineColor)
    {
        Vector2[] outline = [position1, position2, position3, position1];
        PolyLine(outline, lineSize, lineColor);
    }


    // QUAD
    /// <summary>
    ///     Draw a filled and outlined quad with corners at positions
    ///     <paramref name="position1"/>, <paramref name="position2"/>,
    ///     <paramref name="position3"/>, and <paramref name="position4"/>
    ///     using <see cref="Draw.LineSize"/> for the outline thickness,
    ///     <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the quad's fill color.
    /// </summary>
    /// <param name="position1">The quad's first corner's position.</param>
    /// <param name="position2">The quad's second corner's position.</param>
    /// <param name="position3">The quad's third corner's position.</param>
    /// <param name="position4">The quad's third corner's position.</param>
    public static void Quad(Vector2 position1, Vector2 position2, Vector2 position3, Vector2 position4)
        => Quad(position1, position2, position3, position4, FillColor, LineSize, LineColor);
    /// <summary>
    ///     Draw a filled and outlined quad with corners at positions
    ///     (<paramref name="x1"/>, <paramref name="y1"/>),
    ///     (<paramref name="x2"/>, <paramref name="y2"/>),
    ///     (<paramref name="x3"/>, <paramref name="y3"/>), and
    ///     (<paramref name="x4"/>, <paramref name="y4"/>)
    ///     using <see cref="Draw.LineSize"/> for the outline thickness,
    ///     <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the quad's fill color.
    /// </summary>
    /// <param name="x1">The quad's first corner's X position.</param>
    /// <param name="y1">The quad's first corner's Y position.</param>
    /// <param name="x2">The quad's second corner's X position.</param>
    /// <param name="y2">The quad's second corner's Y position.</param>
    /// <param name="x3">The quad's third corner's X position.</param>
    /// <param name="y3">The quad's third corner's Y position.</param>
    /// <param name="x4">The quad's fourth corner's X position.</param>
    /// <param name="y4">The quad's fourth corner's Y position.</param>
    public static void Quad(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        => Quad(new(x1, y1), new(x2, y2), new(x3, y3), new(x4, y4), FillColor, LineSize, LineColor);
    //
    private static void Quad(Vector2 position1, Vector2 position2, Vector2 position3, Vector2 position4, Color fillColor, float lineSize, Color lineColor)
    {
        QuadFill(position1, position2, position3, position4, fillColor);
        QuadOutline(position1, position2, position3, position4, lineSize, lineColor);
    }
    private static void QuadFill(Vector2 position1, Vector2 position2, Vector2 position3, Vector2 position4, Color fillColor)
    {
        Raylib.DrawTriangleFan([position1, position2, position3, position4], 4, fillColor);
        Raylib.DrawTriangleFan([position4, position3, position2, position1], 4, fillColor);
    }
    private static void QuadOutline(Vector2 position1, Vector2 position2, Vector2 position3, Vector2 position4, float lineSize, Color lineColor)
    {
        Vector2[] outline = [position1, position2, position3, position4, position1];
        PolyLine(outline, lineSize, lineColor);
    }

}
