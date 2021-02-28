using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            var maze = new Maze(24, 12);
            var pathBuilder = new PathBuilder(maze);
            var render = new Render(maze);
            pathBuilder.Start(true, 2);
            render.Start(2);
        }
    }
}
