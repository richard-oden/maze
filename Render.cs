using System;

namespace Maze
{
    public static class Render
    {
        public static string[,] BuildMazeArray(Cell[,] cells)
        {
            var maze = new string[cells.GetLength(0)*3, cells.GetLength(1)*3];
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                for (int x = 0; x < cells.GetLength(0); x++)
                {
                    int mazeX = x * 3;
                    int mazeY = y * 3;

                    // Draw corners:
                    maze[mazeX, mazeY] = "\u2588\u2588";
                    maze[mazeX + 2, mazeY] = "\u2588\u2588";
                    maze[mazeX, mazeY + 2] = "\u2588\u2588";
                    maze[mazeX + 2, mazeY + 2] = "\u2588\u2588";

                    // Draw sides where there are no connection:
                    if (true) maze[mazeX + 1, mazeY] = "\u2588\u2588";
                    if (true) maze[mazeX, mazeY + 1] = "\u2588\u2588";
                    if (true) maze[mazeX + 2, mazeY + 1] = "\u2588\u2588";
                    if (true) maze[mazeX + 1, mazeY + 2] = "\u2588\u2588";

                    // Draw center:
                    if (true) maze[mazeX + 1, mazeY + 1] =  "  ";
                }
            }
            return maze;
        }

        public static string BuildMazeString(string[,] mazeArray)
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