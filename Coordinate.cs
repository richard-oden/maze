namespace Maze
{
    public struct Coordinate
    {
        public int X;
        public int Y;

        public static Coordinate Random(int xMax, int yMax) {
            var rand = new System.Random();
            return new Coordinate {X = rand.Next(0, xMax), Y = rand.Next(0, yMax)};
        }
    
        public static Coordinate Random(int xMin, int yMin, int xMax, int yMax) {
            var rand = new System.Random();
            return new Coordinate {X = rand.Next(xMin, xMax), Y = rand.Next(yMin, yMax)};
        }
    }
}