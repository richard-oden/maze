using System;
using System.Collections.Generic;
using System.Linq;
using static Maze.ExtensionsAndHelpers;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // var maze = new Maze(40, 20);
            // var pathBuilder = new PathBuilder(maze);
            // var solutionFinder = new SolutionFinder(maze);
            // var render = new Render(maze);
            // pathBuilder.Start(cellSize: 1);
            // solutionFinder.Start(cellSize: 1);
            // render.Start(cellSize: 1, showSolution: true) ;
            // Console.ReadLine();

            bool running = true;
            Console.WriteLine("Welcome!");
            // MAIN LOOP ===========================================================
            while (running)
            {
                var maze = InputManager.DefineMazeLoop();
                var pathBuilderOptions = InputManager.DefinePathBuilderOptionsLoop(maze);
            }
        }
    }
}
