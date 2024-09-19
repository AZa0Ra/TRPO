using System;

namespace Lab2
{
    // Class for args(data) of event
    public class WolfAgeEventArgs : EventArgs
    {
        public int Age { get; private set; }

        public WolfAgeEventArgs(int age)
        {
            Age = age;
        }
    }
}

