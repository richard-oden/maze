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
        public static Maze MazeOptionsLoop()
        {
            int mazeWidth = 0;
            int mazeHeight = 0;
            Coordinate? startCoord = null;
            Coordinate? endCoord = null;

            bool mazeCreated = false;
            while (!mazeCreated)
            {
                mazeWidth = int.Parse(PromptLoop("Enter a width for your maze", IsInt));
                mazeHeight = int.Parse(PromptLoop("Enter a height for your maze", IsInt));
                startCoord = ParseCoord(PromptLoop("Enter a starting coordinate (leave blank for a random coordinate)", IsCoord));
                endCoord = ParseCoord(PromptLoop("Enter an ending coordinate (leave blank for a random coordinate)", IsCoord));

                mazeCreated = ParseYOrN(PromptLoop($"You have a created a {mazeWidth}x{mazeHeight} maze with the start located at {randomOrDefinedCoord(startCoord)} and the end located at {randomOrDefinedCoord(endCoord)}. Is this correct? (Y/N)", IsYOrN));
            }

            return new Maze(mazeWidth, mazeHeight, startCoord, endCoord);
        }
    }
}