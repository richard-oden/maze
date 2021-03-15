using System;
using System.Collections.Generic;
using System.Linq;
using static Maze.ExtensionsAndHelpers;

namespace Maze
{
    public static class InputManager
    {

        private static string randomOrDefinedCoord(Coordinate? coord)
        {
            return coord == null ? "a random coordinate" : ((Coordinate)coord).ToString();
        }
        public static Maze DefineMazeLoop()
        {
            int mazeWidth = 0;
            int mazeHeight = 0;
            Coordinate? startCoord = null;
            Coordinate? endCoord = null;

            bool mazeCreated = false;
            while (!mazeCreated)
            {
                mazeWidth = int.Parse(PromptLoop("Enter a width for your maze (Note: If maze width is too large, rendering will break due to line wrapping)", IsValidInt));
                mazeHeight = int.Parse(PromptLoop("Enter a height for your maze", IsValidInt));
                startCoord = ParseCoord(PromptLoop("Enter a starting coordinate (leave blank for a random coordinate)", IsValidCoord, mazeWidth, mazeHeight));
                endCoord = ParseCoord(PromptLoop("Enter an ending coordinate (leave blank for a random coordinate)", IsValidCoord, mazeWidth, mazeHeight));

                mazeCreated = ParseYOrN(PromptLoop($"You have a created a {mazeWidth}x{mazeHeight} maze with the start located at {randomOrDefinedCoord(startCoord)} and the end located at {randomOrDefinedCoord(endCoord)}. Is this correct? (Y/N)", IsYOrN));
            }

            return new Maze(mazeWidth, mazeHeight, startCoord, endCoord);
        }

        public static dynamic DefineMazeOptionsLoop(Maze maze)
        {
            int cellSize = 1;
            bool visualizePath = false;
            bool visualizeSolution = false;
            bool solveManually = false;

            bool pathBuilderOptionsCreated = false;
            while (!pathBuilderOptionsCreated)
            {
                cellSize = int.Parse(PromptLoop("Enter cell size (Note: If cell size is too large, rendering will break due to line wrapping)", IsValidInt));
                visualizePath = ParseYOrN(PromptLoop("Visualize maze during path generation? (Y/N)", IsYOrN));
                visualizeSolution = ParseYOrN(PromptLoop("Visualize maze during solution generation? (Y/N)", IsYOrN));
                solveManually = ParseYOrN(PromptLoop("Solve maze manually (Y) or generate solution automatically? (N)", IsYOrN));

                var solutionMethodString = solveManually ? "manually" : "automatically";
                pathBuilderOptionsCreated = ParseYOrN(PromptLoop($"You have chosen a cell size of {cellSize}, set path visualization to {visualizePath.ToString().ToLower()}, and set solution visualization to {visualizeSolution.ToString().ToLower()}. You would also like to solve the maze {solutionMethodString}. Is this correct? (Y/N)", IsYOrN));
            }

            return new 
            {
                CellSize = cellSize, 
                VisualizePath = visualizePath, 
                VisualizeSolution = visualizeSolution,
                SolveManually = solveManually
            };
        }

        private static ConsoleKey? promptNavigationInput()
        {
            return PromptKeyAndValidate("Use the arrow keys to move, S to toggle solution, and Q to quit", new [] 
            {
                ConsoleKey.UpArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.DownArrow,
                ConsoleKey.LeftArrow,
                ConsoleKey.S,
                ConsoleKey.Q
            });
        }

        private static dynamic parseNavigationInput(Maze maze, ConsoleKey input)
        {
            return new {Running = true, ShowSolution = false};
        }

        public static void HandleNavigationLoop(Maze maze, Render render, int cellSize)
        {
            var navigationOptions = new {Running = true, ShowSolution = false};
            while (navigationOptions.Running)
            {
                render.Start(cellSize, navigationOptions.ShowSolution);
                var input = promptNavigationInput();
                if (input != null) navigationOptions = parseNavigationInput(maze, (ConsoleKey)input);
            }
        }
    }
}