using Raylib_cs;
using System;
using System.Numerics;

public class Game
{
    // Variables needed to set up raylib
    public string title = "Game Title";
    public int screenWidth = 800;
    public int screenHeight = 600;
    public Color backgroundColor = new Color(240);

    // Place your variables here


    // Setup runs once before the game loop begins.
    public void Setup()
    {

    }

    // Update runs every frame.
    public void Update()
    {
        Raylib.DrawTextEx(Program.monospaceFont, "testing", new Vector2(5, 5), 16, 0, Color.Black);
        Text.Draw("Hello", new(200, 200));

        Draw.FillColor = Color.LightGray;
        Draw.Circle(new(440, 300), 130);

        Draw.FillColor = Color.Blue;
        Draw.Ellipse(new(400, 300), new(30, 100));
        Draw.Ellipse(new(440, 300), new(30, 100));
        Draw.Ellipse(new(480, 300), new(30, 100));

        // Triangle test
        Draw.Triangle(new(100, 100), 100, Time.Elapsed * 36);
    }
}
