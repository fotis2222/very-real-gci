// i keep unused imports
using System.IO.Compression;
using System.Numerics;
using Raylib_cs;

enum GameScreens
{
    None,
    UpgradeScreen
}

class Program
{

    static Camera3D camera = new Camera3D
    {
        Position = new Vector3(0.0f, 2.5f, 15.0f),
        Target = new Vector3(0.0f, 0.0f, 0.0f),
        Up = new Vector3(0.0f, 1.0f, 0.0f),
        FovY = 90.0f,
        Projection = CameraProjection.Perspective
    };

    static Random random = new();
    static GrassSpawner gs = new();
    static Functions f = new();
    static Game g = new();
    static bool free = false;
    static Parallelepiped test = new(new Vector3(20, 1, 20), new Vector3(2, 2, 2), Color.Red);

    const int screenWidth = 1920;
    const int screenHeight = 1080;

    static GameScreens screen = GameScreens.None;
    

    static void Main()
    {
        Raylib.InitWindow(screenWidth, screenHeight, "what am i doing with my life");
        Raylib.InitAudioDevice();

        Raylib.DisableCursor();

        Raylib.SetTargetFPS(60);

        // Main game loop
        while (!Raylib.WindowShouldClose())
        {
            Raylib.UpdateCamera(ref camera, free ? CameraMode.Free : CameraMode.FirstPerson);
            Process();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            Raylib.BeginMode3D(camera);

            Draw();

            Raylib.EndMode3D();

            Draw2D();


            Raylib.DrawFPS(10, 10);

            Raylib.EndDrawing();
        }

        Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }

    static void Draw(/* inline comment aka ugly */)
    {
        // grass field
        Raylib.DrawCube(new Vector3(0, 0, 0), 15, 0.3f, 15, new Color(100, 255, 100));

        // floor you stand on
        Raylib.DrawPlane(new Vector3(0, 0, 0), new Vector2(100, 100), Color.DarkGreen);

        // draw the grass
        gs.DrawGrass();

        // hit the griddy (nah fr)
        // Raylib.DrawGrid(100, 1.0f);

        test.Draw();
    }

    static void Draw2D()
    {
        Raylib.DrawText($"[{camera.Position.X:F0}, {camera.Position.Z:F0}]", 10, 40, 20, Color.DarkGray);

        // grass meter box
        Raylib.DrawRectangle(500, 20, 920, 150, Color.Green);

        int textWidth = Raylib.MeasureText($"{g.grass} Grass", 40);

        Raylib.DrawText($"{g.grass} Grass", 500 + (920 - textWidth) / 2, 20 + (150 - 40) / 2, 40, Color.Black);

        if (screen == GameScreens.UpgradeScreen)
        {
            Raylib.DrawRectangle(100, 100, screenWidth - 200, screenHeight - 200, Color.Green);
        }

    }

    static void Process()
    {
        if (gs.grass.Count < 1)
        {
            gs.SpawnGrass();
        }
        gs.CutGrass(camera, g);

        if (Raylib.IsKeyPressed(KeyboardKey.Q))
        {
            free = !free;
        }
    }

    static BoundingBox GetCameraBoundingBox(Camera3D camera)
    {
        Vector3 cameraSize = new(1, 1, 1);

        Vector3 min = camera.Position - cameraSize / 2;
        Vector3 max = camera.Position + cameraSize / 2;

        return new BoundingBox(min, max);
    }
}
