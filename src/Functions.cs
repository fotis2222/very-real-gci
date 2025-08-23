using System.Numerics;
using Raylib_cs;

class Functions
{
    public Vector3 Center(BoundingBox box)
    {
        return new Vector3(
            (box.Min.X + box.Max.X) / 2,
            (box.Min.Y + box.Max.Y) / 2,
            (box.Min.Z + box.Max.Z) / 2
        );
    }

    public float DistanceFromCamera(BoundingBox a, Camera3D b)
    {
        float dx = Center(a).X - b.Position.X;
        float dy = Center(a).Y - b.Position.Y;
        float dz = Center(a).Z - b.Position.Z;

        return MathF.Sqrt(dx * dx + dy * dy + dz * dz);
    }
}