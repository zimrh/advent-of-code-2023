using AdventOfCode.Common;
using AdventOfCode.Enums;

namespace AdventOfCode;

public class Day12 : AdventDay
{
    public int Run(TestType testType, Part part)
    {
        return RunPartOne(testType, part);
    }

    private int RunPartOne(TestType testType, Part part)
    {
        var sum = 0;
        foreach(var line in ReadFromFile(testType, part))
        {
            sum += CountPossibilities(line);
        }
        return sum;
    }

    private int CountPossibilities(string line)
    {
        var split = line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
        var spaces = split[0];
        var chunks = split[1];

        for (int i = 0; i < length; i++)
        {
            throw new NotImplementedException();
        }
    }
}
