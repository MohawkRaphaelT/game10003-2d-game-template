/*////////////////////////////////////////////////////////////////////////
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 *////////////////////////////////////////////////////////////////////////

using Raylib_cs;
using System;
using System.Diagnostics;

namespace Game10003;

/// <summary>
///     Access time-related information.
/// </summary>
/// <remarks>
///     A static wrapper to standardize raylib's time API.
/// </remarks>
public static class Time
{
    private static int targetFPS = 60;
    private static double timeOffset = 0;


    // PROPERTIES
    /// <summary>
    ///     How many frames-per-second (FPS) the game tries to output every second.
    /// </summary>
    public static int TargetFPS
    {
        get => targetFPS;
        set => SetTargetFpsOrError(value);
    }

    /// <summary>
    ///     How much time has elapsed (as a <see cref="float"/>).
    /// </summary>
    public static float TimeElapsed
    {
        get => (float)TimeElapsedPrecise;
        set => TimeElapsedPrecise = value;
    }

    /// <summary>
    ///     How much time has elapsed (as a <see cref="double"/>).
    /// </summary>
    public static double TimeElapsedPrecise
    {
        get => Raylib.GetTime() - timeOffset;
        set => timeOffset = value - Raylib.GetTime();
    }

    /// <summary>
    ///     How many frames have elapsed.
    /// </summary>
    public static int FramesElapsed { get; set; }

    /// <summary>
    ///     The time between the last frame and this frame in seconds.
    /// </summary>
    public static float DeltaTime => GetDeltaTime();


    // METHODS
    private static void SetTargetFpsOrError(int targetFPS)
    {
        if (targetFPS < 0)
        {
            string msg = "FPS must be greater than 0!";
            throw new ArgumentException(msg);
        }

        Time.targetFPS = targetFPS;
    }
    private static float GetFixedDeltaTime()
    {
        float fixedDeltaTime = 1f / targetFPS;
        return fixedDeltaTime;
    }
    private static float GetDynamicDeltaTime()
    {
        float dynamicDeltaTime = Raylib.GetFrameTime();
        return dynamicDeltaTime;
    }
    private static float GetDeltaTime()
    {
        bool isDebugging = Debugger.IsAttached;
        float deltaTime = isDebugging ? GetFixedDeltaTime() : GetDynamicDeltaTime();
        return deltaTime;
    }
}
