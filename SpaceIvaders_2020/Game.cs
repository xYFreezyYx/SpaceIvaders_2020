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
        private SpaceshipOne spaceshipOne = null;
        private SpaceshipTow spaceshipTow = null;

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
            AddSpaceshipOneToGame();
            AddSpaceshipTowToGame();
        }

        private void AddSpaceshipOneToGame()
        {
            spaceshipOne = new SpaceshipOne(this);
            spaceshipOne.FireCooldown = 700;
            this.Controls.Add(spaceshipOne);
            spaceshipOne.Left = 293;
            spaceshipOne.Top = ClientRectangle.Height - spaceshipOne.Height;
            //Screen Middle is 353
        }

        private void AddSpaceshipTowToGame()
        {
            spaceshipTow = new SpaceshipTow(this);
            spaceshipTow.FireCooldown = 700;
            this.Controls.Add(spaceshipTow);
            spaceshipTow.Left = 413;
            spaceshipTow.Top = ClientRectangle.Height - spaceshipTow.Height;
            //Screen Middle is 353
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                spaceshipOne.Fire();
            }
            else if (e.KeyCode == Keys.A)
            {
                spaceshipOne.HorVelocity = -2;
            }
            else if (e.KeyCode == Keys.D)
            {
                spaceshipOne.HorVelocity = 2;
            }
            else if (e.KeyCode == Keys.S)
            {
                spaceshipOne.HorVelocity = 0;
            }

            if (e.KeyCode == Keys.Up)
            {
                spaceshipTow.Fire();
            }
            else if (e.KeyCode == Keys.Left)
            {
                spaceshipTow.HorVelocityE = -2;
            }
            else if (e.KeyCode == Keys.Right)
            {
                spaceshipTow.HorVelocityE = 2;
            }
            else if (e.KeyCode == Keys.Down)
            {
                spaceshipTow.HorVelocityE = 0;
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
