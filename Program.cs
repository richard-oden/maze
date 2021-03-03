using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var maze = new Maze(20, 12);
            var pathBuilder = new PathBuilder(maze);
            var solutionFinder = new SolutionFinder(maze);
            var render = new Render(maze);
            pathBuilder.Start();
            solutionFinder.Start();
            render.Start(cellSize: 2, showSolution: true);
            
        }
    }
}
