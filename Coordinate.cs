namespace Maze
{
    public struct Coordinate
    {
        public int X;
        public int Y;

        public static Coordinate Random(int xMax, int yMax) 
        {
            var rand = new System.Random();
            return new Coordinate {X = rand.Next(0, xMax), Y = rand.Next(0, yMax)};
        }
    
        public static Coordinate Random(int xMin, int yMin, int xMax, int yMax) 
        {
            var rand = new System.Random();
            return new Coordinate {X = rand.Next(xMin, xMax), Y = rand.Next(yMin, yMax)};
        }

        public Coordinate[] GetNeighbors() 
        {
            return new Coordinate[] 
            {
                new Coordinate {X = this.X, Y = this.Y - 1},
                new Coordinate {X = this.X, Y = this.Y + 1},
                new Coordinate {X = this.X - 1, Y = this.Y},
                new Coordinate {X = this.X + 1, Y = this.Y}
            };
        }

        public static bool operator ==(Coordinate coordA, Coordinate coordB) 
        {
            return coordA.Equals(coordB);
        }

        public static bool operator !=(Coordinate coordA, Coordinate coordB) 
        {
            return !coordA.Equals(coordB);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}