using System.Text;
using AdventOfCode.Common;
using AdventOfCode.Enums;
using AdventOfCode.Models;

namespace AdventOfCode;

public class Day8 : AdventDay
{

    public long Run(TestType testType, Part part)
    {
        var wastelandMap = GetWastelandMap(testType, part);
        return part == Part.One ?
            RunPartOne(wastelandMap) :
            RunPartTwo(wastelandMap);
    }

    public long RunPartTwo(WastelandMap wastelandMap)
    {
        var startingNodes = new Dictionary<string, int>();
        foreach(var node in wastelandMap.Nodes)
        {
            if (!node.Key.EndsWith('A'))
            {
                continue;
            }
            startingNodes.Add(node.Key, StepsToZ(wastelandMap, node.Key));
        }

        // Never knew there were different methods to LCM!  Using a new one for division using primes,
        // HUGE thank you to https://www.calculatorsoup.com/calculators/math/lcm.php for helping me
        // work this method out!  Also ARylatt for his pattern in 

        var primeNumbers = new HashSet<int>();
        foreach(var prime in ElfMath.PrimeNubers())
        {
            if (startingNodes.All(n => n.Value == 1))
            {
                break;
            }

            foreach(var node in startingNodes)
            {
                if (node.Value % prime == 0)
                {
                    primeNumbers.Add(prime);
                    startingNodes[node.Key] = node.Value / prime;
                }
            }
        }

        long total = 1;
        foreach(var primeNumber in primeNumbers)
        {
            total *= primeNumber;
        }

        return total;

    }

    public int RunPartOne(WastelandMap wastelandMap)
    {
        return StepsToZ(wastelandMap, "AAA");
    }
    
    public int StepsToZ(WastelandMap wastelandMap, string currentNode)
    {
        var steps = 0;
        var directionIndex = 0;
        while(!currentNode.EndsWith('Z'))
        {
            steps++;
            var direction = wastelandMap.Directions[directionIndex];
            directionIndex++;
            if (directionIndex >= wastelandMap.Directions.Count)
            {
                directionIndex = 0;
            }

            currentNode = (direction == 'L') ? 
                wastelandMap.Nodes[currentNode].LeftNode :
                wastelandMap.Nodes[currentNode].RightNode;
        }
        return steps;
    }

    public WastelandMap GetWastelandMap(TestType testType, Part part)
    {
        var wastelandMap = new WastelandMap();
        foreach(var line in ReadFromFile(testType, part))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            if (wastelandMap.Directions.Count == 0)
            {
                wastelandMap.Directions = line.ToList();
                continue;
            }
            var node = new WastelandNode(line);

            wastelandMap.Nodes.Add(node.Id, node);            
        }
        return wastelandMap;
    }
}
