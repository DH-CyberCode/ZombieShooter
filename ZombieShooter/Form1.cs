using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieShooter
{
    public partial class GameWindow : Form
    {

        bool goLeft, goRight, goUp, goDown, gameOver;
        string facing = "up";
        int playerHealth = 100;
        int speed = 10;
        int ammo = 20;
        int zombieSpeed = 3;
        int score = 0;
        Random randNum = new Random();
        List<PictureBox> zombieList = new List<PictureBox>();

        public object Propeties { get; private set; }

        public GameWindow()
        {
            InitializeComponent();
            GameOverBanner.Visible = false;
            RestartGame();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {

            if (playerHealth > 1)
            {
                healthBar.Value = playerHealth;
            }
            else
            {

                GameOverBanner.Visible = true;

                gameOver = true;
                player.Image = Properties.Resources.dead;
                GameTimer.Stop();
            }

            txtAmmo.Text = "Ammo: " + ammo;
            txtScore.Text = "Score: " + score;

            if (goLeft == true && player.Left > 0)
            {
                player.Left -= speed;
            }

            if (goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }

            if (goUp == true && player.Top > 40)
            {
                player.Top -= speed;
            }

            if (goDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += speed;
            }

            foreach (Control item in this.Controls)
            {
                if (item is PictureBox && (string)item.Tag == "ammoDrop")
                {
                    if (player.Bounds.IntersectsWith(item.Bounds))
                    {

                        this.Controls.Remove(item);
                        ((PictureBox)item).Dispose();
                        ammo += 5;

                    }

                }


                if (item is PictureBox && (string)item.Tag == "zombie")
                {

                    if (player.Bounds.IntersectsWith(item.Bounds))
                    {
                        playerHealth -= 1;
                        //if(playerHealth > 0)
                        //{
                        //    player.Image = Properties.Resources.dead;
                        //    gameOver = true;
                        //    RestartGame();
                        //}
                    }

                    if (item.Left > player.Left)
                    {
                        item.Left -= zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zleft;
                    }

                    if (item.Left < player.Left)
                    {
                        item.Left += zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zright;
                    }

                    if (item.Top > player.Top)
                    {
                        item.Top -= zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zup;
                    }


                    if (item.Top < player.Top)
                    {
                        item.Top += zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zdown;
                    }



                }

                foreach (Control pbBullet in this.Controls)
                {
                    if (pbBullet is PictureBox && (string)pbBullet.Tag == "bullet" && item is PictureBox && (string)item.Tag == "zombie")
                    {
                        if (pbBullet.Bounds.IntersectsWith(item.Bounds))
                        {
                            score++;
                            this.Controls.Remove(pbBullet);
                            pbBullet.Dispose();
                            this.Controls.Remove(item);
                            item.Dispose();
                            zombieList.Remove((PictureBox)item);
                            ((PictureBox)item).Dispose();
                            MakeZobie();
                        }
                    }
                }


            }

        }// END OF MAINTIMER

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver == false)
            {


                if (e.KeyCode == Keys.Left)
                {
                    goLeft = true;
                    facing = "left";
                    player.Image = Properties.Resources.left;

                }

                if (e.KeyCode == Keys.Right)
                {
                    goRight = true;
                    facing = "right";
                    player.Image = Properties.Resources.right;

                }

                if (e.KeyCode == Keys.Up)
                {
                    goUp = true;
                    facing = "up";
                    player.Image = Properties.Resources.up;

                }

                if (e.KeyCode == Keys.Down)
                {
                    goDown = true;
                    facing = "down";
                    player.Image = Properties.Resources.down;

                }


            }
            else
            {
                if (e.KeyCode == Keys.Return)
                {
                    gameOver = false;
                    RestartGame();
                }
            }

        }//END OF KeyIsDown

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;


            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;


            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;


            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;

            }

            if (gameOver == false)
            {


                if (e.KeyCode == Keys.Space && ammo > 0)
                {
                    ammo--;
                    ShootBullet(facing);

                    if (ammo == 5 || ammo == 1)
                    {
                        DropAmmo();
                    }

                }
            }


        }//END OF KeyisUp



        private void ShootBullet(string direction)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.direction = direction;
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 2);
            shootBullet.MakeBullet(this);
        }

        private void MakeZobie()
        {

            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;
            zombie.Left = randNum.Next(0, 900);
            zombie.Top = randNum.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombieList.Add(zombie);
            this.Controls.Add(zombie);
            player.BringToFront();
        }

        private void DropAmmo()
        {
            PictureBox ammoDrop = new PictureBox();
            ammoDrop.Image = Properties.Resources.ammo_Image;
            ammoDrop.SizeMode = PictureBoxSizeMode.AutoSize;
            ammoDrop.Left = randNum.Next(10, this.ClientSize.Width - ammoDrop.Width);
            ammoDrop.Top = randNum.Next(40, ClientSize.Height - ammoDrop.Height);
            ammoDrop.Tag = "ammoDrop";
            this.Controls.Add(ammoDrop);

            ammoDrop.BringToFront();
            player.BringToFront();
        }

        private void RestartGame()
        {

            player.Image = Properties.Resources.up;
            GameOverBanner.Visible = false;

            foreach (PictureBox picbox in zombieList)
            {
                this.Controls.Remove(picbox);
            }

            zombieList.Clear();

            for (int i = 0; i < 3; i++)
            {
                MakeZobie();
            }

            goDown = false;
            goUp = false;
            goLeft = false;
            goRight = false;

            playerHealth = 100;
            score = 0;
            ammo = 25;
            GameTimer.Start();
        }


    }
}
