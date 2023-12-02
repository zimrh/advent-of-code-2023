using AdventOfCode.Common;
using AdventOfCode.Enums;

namespace AdventOfCode;

public class Day2 : AdventDay
{
    public int Run(TestType testType, Part part)
    {
        var games = GetGames(testType, part);
        return part == Part.One ?
            RunPartOne(games) :
            RunPartTwo(games);
    }

    public int RunPartOne(List<Game> games) {
        var maxValues = new Dictionary<Color, int>() {
            { Color.Red, 12 },
            { Color.Green, 13 },
            { Color.Blue, 14 }
        };

        var total = 0;
        foreach(var game in games)
        {
            if (IsGamePossible(game, maxValues))
            {
                total += game.Id;
            }
        }
        return total;
    }

    public int RunPartTwo(List<Game> games) {

        var total = 0;
        foreach(var game in games)
        {
            var largestValues = new Dictionary<Color, int>() {
                { Color.Red, 0 },
                { Color.Green, 0 },
                { Color.Blue, 0 }
            };
            foreach(var draw in game.Draws)
            {
                foreach(var result in draw)
                {
                    largestValues[result.Key] = largestValues[result.Key] > result.Value ? 
                        largestValues[result.Key] :
                        result.Value;
                }
            }
            var subTotal = 1;
            foreach(var largestValue in largestValues)
            {
                subTotal *= largestValue.Value;
            }
            total += subTotal;
        }
        return total;
    }

    public List<Game> GetGames(TestType testType, Part part)
    {
        var games = new List<Game>();
        foreach(var line in ReadFromFile(testType, part))
        {
            var game = new Game();
            var gameAndResultSplit = line.Split(":", StringSplitOptions.RemoveEmptyEntries);
            var gameIdSplit = gameAndResultSplit[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            game.Id = int.Parse(gameIdSplit[1]);
            
            var draws = gameAndResultSplit[1].Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var draw in draws)
            {
                var d = new Dictionary<Color, int>();
                var balls = draw.Split(",", StringSplitOptions.RemoveEmptyEntries);
                foreach(var ball in balls)
                {
                    var result = ball.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    d.TryAdd(Game.GetColor(result[1]), int.Parse(result[0]));
                }
                game.Draws.Add(d);
            }
            games.Add(game);
        }
        return games;
    }

    public bool IsGamePossible(Game game, Dictionary<Color, int> maxValues)
    {
        foreach(var maxValue in maxValues)
        {
            foreach(var draw in game.Draws)
            {
                if (draw.ContainsKey(maxValue.Key) && draw[maxValue.Key] > maxValue.Value)
                {
                    return false;
                }
            }
        }
        return true;
    }
}