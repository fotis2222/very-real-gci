using Raylib_cs;
using System.Numerics;

class Parallelepiped
{
    public Vector3 position;
    public Vector3 size;
    public Color color;

    public Parallelepiped(Vector3 position, Vector3 size, Color color)
    {
        this.position = position;
        this.size = size;
        this.color = color;
    }

    public void Draw()
    {
        Raylib.DrawCube(position, size.X, size.Y, size.Z, color);
    }

    public BoundingBox GetBoundingBox()
    {
        return new BoundingBox(position - size/2, position + size/2);
    }
}