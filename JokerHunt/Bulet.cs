using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace JokerHunt
{
    class Bulet
    {
        public PictureBox bulet;
        private PictureBox batman;
        Timer buletTimer;
        Enemy[] enemy = new Enemy[1000];
        int carCounter;
        //int scoreValue = 0;
        Label scoreLabel;
        public Bulet(PictureBox bulet,PictureBox batman,Enemy[] enemy,int carCounter)
        {
            this.bulet = bulet;
            this.batman = batman;
            this.carCounter = carCounter;
            for (int i = 0; i < carCounter; i++)
            {
                this.enemy[i] = enemy[i];
            }
                //bulet = new PictureBox();

                buletTimer = new Timer();
        }

        public void buletCategory(int x)
        {
            switch (x)
            {
                case 2:
                    bulet.BackgroundImage = Properties.Resources.Two_Bulet;
                    bulet.BringToFront();
                    break;
                case 3:
                    bulet.BackgroundImage = Properties.Resources.Three_Bulet;
                    bulet.BringToFront();
                    break;
                default:
                    bulet.BackgroundImage = Properties.Resources.Single_Bulet;
                    buletViewModel(5, 10);
                    bulet.BringToFront();
                    buletTimer.Interval = 20;
                    buletTimer.Tick += buletTimer_Tick;
                    buletTimer.Enabled = true;
                    break;

            }
        }

        public void Start()
        {
            buletTimer.Interval = 10;
            buletTimer.Tick += buletTimer_Tick;
            buletTimer.Enabled = true;
            buletTimer.Start();
        }

        void buletTimer_Tick(object sender, EventArgs e)
        {
            bulet.Location = new Point(bulet.Location.X,bulet.Location.Y-7);
            new Point(bulet.Location.X, bulet.Location.Y - 7);
            for (int i = 0; i < carCounter;i++ )
            {
                if ((bulet.Location.X >= enemy[i].carImage.Location.X) && (bulet.Location.X <= enemy[i].carImage.Location.X + enemy[i].carImage.Width) && (bulet.Location.Y <= enemy[i].carImage.Location.Y + enemy[i].carImage.Height))
                {
                    enemy[i].carImage.Dispose();
                    bulet.Dispose();
                    //buletTimer.Stop();
                    Form1.scoreValue += 5; 
                    Form1.scoreLabel.Text = "Score: " + Convert.ToString(Form1.scoreValue);


                }
            }
            if (bulet.Location.Y < 20)
            {
                bulet.Dispose();
                buletTimer.Stop();
            }
        }

        public PictureBox getPictureBox()
        {
            return bulet;
        }

        private void buletViewModel(int hight,int width)
        {
            bulet.BackColor = Color.Transparent;
            bulet.BackgroundImageLayout = ImageLayout.Stretch;
            bulet.Size = new Size(hight, width);
            bulet.Location = new Point(batman.Location.X+42, 532);
        }

        public bool outOfRange()
        {
            if (bulet.Location.Y < 20)
                return true;
            else
                return false;
        }
    }
}
