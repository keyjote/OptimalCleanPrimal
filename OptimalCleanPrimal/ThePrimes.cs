namespace OptimalCleanPrimal;

public static class ThePrimes
{
    static ThePrimes()
    {
        Primes = new List<long>();
        // _hashPrimes = new HashSet<long>();
    }
    
    public static IList<long> Primes { get; }
    // private static HashSet<long> _hashPrimes { get; }

    public static void AddPrime(long val)
    {
        if (Primes.Contains(val))
        {
            return;
        }
        Primes.Add(val);
    }
}