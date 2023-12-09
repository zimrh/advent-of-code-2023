using AdventOfCode;
using AdventOfCode.Common;
using AdventOfCode.Enums;
using NUnit.Framework.Internal;

namespace AdventOfCodeTests;

public class CommonTests
{
    
    [Test]
    public void TestPrimes()
    {
        var primes = new HashSet<int>(){1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227};
        var count = primes.Count;
        var i = 0;
        foreach(var prime in ElfMath.PrimeNubers())
        {
            if(!primes.Contains(prime))
            {
                Assert.Fail($"{prime} is not a Prime!");
            }
            i++;
            if (++i >= count){
                break;
            }
        }
        Assert.Pass();
    }
}
