namespace Module1
{
    public partial class Form1 : Form
    {
        private CinemaHall cinemaHall;
        private PictureBox[] pictureBoxes;
        private Button buyTicketButton;
        public Form1()
        {
            InitializeComponent();
            cinemaHall = new CinemaHall(10); 

            cinemaHall.SeatsSoldOut += CinemaHall_SeatsSoldOut;

            pictureBoxes = new PictureBox[10];
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                pictureBoxes[i] = new PictureBox
                {
                    Size = new Size(40, 40),
                    Location = new Point(10 + (i * 50), 10), 
                    BackColor = Color.LightGray
                };
                Controls.Add(pictureBoxes[i]);
            }

            buyTicketButton = new Button
            {
                Text = "Купити квиток",
                Location = new Point(10, 70)
            };
            buyTicketButton.Click += BuyTicketButton_Click;
            Controls.Add(buyTicketButton);
        }


        private void BuyTicketButton_Click(object sender, EventArgs e)
        {
            cinemaHall.BuyTicket();
            UpdateSeatColors();
        }

        private void UpdateSeatColors()
        {
            for (int i = 0; i < cinemaHall.SoldTickets; i++)
            {
                pictureBoxes[i].BackColor = Color.Red; 
            }
        }

        private void CinemaHall_SeatsSoldOut(object sender, EventArgs e)
        {
            MessageBox.Show("Усі місця продано! Починаємо перегляд кінострічки!");
        }
    }
}
