using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze
{
    public class Maze
    {
        public int Width {get; private set;}
        public int Height {get; private set;}
        public Cell[,] Cells;
        public Coordinate Start {get; private set;}
        public Coordinate End {get; private set;}
        private Dictionary<string, Quadrant> _quadrants;
        public HashSet<Coordinate> Solution = new HashSet<Coordinate>();

        public Maze(int width, int height, Coordinate? start = null, Coordinate? end = null)
        {
            Width = width;
            Height = height;
            Cells = new Cell[width, height];
            _quadrants = new Dictionary<string, Quadrant>()
            {
                { "NW", new Quadrant(0, 0, Width / 2, Height / 2) },
                { "NE", new Quadrant(Width / 2, 0, Width, Height / 2) },
                { "SW", new Quadrant(0, Height / 2, Width / 2, Height) },
                { "SE", new Quadrant(Width / 2, Height / 2, Width, Height) }
            };
            setStartAndEnd(start, end);
        }

        private Coordinate getCoordinateInOppositeQuadrant(Coordinate originCoord)
        {   
            var originQuad = _quadrants.Single(q => q.Value.IsCoordinateInBounds(originCoord));
            var oppositeQuad = _quadrants.Single(q => q.Key[0] != originQuad.Key[0] && q.Key[1] != originQuad.Key[1]);
            var oppositeCoord = Coordinate.Random(oppositeQuad.Value.XMin, oppositeQuad.Value.YMin, oppositeQuad.Value.XMax, oppositeQuad.Value.YMax);
            return oppositeCoord;
        }

        private void setStartAndEnd(Coordinate? start = null, Coordinate? end = null)
        {
            if (start == null && end == null)
            {
                Start = Coordinate.Random(Width, Height);
                End = getCoordinateInOppositeQuadrant(Start);
            }
            else if (start == null)
            {
                Start = getCoordinateInOppositeQuadrant(End);
            }
            else if (end == null)
            {
                End = getCoordinateInOppositeQuadrant(Start);
            }
            else {
                Start = (Coordinate) start;
                End = (Coordinate) end;
            }
        }

        public bool IsCoordinateInBounds(Coordinate coord)
        {
            return coord.X > -1 && coord.X < Width &&
                   coord.Y > -1 && coord.Y < Height;
        }

        public bool DoesConnectionExistBetween(Coordinate coordA, Coordinate coordB)
        {
            Direction cellAConnection = 0;
            
            if (IsCoordinateInBounds(coordA) && IsCoordinateInBounds(coordB) &&
                Cells[coordA.X, coordA.Y] != null && Cells[coordB.X, coordB.Y] != null)
            {
                if (coordA.X == coordB.X)
                {
                    if (coordA.Y - 1 == coordB.Y)
                        cellAConnection = Direction.North;
                    else if (coordA.Y + 1 == coordB.Y)
                        cellAConnection = Direction.South;
                }
                else if (coordA.Y == coordB.Y)
                {
                    if (coordA.X + 1 == coordB.X)
                        cellAConnection = Direction.East;
                    else if (coordA.X - 1 == coordB.X)
                        cellAConnection = Direction.West;
                }
            }

            return cellAConnection != 0 && 
                Cells[coordA.X, coordA.Y].Connections.Contains(cellAConnection) &&
                Cells[coordB.X, coordB.Y].Connections.Contains(cellAConnection.Opposite());
        }
    }
}