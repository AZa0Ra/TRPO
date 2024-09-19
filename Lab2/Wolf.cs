namespace Lab2
{
    // Class which create event
    public class Wolf
    {
        private int age;

        // Event which start when age too low
        public event WolfAgeEventHandler AgeTooLow;

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 1)
                {
                    // Creating event
                    AgeTooLow(this, new WolfAgeEventArgs(value));
                }
                age = value;
            }
        }

    }
}

