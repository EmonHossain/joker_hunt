using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Threading;

namespace JokerHunt
{
    public partial class Form1 : Form
    {
        Timer roadTimer,carTimer;
       // Thread roadThread;
        PictureBox roadImage;
        PictureBox roadImage2;
        Timer buletTimer;

        Bulet[] bulet;
        PictureBox batmanImage;
        PictureBox[] buletImage,enemyCar;
        ProgressBar lifeOfBatman;

        public static Label scoreLabel;
        

        Road road;
        Batman batman;
        Random rand;
        Enemy[] enemy;
        public static int scoreValue = 0;
        private int increment = 0;
        private int carCounter = 0;
        //private int buletNumber=0;
        public Form1()
        {
            InitializeComponent();

            roadImage = new PictureBox();
            roadImage2 = new PictureBox();
            batmanImage = new PictureBox();
            lifeOfBatman = new ProgressBar();
            buletImage = new PictureBox[100];
            bulet = new Bulet[100];
            enemyCar = new PictureBox[100];
            enemy = new Enemy[10000];
            rand = new Random();
            //Bulet Timer
            //buletTimer = new Timer();
            //buletTimer.Interval = 50;
            //buletTimer.Tick += buletTimer_Tick;
            //buletTimer.Enabled = true;

            scoreLabel = new Label();
            
            road = new Road(roadImage,roadImage2);
            Controls.Add(roadImage);
            Controls.Add(roadImage2);

          //  roadThread = new Thread(new ThreadStart(road.roadMove));
          //  roadThread.Start();

            roadTimer = new Timer();
            roadTimer.Interval = 1;
            roadTimer.Tick +=roadTimer_Tick;
            roadTimer.Enabled = true;
            roadTimer.Start();
            DoubleBuffered = true;

            //Car Timer
            carTimer = new Timer();
            carTimer.Interval = 3000;
            carTimer.Tick += carTimer_Tick;
            carTimer.Enabled = true;
            carTimer.Start();
            DoubleBuffered = true;

            // Bulet location trace timer


            //Batman car
            batman = new Batman(batmanImage, lifeOfBatman);
            Controls.Add(batmanImage);
            Controls.Add(lifeOfBatman);
            scoreLabel.Text = "Score: " + Convert.ToString(scoreValue);
            scoreLabel.Location = new Point(840,40);
            //scoreLabel.AutoSize = false;
            scoreLabel.Height = 42;
            scoreLabel.Width = 400;
            scoreLabel.Font = new Font("Tahoma",20);
            Controls.Add(scoreLabel);
            batmanImage.BringToFront();

            // Batman car move
            this.AutoSize = true;
            this.KeyPreview = true;
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(myPreview);
        }



        void carTimer_Tick(object sender, EventArgs e)
        {
            enemyCar[carCounter] = new PictureBox();
            enemy[carCounter] = new Enemy(enemyCar[carCounter],rand.Next(2,4),batman);

            Controls.Add(enemyCar[carCounter]);
            enemyCar[carCounter].BringToFront();
            DoubleBuffered = true;
            carCounter++;
        }

        

        

        private void roadTimer_Tick(object sender, EventArgs e)
        {
            road.roadMove();
        }

        private void myPreview(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode==Keys.Right)
            {
                batman.moveBatman(Direction.RIGHT);
            }
            else if (e.KeyCode == Keys.Left)
            {
                batman.moveBatman(Direction.LEFT);
            }

            if (e.KeyCode == Keys.ControlKey)
            {

                buletImage[increment] = new PictureBox();
                bulet[increment] = new Bulet(buletImage[increment], batmanImage,enemy,carCounter);
                bulet[increment].buletCategory(1);
                Controls.Add(bulet[increment].getPictureBox());
                DoubleBuffered = true;
                bulet[increment].Start();

                buletImage[increment].BringToFront();
                //buletTimer.Start();
                //DoubleBuffered = true;

                increment++;
                if (increment > 98)
                {
                    increment = 0;
                }
                
            }
        }

        void buletTimer_Tick(object sender, EventArgs e)
        {
            if (buletImage[increment].Location.Y < 50)
            {
                Controls.Remove(buletImage[increment]);
                buletImage[increment].Dispose();
                MessageBox.Show("Destroyed");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
