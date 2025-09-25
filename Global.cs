using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using Raylib_cs;
using VerletParticle;

namespace GlobalInfo;

public static class Global
{
    public static int screenWidth = 1920;
    public static int screenHeight = 1080;
    public static Color backgroundColour = Color.Black;

    public static List<Particle> particles = new List<Particle>();

    public static Vector2 RandomVector(int minX, int maxX, int minY, int maxY)
    {
        Random random = new Random();
        return new Vector2(random.Next(minX, maxX), random.Next(minY, maxY));
    }


}