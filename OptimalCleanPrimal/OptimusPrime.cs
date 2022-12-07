namespace OptimalCleanPrimal;
public static class OptimusPrime
{
    public static bool IsPrime(long value)
    {
        if (ThePrimes.Primes.Any(prime => value > prime && (value % prime == 0)))
        {
            return false;
        }

        return true;
    }

    // private static long _maxValue = 0;
    // private static bool IsPrime(long value)
    // {
    //     if (value <= _maxValue)
    //     {
    //         return ThePrimes.Primes.All(p => value % p != 0);
    //     }
    //     // else - calculate from _maxValue + 1 until reaching val
    //     var isPrimeWithExistingResults = ThePrimes.Primes.All(p => value % p != 0);
    //     if (!isPrimeWithExistingResults)
    //     {
    //         return isPrimeWithExistingResults;
    //     }
    //     
    //     for (var from = _maxValue + 1; from <= value; from++)
    //     {
    //         
    //     }
    // }

    public static bool IsValuePrimeNumber(long value)
    {
        long counter = 2;
        while (counter <= value)
        {
            if (IsPrime(counter))
            {
                ThePrimes.AddPrime(counter);
            }

            counter++;
        }

        return ThePrimes.Primes.Contains(value);
    }

    public static void CalculateSomePrimes(long numOfPrimes)
    {
        long counter = 2;
        while (ThePrimes.Primes.Count < numOfPrimes)
        {
            if (IsPrime(counter))
            {
                ThePrimes.AddPrime(counter);
            }

            counter++;
        }
    }
}
