using AdventOfCode;
using AdventOfCode.Enums;

namespace AdventOfCodeTests;


public class Tests
{
    [Test]
    [TestCase(TestType.Sample, 142, 281)]
    [TestCase(TestType.Actual, 56042, 55358)]
    public void Test1(TestType testType, int partOneExpected, int partTwoExpected)
    {
        var partOneResult = Day1.Run(testType, Part.One);
        Assert.That(partOneResult, Is.EqualTo(partOneExpected));
        Console.WriteLine($"Part One: {partOneResult}");

        var partTwoResult = Day1.Run(testType, Part.Two);
        Assert.That(partTwoResult, Is.EqualTo(partTwoExpected));
        Console.WriteLine($"Part Two: {partTwoResult}");
    }
}