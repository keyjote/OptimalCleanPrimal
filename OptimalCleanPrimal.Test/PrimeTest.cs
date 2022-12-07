using OptimalCleanPrimal.UsingEratosthenes;
using Xunit.Abstractions;

namespace OptimalCleanPrimal.Test;

public class PrimeTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public PrimeTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, false)]
    [InlineData(5, true)]
    [InlineData(6, false)]
    [InlineData(7, true)]
    [InlineData(11, true)]
    [InlineData(23, true)]
    public void IsPrimeTest(long value, bool expectedResult)
    {
        // OptimusPrime.CalculateSomePrimes(value);
        
        Assert.Equal(expectedResult, OptimusPrime.IsValuePrimeNumber(value));
    }

    [Fact]
    public void CalculateFirst10Primes()
    {
        var theRealPrimes = new List<long> { 2,3,5,7,11,13,17,19,23,29 };
        OptimusPrime.CalculateSomePrimes(10);
        
        Assert.All(theRealPrimes, rp => Assert.Contains(rp, ThePrimes.Primes));
    }

    [Fact]
    public void CalculateFirst100Primes()
    {
        var theRealPrimes = new List<long> { 
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
            73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173,
            179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281,
            283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409,
            419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541,
            //
            // 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659,
            // 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809,
            // 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941,
            // 947, 953, 967, 971, 977, 983, 991, 997 
        };
        OptimusPrime.CalculateSomePrimes(100);
        
        Assert.All(theRealPrimes, rp => Assert.Contains(rp, ThePrimes.Primes));
    }

    [Fact]
    public void CalculateFirst200Primes()
    {
        var theRealPrimes = new List<long> { 
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
            73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173,
            179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281,
            283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409,
            419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541,
            547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659,
            661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809,
            811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941,
            947, 953, 967, 971, 977, 983, 991, 997, 1009, 1013, 1019, 1021, 1031, 1033, 1039, 1049, 1051, 1061, 1063, 1069,
            1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151, 1153, 1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223
        };
        OptimusPrime.CalculateSomePrimes(200);
        
        Assert.All(theRealPrimes, rp => Assert.Contains(rp, ThePrimes.Primes));
    }

    [Theory]
    [InlineData(100, 541)]
    [InlineData(200, 1223)]
    [InlineData(300, 1987)]
    [InlineData(400, 2741)]
    [InlineData(500, 3571)]
    [InlineData(600, 4409)]
    [InlineData(700, 5279)]
    [InlineData(800, 6133)]
    [InlineData(900, 6997)]
    [InlineData(1000, 7919)]
    public void CalculateNthPrimeNumber(int nth, long expectedValue)
    {
        OptimusPrime.CalculateSomePrimes(nth);
        Assert.Equal(expectedValue, ThePrimes.Primes[nth-1]);
    }
    
    [Fact]
    public void CalculateMillionthPrimeNumber()
    {
        OptimusPrime.CalculateSomePrimes(1_000_000);
        _testOutputHelper.WriteLine($"The millionth calculated is: {ThePrimes.Primes.Last()}");
        Assert.Equal(666, ThePrimes.Primes[1_000_000-1]);
    }
    
    [Fact]
    public void RunSieveRun()
    {
        SieveController.Main(_testOutputHelper);
        _testOutputHelper.WriteLine("Something should have happened");
    }
}