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
        Draw.CircleFill(new(440, 300), 130);

        Draw.FillColor = Color.Blue;
        Draw.EllipseFill(new(400, 300), new(30, 100));
        Draw.EllipseFill(new(440, 300), new(30, 100));
        Draw.EllipseFill(new(480, 300), new(30, 100));

        // Triangles test
        Draw.TriangleFill(new(100, 100), 100, Time.Elapsed * 36, Color.Red);
        Draw.TriangleOutline(new(250, 100), 100, Time.Elapsed * 36, 5, Color.Black);
        Draw.Triangle(new(400, 100), 100, Time.Elapsed * 36, Color.Red, 5, Color.Black);
    }
}
