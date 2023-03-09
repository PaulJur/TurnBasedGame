
using EntityList;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TurnBasedGame;
using System.Threading;



namespace TurnBasedCombat
{
    class MainClass
    {
        private Random r = new Random();
        
        static void Main(string[] args)
        {
            
            Random r = new Random();

            var counter = 0;
            #region playerInfo
            Player player = new Player();
            player.Name = "Chad";
            player.HitPoints = 50;
            player.AttackDamage = 5;

            #endregion
            Console.WriteLine("Game made by Paulius Jurgelis");
            Thread.Sleep(2000);
            Console.WriteLine(" ");
            Console.WriteLine("You can quit anytime if you write q, enjoy");
            Thread.Sleep(1500);
            Console.WriteLine(" ");
            Console.WriteLine("------------------------------------------------------");

            while (true)
            {
                

                int randomMonsterID = MonsterSpawner.RandomNumber(1, 3);
                Monster randomMonster = MonsterSpawner.GetMonster(randomMonsterID);
               
                while (player.HitPoints>0 && randomMonster.HitPoints > 0) 
                {
                    counter++;
                    if (counter <= 1)
                    {
                        Console.Write($"You have encountered: {randomMonster.Name}");
                        Console.WriteLine(" ");
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("YOUR TURN");
                    Console.WriteLine(" ");
                    Console.WriteLine($"Player Health: {player.HitPoints}");
                    Console.WriteLine(" ");
                    Console.WriteLine($"Monster Health: {randomMonster.HitPoints}");
                    Console.WriteLine(" ");
                    Console.WriteLine("A TO ATTACK H TO HEAL");
                    Console.WriteLine("------------------------------------------------------");

                    string choice = Console.ReadLine();

                    if (choice == "a")
                    {
                        Console.WriteLine(player.Name + " DEALT: " + player.AttackDamage + " To " + randomMonster.Name);
                        randomMonster.HitPoints -= player.AttackDamage;
                        Thread.Sleep(1000);
                        Console.WriteLine("Monster Turn!");
                        Console.WriteLine("------------------------------------------------------");
                        Console.WriteLine(" ");
                        Thread.Sleep(1500);
                        MonsterActions.MonsterTakingAction(randomMonster,player);

                        

                        if (randomMonster.HitPoints <= 0)
                        {
                            counter = 0;
                            Console.WriteLine("Monster Killed!");
                            //Console.WriteLine("If you want to quit press q!");
                        }


                    }
                    if (choice == "h")
                    {
                        player.HitPoints += player.Heal;
                        Console.WriteLine("Healed for: " + player.Heal + "HP" + " Current Health: " + player.HitPoints);

                        Thread.Sleep(1000);
                        Console.WriteLine("Monster Turn!");
                        Console.WriteLine("------------------------------------------------------");
                        Console.WriteLine(" ");
                        Thread.Sleep(1500);
                        MonsterActions.MonsterTakingAction(randomMonster, player);

                        if (player.HitPoints < 30)// Healing not allowed until the player is below 30HP
                        {
                            for (int i = 1; i <= 1; i++)
                            {
                                player.Heal = r.Next(2, 11);//Heals a random amount between 2 and 10
                            }
                        }
                        else { Console.WriteLine("You are to healthy to heal!"); Console.WriteLine(" "); }
                    }
                   
                    if(choice == "q") {

                        player.HitPoints = 0;
                        Console.WriteLine("Thank you for playing!");

                    }
                    
                }
               
            }
        }


    }


}