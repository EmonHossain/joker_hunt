using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace JokerHunt
{
    class Batman
    {
        public PictureBox batmanImage;
        private PictureBox[] buletImage;
        public ProgressBar lifeOfBatman;
        private int moveRate=5;
        public int life = 100, increment=0;
        int score=0;
        Bulet[] bulet;
        Rectangle rect;

        public Batman(PictureBox batmanImage,ProgressBar lifeOfBatman)
        {
            rect = new Rectangle(140, 0, 440, 700);

            this.batmanImage = batmanImage;
            this.lifeOfBatman = lifeOfBatman;
            //batman car
            batmanImage.BackColor = Color.Transparent;
            batmanImage.BackgroundImage = Properties.Resources.BatmanCar1;
            
            batmanImage.BackgroundImageLayout = ImageLayout.Stretch;
            batmanImage.Size = new Size(84, 145);
            batmanImage.Location = new Point(300, 530);
            //batman life progressbar
            lifeOfBatman.Value = life;
            lifeOfBatman.Location = new Point(840,100);
            lifeOfBatman.Width = 300;

            buletImage = new PictureBox[100];
            bulet = new Bulet[100];
        
        }

        public void moveBatman(Direction direction)
        {
            if(direction==Direction.RIGHT)
            {
                if (rect.Right >= batmanImage.Location.X)
                    batmanImage.Location = new Point(batmanImage.Location.X + moveRate, batmanImage.Location.Y);
            }
            else if(direction==Direction.LEFT)
            {
                if (rect.Left <= batmanImage.Location.X)
                    batmanImage.Location = new Point(batmanImage.Location.X - moveRate, batmanImage.Location.Y);
            }
        }

        public PictureBox getBuletPictureBox()
        {
            return bulet[increment].getPictureBox();
        }

        public void shotRival(PictureBox buletImage)
        {
            //buletImage = new PictureBox();
            //bulet[increment] = new Bulet(buletImage, batmanImage);
            //bulet[increment].buletCategory(1);

            //bulet[increment].Start();

            //buletImage.BringToFront();
            ////buletTimer.Start();
            ////DoubleBuffered = true;

            //increment++;
            //if (increment > 98)
            //{
            //    increment = 0;
            //}
        }

        public void collectEnergy()
        {

        }

        public void collctWeapon()
        {
 
        }




    }
}
