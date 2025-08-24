using Raylib_cs;

class Building
{
    public List<Parallelepiped> blocks;

    public Building(List<Parallelepiped> blocks)
    {
        this.blocks = blocks;
    }

    public void Draw()
    {
        foreach (var block in blocks)
        {
            block.Draw();
        }
    }
}