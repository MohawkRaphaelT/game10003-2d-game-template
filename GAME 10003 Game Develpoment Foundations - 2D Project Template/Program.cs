/*////////////////////////////////////////////////////////////////////////
 * Raylib-CS Template
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 * 
 * Written by:
 *      Raphaël Tétreault
 * History:
 *      2024/05/26: Initial version
 *////////////////////////////////////////////////////////////////////////

using Raylib_cs;

public class Program
{
    static void Main()
    {
        // Create game instance
        Game game = new();

        // Raylib one-time setup
        Raylib.InitWindow(game.screenWidth, game.screenHeight, game.title);
        Raylib.InitAudioDevice();
        Raylib.SetTargetFPS(Time.TargetFPS);

        // Wrapper setup
        Text.Initialize();
        game.Setup();

        // Raylib & wrapper frame loop
        while (!Raylib.WindowShouldClose())
        {
            // Update music buffers every frame
            foreach (var music in Audio.ActiveMusic)
                Raylib.UpdateMusicStream(music);

            Raylib.SetWindowSize(game.screenWidth, game.screenHeight);
            Raylib.BeginDrawing();
            game.Update();
            Raylib.EndDrawing();
            Time.ElapsedFrames++;
        }

        // Proper shutdown
        Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }
}