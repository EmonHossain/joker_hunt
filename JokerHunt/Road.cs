using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
//using System.Threading;

namespace JokerHunt
{
    class Road
    {
        PictureBox roadImage,roadImage2;

        public Road(PictureBox roadImage,PictureBox roadImage2)
        {
            this.roadImage = roadImage;
            this.roadImage2 = roadImage2;
            roadImage2.Location=new Point(roadImage.Location.X,roadImage.Location.Y-745);

            //roadImage2.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //Image im = roadImage2.Image;
            //im.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //roadImage2.Image = im;

            //Road
            roadImage.Size = new Size(800, 750);
            roadImage.BackgroundImage = Properties.Resources.Road_11;
            roadImage.BackgroundImageLayout = ImageLayout.Stretch;
            
            roadImage2.Size = new Size(800, 750);
            roadImage2.BackgroundImage = Properties.Resources.Road_21;
            roadImage2.BackgroundImageLayout = ImageLayout.Stretch;
            

        }

        public void roadMove()
        {
           // while(true)
            {
                //Thread.Sleep(5);
                roadImage.Location = new Point(roadImage.Location.X,roadImage.Location.Y+5);
                roadImage2.Location = new Point(roadImage2.Location.X, roadImage2.Location.Y + 5);
                //MessageBox.Show("etew");
                if(roadImage.Location.Y>=745)
                {
                    roadImage.Location = new Point(roadImage.Location.X,roadImage.Location.Y*-1);
                }
                else if(roadImage2.Location.Y>=745)
                {
                    roadImage2.Location = new Point(roadImage2.Location.X, roadImage2.Location.Y * -1);
                }
            }
        }


    }
}
