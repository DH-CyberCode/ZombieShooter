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

        bool goLeft, goRight, goUp, goDown, gamePaused, gameOver;
        bool grenadeAvailable = false;
        string facing = "up";
        int playerHealth = 100;
        int speed = 10;
        int ammo = 20;
        int zombieSpeed = 3;
        int score = 0;
        Random randNum = new Random();
        int counter = 100;
        List<PictureBox> zombieList = new List<PictureBox>();
        List<PictureBox> ammoList = new List<PictureBox>();
        List<PictureBox> firstAidList = new List<PictureBox>();
        List<PictureBox> gernadeList = new List<PictureBox>();
        


        public object Propeties { get; private set; }

        public GameWindow()
        {
            InitializeComponent();
            GameOverBanner.Visible = false;
            RestartGame();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            //----  KEEP TRACK OF SCORE & AMMO
            txtAmmo.Text = "Ammo: " + ammo;
            txtScore.Text = "Score: " + score;

            //---- RANDOM GRENADE DROPS
            int rando = randNum.Next(counter, counter+200);
            counter++;
            if(counter == rando && grenadeAvailable == false)
            {
                grenadeAvailable = true;
                DropGrenade();

            }

            
            //==========================================================]
            //=========     GAME OVER   ================================]
            //==========================================================]

            if (playerHealth > 1)
            {
                healthBar.Value = playerHealth;
            }
            else
            {
                GameOverBanner.BringToFront();
                GameOverBanner.Visible = true;

                gameOver = true;
                player.Image = Properties.Resources.dead;
                GameTimer.Stop();
            }

            
            //==========================================================]
            //=========     PLAYER MOVES    ============================]
            //==========================================================]
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

                //==========================================================]
                //=========     AMMO PICKUP     ============================]
                //==========================================================]
                if (item is PictureBox && (string)item.Tag == "ammoDrop")
                {
                    if (player.Bounds.IntersectsWith(item.Bounds))
                    {
                        
                        this.Controls.Remove(item);
                        item.Dispose();
                        //((PictureBox)item).Dispose();
                        ammo += 5;

                    }

                }

                //==========================================================]
                //=========     GRENADE PICKUP    ==========================]
                //==========================================================]
                if (item is PictureBox && (string)item.Tag == "grenadeDrop")
                {
                    if (player.Bounds.IntersectsWith(item.Bounds))
                    {

                        this.Controls.Remove(item);
                        item.Dispose();
                        zombieSpeed = 0;
                        foreach (PictureBox z in zombieList)
                        {
                            z.BackgroundImage = Properties.Resources.Explosion;
                            z.BackgroundImageLayout = ImageLayout.Center;


                        }
                        grenadeAvailable = false;
                        //        GameTimer.Stop();
                        //        foreach (PictureBox z in zombieList)
                        //        {

                        //            this.Controls.Remove((PictureBox)z);
                        //            ((PictureBox)z).Dispose();


                        //        }
                        //        zombieList.Clear();
                        //        for(int i =0; i<=3; i++)
                        //        {
                        //            MakeZobie();
                        //        }

                        //        GameTimer.Start();

                    }

                }

                    //==========================================================]
                    //=========     ZOMBIE CHASE    ============================]
                    //==========================================================]
                    if (item is PictureBox && (string)item.Tag == "zombie")
                {

                    if (player.Bounds.IntersectsWith(item.Bounds))
                    {
                        playerHealth -= 1;
             
                    }
                    //----  ZOMBIE IS LOWER AND RIGHT OF PLAYER
                    if (item.Top > player.Top && item.Left > player.Left)
                    {
                        
                        ((PictureBox)item).Image = Properties.Resources.zUpperLeft;
                    }
                    
                    //----  ZOMBIE IS LOWER AND LEFT OF PLAYER
                    if (item.Top > player.Top && item.Left < player.Left)
                    {
                        
                        ((PictureBox)item).Image = Properties.Resources.zUpperRight;
                    }
                    
                    //----  ZOMBIE IS HIGHER AND LEFT OF PLAYER
                    if (item.Top < player.Top && item.Left < player.Left)
                    {
                        
                        ((PictureBox)item).Image = Properties.Resources.zLowerRight;
                    }
                    
                    //----  ZOMBIE IS HIGHER AND RIGHT OF PLAYER
                    if (item.Top < player.Top && item.Left > player.Left)
                    {
                        
                        ((PictureBox)item).Image = Properties.Resources.zLowerLeft;
                    }

                    //----  MOVE ZOMBIE TOWARDS PLAYER
                    if (item.Top > player.Top)
                    {
                        item.Top -= zombieSpeed;
                    }

                    if (item.Top < player.Top)
                    {
                        item.Top += zombieSpeed;
                    }

                    if (item.Left > player.Left)
                    {
                        item.Left -= zombieSpeed;
                    }

                    if (item.Left < player.Left)
                    {
                        item.Left += zombieSpeed;
                    }



                }

                //==========================================================]
                //=========     SHOOT ZOMBIE    ============================]
                //==========================================================]
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
                if(e.KeyCode == Keys.F)
                {
                    //Panel boom = new Panel();
                    //boom.Dock = DockStyle.Fill;
                    //boom.BackColor = Color.White;
                    //boom.BackgroundImage = Properties.Resources.Explosion;
                    //boom.BackgroundImageLayout = ImageLayout.Center;
                    //boom.Tag = "boom";
                    //this.Controls.Add(boom);
                    //boom.BringToFront();
                    foreach(PictureBox z in zombieList)
                    {
                        z.BackgroundImage = Properties.Resources.Explosion;
                        z.BackgroundImageLayout = ImageLayout.Center;
                    }

                }

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
                //PAUSE GAME
                if(e.KeyCode == Keys.Escape)
                {
                    if (gamePaused)
                    {
                        //RESUME
                        gamePaused = false;
                        GameTimer.Start();
                    }
                    else
                    {
                        //PAUSE
                        gamePaused = true;
                        GameTimer.Stop();
                    }
                    
                }


            }
            else
            {

                

                //RESTART GAME
                if (e.KeyCode == Keys.Return)
                {
                    gameOver = false;
                    RestartGame();
                }
            }

        }//END OF KeyIsDown

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode == Keys.F)
            {
                //foreach(Control boom in Controls)
                //{
                //   if((string)boom.Tag == "boom")
                //    {
                //        Controls.Remove(boom);
                //        boom.Dispose();
                //    }
                    
                //}
                foreach(PictureBox z in zombieList)
                {
                    z.BackgroundImage = null;

                }

            }
            
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
            int posLeft = randNum.Next(0, 900);
            int posTop = randNum.Next(0, 800);
            Zombie zombie = new Zombie(posLeft,posTop);
            //PictureBox zombie = new PictureBox();
            //zombie.Tag = "zombie";
            //zombie.Image = Properties.Resources.zdown;
            //zombie.Left = randNum.Next(0, 900);
            //zombie.Top = randNum.Next(0, 800);
            //zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombieList.Add(zombie);
            this.Controls.Add(zombie);
            zombie.BringToFront();
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
            ammoList.Add(ammoDrop);
            this.Controls.Add(ammoDrop);

            ammoDrop.BringToFront();
            player.BringToFront();
        }
        
        private void DropGrenade()
        {
            PictureBox grenadeDrop = new PictureBox();
            grenadeDrop.Image = Properties.Resources.Gernade;
            grenadeDrop.SizeMode = PictureBoxSizeMode.AutoSize;
            grenadeDrop.Left = randNum.Next(10, this.ClientSize.Width - grenadeDrop.Width);
            grenadeDrop.Top = randNum.Next(40, ClientSize.Height - grenadeDrop.Height);
            grenadeDrop.Tag = "grenadeDrop";
            this.Controls.Add(grenadeDrop);

            grenadeDrop.BringToFront();
            player.BringToFront();
        }

        private void RestartGame()
        {

            foreach(PictureBox pbox in ammoList)
            {
                this.Controls.Remove(pbox);
                pbox.Dispose();
            }

            foreach (PictureBox picbox in zombieList)
            {
                this.Controls.Remove(picbox);
                picbox.Dispose();
            }

            foreach (Control picBox in Controls)
            {
                if((string)picBox.Tag == "grenadeDrop")
                {
                    this.Controls.Remove(picBox);
                    picBox.Dispose();
                }
            }

            zombieList.Clear();

            for (int i = 0; i < 3; i++)
            {
                MakeZobie();
            }

            player.Image = Properties.Resources.up;
            facing = "up";
            GameOverBanner.Visible = false;
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
