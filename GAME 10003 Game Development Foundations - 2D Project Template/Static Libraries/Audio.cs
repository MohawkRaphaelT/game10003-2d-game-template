/*////////////////////////////////////////////////////////////////////////
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 *////////////////////////////////////////////////////////////////////////

using Raylib_cs;
using System.Collections.Generic;

namespace Game10003;

/// <summary>
///     Access audio functions.
/// </summary>
/// <remarks>
///     A static wrapper to standardize raylib's audio API.
/// </remarks>
public static class Audio
{
    // Keep list of music to auto-update in background
    private static readonly List<Music> activeMusic = [];

    /// <summary>
    ///     Get an array of all active music.
    /// </summary>
#pragma warning disable IDE0305 // Simplify collection initialization
    public static Music[] ActiveMusic => activeMusic.ToArray();
#pragma warning restore IDE0305 // Simplify collection initialization

    /// <summary>
    ///     Loads a music file at <paramref name="filePath"/>.
    /// </summary>
    /// <remarks>
    ///     Music should be more than 10s long, otherwise use <see cref="Sound"/>.
    ///     Supported file types: FLAC, MOD, MP3, OGG, QOA, WAV, XM.
    /// </remarks>
    /// <param name="filePath">The file path to the audio file.</param>
    /// <returns>
    ///     Returns the loaded music data.
    /// </returns>
    public static Music LoadMusic(string filePath)
    {
        var music = Raylib.LoadMusicStream(filePath);
        activeMusic.Add(music);
        return music;
    }

    /// <summary>
    ///     Unloads <paramref name="music"/> from memory.
    /// </summary>
    /// <param name="music">The music to unload.</param>
    public static void UnloadMusic(Music music)
    {
        activeMusic.Remove(music);
        Raylib.UnloadMusicStream(music);
    }

    /// <summary>
    ///     Loads a sound file at <paramref name="filePath"/>.
    /// </summary>
    /// <remarks>
    ///     Sound should be 10s or less, otherwise use <see cref="Music"/>.
    ///     Supported file types: FLAC, MOD, MP3, OGG, QOA, WAV, XM.
    /// </remarks>
    /// <param name="filePath">The file path to the audio file.</param>
    /// <returns>
    ///     Returns the loaded sound data.
    /// </returns>
    public static Sound LoadSound(string filePath)
    {
        var sound = Raylib.LoadSound(filePath);
        return sound;
    }

    /// <summary>
    ///     Unloads a <paramref name="sound"/> from memory.
    /// </summary>
    /// <param name="sound">The sound to unload.</param>
    public static void UnloadSound(Sound sound)
    {
        Raylib.UnloadSound(sound);
    }

    /// <summary>
    ///     Plays <paramref name="sound"/>.
    /// </summary>
    /// <param name="sound">The sound to play.</param>
    public static void Play(Sound sound) => Raylib.PlaySound(sound);
    /// <summary>
    ///     Pause a playing <paramref name="sound"/>.
    /// </summary>
    /// <param name="sound">The sound to pause.</param>
    public static void Pause(Sound sound) => Raylib.PauseSound(sound);
    /// <summary>
    ///     Resumes a paused <paramref name="sound"/>.
    /// </summary>
    /// <param name="sound">The sound to resume.</param>
    public static void Resume(Sound sound) => Raylib.ResumeSound(sound);
    /// <summary>
    ///     Stop a playing or paused <paramref name="sound"/>.
    /// </summary>
    /// <param name="sound">The sound to stop.</param>
    public static void Stop(Sound sound) => Raylib.StopSound(sound);
    /// <summary>
    ///     Checks if <paramref name="sound"/> is playing.
    /// </summary>
    /// <param name="sound">The sound to check.</param>
    /// <returns>
    ///     Returns true if playing, false otherwise.
    /// </returns>
    public static bool IsPlaying(Sound sound) => Raylib.IsSoundPlaying(sound);
    /// <summary>
    ///     Sets the <paramref name="pan"/> for <paramref name="sound"/>.
    /// </summary>
    /// <param name="sound">The sound to pan.</param>
    /// <param name="pan">The pan value. 0.5 is center, 0 left, and 1 right.</param>
    public static void SetPan(Sound sound, float pan) => Raylib.SetSoundPan(sound, pan);
    /// <summary>
    ///     Sets the <paramref name="pitch"/> for <paramref name="sound"/>.
    /// </summary>
    /// <param name="sound">The sound to pitch.</param>
    /// <param name="pitch">The pitch value. 1.0 is the base pitch level.</param>
    public static void SetPitch(Sound sound, float pitch) => Raylib.SetSoundPitch(sound, pitch);
    /// <summary>
    ///     Sets the <paramref name="volume"/> for <paramref name="sound"/>.
    /// </summary>
    /// <param name="sound">The sound to set.</param>
    /// <param name="volume">The volume amount. 0 is silent, 1 is max volume.</param>
    public static void SetVolume(Sound sound, float volume) => Raylib.SetSoundVolume(sound, volume);


    /// <summary>
    ///     Plays <paramref name="music"/>.
    /// </summary>
    /// <param name="music">The music to play.</param>
    public static void Play(Music music) => Raylib.PlayMusicStream(music);
    /// <summary>
    ///     Pause a playing <paramref name="music"/>.
    /// </summary>
    /// <param name="music">The music to pause.</param>
    public static void Pause(Music music) => Raylib.PauseMusicStream(music);
    /// <summary>
    ///     Resumes a paused <paramref name="music"/>.
    /// </summary>
    /// <param name="music">The music to resume.</param>
    public static void Resume(Music music) => Raylib.ResumeMusicStream(music);
    /// <summary>
    ///     Stop a playing or paused <paramref name="music"/>.
    /// </summary>
    /// <param name="music">The music to stop.</param>
    public static void Stop(Music music) => Raylib.StopMusicStream(music);
    /// <summary>
    ///     Checks if <paramref name="music"/> is playing.
    /// </summary>
    /// <param name="music">The music to check.</param>
    /// <returns>
    ///     Returns true if playing, false otherwise.
    /// </returns>
    public static bool IsPlaying(Music music) => Raylib.IsMusicStreamPlaying(music);
    /// <summary>
    ///     Sets the <paramref name="pan"/> for <paramref name="music"/>.
    /// </summary>
    /// <param name="music">The music to pan.</param>
    /// <param name="pan">The pan value. 0.5 is center, 0 left, and 1 right.</param>
    public static void SetPan(Music music, float pan) => Raylib.SetMusicPan(music, pan);
    /// <summary>
    ///     Sets the <paramref name="pitch"/> for <paramref name="music"/>.
    /// </summary>
    /// <param name="music">The music to pitch.</param>
    /// <param name="pitch">The pitch value. 1.0 is the base pitch level.</param>
    public static void SetPitch(Music music, float pitch) => Raylib.SetMusicPitch(music, pitch);
    /// <summary>
    ///     Sets the <paramref name="volume"/> for <paramref name="music"/>.
    /// </summary>
    /// <param name="music">The music to set.</param>
    /// <param name="volume">The volume amount. 0 is silent, 1 is max volume.</param>
    public static void SetVolume(Music music, float volume) => Raylib.SetMusicVolume(music, volume);

}