using System;
using System.Collections.Generic;

namespace Maze
{
    public class PathBuilder
    {
        private Cell[,] _maze;
        private int _width;
        private int _height;
        public LinkedList<Cell> Path = new LinkedList<Cell>();
        public PathBuilder(Cell[,] maze)
        {
            _maze = maze;
            _width = maze.GetLength(0);
            _height = maze.GetLength(1);

            Path.AddFirst(new Cell { Coordinate = Coordinate.Random(_width, _height) });
            // Maze algorithm
            while (Path.Count < _width * _height)
            {
                // Create list of unvisited neighbor coordinates:
                var unvisitedNeighborCoords = new HashSet<Coordinate>();
                var coordOfFirstCell = Path.First.Value.Coordinate;

                // North border
                if (coordOfFirstCell.Y > 0 && 
                    maze[coordOfFirstCell.X, coordOfFirstCell.Y-1] == null)
                {
                    unvisitedNeighborCoords.Add(new Coordinate { X = coordOfFirstCell.X, Y = coordOfFirstCell.Y-1 });   
                }
                // South border
                if (coordOfFirstCell.Y < _height - 1 && 
                    maze[coordOfFirstCell.X, coordOfFirstCell.Y+1] == null)
                {
                    unvisitedNeighborCoords.Add(new Coordinate { X = coordOfFirstCell.X, Y = coordOfFirstCell.Y+1 });
                }
                // East border
                if (coordOfFirstCell.X > 0 && 
                    maze[coordOfFirstCell.X-1, coordOfFirstCell.Y] == null)
                {
                    unvisitedNeighborCoords.Add(new Coordinate { X = coordOfFirstCell.X-1, Y = coordOfFirstCell.Y });
                }
                // West border
                if (coordOfFirstCell.X < _width - 1 && 
                    maze[coordOfFirstCell.X+1, coordOfFirstCell.Y] == null)
                {
                    unvisitedNeighborCoords.Add(new Coordinate { X = coordOfFirstCell.X+1, Y = coordOfFirstCell.Y });
                }
            }
        }
    }
}