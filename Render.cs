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

        public void Start(int cellSize = 1, bool showSolution = false, bool showPlayerSolution = false, bool showDistance = false) {
            var mazeArray = buildMazeArray(cellSize, showSolution, showPlayerSolution, showDistance);
            var mazeString = buildMazeString(mazeArray);
            Console.WriteLine(mazeString);
        }

        private string getCellCenterShading(int x, int y, bool showSolution, bool showPlayerSolution, bool showDistance)
        {
            if (_maze.Start.X == x && _maze.Start.Y == y) 
                return "\u25B8 ";
            else if (_maze.End.X == x && _maze.End.Y == y) 
                return "\u25AA ";
            else if (showPlayerSolution && _maze.PlayerSolution.Contains(new Coordinate {X = x, Y = y}))
                return "\u2592\u2592";
            else if (showSolution && _maze.Solution.Contains(new Coordinate {X = x, Y = y}))
                return "\u2591\u2591";
            else if (showDistance) 
                return $"{_maze.Cells[x,y].DistanceFromEnd}".PadRight(2);
            else
                return "  ";
        }

        private string getCellBorderShading(int x, int y, Direction direction, bool showSolution, bool showPlayerSolution)
        {
            var cellCoord = new Coordinate {X = x, Y = y};
            
            if (!_maze.Cells[x,y].Connections.Contains(direction))
                return "\u2588\u2588";
            else if (showPlayerSolution && 
                _maze.PlayerSolution.Contains(cellCoord) &&
                _maze.PlayerSolution.Contains(cellCoord.GetAdjacent(direction)))
                return "\u2592\u2592";
            else if (showSolution && 
                _maze.Solution.Contains(cellCoord) &&
                _maze.Solution.Contains(cellCoord.GetAdjacent(direction)))
                return "\u2591\u2591";
            else
                return "  ";
        }

        private string[,] buildMazeArray(int cellSize, bool showSolution, bool showPlayerSolution, bool showDistance)
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
                                    mazeArray[mazeX + cellX, mazeY + cellY] = getCellBorderShading(x, y, Direction.East, showSolution, showPlayerSolution);
                                else if (cellY == cellSize)
                                    // Draw south border
                                    mazeArray[mazeX + cellX, mazeY + cellY] = getCellBorderShading(x, y, Direction.South, showSolution, showPlayerSolution);
                                else
                                    // Draw center
                                    mazeArray[mazeX + cellX, mazeY + cellY] = getCellCenterShading(x, y, showSolution, showPlayerSolution, showDistance);
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

        private string buildMazeString(string[,] mazeArray)
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