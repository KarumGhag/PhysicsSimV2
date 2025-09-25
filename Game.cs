using Raylib_cs;
using GlobalInfo;
using VerletParticle;
using System.Numerics;
using System.Runtime.InteropServices;

namespace GameClass;

public class Game
{
    public void Run()
    {
        Raylib.InitWindow(Global.screenWidth,Global.screenHeight, "Physics Simulation");
        Raylib.SetTargetFPS(121);


        for (int i = 0; i < 5000; i++)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            new Particle(new Vector2(Global.screenWidth / 2, Global.screenHeight / 2), new Vector2(random.Next(-10, 10), random.Next(-10, 10)));
        }
        int frame = 0;

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

            foreach (Particle particle in Global.particles) Raylib.DrawCircleV(particle.position, particle.radius, particle.color);
            foreach (Particle particle in Global.particles) particle.Update(Raylib.GetFrameTime());


            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}