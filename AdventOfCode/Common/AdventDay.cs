namespace AdventOfCode.Common;

using AdventOfCode.Enums;

public abstract class AdventDay
{
    public IEnumerable<string> ReadFromFile(TestType testType, Part part)
    {
        using var file = File.OpenRead($"./inputs/{GetType().Name}/{testType}Part{part}.txt");
        using var sr = new StreamReader(file);
        
        while (!sr.EndOfStream)
        {
            yield return sr.ReadLine() ?? string.Empty;  
        }      
    }
}
