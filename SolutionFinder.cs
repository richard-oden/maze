using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze
{
    public class SolutionFinder
    {
        Maze _maze;
        public SolutionFinder(Maze maze)
        {
            _maze = maze;
        }

        public void PropogateWaves()
        {
            var oldCoords = new HashSet<Coordinate>();
            var newCoords = new HashSet<Coordinate>() {_maze.End};
            while (oldCoords.Count < _maze.Width * _maze.Height)
            {
                var newNeighbors = new HashSet<Coordinate>();
                foreach (var newCoord in newCoords)
                {
                    foreach (var neighbor in newCoord.GetNeighbors())
                    {
                        // If connection exists between this cell and cell at neighbor coords, and neighbor has default distance:
                        if (_maze.DoesConnectionExistBetween(newCoord, neighbor) &&
                            _maze.Cells[neighbor.X, neighbor.Y].DistanceFromEnd == 0)
                        {
                            // Add neighbor to new neighbors and set cell distance if new neighbors does not already contain this neighbor:
                            if (newNeighbors.Add(neighbor)) _maze.Cells[neighbor.X, neighbor.Y].DistanceFromEnd = _maze.Cells[newCoord.X, newCoord.Y].DistanceFromEnd + 1;
                        }
                    }
                }
                // Move all new coords to old coords:
                oldCoords.UnionWith(newCoords);
                newCoords.Clear();

                // Move all neighbors to new coords:
                newCoords.UnionWith(newNeighbors);
            }
        }
    }
}