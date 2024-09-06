/*////////////////////////////////////////////////////////////////////////
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 *////////////////////////////////////////////////////////////////////////

using Raylib_cs;

/// <summary>
///     The main underlying program. DO NOT EDIT.
/// </summary>
internal class Program
{
    static void Main()
    {
        // Create game instance
        Game game = new();

        // Raylib one-time setup
        Raylib.InitWindow(Window.Width, Window.Height, Window.Title);
        Raylib.InitAudioDevice();
        Raylib.SetTargetFPS(Window.TargetFPS);

        // Wrapper setup
        Text.Initialize();
        game.Setup();

        // Raylib & wrapper frame loop
        while (!Raylib.WindowShouldClose())
        {
            // Update music buffers every frame
            foreach (var music in Audio.ActiveMusic)
                Raylib.UpdateMusicStream(music);

            // Run game frame
            Raylib.BeginDrawing();
            game.Update();
            Raylib.EndDrawing();

            // Update rendered frame count
            Time.FramesElapsed++;
        }

        // Proper shutdown
        Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }
}