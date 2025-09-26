using System.Numerics;
using GlobalInfo;
using Raylib_cs;
using CellSystem;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;

namespace VerletParticle;

public class Particle
{
    public Vector2 position;
    public Vector2 oldPosition;
    public Vector2 velocity;

    public int radius = 10;
    public Color color = Color.Red;

    private static float bounceDamping = 0.9f;
    private static float friction = 0.9999f;


    public int gridX;
    public int gridY;

    public Particle(Vector2 startPosition, Vector2 startVelocity)
    {
        position = startPosition;
        oldPosition = position - startVelocity;
        velocity = startVelocity;

        color = Global.HsvToRgb(new Random().Next(0, 360), new Random().Next(0, 255));

        Global.particles.Add(this);
    }

    public void Update(float dt)
    {
        velocity = position - oldPosition;

        oldPosition = position;

        position += velocity * friction;
        position.Y += 1750 * dt * dt;

        EdgeCheck();
    }

    public void PopulateCells()
    {
        gridX = Math.Clamp((int)Math.Floor(position.X / Cell.cellSize), 0, Global.cellManager.cols - 1);
        gridY = Math.Clamp((int)Math.Floor(position.Y / Cell.cellSize), 0, Global.cellManager.rows - 1);

        Global.cellManager.grid[gridX, gridY].particles.Add(this);
        Global.cellManager.grid[gridX, gridY].isEmpty = false;

    }

    private void EdgeCheck()
    {
        if (position.X > Global.screenWidth)
        {
            position.X = Global.screenWidth;
            oldPosition.X = position.X + velocity.X * bounceDamping;
        }
        else if (position.X < 0)
        {
            position.X = 0;
            oldPosition.X = position.X + velocity.X * bounceDamping;
        }

        if (position.Y > Global.screenHeight)
        {
            position.Y = Global.screenHeight;
            oldPosition.Y = position.Y + velocity.Y * bounceDamping;
        }
        else if (position.Y < 0)
        {
            position.Y = 0;
            oldPosition.Y = position.Y + velocity.Y * bounceDamping;
        }
    }
}