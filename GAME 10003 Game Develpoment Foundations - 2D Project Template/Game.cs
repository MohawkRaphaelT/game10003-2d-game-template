using Raylib_cs;
using System;
using System.Numerics;

/// <summary>
///     Your game code goes inside this class!
/// </summary>
public class Game
{
    // Variables needed to set up raylib
    public string title = "Game Title";
    public int screenWidth = 800;
    public int screenHeight = 600;

    // Place your variables here
    public Color backgroundColor = new Color(240);


    /// <summary>
    ///     Setup runs once before the game loop begins.
    /// </summary>
    public void Setup()
    {

    }

    /// <summary>
    ///     Update runs every frame.
    /// </summary>
    public void Update()
    {
        Raylib.ClearBackground(backgroundColor);

        //Raylib.DrawTextEx(Program.monospaceFont, "testing", new Vector2(5, 5), 16, 0, Color.Black);
        Text.Draw("Hello", new Vector2(200, 200) * Time.TimeElapsed / 5);

        Draw.FillColor = Color.LightGray;
        Draw.Circle(new(440, 300), 130);

        Draw.FillColor = Color.Blue;
        Draw.Ellipse(new(400, 300), new(30, 100));
        Draw.Ellipse(new(440, 300), new(30, 100));
        Draw.Ellipse(new(480, 300), new(30, 100));

        // Triangle test
        Draw.FillColor = Color.Red;
        Draw.Circle(new(100, 100), 5);
        Draw.Triangle(new(100, 100), 100, Time.TimeElapsed * 1);
        Draw.FillColor = Color.Black;

        // Lines
        var lineSize = Draw.LineSize;
        Draw.LineSize = 10;
        Draw.LineSharp(new(100, 400), new(300, 200));
        Draw.Line(new(200, 400), new(400, 200));
        Draw.PolyLine([ new(10, 10), new(50, 50), new(100, 10) ]);
        Draw.LineSize = lineSize;
    }
}
