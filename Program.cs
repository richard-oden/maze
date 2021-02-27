using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze
{
    class Program
    {
        static Coordinate RandomPosition(int width, int height) 
        {
            var rand = new Random();
            return new Coordinate {X = rand.Next(0, width), Y = rand.Next(0, height)};
        }

        static void Main(string[] args)
        {
            var cells = new Cell[30, 15];
            var mazeArray = Render.BuildMazeArray(cells);
            var mazeString = Render.BuildMazeString(mazeArray);
            Console.Write(mazeString);
        }
    }
}
