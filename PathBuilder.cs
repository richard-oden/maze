using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze
{
    public class PathBuilder
    {
        private Maze _maze;
        private int _width;
        private int _height;
        public LinkedList<Coordinate> Path = new LinkedList<Coordinate>();
        public PathBuilder(Maze maze)
        {
            _maze = maze;
            _width = maze.Width;
            _height = maze.Height;
        }

        public void Start()
        {
            // Create starting point
            var initialCoord = Coordinate.Random(_width, _height);
            addToPath(initialCoord);

            // Maze algorithm
            while (Path.Count < _width * _height)
            {
                var originNode = Path.First;
                var unvisitedNeighbors = getUnvisitedNeighborsByDirection(originNode);
                // If no neighbors, recursively check previous coord until neighbor is found:
                while (!unvisitedNeighbors.Any())
                {
                    originNode = originNode.Next;
                    unvisitedNeighbors = getUnvisitedNeighborsByDirection(originNode);
                }
                var nextNeighborByDirection = unvisitedNeighbors.RandomElement();
                extendPath(originNode.Value, nextNeighborByDirection.Key, nextNeighborByDirection.Value);
            }
        }

        private void addToPath(Coordinate newCoord)
        {
            Path.AddFirst(newCoord);
            _maze.Cells[newCoord.X, newCoord.Y] = new Cell();
        }

        private void extendPath(Coordinate originCoord, Direction directionTo, Coordinate newCoord)
        {
            Path.AddFirst(newCoord);
            _maze.Cells[originCoord.X, originCoord.Y].Connections.Add(directionTo);
            _maze.Cells[newCoord.X, newCoord.Y] = new Cell { Connections = new HashSet<Direction> { directionTo.Opposite() } };
        }

        private Dictionary<Direction, Coordinate> getUnvisitedNeighborsByDirection(LinkedListNode<Coordinate> originNode)
        {
            var unvisitedNeighbors = new Dictionary<Direction, Coordinate>();
            var origin = originNode.Value;

            // Check for north neighbor
            if (origin.Y > 0 && 
                _maze.Cells[origin.X, origin.Y-1] == null)
            {
                unvisitedNeighbors.Add(Direction.North, new Coordinate { X = origin.X, Y = origin.Y-1 });   
            }
            // Check for south neighbor
            if (origin.Y < _height - 1 && 
                _maze.Cells[origin.X, origin.Y+1] == null)
            {
                unvisitedNeighbors.Add(Direction.South, new Coordinate { X = origin.X, Y = origin.Y+1 });
            }
            // Check for east neighbor
            if (origin.X > 0 && 
                _maze.Cells[origin.X-1, origin.Y] == null)
            {
                unvisitedNeighbors.Add(Direction.East, new Coordinate { X = origin.X-1, Y = origin.Y });
            }
            // Check for west neighbor
            if (origin.X < _width - 1 && 
                _maze.Cells[origin.X+1, origin.Y] == null)
            {
                unvisitedNeighbors.Add(Direction.West, new Coordinate { X = origin.X+1, Y = origin.Y });
            }

            return unvisitedNeighbors;
        }
    }
}