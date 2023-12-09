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
            var day = new List<List<int>> {
                line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList()
            };

            var record = 0;
            do
            {
                day.Add([]);
                for (int entry = 1; entry < day[record].Count; entry++)
                {
                    day[record + 1].Add(
                        day[record][entry] - day[record][entry - 1]);
                }
                record++;
            } while (!day[record].All(r => r == 0));

            do
            {
                day[record - 1].Insert(0,
                    day[record - 1].First() - day[record].First()
                );
                day[record - 1].Add(
                    day[record].Last() + day[record - 1].Last()
                );
                record--;
            } while (record > 0);
            
            oasisHistory.Add(day);
        }

        return oasisHistory;
    }
}
