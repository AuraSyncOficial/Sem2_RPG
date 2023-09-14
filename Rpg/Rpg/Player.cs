using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class Player
    {
        private int maxHealth = 100;
        private int maxDamage = 20;
        private int health;
        private int damage;
            
        public Player(int health, int damage)
        {
            this.health = Math.Min(health, maxHealth);
            this.damage = Math.Min(damage, maxDamage);
        }

        public void TakeDamage(int damageTaken)
        {
            health -= damageTaken;
            if (health < 0)
            {
                health = 0;
            }
        }

        public int GetDamage()
        {
            return damage;
        }

        public bool IsAlive()
        {
            return health > 0;
        }

        public int Health
        {
            get { return health; }
        }

        public int Damage
        {
            get { return damage; }
        }
    }
}
