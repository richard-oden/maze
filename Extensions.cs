using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze
{
    public static class Extensions
    {
        public static T RandomElement<T>(this IEnumerable<T> enumerable)
        {
            var rand = new Random();
            int index = rand.Next(0, enumerable.Count());
            return enumerable.ElementAt(index);
        }

        public static Direction Opposite(this Direction originDirection)
        {
            return originDirection == Direction.North || originDirection == Direction.East ? originDirection + 1 : originDirection - 1;
        }
    }
}