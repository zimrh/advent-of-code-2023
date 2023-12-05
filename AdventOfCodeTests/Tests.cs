using AdventOfCode;
using AdventOfCode.Enums;

namespace AdventOfCodeTests;


public class Tests
{
    [Test]
    [TestCase(TestType.Sample, Part.One, 142)]
    [TestCase(TestType.Actual, Part.One, 56042)]
    [TestCase(TestType.Sample, Part.Two, 281)]
    [TestCase(TestType.Actual, Part.Two, 55358)]
    public void Day1(TestType testType, Part part, int expected)
    {
        var partOneResult = new Day1().Run(testType, part);
        Assert.That(partOneResult, Is.EqualTo(expected));
        Console.WriteLine($"Part {part}: {partOneResult}");
    }

    [Test]
    [TestCase(TestType.Sample, Part.One, 8)]
    [TestCase(TestType.Actual, Part.One, 2406)]
    [TestCase(TestType.Sample, Part.Two, 2286)]
    [TestCase(TestType.Actual, Part.Two, 78375)]
    public void Day2(TestType testType, Part part, int expected)
    {
        var partOneResult = new Day2().Run(testType, part);
        Assert.That(partOneResult, Is.EqualTo(expected));
        Console.WriteLine($"Part {part}: {partOneResult}");
    }

    [Test]
    [TestCase(TestType.Sample, Part.One, 4361)]
    [TestCase(TestType.Actual, Part.One, 535078)]
    [TestCase(TestType.Sample, Part.Two, 467835)]
    [TestCase(TestType.Actual, Part.Two, 75312571)]
    public void Day3(TestType testType, Part part, int expected)
    {
        var partOneResult = new Day3().Run(testType, part);
        Assert.That(partOneResult, Is.EqualTo(expected));
        Console.WriteLine($"Part {part}: {partOneResult}");
    }
    
    [Test]
    [TestCase(TestType.Sample, Part.One, 13)]
    [TestCase(TestType.Actual, Part.One, 15268)]
    [TestCase(TestType.Sample, Part.Two, 30)]
    [TestCase(TestType.Actual, Part.Two, 6283755)]
    public void Day4(TestType testType, Part part, int expected)
    {
        var partOneResult = new Day4().Run(testType, part);
        Assert.That(partOneResult, Is.EqualTo(expected));
        Console.WriteLine($"Part {part}: {partOneResult}");
    }
}