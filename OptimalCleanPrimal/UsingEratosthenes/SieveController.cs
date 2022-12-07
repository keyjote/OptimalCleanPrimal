using Xunit.Abstractions;

namespace OptimalCleanPrimal.UsingEratosthenes;

public class SieveController
{
    public static int upperLimit = 1000000000;
    public static bool[] primeArray = new bool[upperLimit];
    private static int highest = 0;
    private static int secondHighest = 0;

    public static void Main(ITestOutputHelper testOutputHelper)
    {
        DateTime startTime = DateTime.Now;

        var initial1 = new Initialize(0, 249999999);
        var initial2 = new Initialize(250000000, 499999999);
        var initial3 = new Initialize(500000000, 749999999);
        var initial4 = new Initialize(750000000, 999999999);

        initial1.thread.Join();
        initial2.thread.Join();
        initial3.thread.Join();
        initial4.thread.Join();

        int sqrtLimit = (int) Math.Sqrt(upperLimit);

        Sieve sieve1 = new Sieve(249999999);
        Sieve sieve2 = new Sieve(499999999);
        Sieve sieve3 = new Sieve(749999999);
        Sieve sieve4 = new Sieve(999999999);

        for (int i = 3; i < sqrtLimit; i += 2)
        {
            if (primeArray[i] == true)
            {
                int squareI = i * i;

                if (squareI <= 249999999)
                {
                    sieve1.set(i);
                    sieve2.set(i);
                    sieve3.set(i);
                    sieve4.set(i);
                    sieve1.thread.Join();
                    sieve2.thread.Join();
                    sieve3.thread.Join();
                    sieve4.thread.Join();
                }
                else if (squareI > 249999999 & squareI <= 499999999)
                {
                    sieve2.set(i);
                    sieve3.set(i);
                    sieve4.set(i);
                    sieve2.thread.Join();
                    sieve3.thread.Join();
                    sieve4.thread.Join();
                }
                else if (squareI > 499999999 & squareI <= 749999999)
                {
                    sieve3.set(i);
                    sieve4.set(i);
                    sieve3.thread.Join();
                    sieve4.thread.Join();
                }
                else if (squareI > 749999999 & squareI <= 999999999)
                {
                    sieve4.set(i);
                    sieve4.thread.Join();
                }
            }
        }

        int count = 0;
        primeArray[2] = true;
        for (int i = 2; i < upperLimit; i++)
        {
            if (primeArray[i])
            {
                // testOutputHelper.WriteLine($"Prime?: {i}");
                SetHighest(i);
                count++;
            }
        }

        testOutputHelper.WriteLine("Total: " + count);

        DateTime endTime = DateTime.Now;
        TimeSpan elapsedTime = endTime - startTime;
        testOutputHelper.WriteLine("Elapsed time: " + elapsedTime.Seconds);
        testOutputHelper.WriteLine($"Second highest value: {secondHighest}");
        testOutputHelper.WriteLine($"Highest value: {highest}");
    }

    private static void SetHighest(int val)
    {
        secondHighest = highest;
        highest = val;
    }
}