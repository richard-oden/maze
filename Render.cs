using System;
using System.Linq;

namespace Maze
{
    public class Render
    {
        private Maze _maze;

        public Render(Maze maze)
        {
            _maze = maze;
        }

        public void Start(int cellSize = 1) {
            var mazeArray = buildMazeArray(cellSize);
            var mazeString = BuildMazeString(mazeArray);
            Console.WriteLine(mazeString);
        }
        private string[,] buildMazeArray(int cellSize)
        {
            var mazeArray = new string[_maze.Cells.GetLength(0) * (cellSize + 1), _maze.Cells.GetLength(1) * (cellSize + 1)];
            for (int y = 0; y < _maze.Cells.GetLength(1); y++)
            {
                for (int x = 0; x < _maze.Cells.GetLength(0); x++)
                {
                    int mazeX = x * (cellSize + 1);
                    int mazeY = y * (cellSize + 1);
                    // Draw cell:
                    for (int cellY = 0; cellY <= cellSize; cellY++)
                    {
                        for (int cellX = 0; cellX <= cellSize; cellX++)
                        {
                            if (_maze.Cells[x,y] != null)
                            {
                                if (cellX == cellSize && cellY == cellSize)
                                    // Draw SE corner
                                    mazeArray[mazeX + cellX, mazeY + cellY] = "\u2588\u2588";
                                else if (cellX == cellSize)
                                    // Draw east border
                                    mazeArray[mazeX + cellX, mazeY + cellY] = _maze.Cells[x,y].Connections.Contains(Direction.East) ? "  " : "\u2588\u2588";
                                else if (cellY == cellSize)
                                    // Draw south border
                                    mazeArray[mazeX + cellX, mazeY + cellY] = _maze.Cells[x,y].Connections.Contains(Direction.South) ? "  " : "\u2588\u2588";
                                else
                                    // Draw center
                                    mazeArray[mazeX + cellX, mazeY + cellY] = "  ";
                            }
                            else
                            {
                                mazeArray[mazeX + cellX, mazeY + cellY] = "\u2588\u2588";
                            }
                        }
                    }
                }
            }
            return mazeArray;
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