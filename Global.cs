using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using CellSystem;
using Raylib_cs;
using VerletParticle;

namespace GlobalInfo;

public static class Global
{
    public static int screenWidth = 1920;
    public static int screenHeight = 1080;
    public static Color backgroundColour = Color.Black;

    public static List<Particle> particles = new List<Particle>();


    public static CellManager cellManager;


    public static Vector2 RandomVector(int minX, int maxX, int minY, int maxY)
    {
        Random random = new Random();
        return new Vector2(random.Next(minX, maxX), random.Next(minY, maxY));
    }


    public static Color HsvToRgb(float hue, float saturation)
    {
        // Normalize hue into [0,360)
        hue = hue % 360;
        if (hue < 0) hue += 360;

        // Always full brightness
        float value = 1.0f;

        if (saturation <= 0.0f)
        {
            // Achromatic (white, since value=1)
            return new Color(255, 255, 255, 255);
        }

        float hueSector = hue / 60.0f;
        int sectorIndex = (int)hueSector;
        float fractionalPart = hueSector - sectorIndex;

        float p = value * (1 - saturation);
        float q = value * (1 - saturation * fractionalPart);
        float t = value * (1 - saturation * (1 - fractionalPart));

        float r, g, b;

        switch (sectorIndex)
        {
            case 0:
                r = value; g = t; b = p;
                break;
            case 1:
                r = q; g = value; b = p;
                break;
            case 2:
                r = p; g = value; b = t;
                break;
            case 3:
                r = p; g = q; b = value;
                break;
            case 4:
                r = t; g = p; b = value;
                break;
            default: // case 5
                r = value; g = p; b = q;
                break;
        }

        return new Color(
            (byte)(r * 255),
            (byte)(g * 255),
            (byte)(b * 255)
        );
    }



}