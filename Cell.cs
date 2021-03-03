using System;
using System.Collections.Generic;

namespace Maze
{
    public class Cell
    {
        public HashSet<Direction> Connections = new HashSet<Direction>();
        public int DistanceFromEnd = 0;
    }
    public enum Direction
    {
        Undefined = 0,
        North,
        South,
        East,
        West       
    }
}