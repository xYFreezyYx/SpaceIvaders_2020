﻿//I have tow spaceship classes for easiyer spaceship manegment. When I upadate the code I can test if the code works on one spaceship. And if that code works i can apply it to the oather spaceship. If something goes wrong to a spaceship its easiyer to find it. I'ts easiyer to owersee the eache spaceship too.
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

        public List<Bullet> bullets = new List<Bullet>();

        private bool canFire = true;
        private Game game = null;
        private Timer timerCooldown = null;
        private Timer timerMove = null;

        public SpaceshipOne(Game gameForm)
        {
            game = gameForm;
            InitializeSpaceshiOne();
            InitializeTimerMove();
        }

        private void InitializeSpaceshiOne()
        {
            this.Height = 100;
            this.Width = 60;
            this.BackColor = Color.RoyalBlue;
        }

        public void Fire()
        {
            if (!canFire) return;

            Bullet bullet = new Bullet();
            bullet.Left = this.Left + 30;
            bullet.Top = this.Top - bullet.Height;
            game.Controls.Add(bullet);
            bullets.Add(bullet);
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
            CheckSpaceshipOneLocation();
        }

        private void CheckSpaceshipOneLocation()
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

        public void MoveRight()
        {
            this.HorVelocity = 2;
        }

        public void MoveLeft()
        {

            this.HorVelocity = -2;
        }

        public void StopMovement()
        {
            this.HorVelocity = 0;
        }
    }
}
