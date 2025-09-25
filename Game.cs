using Raylib_cs;
using GlobalInfo;
using VerletParticle;
using System.Numerics;
using CellSystem;

namespace GameClass;

public class Game
{
    public void Run()
    {
        Raylib.InitWindow(Global.screenWidth,Global.screenHeight, "Physics Simulation");
        Raylib.SetTargetFPS(121);


        for (int i = 0;  i < 1; i++) new Particle(Global.RandomVector(0, Global.screenWidth, 0, Global.screenHeight), Global.RandomVector(-10, 10, -10, 10));

        int frame = 0;

        Global.cellManager = new CellManager();

        while (!Raylib.WindowShouldClose())
        {
            frame++;
            float FPS = (float)Math.Floor(1 / Raylib.GetFrameTime());

            Raylib.BeginDrawing();

            Raylib.ClearBackground(Global.backgroundColour);

            Raylib.DrawText("FPS: " + Convert.ToString(FPS), 10, 10, 25, Color.White);
            Raylib.DrawText("Delta Time: " + Convert.ToString(Raylib.GetFrameTime()), 10, 40, 25, Color.White);
            Raylib.DrawText("Frame Number: " + Convert.ToString(frame), 10, 70, 25, Color.White);
            Raylib.DrawText("Particles: " + Convert.ToString(Global.particles.Count()), 10, 100, 25, Color.White);

            // Drawing and physics
            foreach (Particle particle in Global.particles) Raylib.DrawCircleV(particle.position, particle.radius, particle.color);
            foreach (Particle particle in Global.particles) particle.Update(Raylib.GetFrameTime());

            // Collision
            Global.cellManager.ClearCells();
            foreach (Particle particle in Global.particles) particle.PopulateCells();
            Global.cellManager.CellEmptyCheck();


            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}