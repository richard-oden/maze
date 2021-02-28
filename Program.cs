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
            var cells = new Cell[28, 14];
            cells[0,0] = new Cell {Connections = new HashSet<CellConnection>() {CellConnection.East, CellConnection.South} };
            cells[1,0] = new Cell {Connections = new HashSet<CellConnection>() {CellConnection.West, CellConnection.South} };
            cells[0,1] = new Cell {Connections = new HashSet<CellConnection>() {CellConnection.East, CellConnection.North} };
            cells[1,1] = new Cell {Connections = new HashSet<CellConnection>() {CellConnection.West, CellConnection.North} };
            var render = new Render();
            var mazeArray = render.BuildMazeArray(cells);
            var mazeString = render.BuildMazeString(mazeArray);
            Console.Write(mazeString);
        }
    }
}
