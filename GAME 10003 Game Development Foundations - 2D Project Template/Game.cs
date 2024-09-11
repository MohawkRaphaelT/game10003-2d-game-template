// Include code libraries you need here:
using System;
using System.Numerics;

// Where your code is placed.
namespace Game10003;

/// <summary>
///     Your game code goes inside this class!
/// </summary>
public class Game
{
    // Place your variables here:


    /// <summary>
    ///     Setup runs once before the game loop begins.
    /// </summary>
    public void Setup()
    {
        Window.SetSize(400, 400);
    }

    /// <summary>
    ///     Update runs every frame.
    /// </summary>
    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);
        Draw.FillColor = Color.Red;
        Draw.Triangle(10, 10, 110, 10, 55, 100);
        Draw.Quad(10, 200, 110, 200, 110, 300, 10, 300);
    }
}
