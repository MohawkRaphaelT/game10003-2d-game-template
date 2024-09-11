/*////////////////////////////////////////////////////////////////////////
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 *////////////////////////////////////////////////////////////////////////

using Raylib_cs;
using System.Diagnostics;

namespace Game10003;

/// <summary>
///     Access time information.
/// </summary>
/// <remarks>
///     A static wrapper to standardize raylib's time API.
/// </remarks>
public static class Time
{
    private static double timeOffset = 0;


    // PROPERTIES
    /// <summary>
    ///     How much time in seconds has elapsed (as a <see cref="float"/>).
    /// </summary>
    public static float SecondsElapsed
    {
        get => (float)SecondsElapsedPrecise;
        set => SecondsElapsedPrecise = value;
    }

    /// <summary>
    ///     How much time in seconds has elapsed (as a <see cref="double"/>).
    /// </summary>
    public static double SecondsElapsedPrecise
    {
        get => Raylib.GetTime() - timeOffset;
        set => timeOffset = Raylib.GetTime() - value;
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
    private static float GetFixedDeltaTime()
    {
        float fixedDeltaTime = 1f / Window.TargetFPS;
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
