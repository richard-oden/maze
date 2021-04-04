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
            while (running)
            {
                var maze = InputManager.DefineMazeLoop();
                var mazeOptions = InputManager.DefineMazeOptionsLoop(maze);

                var pathBuilder = new PathBuilder(maze);
                var solutionBuilder = new SolutionBuilder(maze);
                var render = new Render(maze);

                pathBuilder.Start(mazeOptions.VisualizePath, mazeOptions.CellSize);

                if (mazeOptions.SolveManually)
                    InputManager.HandleNavigationLoop(maze, render, mazeOptions.CellSize);
                else
                    solutionBuilder.Start(mazeOptions.CellSize, mazeOptions.VisualizePath);
                
                render.Start(mazeOptions.CellSize, showSolution: true);
                running = InputManager.HandleTryAgainInput();
            }
        }
    }
}
