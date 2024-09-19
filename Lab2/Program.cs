namespace Lab2
{
    // Delegate for event
    public delegate void WolfAgeEventHandler(object sender, WolfAgeEventArgs e);

    class Program
    {
        static void Main(string[] args)
        {
            Wolf wolf = new Wolf();
            WolfAgeObserver observer = new WolfAgeObserver();

            // Adding event (Subscribe)
            wolf.AgeTooLow += observer.OnAgeTooLow;

            // Changing age to activate event
            wolf.Age = 2;
            wolf.Age = 0;
            wolf.Age = 1;
            wolf.Age = 0;

        }
    }
}

