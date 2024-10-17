namespace Module1
{
    public delegate void SeatsSoldOutEventHandler(object sender, EventArgs e);
    public class CinemaHall
    {
        public event SeatsSoldOutEventHandler SeatsSoldOut;

        public int TotalSeats { get; set; }
        public int SoldTickets { get; set; }

        public CinemaHall(int totalSeats)
        {
            this.TotalSeats = totalSeats;
            this.SoldTickets = 0;
        }

        public void BuyTicket()
        {
            if (SoldTickets < TotalSeats)
            {
                SoldTickets++;
                if (SoldTickets == TotalSeats)
                {
                    OnSeatsSoldOut();
                }
            }
        }

        protected virtual void OnSeatsSoldOut()
        {
            SeatsSoldOut?.Invoke(this, EventArgs.Empty);
        }
    }

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}