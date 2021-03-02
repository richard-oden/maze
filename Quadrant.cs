namespace Maze
{
    public class Quadrant
    {
        public int XMin {get; private set;}
        public int XMax {get; private set;}
        public int YMin {get; private set;}
        public int YMax {get; private set;}
        public Quadrant(int xMin, int yMin, int xMax, int yMax)
        {
            XMin = xMin;
            XMax = xMax;
            YMin = yMin;
            YMax = yMax;
        }

        public bool IsCoordinateInBounds(Coordinate coord)
        {
            return coord.X >= XMin && coord.X < XMax &&
                   coord.Y >= YMin && coord.Y < YMax;
        }
    }
}