/*////////////////////////////////////////////////////////////////////////
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 *////////////////////////////////////////////////////////////////////////

using Raylib_cs;
using System;
using System.Numerics;

/// <summary>
///     Access window-related information.
/// </summary>
public static class Window
{
    // FIELDS
    private static int width = 256;
    private static int height = 256;
    private static string title = "2D Game Template";
    private static int targetFPS = 60;

    //PROPERTIES
    /// <summary>
    ///     Width of screen in pixels.
    /// </summary>
    public static int Width
    {
        get => width;
        set => SetHeight(value);
    }

    /// <summary>
    ///     Height of screen in pixels.
    /// </summary>
    public static int Height
    {
        get => height;
        set => SetWidth(value);
    }

    /// <summary>
    ///     Size of screen in pixels.
    /// </summary>
    public static Vector2 Size
    {
        get => new(width, height);
        set => SetSize(value);
    }

    /// <summary>
    ///     Title displayed on top of window.
    /// </summary>
    public static string Title
    {
        get => title;
        set => title = value;
    }

    /// <summary>
    ///     How many frames-per-second (FPS) the game tries to output every second.
    /// </summary>
    public static int TargetFPS
    {
        get => targetFPS;
        set => SetTargetFpsOrError(value);
    }

    /// <summary>
    ///     How many frames-per-second the window is running at.
    /// </summary>
    public static float CurrentFPS => Raylib.GetFPS();

    // METHODS
    /// <summary>
    ///     Clears the screen to the specified <paramref name="color"/>.
    /// </summary>
    /// <param name="color">The background color to paint.</param>
    public static void ClearBackground(Color color)
    {
        Raylib.ClearBackground(color);
    }

    /// <summary>
    ///     Set the window size in pixels.
    /// </summary>
    /// <param name="width">Width of screen in pixels.</param>
    /// <param name="height">Height of screen in pixels.</param>
    public static void SetSize(int width, int height)
    {
        Window.width = width;
        Window.height = height;
        Raylib.SetWindowSize(width, height);
    }

    /// <summary>
    ///     Set the window title.
    /// </summary>
    /// <param name="value">The new title to display.</param>
    public static void SetTitle(string value)
    {
        Raylib.SetWindowTitle(value);
    }

    private static void SetWidth(int width)
    {
        Window.width = width;
        Raylib.SetWindowSize(width, height);
    }
    private static void SetHeight(int height)
    {
        Window.height = height;
        Raylib.SetWindowSize(width, height);
    }
    private static void SetSize(Vector2 size)
    {
        int width = (int)size.X;
        int height = (int)size.Y;
        Raylib.SetWindowSize(width, height);
    }
    private static void SetTargetFpsOrError(int targetFPS)
    {
        if (targetFPS <= 0)
        {
            string msg = "FPS must be greater than 0!";
            throw new ArgumentException(msg);
        }

        Window.targetFPS = targetFPS;
    }

}
