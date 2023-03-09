
using EntityList;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TurnBasedGame;



namespace TurnBasedCombat
{
    class MainClass
    {
        private Random r = new Random();
        
        static void Main(string[] args)
        {
            int randomMonsterID = MonsterSpawner.RandomNumber(1, 3);
            Monster randomMonster = MonsterSpawner.GetMonster(randomMonsterID);
            Random r = new Random();

            var counter = 0;
            #region playerInfo
            Player player = new Player();
            player.Name = "Chad";
            player.HitPoints = 50;
            player.AttackDamage = 10;

            #endregion

            while (player.HitPoints > 0 && randomMonster.HitPoints>0)
            {
                counter++;
                if (counter <= 1)
                {
                    Console.Write($"You have encountered: {randomMonster.Name}");
                }
                Console.WriteLine(" ");
                Console.WriteLine("YOUR TURN");
                Console.WriteLine(" ");
                Console.WriteLine("A TO ATTACK H TO HEAL");
                Console.WriteLine("------------------------------------------------------ ");

                string choice = Console.ReadLine();

                if (choice == "a")
                {
                    Console.WriteLine(player.Name + " DEALT: " + player.AttackDamage);

                }
                if (choice == "h")
                {
                    player.HitPoints += player.Heal;
                    Console.WriteLine("Healed for: " + player.Heal + "HP" + " Current Health: " + player.HitPoints);

                    if (player.HitPoints < 30)
                    {
                        for (int i = 1; i <= 1; i++)
                        {
                            player.Heal = r.Next(2, 11);
                        }
                    }else { Console.WriteLine("You are to healthy to heal!"); Console.WriteLine(" "); }
                }
            }
        }
        public void AddMonster(int monsterID, int chanceToEncounter)
        {

        }

    }


}