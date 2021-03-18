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
            Console.Write(prompt);
            return Console.ReadKey(true).Key;
        }

        public static ConsoleKey? PromptKeyAndValidate(string prompt, IEnumerable<ConsoleKey> validKeys)
        {
            ConsoleKey? output = null;

            var input = PromptKey(prompt);
            if (validKeys.Contains((ConsoleKey)input))
                output = input;
            else
                PromptKey($"Input \"{input.ToString()}\" is not valid.");

            return output;
        }

        public static string PromptLoop(string prompt, Func<string, int?, int?, bool> validator, int? param1 = null, int? param2 = null)
        {
            string output = null;
            while (output == null)
            {
                var input = Prompt(prompt);
                if (validator(input, param1, param2)) 
                    output = input;
                else
                    PromptKey($"Input \"{input}\" is not valid.");
                Console.Clear();
            }
            return output;
        }

        public static bool IsYOrN(string input, int? param1 = null, int? param2 = null)
        {
            return new string[] {"y", "n"}.Contains(input.ToLower());
        }

        public static bool IsValidInt(string input, int? lowerBound = null, int? upperBound = null)
        {
            int parsedInput;
            return int.TryParse(input, out parsedInput)
                && (lowerBound == null || parsedInput >= (int)lowerBound)
                && (upperBound == null || parsedInput <= (int)upperBound);
        }

        public static bool IsValidCoord(string input, int? width = null, int? height = null)
        {
            var inputArr = Regex.Split(input, @"[,|\s]+");
            return input == ""
                || inputArr.Length == 2 // input contains only 2 values separated by comma or space
                && IsValidInt(inputArr[0]) && IsValidInt(inputArr[1]) // values are integers
                && ((width == null || height == null) // don't check bounding if width or height are null
                || ((Coordinate)ParseCoord(input)).IsInBounds((int)width, (int)height)); // otherwise check bounding
        }

        public static bool ParseYOrN(string input)
        {
            return input.ToLower() == "y";
        }

        public static Coordinate? ParseCoord(string input)
        {
            var inputArr = Regex.Split(input, @"[,|\s]+");
            return input == "" ? null : new Coordinate {X = int.Parse(inputArr[0]), Y = int.Parse(inputArr[1])};
        }
    }
}