/*////////////////////////////////////////////////////////////////////////
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 *////////////////////////////////////////////////////////////////////////

using Game10003;
using Raylib_cs;
using System.Numerics;

/// <summary>
///     The main underlying program. DO NOT EDIT.
/// </summary>
[GeneratorTools.OmitFromDocumentation]
public static class Program
{
    const int MaxRenderSize = 800;

    private static void Main()
    {
        // Create game instance
        Game game = new();

        // Raylib one-time setup
        Raylib.InitWindow(Window.Width, Window.Height, Window.Title);
        Raylib.SetTargetFPS(Window.TargetFPS);
        Raylib.InitAudioDevice();

        // Wrapper setup
        Text.Initialize();

        // Get 2 render textures used to draw to screen
        bool drawBuffer0 = true;
        RenderTexture2D[] buffers =
        {
            Raylib.LoadRenderTexture(MaxRenderSize, MaxRenderSize),
            Raylib.LoadRenderTexture(MaxRenderSize, MaxRenderSize),
        };
        // Init: set window size and inital background draw
        Raylib.BeginTextureMode(buffers[0]);
        game.Setup();
        Draw.FillColor = Game10003.Color.Blue;
        Draw.Square(0, 0, 100);
        Raylib.EndTextureMode();
        // Copy contents to other buffer
        Raylib.BeginTextureMode(buffers[1]);
        Raylib.DrawTexture(buffers[0].Texture, 0, 0, Raylib_cs.Color.White);
        Draw.FillColor = Game10003.Color.Green;
        Draw.Square(0, 0, 100);
        Raylib.EndTextureMode();

        // Raylib & wrapper frame loop
        while (!Raylib.WindowShouldClose())
        {
            // Update music buffers every frame
            foreach (var music in Audio.LoadedMusic)
                Raylib.UpdateMusicStream(music);

            // Choose current buffer
            RenderTexture2D thisFrame = drawBuffer0 ? buffers[0] : buffers[1];
            RenderTexture2D lastFrame = drawBuffer0 ? buffers[1] : buffers[0];
            Rectangle renderArea = new Rectangle(MaxRenderSize - Window.Width, MaxRenderSize - Window.Height, Window.Width, -Window.Height);
            // Start frame with contens of previous frame
            Raylib.BeginTextureMode(thisFrame);
            Raylib.DrawTextureRec(lastFrame.Texture, renderArea, Vector2.Zero, Raylib_cs.Color.White);
            game.Update();
            Raylib.EndTextureMode();
            // Render to screen
            Raylib.BeginDrawing();
            Raylib.DrawTextureRec(thisFrame.Texture, renderArea, Vector2.Zero, Raylib_cs.Color.White);
            Raylib.EndDrawing();
            // Swap buffers
            drawBuffer0 = !drawBuffer0;

            // Update rendered frame count
            Time.FramesElapsed++;
        }

        // Unload assets
        foreach (var music in Audio.LoadedMusic)
            Audio.UnloadMusic(music);
        foreach (var sound in Audio.LoadedSounds)
            Audio.UnloadSound(sound);
        foreach (var font in Text.LoadedFonts)
            Text.UnloadFont(font);
        foreach (var texture in Graphics.LoadedTextures)
            Graphics.UnloadTexture(texture);
        // Proper shutdown
        Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }
}