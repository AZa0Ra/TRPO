using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    // Delegate for event
    public delegate void WolfAgeEventHandler(object sender, WolfAgeEventArgs e);

    // Class for args(data) of event
    public class WolfAgeEventArgs : EventArgs
    {
        public int Age { get; private set; }

        public WolfAgeEventArgs(int age)
        {
            Age = age;
        }
    }

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
                    OnAgeTooLow(value);
                }
                age = value;
            }
        }

        // Method to call event
        protected virtual void OnAgeTooLow(int age)
        {
            if (AgeTooLow != null)
            {
                // Виклик делегата з передачею даних про подію
                AgeTooLow(this, new WolfAgeEventArgs(age));
            }
        }
    }

    // 4. Клас для обробки події
    public class WolfAgeObserver
    {
        public void OnAgeTooLow(object sender, WolfAgeEventArgs e)
        {
            Console.WriteLine($"Невiдповiднiсть умов для утримання таких молодих тварин! Вiк: {e.Age} мiсяцiв");
        }
    }

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

