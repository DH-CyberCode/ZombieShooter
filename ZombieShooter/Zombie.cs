using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZombieShooter;

namespace ZombieShooter
{
    public class Zombie : PictureBox
    {
        //PROPERTIES
        public string Facing { get; set; }
        public bool Stopped { get; set; }
        public bool Blocked { get; set; }

        //CONSTRUCTOR
        public Zombie(int leftPos, int topPos)
        {
            this.Tag = "zombie";
            this.Image = Properties.Resources.zdown;
            this.Left = leftPos;
            this.Top = topPos;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        //METHODS
        public void Explode(List<PictureBox> zombieList)
        {
            foreach (PictureBox picbox in zombieList)
            {
               
               GameWindow.ActiveForm.Controls.Remove(picbox);
            }
        }


    }
}
