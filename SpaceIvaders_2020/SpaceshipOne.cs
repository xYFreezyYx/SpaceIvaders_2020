﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceInvaders2020
{
    class SpaceshipOne : PictureBox
    {
        public int FireCooldown { get; set; } = 1000;

        public int HorVelocity { get; set; } = 0;

        private bool canFire = true;
        private Game game = null;
        private Timer timerCooldown = null;
        private Timer timerMove = null;
        public SpaceshipOne(Game gameForm)
        {
            game = gameForm;
            InitializeFirstspaceshi();
            InitializeTimerMove();
        }

        private void InitializeFirstspaceshi()
        {
            this.Height = 100;
            this.Width = 60;
            this.BackColor = Color.SteelBlue;
        }

        public void FirstSpaceshipFire()
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
            this.Left += this.HorVelocity;
            CheckFirstSpaceshipLocation();
        }

        private void CheckFirstSpaceshipLocation()
        {
            if (this.Left <= 0)
            {
                this.HorVelocity = -this.HorVelocity;
            }
            else if (this.Left + this.Width >= game.ClientRectangle.Width)
            {
                this.HorVelocity = -this.HorVelocity;
            }
        }
    }
}
