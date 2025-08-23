using Raylib_cs;
using System.Numerics;

class GrassSpawner
{
    private Random random = new();
    public List<Parallelepiped> grass = [];

    public void DrawGrass()
    {
        foreach (var blade in grass)
        {
            blade.Draw();
        }
    }

    public void SpawnGrass()
    {
        for (int i = 0; i < 5; i++)
        {
            grass.Add(new Parallelepiped(new Vector3(random.Next(-7, 8), 0.15f + 1.5f / 2, random.Next(-7, 8)), new Vector3(0.5f, 1.5f, 0.5f), new Color(75, 150, 75)));
        }
    }

    public void CutGrass(Camera3D cam, Game g)
    {
        Functions f = new();
        for (int i = grass.Count - 1; i >= 0; i --)
        {
            if (f.DistanceFromCamera(grass[i].GetBoundingBox(), cam) < 3)
            {
                grass.RemoveAt(i);
                g.grass += 1;
            }
        }
    }
}