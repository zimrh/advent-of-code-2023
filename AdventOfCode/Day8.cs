using AdventOfCode.Common;
using AdventOfCode.Enums;
using AdventOfCode.Models;

namespace AdventOfCode;

public class Day8 : AdventDay
{
    public int Run(TestType testType, Part part)
    {
        var wastelandMap = GetMapAndDirections(testType, part);
        var steps = 0;
        var currentNode = "AAA";
        var directionIndex = 0;
        while(!string.Equals(currentNode, "ZZZ"))
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

    public WastelandMap GetMapAndDirections(TestType testType, Part part)
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
