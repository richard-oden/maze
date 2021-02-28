using System;

namespace Maze
{
    public class Render
    {
        private Maze _maze;
        private int _cellWidth;

        public Render(Maze maze, int cellWidth = 1)
        {
            _maze = maze;
            _cellWidth = cellWidth;
        }

        public void Start() {
            var mazeArray = buildMazeArray();
            var mazeString = BuildMazeString(mazeArray);
            Console.WriteLine(mazeString);
        }
        private string[,] buildMazeArray()
        {
            var maze = new string[_maze.Cells.GetLength(0) * 2, _maze.Cells.GetLength(1) * 2];
            for (int y = 0; y < _maze.Cells.GetLength(1); y++)
            {
                for (int x = 0; x < _maze.Cells.GetLength(0); x++)
                {
                    int mazeX = x * 2;
                    int mazeY = y * 2;
                    if (_maze.Cells[x,y] != null)
                    {
                        // Draw center:
                        maze[mazeX, mazeY] =  "  ";
                        // Draw SE corner:
                        maze[mazeX + 1, mazeY + 1] = "\u2588\u2588";
                        // Draw south and east sides where there are no connections:
                        maze[mazeX + 1, mazeY] = _maze.Cells[x,y].Connections.Contains(Direction.East) ? "  " : "\u2588\u2588";
                        maze[mazeX, mazeY + 1] = _maze.Cells[x,y].Connections.Contains(Direction.South) ? "  " : "\u2588\u2588";
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