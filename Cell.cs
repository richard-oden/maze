using System;
using System.Collections.Generic;

namespace Maze
{
    public class Cell
    {
        public HashSet<CellConnection> Connections = new HashSet<CellConnection>();
    }
    public enum CellConnection
    {
        North,
        South,
        East,
        West       
    }
}