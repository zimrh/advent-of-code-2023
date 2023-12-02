namespace AdventOfCode;

using AdventOfCode.Enums;

public static class Day1
{
    public static IEnumerable<string> ReadFromFile(TestType testType, string day, Part part)
    {
        using var file = File.OpenRead($"./{testType}/{day}-{part}.txt");
        using var sr = new StreamReader(file);
        
        while (!sr.EndOfStream)
        {
            yield return sr.ReadLine() ?? string.Empty;  
        }      
    }

    // Sample Expected Value
    public static int Run(TestType testType, Part part)
    {
        var total = 0;
        foreach(var line in ReadFromFile(testType, nameof(Day1), part))
        {
            var left = ' ';
            var right = ' ';
            var length = line.Length - 1;

            for (int i = 0; i <= length; i++)
            {
                left = (left == ' ') ? GetNumber(line, i, part) : left;
                right = (right == ' ') ? GetNumber(line, length - i, part) : right;
            }
            total += int.Parse($"{left}{right}");
        }
        return total;
    }

    public static char GetNumber(string line, int i, Part part)
    {
        if(IsInteger(line[i])) {
            return line[i];
        }
        if (part == Part.One) {
            return ' ';
        }
        return TextNumberToChar(line, i);
    }

    public static char TextNumberToChar(string line, int i)
    {
        var numbers = new Dictionary<string, char>
        {
            {"one", '1'},        
            {"two", '2'},
            {"three", '3'},
            {"four", '4'},
            {"five", '5'},
            {"six", '6'},
            {"seven", '7'},
            {"eight", '8'},
            {"nine", '9'}
        };
        foreach (var number in numbers)
        {
            if (line[i..].StartsWith(number.Key))
            {
                return number.Value;
            }
        }
        return ' ';
    }

    public static bool IsInteger(char c) {
        return c >= 48 && c <= 57;
    }
}
