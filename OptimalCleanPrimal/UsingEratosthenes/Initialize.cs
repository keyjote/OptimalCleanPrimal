namespace OptimalCleanPrimal.UsingEratosthenes;

public class Initialize
{
    public Thread thread;
    private int lowerLimit;
    private int upperLimit;

    public Initialize(int lowerLimit, int upperLimit) 
    {
        this.lowerLimit = lowerLimit;
        this.upperLimit = upperLimit;
        thread = new Thread(InitializeArray);
        thread.Priority = ThreadPriority.Highest;
        thread.Start();
    }

    private void InitializeArray() 
    {
        for (int i = this.lowerLimit; i <= this.upperLimit; i++) 
        {
            if (i % 2 == 0) 
            {
                SieveController.primeArray[i] = false;
            } 
            else 
            {
                SieveController.primeArray[i] = true;
            }
        }
    }
}