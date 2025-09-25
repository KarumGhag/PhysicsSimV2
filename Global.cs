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
}