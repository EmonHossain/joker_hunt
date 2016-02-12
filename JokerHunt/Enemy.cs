using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace JokerHunt
{
    class Enemy
    {
        public PictureBox carImage,batmanImage;
        Random rand;
        int moveRate = 0;
        Timer carTime;
        Batman batman;
        public Enemy(PictureBox carImage,int moveRate,Batman batman)
        {
            this.carImage = carImage;
            this.batman = batman;
            rand = new Random();
            carType();
            this.moveRate = moveRate;
            carTime = new Timer();
            carTime.Interval = 30;
            carTime.Enabled = true;
            carTime.Tick += carTime_Tick;
        }

        void carTime_Tick(object sender, EventArgs e)
        {
            carImage.Location = new Point(carImage.Location.X,carImage.Location.Y+moveRate);
            if(batman.batmanImage.Location.X+batman.batmanImage.Width>=carImage.Location.X && batman.batmanImage.Location.X<=carImage.Location.X+carImage.Width && carImage.Location.Y+carImage.Height>=batman.batmanImage.Location.Y+5)
            {
                if (!carImage.IsDisposed)
                {

                    carTime.Stop();
                    carImage.Dispose();
                    if (batman.life - 20 >= 0)
                    {
                        batman.lifeOfBatman.Value = batman.life - 20;
                        batman.life = batman.life - 20;
                    }
                    else
                    {
                        MessageBox.Show("Game Over");
                        carTime.Stop();
                    }
                    if (batman.life < 60)
                    {
                        batman.lifeOfBatman.ForeColor = Color.Red;
                    }
                }
                
            }
            if (carImage.Location.Y > 700)
            {
                carImage.Dispose();
                carTime.Stop();
            }
        }

        public void carType()
        {
            int x = rand.Next(1,3);
            switch(x){
                case 1:
                    carImage.BackgroundImage = Properties.Resources.Car;
                    carProperties();
                    break;
                case 2:
                    carImage.BackgroundImage = Properties.Resources.Car2;
                    carProperties();
                    break;
                case 3:
                    carImage.BackgroundImage = Properties.Resources.Car3;
                    carProperties();
                    break;
                default:
                    break;
            }
        }

        private void carProperties()
        {
            carImage.BackColor = Color.Transparent;
            carImage.BackgroundImageLayout = ImageLayout.Stretch;
            carImage.Size = new Size(65,145);
            carImage.Location = new Point(carImage.Location.X+rand.Next(150,565),rand.Next(-300,0));
        }

        public void startTime()
        {
            carTime.Start();
        }
    }
}
