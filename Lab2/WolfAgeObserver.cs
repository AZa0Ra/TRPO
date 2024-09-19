using System;

namespace Lab2
{
    // 4. Клас для обробки події
    public class WolfAgeObserver
    {
        public void OnAgeTooLow(object sender, WolfAgeEventArgs e)
        {
            Console.WriteLine($"Невiдповiднiсть умов для утримання таких молодих тварин! Вiк: {e.Age} мiсяцiв");
        }
    }
}

