namespace Maze
{
    public class Maze
    {
        public int Width {get; private set;}
        public int Height {get; private set;}
        public Cell[,] Cells;

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new Cell[width, height];
        }

        private bool isCoordinateInBounds(Coordinate coord)
        {
            return coord.X > -1 && coord.X < Width &&
                   coord.Y > -1 && coord.Y < Height;
        }

        public bool DoesConnectionExistBetween(Coordinate coordA, Coordinate coordB)
        {
            Direction cellAConnection = 0;
            
            if (isCoordinateInBounds(coordA) && isCoordinateInBounds(coordB) &&
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