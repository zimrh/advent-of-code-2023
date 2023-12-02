using AdventOfCode;
using AdventOfCode.Enums;

namespace AdventOfCodeTests;


public class Tests
{
    [Test]
    [TestCase(TestType.Sample, Part.One, 142)]
    [TestCase(TestType.Sample, Part.Two, 281)]
    [TestCase(TestType.Actual, Part.One, 56042)]
    [TestCase(TestType.Actual, Part.Two, 55358)]
    public void Day1(TestType testType, Part part, int expected)
    {
        var partOneResult = new Day1().Run(testType, part);
        Assert.That(partOneResult, Is.EqualTo(expected));
        Console.WriteLine($"Part {part}: {partOneResult}");
    }
}