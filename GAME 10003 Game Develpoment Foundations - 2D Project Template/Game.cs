using Raylib_cs;
using System;
using System.Numerics;

public class Game
{
    // Variables needed to set up raylib
    public string title = "Game Title";
    public int screenWidth = 800;
    public int screenHeight = 600;

    // Place your variables here
    public Color backgroundColor = new Color(240);


    // Setup runs once before the game loop begins.
    public void Setup()
    {

    }

    // Update runs every frame.
    public void Update()
    {
        Raylib.ClearBackground(backgroundColor);

        //Raylib.DrawTextEx(Program.monospaceFont, "testing", new Vector2(5, 5), 16, 0, Color.Black);
        Text.Draw("Hello", new Vector2(200, 200) * Time.Elapsed / 5);

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
