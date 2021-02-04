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
    class BackRound : PictureBox
    {
        Timer timerSpace = null;
        private int imageSpaceBackRoundCounter = 0;

        public BackRound()
        {
            InitializeSpace();
            SpaceBackRound();
        }

        private void InitializeSpace()
        {
            this.Width = 800;
            this.Height = 500;
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            string pictureName = "Space_000";
            this.Image = (Image)Resources.ResourceManager.GetObject(pictureName);
        }

        private void SpaceBackRound()
        {
            InitializeTimerSpaceBackRound();
        }

        private void InitializeTimerSpaceBackRound()
        {
            timerSpace = new Timer();
            timerSpace.Interval = 500;
            timerSpace.Tick += TimerSpaceBackRound_Tick;
            timerSpace.Start();
        }

        private void TimerSpaceBackRound_Tick(object sender, EventArgs e)
        {
            AnimateSpace();
        }

        private void AnimateSpace()
        {
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            string imageName = "Space_" + imageSpaceBackRoundCounter.ToString("000");
            this.Image = (Image)Resources.ResourceManager.GetObject(imageName);
            imageSpaceBackRoundCounter++;
            if (imageSpaceBackRoundCounter > 6) 
            {
                imageSpaceBackRoundCounter = 0;
            } 
        }
    }
}
