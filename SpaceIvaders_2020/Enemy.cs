
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
    class Enemy : PictureBox
    {
        private int HorVelocity { get; set; } = 5;

        private int imageExplosionCount = 0;

        private Timer timerEnemyMovement = null;
        private Timer timerAnimateExplosion = null;
        private Game game = null;

        public Enemy(Game gameForm)
        {
            game = gameForm;
            InitializeEnemy();
            //InitializeEnemyMovement();
        }

        private void InitializeEnemy()
        {
            this.Width = 40;
            this.Height = 40;
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            string pictureName = "enemy";
            this.Image = (Image)Resources.ResourceManager.GetObject(pictureName);
        }

        public void Explode()
        {
            this.BackColor = Color.Transparent;
            InitializeTimerAnimateExpolosion();  
        }

        private void InitializeTimerAnimateExpolosion()
        {
            timerAnimateExplosion = new Timer();
            timerAnimateExplosion.Interval = 16;
            timerAnimateExplosion.Tick += TimerAnimateExplosion_Tick;
            timerAnimateExplosion.Start();
        }

        private void TimerAnimateExplosion_Tick(object sender, EventArgs e)
        {
            AnimateExplosion();
        }

        private void AnimateExplosion()
        {
            string imageName = "exp" + imageExplosionCount.ToString("000");
            this.Image = (Image)Resources.ResourceManager.GetObject(imageName);
            imageExplosionCount += 1;
            if (imageExplosionCount > 22)
            {
                imageExplosionCount = 0;
                timerAnimateExplosion.Stop();
                timerAnimateExplosion.Dispose();
                this.Top = -1000000000;
                game.Controls.Remove(this);
                this.Dispose();
            }
        }

        private void InitializeEnemyMovement()
        {
            timerEnemyMovement = new Timer();
            timerEnemyMovement.Interval = 10;
            timerEnemyMovement.Tick += EnemyMovement_Tick;
            timerEnemyMovement.Start();
        }

        private void EnemyMovement_Tick(object sender, EventArgs e)
        {
            this.Left += this.HorVelocity;
            CheckEnemyLocation();
        }

        private void CheckEnemyLocation()
        {
            if (this.Left <= 0)
            {
                this.HorVelocity = -this.HorVelocity;
            }
            else if (this.Left + this.Width >= game.ClientRectangle.Width)
            {
                this.HorVelocity = -this.HorVelocity;
            }

            if (this.Right <= 0)
            {
                this.HorVelocity = -this.HorVelocity;
            }
            else if (this.Right + this.Width * 2 >= game.ClientRectangle.Width)
            {
                this.HorVelocity = -this.HorVelocity;
            }
        }
    }
}