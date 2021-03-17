using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze
{
    public class SolutionBuilder
    {
        Maze _maze;
        public SolutionBuilder(Maze maze)
        {
            _maze = maze;
        }

        public void Start(int cellSize = 1, bool visualize = false)
        {
            AssignDistances();
            BuildSolution(cellSize, visualize);
        }

        public void AssignDistances()
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

        public void BuildSolution(int cellSize, bool visualize)
        {
            var render = new Render(_maze);
            var currentCoord = _maze.Start;
            _maze.Solution.Add(currentCoord);
            while (_maze.Cells[currentCoord.X, currentCoord.Y].DistanceFromEnd > 1)
            {
                // Add neighbor with least distance from end which has connection to cell at current coord:
                var validNeighbors = currentCoord.GetNeighbors().Where(n =>
                    _maze.DoesConnectionExistBetween(currentCoord, n));
                var lowestDistance = validNeighbors.Min(n => _maze.Cells[n.X, n.Y].DistanceFromEnd);
                var nextCoord = validNeighbors.First(n => _maze.Cells[n.X, n.Y].DistanceFromEnd == lowestDistance);
                _maze.Solution.Add(nextCoord);
                currentCoord = nextCoord;

                if (visualize)
                {
                    render.Start(cellSize, true);
                    System.Threading.Thread.Sleep(50);
                    Console.Clear();
                }
            }
        }

        public void BuildPlayerSolution(Direction inputDirection)
        {
            var currentNode = _maze.PlayerSolution.First;
            var desiredDestination = currentNode.Value.GetAdjacent(inputDirection);
            if (_maze.IsCoordinateInBounds(desiredDestination))
            {
                if (currentNode.Next.Value == desiredDestination)
                    _maze.PlayerSolution.RemoveFirst();
                else if (_maze.DoesConnectionExistBetween(currentNode.Value, desiredDestination))
                    _maze.PlayerSolution.AddFirst(desiredDestination);
            }
        }
    }
}