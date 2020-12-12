
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceInvaders2020
{
    class SpaceshipTow : PictureBox
    {
        public int FireCooldown { get; set; } = 1000;
        public int HorVelocityE { get; set; } = 0;

        private bool canFire = true;
        private Game game = null;
        private Timer timerCooldown = null;
        private Timer timerMove = null;

        public SpaceshipTow(Game gameForm)
        {
            game = gameForm;
            InitializeSeconSpaceship();
            InitializeTimerMove();
        }

        private void InitializeSeconSpaceship()
        {
            this.Height = 100;
            this.Width = 60;
            this.BackColor = Color.Red;
        }

        public void SecondSpaceshipFire()
        {
            if (!canFire) return;

            Bullet bullet = new Bullet();
            bullet.Left = this.Left + 30;
            bullet.Top = this.Top - bullet.Height;
            game.Controls.Add(bullet);
            canFire = false;
            InitializeTimerCooldown();
        }

        private void InitializeTimerCooldown()
        {
            timerCooldown = new Timer();
            timerCooldown.Interval = FireCooldown;
            timerCooldown.Tick += TimerCooldown_Tick;
            timerCooldown.Start();
        }

        private void TimerCooldown_Tick(object sender, EventArgs e)
        {
            canFire = true;
            timerCooldown.Stop();
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
            this.Left += this.HorVelocityE;
            CheckSecondSpaceshipLocation();
        }

        private void CheckSecondSpaceshipLocation()
        {
            if (this.Left <= 0)
            {
                this.HorVelocityE = -this.HorVelocityE;
            }
            else if (this.Left + this.Width >= game.ClientRectangle.Width)
            {
                this.HorVelocityE = -this.HorVelocityE;
            }
        }
    }
}