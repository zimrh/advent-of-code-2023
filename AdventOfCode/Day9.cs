using AdventOfCode.Common;
using AdventOfCode.Enums;

namespace AdventOfCode;

public class Day9 : AdventDay
{
    public int Run(TestType testType, Part part)
    {
        var oasisHistory = GetOasisHistory(testType, part);

        return part == Part.One ?
            oasisHistory.Sum(h => h.First().Last()) :
            oasisHistory.Sum(h => h.First().First());
    }

    public List<List<List<int>>> GetOasisHistory(TestType testType, Part part)
    {
        var oasisHistory = new List<List<List<int>>>();
        foreach (var line in ReadFromFile(testType, part))
        {
            oasisHistory.Add([
                line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList()
            ]);           
        }
        
        for (int day = 0; day < oasisHistory.Count; day++)
        {
            var record = 0;
            do
            {
                oasisHistory[day].Add(new List<int>());
                for (int entry = 1; entry < oasisHistory[day][record].Count; entry++)
                {
                    oasisHistory[day][record + 1].Add(
                        oasisHistory[day][record][entry] - oasisHistory[day][record][entry - 1]);
                }
                record++;
            } while (!oasisHistory[day][record].All(r => r == 0));
        }

        for (int day = 0; day < oasisHistory.Count; day++)
        {
            var record = oasisHistory[day].Count - 1;
            oasisHistory[day][record].Insert(0, 0);

            do
            {
                oasisHistory[day][record - 1].Insert(0,
                    oasisHistory[day][record - 1].First() - oasisHistory[day][record].First()
                );
                oasisHistory[day][record - 1].Add(
                    oasisHistory[day][record].Last() + oasisHistory[day][record - 1].Last()
                );
                record--;
            } while (record > 0);
        }

        return oasisHistory;
    }
}
