using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SpaceInvaders2020
{
    public partial class Game : Form
    {
        private SpaceshipOne spaceshipOne = null;
        private SpaceshipTow spaceshipTow = null;
        private List<Enemy> enemies = new List<Enemy>();
        private Timer mainTimer = null;
        private int killCounter = 0;
        private int lifeCounter = 0;

        public Game()
        {
            InitializeMainTimer();
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
            AddEnemyToGame(4, 13);
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

        private void AddEnemyToGame(int rows, int columns)
        {
            Enemy enemy = null;

            for (int rowCounter = 0; rowCounter < rows; rowCounter++) //variable = rowCounter = 1,2,3,4 rows
            {
                for (int colCounter = 0; colCounter < columns; colCounter++) //variable = colCounter = 1,2,3,4,5,6,7,8,9,10,11,12,13 colums
                {
                    enemy = new Enemy(this);
                    enemy.Left = 20 + 60 * colCounter; //Locatione from Left side in pixels
                    enemy.Top = 20 + 60 * rowCounter; //Locatione from Top side in pixels
                    this.Controls.Add(enemy);
                    enemies.Add(enemy);
                }
            }
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                spaceshipOne.Fire();
            }
            else if (e.KeyCode == Keys.A)
            {
                spaceshipOne.MoveLeft();
            }
            else if (e.KeyCode == Keys.D)
            {
                spaceshipOne.MoveRight();
            }
            else if (e.KeyCode == Keys.S)
            {
                spaceshipOne.StopMovement();
            }

            if (e.KeyCode == Keys.Up)
            {
                spaceshipTow.Fire();
            }
            else if (e.KeyCode == Keys.Left)
            {
                spaceshipTow.MoveLeft();
            }
            else if (e.KeyCode == Keys.Right)
            {
                spaceshipTow.MoveRight();
            }
            else if (e.KeyCode == Keys.Down)
            {
                spaceshipTow.StopMovement();
            }
        }

        private void InitializeMainTimer()
        {
            mainTimer = new Timer();
            mainTimer.Interval = 10;
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            CheckBulletEnemyCollision();        
        }

        private void CheckBulletEnemyCollision()
        {
            foreach (var bullet in spaceshipOne.bullets) //Dispose dosn't delite it it removes it but it is still there invisable (for now)
            {
                foreach (var enemy in enemies)
                {
                    if (bullet.Bounds.IntersectsWith(enemy.Bounds))
                    {
                        enemy.Explode();
                        this.Controls.Remove(bullet);
                        bullet.Dispose(); //Dispose dosn't delite it it removes it but it is still there invisable (for now)                                               
                        bullet.Top = 0; //temporary solution 
                        PlaySimpleSound();
                        killCounter++; //1 kill = 34 ponts (for now)
                        KillCounterLable.Text = killCounter.ToString();
                    }
                }
            }

            foreach (var bullet in spaceshipTow.bullets)
            {
                foreach (var enemy in enemies)
                {
                    if (bullet.Bounds.IntersectsWith(enemy.Bounds))
                    {
                        enemy.Explode();
                        this.Controls.Remove(bullet);
                        bullet.Dispose(); //Dispose dosn't delite it it removes it but it is still there invisable (for now)                                               
                        bullet.Top = 0; //temporary solution 
                        PlaySimpleSound();
                        killCounter++; //1 kill = 34 ponts (for now)
                        KillCounterLable.Text = killCounter.ToString();
                    }
                }
            }            
        }

        private void LifeCounter()
        {            
            lifeCounter--;
            LifeCounterLable.Text = lifeCounter.ToString();
        }

        private void StartText()
        {
            PlaySimpleSound();
            MessageBox.Show(GlueText("To Start Press", "'OK'", " "));
            PlaySimpleSound();
        }

        private string GlueText(string firstText, string secondText, string delimiter)
        {
            return firstText + delimiter + secondText;
        }

        private void PlaySimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();
        }
    }
}
