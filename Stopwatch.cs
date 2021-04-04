using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;

namespace Maze
{
    public class Stopwatch
    {
        private DateTime _startTime;

        public void Start()
        {
            _startTime = DateTime.Now;
        }

        public string GetElpasedTime()
        {
            if (_startTime != default(DateTime))
            {
                TimeSpan duration = DateTime.Now - _startTime;
                return duration.ToString(@"mm\:ss\.ff");
            }
            return "Stopwatch has not been started yet.";
        }
    }
}