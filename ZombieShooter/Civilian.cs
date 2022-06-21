using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieShooter
{
    public class Civilian
    {
        //PROPERTIES
        public int Health { get; set; } = 10;


        //CONSTRUCTOR


        //METHODS
        public int Damage(int amtOfDamage)
        {
            int intRemainingHealth = this.Health - amtOfDamage;


            return intRemainingHealth;
        }

    }
}
