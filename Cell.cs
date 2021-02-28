using System;
using System.Collections.Generic;

namespace Maze
{
    public class Cell
    {
        public HashSet<Direction> Connections = new HashSet<Direction>();
    }
    public enum Direction
    {
        North,
        South,
        East,
        West       
    }
}