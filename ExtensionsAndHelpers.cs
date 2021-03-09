using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Maze
{
    public static class ExtensionsAndHelpers
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

        public static string Prompt(string promptPhrase)
        {
            Console.Write(promptPhrase + ": ");
            return Console.ReadLine();
        }

        public static ConsoleKey PromptKey(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadKey(true).Key;
        }

        public static string PromptLoop(string prompt, Func<string, bool> validator)
        {
            string output = null;
            while (output == null)
            {
                var input = Prompt(prompt);
                if (validator(input)) 
                    output = input;
                else
                    PromptKey($"Input \"{input}\" is not valid.");
                Console.Clear();
            }
            return output;
        }

        public static bool IsYOrN(string input)
        {
            return new string[] {"y", "n"}.Contains(input.ToLower());
        }

        public static bool IsInt(string input)
        {
            return int.TryParse(input, out _);
        }

        public static bool IsCoord(string input)
        {
            var inputArr = Regex.Split(input, @"[,| ]");
            return input == ""
                || inputArr.Length == 2 
                && IsInt(inputArr[0]) 
                && IsInt(inputArr[1]);
        }

        public static bool ParseYOrN(string input)
        {
            return input.ToLower() == "y";
        }

        public static Coordinate? ParseCoord(string input)
        {
            var inputArr = Regex.Split(input, @"[,| ]");
            return input == "" ? null : new Coordinate {X = int.Parse(inputArr[0]), Y = int.Parse(inputArr[1])};
        }
    }
}