namespace AdventOfCode.Common;

using AdventOfCode.Enums;

public abstract class AdventDay
{
    public IEnumerable<string> ReadFromFile(TestType testType, Part part)
    {
        var fileName = $"./inputs/{GetType().Name}/{testType}Part{part}.txt";

        if (!File.Exists(fileName))
        {
            fileName = $"./inputs/{GetType().Name}/{testType}.txt";
        }
        
        using var file = File.OpenRead(fileName);
        using var sr = new StreamReader(file);
        
        while (!sr.EndOfStream)
        {
            yield return sr.ReadLine() ?? string.Empty;  
        }      
    }
}
