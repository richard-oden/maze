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
                mazeWidth = int.Parse(PromptLoop("Enter a width for your maze (Note: If maze width is too large, rendering will break due to line wrapping)", IsInt));
                mazeHeight = int.Parse(PromptLoop("Enter a height for your maze", IsInt));
                startCoord = ParseCoord(PromptLoop("Enter a starting coordinate (leave blank for a random coordinate)", IsCoord));
                endCoord = ParseCoord(PromptLoop("Enter an ending coordinate (leave blank for a random coordinate)", IsCoord));

                mazeCreated = ParseYOrN(PromptLoop($"You have a created a {mazeWidth}x{mazeHeight} maze with the start located at {randomOrDefinedCoord(startCoord)} and the end located at {randomOrDefinedCoord(endCoord)}. Is this correct? (Y/N)", IsYOrN));
            }

            return new Maze(mazeWidth, mazeHeight, startCoord, endCoord);
        }

        public static object DefinePathBuilderOptionsLoop(Maze maze)
        {
            bool visualize = false;
            int cellSize = 1;

            bool pathBuilderOptionsCreated = false;
            while (!pathBuilderOptionsCreated)
            {
                cellSize = int.Parse(PromptLoop("Enter cell size (Note: If cell size is too large, rendering will break due to line wrapping)", IsInt));
                visualize = ParseYOrN(PromptLoop("Visualize maze during path generation? (Y/N)", IsYOrN));

                pathBuilderOptionsCreated = ParseYOrN(PromptLoop($"You have chosen a cell size of {cellSize} and have set path visualization to {visualize.ToString().ToLower()}. Is this correct? (Y/N)", IsYOrN));
            }

            return new {Visualize = visualize, CellSize = cellSize};
        }
    }
}