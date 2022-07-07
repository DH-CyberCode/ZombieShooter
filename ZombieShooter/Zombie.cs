using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieShooter
{
    public class Zombie : PictureBox
    {
        //PROPERTIES
        public string Facing { get; set; }
        public bool Stopped { get; set; }
        public bool Blocked { get; set; }
        public int MoveSpeed { get; set; }
        private Timer zTimer = new Timer();
        private int Ticks { get; set; }


        //CONSTRUCTOR
        public Zombie(int leftPos, int topPos)
        {
            this.Tag = "zombie";
            this.Image = Properties.Resources.zdown;
            this.Left = leftPos;
            this.Top = topPos;
            this.MoveSpeed = 3;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        //METHODS
        public void Explode()
        {
            // foreach (PictureBox picbox in zombieList)
            // {
            this.MoveSpeed = 0;
            this.BackgroundImage = Properties.Resources.Explosion;
            this.BackgroundImageLayout = ImageLayout.Center;
            zTimer.Interval = 250;
            zTimer.Tick += new EventHandler(zTimerEvent);
            zTimer.Start();


        }

        private void zTimerEvent(object sender, EventArgs e)
        {
            this.Ticks++;
            if(this.Ticks > 6)
            {
                zTimer.Stop();
                this.MoveSpeed = 3;
                //zTimer.Dispose();
                //this.Dispose();
                //zTimer = null;
                Game.ActiveForm.Controls.Remove(this);
                
                
            }
            else
            {
                if (this.Image == Properties.Resources.z_exploded)
                {
                    this.Image = null;
                }
                else
                {

                    this.Image = Properties.Resources.z_exploded;
                }
            }

        }
            


    }
}
