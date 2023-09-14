using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(numMeleeEnemies: 3, numRangedEnemies: 2);
            game.CreatePlayer(100, 20); 
            game.Play();
        }
    }
}
    