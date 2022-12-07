namespace OptimalCleanPrimal.UsingEratosthenes;

public class Sieve
{
    public Thread thread;
    public int i;
    private int upperLimit;

    public Sieve(int upperLimit)
    {
        this.upperLimit = upperLimit;
    }

    public void set(int i)
    {
        this.i = i;
        thread = new Thread(this.primeGen);
        thread.Start();
    }

    public void primeGen()
    {
        for (int j = this.i * this.i; j <= this.upperLimit; j += i)
        {
            SieveController.primeArray[j] = false;
        }
    }
}