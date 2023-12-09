namespace AdventOfCode.Common;

public static class ElfMath
{
    public static IEnumerable<int> PrimeNubers()
    {
        yield return 1;
        yield return 2;
        int number = 3;
        var isPrime = true;
        do
        {
            if (isPrime)
            {
                yield return number;
            }
            
            number += 2;
            var boundary = (int)Math.Floor(Math.Sqrt(number));
            isPrime = true;
            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                    isPrime = false;
                break;
            }
        } while (true);
    }

}
