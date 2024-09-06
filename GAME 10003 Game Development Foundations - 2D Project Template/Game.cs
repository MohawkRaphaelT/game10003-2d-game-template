using System;
using System.Numerics;

// Your game code goes inside this class!
public class Game
{
    // Place your variables here
    

    // Setup runs once before the game loop begins.
    public void Setup()
    {
        Window.TargetFPS = 30;
        Window.SetSize(400, 400);
    }

    // Update runs every frame.
    public void Update()
    {
        Window.ClearBackground(Color.White);

        Draw.LineColor = Color.Black;
        Draw.FillColor = Color.Red;
        Draw.Triangle(new(100, 100), 50, Time.SecondsElapsed);
        Draw.Square(20, 20, 50);

        Raylib_cs.Raylib.DrawCircle(200, 200, 50, Color.Blue);
    }
}
