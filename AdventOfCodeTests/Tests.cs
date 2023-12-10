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
        var result = new Day1().Run(testType, part);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(TestType.Sample, Part.One, 8)]
    [TestCase(TestType.Actual, Part.One, 2406)]
    [TestCase(TestType.Sample, Part.Two, 2286)]
    [TestCase(TestType.Actual, Part.Two, 78375)]
    public void Day2(TestType testType, Part part, int expected)
    {
        var result = new Day2().Run(testType, part);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(TestType.Sample, Part.One, 4361)]
    [TestCase(TestType.Actual, Part.One, 535078)]
    [TestCase(TestType.Sample, Part.Two, 467835)]
    [TestCase(TestType.Actual, Part.Two, 75312571)]
    public void Day3(TestType testType, Part part, int expected)
    {
        var result = new Day3().Run(testType, part);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    [TestCase(TestType.Sample, Part.One, 13)]
    [TestCase(TestType.Actual, Part.One, 15268)]
    [TestCase(TestType.Sample, Part.Two, 30)]
    [TestCase(TestType.Actual, Part.Two, 6283755)]
    public void Day4(TestType testType, Part part, int expected)
    {
        var result = new Day4().Run(testType, part);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    [TestCase(TestType.Sample, Part.One, 288)]
    [TestCase(TestType.Actual, Part.One, 2344708)]
    [TestCase(TestType.Sample, Part.Two, 71503)]
    [TestCase(TestType.Actual, Part.Two, 30125202)]
    public void Day6(TestType testType, Part part, int expected)
    {
        var result = new Day6().Run(testType, part);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(TestType.Sample, Part.One, 6440)]
    [TestCase(TestType.Actual, Part.One, 250957639)]
    [TestCase(TestType.Sample, Part.Two, 5905)]
    [TestCase(TestType.Actual, Part.Two, 251515496)]
    public void Day7(TestType testType, Part part, int expected)
    {
        var result = new Day7().Run(testType, part);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(TestType.Sample, Part.One, 6)]
    [TestCase(TestType.Actual, Part.One, 12599)]
    [TestCase(TestType.Sample, Part.Two, 6)]
    [TestCase(TestType.Actual, Part.Two, 8245452805243)]
    public void Day8(TestType testType, Part part, long expected)
    {
        var result = new Day8().Run(testType, part);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(TestType.Sample, Part.One, 114)]
    [TestCase(TestType.Actual, Part.One, 1992273652)]
    [TestCase(TestType.Sample, Part.Two, 2)]
    [TestCase(TestType.Actual, Part.Two, 1012)]
    public void Day9(TestType testType, Part part, long expected)
    {
        var result = new Day9().Run(testType, part);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(TestType.Sample, Part.One, 8)]
    [TestCase(TestType.Actual, Part.One, 7107)]
    [TestCase(TestType.Sample, Part.Two, 10)]
    [TestCase(TestType.Actual, Part.Two, 281)]
    public void Day10(TestType testType, Part part, long expected)
    {
        var result = new Day10().Run(testType, part);
        Assert.That(result, Is.EqualTo(expected));
    }
}