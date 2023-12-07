using AdventOfCode.Common;
using AdventOfCode.Enums;

namespace AdventOfCode;

public class Day6 : AdventDay
{
    public int Run(TestType testType, Part part)
    {
        var total = 1;
        var times = ReadFromFile(testType, part).First()
            .Split(":", StringSplitOptions.RemoveEmptyEntries)[1]
            .Split(" ",StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse).ToList();
        var distance = ReadFromFile(testType, part).Last()
            .Split(":", StringSplitOptions.RemoveEmptyEntries)[1]
            .Split(" ",StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse).ToList();
        
        for (int i = 0; i < times.Count; i++)
        {
            total *= GetWinningCount(times[i], distance[i]);
        }
        return total;
    }

    public int GetWinningCount(long raceTime, long distanceRecord)
    {
        var wins = 0;
        for (int i = 0; i <= raceTime/2; i++)
        {
            if (CalculateDistance(i, raceTime) > distanceRecord)
            {
                wins++;
            }
        }
        wins *= 2;
        if (raceTime % 2 == 0)
        {
            wins -= 1;
        }
        return wins;
    }

    public long CalculateDistance(long holdTime, long raceTime)
    {
        var movingTime = raceTime - holdTime;
        return holdTime * movingTime;
    }
}
