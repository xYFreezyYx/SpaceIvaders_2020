using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders2020
{
    public partial class Game : Form
    {
        private SpaceshipOne spaceship = null;
        private SpaceshipTow enemyship = null;

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            StartText();
        }

        private void InitializeGame()
        {
            this.KeyDown += Game_KeyDown;
            this.BackColor = Color.Black;
            AddFirstPlayerToGame();
            AddSecondPlayerToGame();
        }

        private void AddFirstPlayerToGame()
        {
            spaceship = new SpaceshipOne(this);
            spaceship.FireCooldown = 700;
            this.Controls.Add(spaceship);
            spaceship.Left = 293;
            spaceship.Top = ClientRectangle.Height - spaceship.Height;
            //Screen Middle is 353
        }

        private void AddSecondPlayerToGame()
        {
            enemyship = new SpaceshipTow(this);
            enemyship.FireCooldown = 700;
            this.Controls.Add(enemyship);
            enemyship.Left = 413;
            enemyship.Top = ClientRectangle.Height - enemyship.Height;
            //Screen Middle is 353
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                spaceship.FirstSpaceshipFire();
            }
            else if (e.KeyCode == Keys.A)
            {
                spaceship.HorVelocity = -2;
            }
            else if (e.KeyCode == Keys.D)
            {
                spaceship.HorVelocity = 2;
            }
            else if (e.KeyCode == Keys.S)
            {
                spaceship.HorVelocity = 0;
            }

            if (e.KeyCode == Keys.Up)
            {
                enemyship.SecondSpaceshipFire();
            }
            else if (e.KeyCode == Keys.Left)
            {
                enemyship.HorVelocityE = -2;
            }
            else if (e.KeyCode == Keys.Right)
            {
                enemyship.HorVelocityE = 2;
            }
            else if (e.KeyCode == Keys.Down)
            {
                enemyship.HorVelocityE = 0;
            }
        }

        private void StartText()
        {
            MessageBox.Show(GlueText("To Start Press", "'OK'", " "));
        }

        private string GlueText(string firstText, string secondText, string delimiter)
        {
            return firstText + delimiter + secondText;
        }
    }
}
