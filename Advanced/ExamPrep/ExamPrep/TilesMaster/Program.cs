using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    internal class Program
    {
        static void Main()
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Dictionary<int, string> locations = new Dictionary<int, string>()
            {
                {40, "Sink"},
                {50, "Oven"},
                {60, "Countertop"},
                {70, "Wall"}
            };

            Dictionary<string, int> placesTiles = new Dictionary<string, int>()
            {
                {"Sink",0},
                {"Oven",0},
                {"Countertop",0},
                {"Wall", 0},
                {"Floor",0}
            };

            while (greyTiles.Count > 0 && whiteTiles.Count > 0)
            {
                int currentWhiteTile = whiteTiles.Pop();
                int currentGreyTile = greyTiles.Dequeue();

                if (currentWhiteTile != currentGreyTile)
                {
                    whiteTiles.Push(currentWhiteTile / 2);
                    greyTiles.Enqueue(currentGreyTile);
                    continue;
                }

                if (locations.Any(l => l.Key == currentGreyTile + currentWhiteTile))
                {
                    placesTiles[locations[currentGreyTile + currentWhiteTile]]++;
                }
                else
                {
                    placesTiles["Floor"]++;
                }
            }

            Console.WriteLine(whiteTiles.Count > 0
                ? $"White tiles left: {string.Join(", ", whiteTiles)}"
                : "White tiles left: none");
            Console.WriteLine(greyTiles.Count > 0
                ? $"Grey tiles left: {string.Join(", ", greyTiles)}"
                : "Grey tiles left: none");

            foreach (var tile in placesTiles
                         .Where(t => t.Value > 0)
                         .OrderByDescending(t => t.Value)
                         .ThenBy(t => t.Key))
            {
                Console.WriteLine($"{tile.Key}: {tile.Value}");
            }
        }
    }
}
