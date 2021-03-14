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
            bool running = true;
            
            Console.WriteLine("Welcome!");
            // MAIN LOOP ===========================================================
            while (running)
            {
                var maze = InputManager.DefineMazeLoop();
                var mazeOptions = InputManager.DefineMazeOptions(maze);

                var pathBuilder = new PathBuilder(maze);
                var solutionFinder = new SolutionFinder(maze);
                var render = new Render(maze);

                pathBuilder.Start(mazeOptions.VisualizePath, mazeOptions.CellSize);
                if (mazeOptions.SolveManually)
                {
                    // Solve manual loop
                }
                else
                {
                    solutionFinder.Start(mazeOptions.CellSize, mazeOptions.VisualizePath);
                }
                render.Start(mazeOptions.CellSize, showSolution: true);
            }
        }
    }
}
