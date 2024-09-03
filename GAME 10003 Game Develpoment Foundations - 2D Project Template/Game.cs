// Add libraries to be used here
using System;
using System.Numerics;

/// <summary>
///     Your game code goes inside this class!
/// </summary>
public class Game
{
    // Place your variables here
    // ex. Color backgroundColor = new Color(240);


    /// <summary>
    ///     Setup runs once before the game loop begins.
    /// </summary>
    public void Setup()
    {
        Window.SetTitle("Game");
        Window.SetSize(800, 600);
    }

    /// <summary>
    ///     Update runs every frame.
    /// </summary>
    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);
        Draw.LineColor = Color.Clear;
        Draw.FillColor = Color.Red;
        Draw.Circle(Window.Width / 2, Window.Height / 2, 100);
    }
}
