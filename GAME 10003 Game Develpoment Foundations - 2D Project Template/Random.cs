using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public static class Random
{
    private static readonly System.Random rng = new();

    // BYTES
    public static byte Byte() => (byte)rng.Next(256);
    public static byte Byte(byte max) => (byte)rng.Next(max);
    public static byte Byte(byte min, byte max) => (byte)rng.Next(min, max);

    // INTEGERS
    public static int Integer() => rng.Next();
    public static int Integer(int max) => rng.Next(max);
    public static int Integer(int min, int max) => rng.Next(min, max);

    // FLOATS
    public static float Float() => rng.NextSingle();
    public static float Float(float max) => rng.NextSingle() * max;
    public static float Float(float min, float max) => rng.NextSingle() * (max - min) + min;
    public static float AngleDegree()
    {
        float angleDegrees = Float(0, 360);
        return angleDegrees;
    }
    public static float AngleRadian()
    {
        float angleRadians = Float(0, MathF.Tau);
        return angleRadians;
    }

    // VECTOR2
    public static Vector2 Vector2() => new(Float(), Float());
    public static Vector2 Vector2(Vector2 max) => new(Float(max.X), Float(max.Y));
    public static Vector2 Vector2(float maxX, float maxY) => new(Float(maxX), Float(maxY));
    public static Vector2 Vector2(Vector2 min, Vector2 max) => new(Float(min.X, max.X), Float(min.Y, max.Y));
    public static Vector2 Vector2(float minX, float maxX, float minY, float maxY) => new(Float(minX, maxX), Float(minY, maxY));
    public static Vector2 PointInCircle()
    {
        Vector2 direction = PointOnCircle();
        float magnitude = Float();
        Vector2 pointInCircle = direction * magnitude;
        return pointInCircle;
    }
    public static Vector2 PointOnCircle()
    {
        float angle = AngleRadian();
        Vector2 pointOnCircle = new(MathF.Cos(angle), -MathF.Sin(angle));
        return pointOnCircle;
    }
    public static Vector2 Direction()
        => PointOnCircle();

    // COLOR
    public static Color Color() => new(Byte(), Byte(), Byte());
    public static Color Greyscale() => new(Byte());
}
