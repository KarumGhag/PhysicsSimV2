using Raylib_cs;
using GlobalInfo;

namespace GameClass;

public class Game
{
    public void Run()
    {
        Raylib.InitWindow(Global.screenWidth,Global.screenHeight, "Physics Simulation");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Global.backgroundColour);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}