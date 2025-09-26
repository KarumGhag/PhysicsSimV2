using System.Drawing;
using System.Security;
using GlobalInfo;
using Raylib_cs;
using VerletParticle;

namespace CellSystem;

public class Cell
{
    public static int cellSize = 10;
    public List<Particle> particles = new List<Particle>();
    public bool isEmpty = true;
}

public class CellManager
{
    public int cols = (int)Math.Ceiling((float)Global.screenWidth / Cell.cellSize);
    public int rows = (int)Math.Ceiling((float)Global.screenHeight / Cell.cellSize);

    public Cell[,] grid;

    public CellManager()
    {
        grid = new Cell[cols, rows];

        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                grid[x, y] = new Cell();
            }
        }
    }

    public void ClearCells()
    {
        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                grid[x, y].particles.Clear();
                grid[x, y].isEmpty = true;
            }
        }
    }

}