
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceInvaders2020
{
    class Enemy : PictureBox
    {

        public Enemy()
        {
            Initializeenemy();
        }

        private void Initializeenemy()
        {
            this.BackColor = Color.Red;
            this.Width = 40;
            this.Height = 40;
        }
    }
}