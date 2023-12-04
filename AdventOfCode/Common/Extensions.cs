namespace AdventOfCode.Common;

public static class Extensions
{
    public static bool IsNumber(this char c) {
        return c >= 48 && c <= 57;
    }
}
