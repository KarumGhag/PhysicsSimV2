using System.Drawing;
using System.Security;
using GlobalInfo;
using Raylib_cs;
using VerletParticle;

namespace CellSystem;

public class Cell
{
    public static int cellSize = 20;
    public List<Particle> particles = new List<Particle>();
    public bool empty;
}

public class CellManager
{
    int cols = Global.screenHeight / Cell.cellSize;
    int rows = Global.screenWidth / Cell.cellSize;

    Cell[,] grid;

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
            }
        }
    }

    public void CellEmptyCheck()
    {
        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                if (grid[x, y].particles.Count() != 0) grid[x, y].empty = false;
                else grid[x, y].empty = true;
            }
        }
    }
}