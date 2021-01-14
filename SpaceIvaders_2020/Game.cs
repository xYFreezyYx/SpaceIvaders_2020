using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using SpaceIvaders_2020.Properties;

namespace SpaceInvaders2020
{
    public partial class Game : Form
    {
        private SpaceshipOne spaceshipOne = null;
        private SpaceshipTow spaceshipTow = null;
        private List<Enemy> enemies = new List<Enemy>();
        Label kills = new Label();
        Label life = new Label();
        private Timer mainTimer = null;
        private int killCounter = 0;
        private int lifeCounter = 0;

        public Game()
        {
            StartText();
            InitializeMainTimer();
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            this.Width = 700;
            this.Height = 500;
            this.KeyDown += Game_KeyDown;
            this.BackColor = Color.Black;
            AddSpaceshipOneToGame();
            AddSpaceshipTowToGame();
            LifeLable();
            KillCounterLable();
            LifeCounterLable();
            KillLable();
            AddEnemyToGame(4, 13);
        }

        private void AddSpaceshipOneToGame()
        {
            spaceshipOne = new SpaceshipOne(this);
            spaceshipOne.FireCooldown = 700;
            this.Controls.Add(spaceshipOne);
            spaceshipOne.Left = 293;
            spaceshipOne.Top = ClientRectangle.Height - spaceshipOne.Height; 
        }

        private void AddSpaceshipTowToGame()
        {
            spaceshipTow = new SpaceshipTow(this);
            spaceshipTow.FireCooldown = 700;
            this.Controls.Add(spaceshipTow);
            spaceshipTow.Left = 413;
            spaceshipTow.Top = ClientRectangle.Height - spaceshipTow.Height;
        }

        private void AddEnemyToGame(int rows, int columns)
        {
            Enemy enemy = null;

            for (int rowCounter = 0; rowCounter < rows; rowCounter++)
            {
                for (int colCounter = 0; colCounter < columns; colCounter++)
                {
                    enemy = new Enemy(this);
                    enemy.Left = 20 + 60 * colCounter;
                    enemy.Top = 20 + 60 * rowCounter;
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
            foreach (var bullet in spaceshipOne.bullets)
            {
                foreach (Control enemy in this.Controls)
                {
                    if (enemy is PictureBox && (string)enemy.Tag == "Enemy")
                    {
                        if (bullet.Bounds.IntersectsWith(enemy.Bounds))
                        {
                            enemy.Dispose();
                            this.Controls.Remove(bullet);
                            bullet.Dispose(); //Deletes the bullet on colisione with enemy                                                
                            bullet.Top = 0; //temporary solution 
                            playHand();
                            KillCounter();
                        }
                    }
                }
            }

            foreach (var bullet in spaceshipTow.bullets)
            {
                foreach (Control enemy in this.Controls)
                {
                    if (enemy is PictureBox && (string)enemy.Tag == "Enemy")
                    {
                        if (bullet.Bounds.IntersectsWith(enemy.Bounds))
                        {
                            enemy.Dispose();
                            this.Controls.Remove(bullet);
                            bullet.Dispose(); //Deletes the bullet on colisione with enemy                                                
                            bullet.Top = 0; //temporary solution 
                            playHand();
                            KillCounter();
                        }
                    }
                }
            }
        }

        private void KillCounter()
        {
            killCounter++;
            kills.Text = killCounter.ToString();
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

        private void PlaySimpleSound() //this is for StartText()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();
        }

        private void playHand() //This is for CheckBulletEnemyCollision()
        {
            SystemSounds.Hand.Play();
        }

        private void playExclamation() //This is for LifeCounter() (when I make it)
        {
            SystemSounds.Exclamation.Play();
        }

        private void LifeLable()
        {
            Label Life = null;
            Life = new Label();
            Life.Text = "Life";
            Life.BackColor = Color.Black;
            Life.ForeColor = Color.White;
            Life.BorderStyle = BorderStyle.None;
            Life.TextAlign = ContentAlignment.MiddleCenter;
            Life.Font = new Font("Papyrus", 20);
            Life.Width = 85;
            Life.Height = 50;
            Life.Location = new Point(775, 20);
            this.Controls.Add(Life);
        }

        private void LifeCounterLable()
        {
            life = new Label();
            life.Text = "3";
            life.BackColor = Color.Black;
            life.ForeColor = Color.White;
            life.BorderStyle = BorderStyle.None;
            life.TextAlign = ContentAlignment.MiddleCenter;
            life.Font = new Font("Papyrus", 30);
            life.Width = 85;
            life.Height = 50;
            life.Location = new Point(775, 60);
            this.Controls.Add(life);
        }

        private void LifeCounter() //Not working (disabled it for now) (this is for when I make so enemy shoot at rondam at the ship from a rondom enemy)
        {
            lifeCounter--;
            if (lifeCounter < 3) lifeCounter = 0;
            life.Text = lifeCounter.ToString();
            playExclamation();
        }

        private void KillLable()
        {
            Label Kills = null;
            Kills = new Label();
            Kills.Text = "Kills";
            Kills.BackColor = Color.Black;
            Kills.ForeColor = Color.White;
            Kills.BorderStyle = BorderStyle.None;
            Kills.TextAlign = ContentAlignment.MiddleCenter;
            Kills.Font = new Font("Papyrus", 20);
            Kills.Width = 85;
            Kills.Height = 50;
            Kills.Location = new Point(775, 115);
            this.Controls.Add(Kills);
        }

        private void KillCounterLable()
        {            
            kills = new Label();
            kills.Text = "0";
            kills.BackColor = Color.Black;
            kills.ForeColor = Color.White;
            kills.BorderStyle = BorderStyle.None;
            kills.TextAlign = ContentAlignment.MiddleCenter;
            kills.Font = new Font("Papyrus", 30);
            kills.Width = 85;
            kills.Height = 50;
            kills.Location = new Point(775, 155);
            this.Controls.Add(kills);
        }
    }
}
