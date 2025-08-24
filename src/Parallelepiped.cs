using Raylib_cs;
using System.Numerics;

class Parallelepiped
{
    public Vector3 position;
    public Vector3 size;
    public Color color;

    public enum Faces
    {
        Front,
        Back,
        Left,
        Right,
        Top,
        Bottom
    }

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
        return new BoundingBox(position - size / 2, position + size / 2);
    }
    // chatGPT generated
    public Vector3 GetFaceCenter(Faces face)
    {
        Vector3 halfSize = size / 2;

        return face switch
        {
            Faces.Front => position + new Vector3(0, 0, halfSize.Z),
            Faces.Back => position + new Vector3(0, 0, -halfSize.Z),
            Faces.Left => position + new Vector3(-halfSize.X, 0, 0),
            Faces.Right => position + new Vector3(halfSize.X, 0, 0),
            Faces.Top => position + new Vector3(0, halfSize.Y, 0),
            Faces.Bottom => position + new Vector3(0, -halfSize.Y, 0),
            _ => position
        };
    }
    // chatGPT generated
    public Vector3 GetFaceNormal(Faces face)
    {
        return face switch
        {
            Faces.Front => new Vector3(0, 0, -1),
            Faces.Back => new Vector3(0, 0, 1),
            Faces.Left => new Vector3(-1, 0, 0),
            Faces.Right => new Vector3(1, 0, 0),
            Faces.Top => new Vector3(0, 1, 0),
            Faces.Bottom => new Vector3(0, -1, 0),
            _ => Vector3.Zero
        };
    }
}