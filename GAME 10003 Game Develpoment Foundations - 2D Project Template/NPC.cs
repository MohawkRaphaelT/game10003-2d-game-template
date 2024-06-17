using Raylib_cs;
using System.Numerics;

public class NPC
{
    // The information we need to represent the NPC
    public Color color;
    public Vector2 position;
    public float size;

    // Constructor
    public NPC(Color color, Vector2 position, float size)
    {
        // Assign the incoming arguments to this instance
        this.color = color;
        this.position = position;
        this.size = size;
    }

    // Draw NPC from the position point upwards
    public void Draw()
    {
        // Calculate the position of the body and head
        float halfSize = size / 2;
        Vector2 bodyBase = new Vector2(position.X - halfSize, position.Y - size);
        Vector2 bodyTop = new Vector2(position.X, bodyBase.Y);
        Vector2 head = new Vector2(position.X, bodyBase.Y - size);
        // Draw body as a square bottom with a circular top, and a circle for the head
        Raylib.DrawRectangleV(bodyBase, Vector2.One * size, color);
        Raylib.DrawCircleV(bodyTop, halfSize, color);
        Raylib.DrawCircleV(head, halfSize, color);
    }
}