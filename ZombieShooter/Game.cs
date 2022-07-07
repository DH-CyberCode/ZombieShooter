using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace ZombieShooter
{
    public partial class Game : Form
    {

        bool goLeft, goRight, goUp, goDown, gamePaused, gameOver;
        bool grenadeAvailable = false;
        bool firstAidAvailable = false;
        bool muted = false;
        string facing = "up";
        int playerHealth = 100;
        int speed = 10;
        int ammo = 20;
        int score = 0;
        Random randNum = new Random();
        int counter = 100;
        int tickCount = 0;
        List<Zombie> zombieList = new List<Zombie>();
        List<PictureBox> ammoList = new List<PictureBox>();
        List<PictureBox> firstAidList = new List<PictureBox>();
        List<PictureBox> gernadeList = new List<PictureBox>();

        SoundPlayer gun_fire = new SoundPlayer(Properties.Resources.GUN_FIRE_low);
        SoundPlayer reload_sound = new SoundPlayer(Properties.Resources.Reload);
        SoundPlayer explode_sound = new SoundPlayer(Properties.Resources.Grenade_Explosion);
        SoundPlayer sound_track = new SoundPlayer(Properties.Resources.ZS_soundtrack);
        SoundPlayer dry_Fire = new SoundPlayer(Properties.Resources.OutOfAmmo);
        SoundPlayer bite_sound = new SoundPlayer(Properties.Resources.Pain);
        SoundPlayer cheer_sound = new SoundPlayer(Properties.Resources.yay);

        Label pauseLabel = new Label();
        


        public object Propeties { get; private set; }

        public Game()
        {
            InitializeComponent();
            GameOverBanner.Visible = false;
            titleGroup.BringToFront();
            sound_track.PlayLooping();

            pauseLabel.AutoSize = true;
            pauseLabel.Text = "GAME PAUSED";
            pauseLabel.ForeColor = Color.MediumVioletRed;
            pauseLabel.Font = new Font("Comic Sans", 24, FontStyle.Bold);
            pauseLabel.Top = this.Height / 2;
            pauseLabel.Left = this.Width / 2;
            pauseLabel.Visible = false;
            this.Controls.Add(pauseLabel);

            //backgroundTrack.Hide();
            gameOver = true;
            gamePaused = true;
           // RestartGame();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {

            
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

                if (!muted)
                {
                    sound_track.PlayLooping();
                }

                
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
            if(counter == rando && grenadeAvailable == false && !gamePaused)
            {
                grenadeAvailable = true;
                DropGrenade();

            }

            //---- FIRSTAID DROPS
            if(playerHealth < 50 && firstAidAvailable == false && !gamePaused)
            {
                DropFirstAid();
                firstAidAvailable = true;
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
                        if (!muted)
                        {
                            reload_sound.Play();
                        }

                    }

                }

                //==========================================================]
                //=========     GRENADE PICKUP    ==========================]
                //==========================================================]
                if (item is PictureBox && (string)item.Tag == "grenadeDrop")
                {
                    if (player.Bounds.IntersectsWith(item.Bounds))
                    {
                        if (!muted)
                        {
                            explode_sound.Play();
                        }
                       
                        this.Controls.Remove(item);
                        item.Dispose();
                        
                        foreach (Zombie z in zombieList)
                        {
                            
                            z.Explode();

                        }
                        grenadeTimer.Start();
                        grenadeAvailable = false;
                        
                      
                    }

                }
                
                //==========================================================]
                //=========     FIRSTAID PICKUP    =========================]
                //==========================================================]
                if (item is PictureBox && (string)item.Tag == "FirstAid")
                {
                    if (player.Bounds.IntersectsWith(item.Bounds))
                    {
                        if (!muted)
                        {
                            cheer_sound.Play();
                        }
                        
                        this.Controls.Remove(item);
                        item.Dispose();

                        playerHealth += 20;
                        
                        firstAidAvailable = false;
                        
                      
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
                        if(facing == "left")
                        {
                            player.Image = Properties.Resources.leftDamaged;
                        }
                        else if(facing == "right")
                        {
                            player.Image = Properties.Resources.rightDamaged;
                        }
                        else if(facing == "down")
                        {
                            player.Image = Properties.Resources.downDamaged;
                        }
                        else if(facing == "up")
                        {
                            player.Image = Properties.Resources.upDamaged;
                        }
                        
                        biteTimer.Start();



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
                        item.Top += ((Zombie)item).MoveSpeed;
                    }

                    if (item.Left > player.Left)
                    {
                        item.Left -= ((Zombie)item).MoveSpeed;
                    }

                    if (item.Left < player.Left)
                    {
                        item.Left += ((Zombie)item).MoveSpeed;
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
                        pauseLabel.Visible = false;
                    }
                    else
                    {
                        //PAUSE
                        gamePaused = true;
                        GameTimer.Stop();
                        pauseLabel.Visible = true;
                        if (!muted)
                        {
                            sound_track.PlayLooping();
                        }
                        
                    }
                    
                }


            }
            else
            {



                //RESTART GAME
                if (e.KeyCode == Keys.Return)
                {
                    gameOver = false;
                    gamePaused = false;
                    
                    
                        titleGroup.Visible = false;
                    
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

            if (gameOver == false )
            {

                if(gamePaused == false)
                {
                    if (e.KeyCode == Keys.Space && ammo > 0)
                    {
                        if (!muted)
                        {
                            gun_fire.Play();
                        }
                        ammo--;
                        ShootBullet(facing);


                        if (ammo == 5 || ammo == 1)
                        {
                            DropAmmo();
                        }

                    }
                    else if(e.KeyCode == Keys.Space && ammo == 0)
                    {
                        if (!muted)
                        {
                            dry_Fire.Play();
                        }
                    }
                   
                }
            }
              


        }//END OF KeyisUp

        private void soundFX_Click(object sender, EventArgs e)
        {
            if (soundFX.Tag.ToString() == "On")
            {
                soundFX.Tag = "Off";
                soundFX.Image = Properties.Resources.soundOff;
                muted = true;
                sound_track.Stop();
            }
            else
            {
                muted = false;
                soundFX.Tag = "On";
                soundFX.Image = Properties.Resources.soundOn;
                sound_track.Play();
            }
        }

 

        private void biteTimer_Tick(object sender, EventArgs e)
        {

            if (facing == "left")
            {
                player.Image = Properties.Resources.left;
            }
            else if (facing == "right")
            {
                player.Image = Properties.Resources.right;
            }
            else if (facing == "down")
            {
                player.Image = Properties.Resources.down;
            }
            else if (facing == "up")
            {
                player.Image = Properties.Resources.up;
            }
            bite_sound.Play();
            biteTimer.Stop();
        }

        private void grenadeTimer_Tick(object sender, EventArgs e)
        {
            MakeZobie(4);
            grenadeTimer.Stop();
        }

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
                int posLeft = randNum.Next(0, ActiveForm.Width);
                int posTop = randNum.Next(0, ActiveForm.Height);
            
                Zombie zombie = new Zombie(posLeft, posTop);
                zombieList.Add(zombie);
                this.Controls.Add(zombie);
                zombie.BringToFront();
                
            }
            player.BringToFront();
   
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

        private void DropFirstAid()
        {
            PictureBox firstAidDrop = new PictureBox();
            firstAidDrop.Image = Properties.Resources.FirstAid;
            firstAidDrop.SizeMode = PictureBoxSizeMode.AutoSize;
            firstAidDrop.Left = randNum.Next(10, this.ClientSize.Width - firstAidDrop.Width);
            firstAidDrop.Top = randNum.Next(40, ClientSize.Height - firstAidDrop.Height);
            firstAidDrop.Tag = "FirstAid";
            this.Controls.Add(firstAidDrop);

            firstAidDrop.BringToFront();
            player.BringToFront();
        }

        private void RestartGame()
        {

            titleGroup.Hide();
            pauseLabel.Visible = false;

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

            foreach (Control label in Controls)
            {
                if ((string)label.Name == "restartWithEnterLabel")
                {
                    this.Controls.Remove(label);
                    label.Dispose();
                }
            }

            zombieList.Clear();


            //--MAKE NEW STARTING ZOMBIES
           if(ActiveForm.Width > 900)
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
            facing = "up";
            GameOverBanner.Visible = false;
            goDown = false;
            goUp = false;
            goLeft = false;
            goRight = false;
            sound_track.Stop();
            playerHealth = 100;
            score = 0;
            ammo = 25;

            //--START GAME
            GameTimer.Start();
        }

       
    }
}
