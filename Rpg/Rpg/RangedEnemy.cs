using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class RangedEnemy
    {
        private int health;
        private int damage;
        private int bullets;

        public RangedEnemy(int health, int damage, int bullets)
        {
            this.health = health;
            this.damage = damage;
            this.bullets = bullets;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public int GetDamage()
        {
            return damage;
        }

        public bool IsAlive()
        {
            return health > 0;
        }

        public bool CanAttack()
        {
            return bullets > 0;
        }

        public void ConsumeBullet()
        {
            if (CanAttack())
            {
                bullets--;
            }
        }

        public int Health
        {
            get { return health; }
        }
    }
}
