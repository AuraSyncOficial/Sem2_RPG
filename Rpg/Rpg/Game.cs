using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class Game
    {
        private List<MeleeEnemy> meleeEnemies;
        private List<RangedEnemy> rangedEnemies;
        private Player player;

        public Game(int numMeleeEnemies, int numRangedEnemies)
        {
            meleeEnemies = new List<MeleeEnemy>();
            rangedEnemies = new List<RangedEnemy>();
            for (int i = 0; i < numMeleeEnemies; i++)
            {
                meleeEnemies.Add(new MeleeEnemy(30, 10, 5));
            }

            for (int i = 0; i < numRangedEnemies; i++)
            {
                rangedEnemies.Add(new RangedEnemy(10,15,10));
            }
        }

        public void CreatePlayer(int playerHealth, int playerDamage)
        {
            if (playerHealth <= 100 && playerDamage <= 100)
            {
                player = new Player(playerHealth, playerDamage);
            }
            else
            {
                Console.WriteLine("Hey! no more than 100.");
            }
        }
        public void Play()
        {
            if (player == null)
            {
                Console.WriteLine("We dont have player. Use CreatePlayer method before.");
                return;
            }

            while (player.IsAlive() && (meleeEnemies.Count > 0 || rangedEnemies.Count > 0))
            {
                Console.WriteLine("Current Status:");
                Console.WriteLine($"Player's Health:   {player.Health}");
                Console.WriteLine("Remaining Melee Enemies: " + meleeEnemies.Count);
                Console.WriteLine("Remaining Ranged Enemies: " + rangedEnemies.Count);

                Console.WriteLine("Player's turn:");
                Console.WriteLine("Select an enemy to attack (1.- Melee, 2.- Ranged):");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number (1.- Melee, 2.- Ranged).");
                    continue;
                }

                if (choice == 1 && meleeEnemies.Count > 0)
                {
                    MeleeEnemy enemy = meleeEnemies[0];
                    int playerDamage = player.GetDamage();
                    enemy.TakeDamage(playerDamage);

                    if (!enemy.IsAlive())
                    {
                        meleeEnemies.RemoveAt(0);
                        Console.WriteLine("Melee Enemy die");
                    }
                    else
                    {
                        Console.WriteLine($"Player attacks Melee Enemy with {playerDamage} damage.");
                        Console.WriteLine($"Melee Enemy's remaining health: {enemy.Health}");
                    }
                    player.TakeDamage(enemy.GetDamage());
                    Console.WriteLine($"Player's remaining health: {player.Health}");
                }
                else if (choice == 2 && rangedEnemies.Count > 0)
                {
                    RangedEnemy enemy = rangedEnemies[0];
                    int playerDamage = player.GetDamage();
                    enemy.TakeDamage(playerDamage);

                    if (!enemy.IsAlive())
                    {
                        rangedEnemies.RemoveAt(0);
                        Console.WriteLine("Ranged Enemy die");
                    }
                    else
                    {
                        Console.WriteLine($"Player attacks Ranged Enemy with {playerDamage} damage.");
                        Console.WriteLine($"Ranged Enemy's remaining health: {enemy.Health}");
                    }
                    player.TakeDamage(enemy.GetDamage());
                    Console.WriteLine($"Player's remaining health: {player.Health}");
                }
                else
                {
                    Console.WriteLine("Wait!. You did not select a valid enemy to attack.");
                }
            }
            if (!player.IsAlive())
            {
                Console.WriteLine("Oops, you lost!");
            }
            else
            {
                Console.WriteLine("Nice, you win!");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

