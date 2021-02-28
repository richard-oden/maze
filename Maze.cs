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
    }
}