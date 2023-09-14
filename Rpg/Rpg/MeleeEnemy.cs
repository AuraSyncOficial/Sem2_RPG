using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class MeleeEnemy
    {
        private int health;
        private int damage;
        private int armor;

        public MeleeEnemy(int health, int damage, int armor)
        {
            this.health = health;
            this.damage = damage;
            this.armor = armor;
        }

        public void TakeDamage(int damage)
        {
            int finalDamage = damage - armor;
            if (finalDamage > 0)
            {
                health -= finalDamage;
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
    }
}
