using System;

namespace Maze
{
    public class Render
    {
        private int _cellWidth;

        public Render(int cellWidth = 1)
        {
            _cellWidth = cellWidth;
        }
        public string[,] BuildMazeArray(Cell[,] cells)
        {
            var maze = new string[cells.GetLength(0) * 2, cells.GetLength(1) * 2];
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                for (int x = 0; x < cells.GetLength(0); x++)
                {
                    int mazeX = x * 2;
                    int mazeY = y * 2;
                    if (cells[x,y] != null)
                    {
                        // Draw center:
                        maze[mazeX, mazeY] =  "  ";
                        // Draw SE corner:
                        maze[mazeX + 1, mazeY + 1] = "\u2588\u2588";
                        // Draw south and east sides where there are no connections:
                        maze[mazeX + 1, mazeY] = cells[x,y].Connections.Contains(CellConnection.East) ? "  " : "\u2588\u2588";
                        maze[mazeX, mazeY + 1] = cells[x,y].Connections.Contains(CellConnection.South) ? "  " : "\u2588\u2588";
                    }
                }
            }
            return maze;
        }

        public string BuildMazeString(string[,] mazeArray)
        {
            string mazeString = "";
            for (int y = 0; y < mazeArray.GetLength(1); y++)
            {
                for (int x = 0; x < mazeArray.GetLength(0); x++)
                {
                    mazeString += mazeArray[x, y];
                }
                mazeString += '\n';
            }
            return mazeString;
        }
    }
}