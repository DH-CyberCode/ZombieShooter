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

namespace ZombieShooter
{
    public partial class Game : Form
    {

        int game_height = Screen.PrimaryScreen.Bounds.Height;
        int game_width = Screen.PrimaryScreen.Bounds.Width;
        bool goLeft, goRight, goUp, goDown, gamePaused, gameOver;
        bool grenadeAvailable = false;
        string facing = "up";
        string strToScroll = "Welcome To The Zombie Apocalypse";
        int playerHealth = 100;
        int speed = 10;
        int ammo = 20;
        int zombieSpeed = 3;
        int score = 0;
        Random randNum = new Random();
        int counter = 100;
        int strCount = 0;
        List<Zombie> zombieList = new List<Zombie>();
        List<PictureBox> ammoList = new List<PictureBox>();
        List<PictureBox> firstAidList = new List<PictureBox>();
        List<PictureBox> gernadeList = new List<PictureBox>();
        SoundPlayer gun_fire = new SoundPlayer(Properties.Resources.GUN_FIRE_low);
        SoundPlayer reload_sound = new SoundPlayer(Properties.Resources.Reload);
        SoundPlayer explode_sound = new SoundPlayer(Properties.Resources.Grenade_Explosion);
        SoundPlayer sound_track = new SoundPlayer(Properties.Resources.ZS_soundtrack);
        
        
        public object Propeties { get; private set; }

        public Game()
        {
            InitializeComponent();
            strCount = strToScroll.Length - 1;
            GameOverBanner.Visible = false;
            titleGroup.BringToFront();
            sound_track.PlayLooping();
            //gamePaused = false;
            RestartGame();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {

            //--TITLE SCROLL
            
            if(strCount == strToScroll.Length)
            {
                titleText.Text = " ";
                strCount = 0;
            }
            else
            {
                titleText.Text += strToScroll[strCount].ToString().ToUpper();
                    strCount++;
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
                        reload_sound.Play();

                    }

                }

                //==========================================================]
                //=========     GRENADE PICKUP    ==========================]
                //==========================================================]
                if (item is PictureBox && (string)item.Tag == "grenadeDrop")
                {
                    if (player.Bounds.IntersectsWith(item.Bounds))
                    {
                        explode_sound.Play();
                        this.Controls.Remove(item);
                        item.Dispose();
                        zombieSpeed = 0;
                        foreach (Zombie z in zombieList)
                        {
                            
                            z.Explode();

                        }
                        grenadeAvailable = false;
                        MakeZobie(4);
                        
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
                    if (item is Zombie && (string)item.Tag == "zombie")
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
                        item.Top -= ((Zombie)item).MoveSpeed; //zombieSpeed;
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
                            zombieList.Remove((Zombie)item);
                            ((Zombie)item).Dispose();
                            MakeZobie(1);
                        }
                    }
                }


            }

        }// END OF MAIN TIMER

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver == false)
            {
                if(e.KeyCode == Keys.F)
                {
                   
                                       

                    foreach (PictureBox z in zombieList)
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
                        sound_track.Stop();
                    }
                    else
                    {
                        //PAUSE
                        gamePaused = true;
                        GameTimer.Stop();
                        sound_track.PlayLooping();
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
               
                
                foreach (PictureBox z in zombieList)
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
                    gun_fire.Play();
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

        private void MakeZobie(int numOfZombiesToMake)
        {
            for (int i = 0; i < numOfZombiesToMake; i++)
            {
                int posLeft = randNum.Next(0, game_width);
                int posTop = randNum.Next(0, game_height);
            
                Zombie zombie = new Zombie(posLeft, posTop);
                zombieList.Add(zombie);
                this.Controls.Add(zombie);
                zombie.BringToFront();
                
            }
            player.BringToFront();
            //PictureBox zombie = new PictureBox();
            //zombie.Tag = "zombie";
            //zombie.Image = Properties.Resources.zdown;
            //zombie.Left = randNum.Next(0, 900);
            //zombie.Top = randNum.Next(0, 800);
            //zombie.SizeMode = PictureBoxSizeMode.AutoSize;

        }

        private void DropAmmo()
        {
            PictureBox ammoDrop = new PictureBox();
            ammoDrop.Image = Properties.Resources.ammo_Image;
            ammoDrop.SizeMode = PictureBoxSizeMode.AutoSize;
            ammoDrop.Left = randNum.Next(10, this.ClientSize.Width - ammoDrop.Width);
            ammoDrop.Top = randNum.Next(40, this.ClientSize.Height - ammoDrop.Height);
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

            titleGroup.Visible = false;

            //--REMOVE ALL GAME ASSETS
            foreach (PictureBox pbox in ammoList)
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


            //--MAKE NEW STARTING ZOMBIES
           if(game_width > 900)
            {
                MakeZobie(4);
            }
            else
            {
                MakeZobie(3);
            }

           //--RESET ALL GAME VARIABLES
            counter = 100;
            grenadeAvailable = false;
            player.Image = Properties.Resources.up;
            zombieSpeed = 3;
            facing = "up";
            GameOverBanner.Visible = false;
            goDown = false;
            goUp = false;
            goLeft = false;
            goRight = false;

            playerHealth = 100;
            score = 0;
            ammo = 25;

            //--START GAME
            GameTimer.Start();
        }


    }
}
