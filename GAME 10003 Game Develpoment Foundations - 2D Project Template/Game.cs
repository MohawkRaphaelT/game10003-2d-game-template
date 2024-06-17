using Raylib_cs;
using System;
using System.Numerics;

public class Game
{
    // Variables needed to set up raylib
    public string title = "Game Title";
    public int screenWidth = 800;
    public int screenHeight = 600;
    public int targetFps = 60;
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
    }
}
