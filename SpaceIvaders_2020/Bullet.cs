
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SpaceIvaders_2020.Properties;

namespace SpaceInvaders2020
{
    class Bullet : PictureBox
    {
        private int step = 2;
        private Timer timerMove = null;

        public Bullet()
        {
            InitializeBullet();
            InitializeTimerMove();
        }
        public void InitializeBullet()
        {
            this.Height = 20;
            this.Width = 6;
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            string pictureName = "Bullet";
            this.Image = (Image)Resources.ResourceManager.GetObject(pictureName);
        }

        private void InitializeTimerMove()
        {
            timerMove = new Timer();
            timerMove.Interval = 10;
            timerMove.Tick += TimerMove_Tick;
            timerMove.Start();
        }

        private void TimerMove_Tick(object sender, EventArgs e)
        {
            this.Top -= step;
            DisposeIfNotVisible();
        }

        private void DisposeIfNotVisible()
        {
            if (this.Top + this.Height < 0)
            {
                this.Dispose();
            }
        }
    }
}