
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TurnBasedGame;
using System.Threading;
using System.Diagnostics;

namespace TurnBasedCombat
{
    class MainClass
    {
        static void Main(string[] args)
        {

            Inventory inventory = new Inventory();



            var counter = 0;
            Player player = new Player("Chad", 5000, 5000, 4, 11, 6, 8, 0, 0);
            

            Console.WriteLine("Game made by Paulius Jurgelis\n");
            Thread.Sleep(2000);
            Console.WriteLine("You can quit anytime if you write q, enjoy\n");
            Thread.Sleep(1500);
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("Please enter your characters name:");
            player.Name = Console.ReadLine();
            Console.Clear();

            while (true)
            {

                int randomMonsterID = MonsterSpawner.RandomNumber(1, 4);
                MonsterConst randomMonster = MonsterSpawner.GetMonster(randomMonsterID);
                MonsterItemDrop monsterItemDrop = new MonsterItemDrop();

                while (player.HitPoints > 0 && randomMonster.HitPoints > 0)
                {

                    counter++;
                    if (counter <= 1)
                    {
                        Console.Write($"You have encountered: {randomMonster.Name}\n");
                    }
                    Console.WriteLine("\nYOUR TURN\n");
                    Console.WriteLine($"Player Health: {player.HitPoints}\n");
                    Console.WriteLine($"Monster Health: {randomMonster.HitPoints}\n");
                    Console.WriteLine("A TO ATTACK H TO HEAL          'stats' for player stats         Write 'help' if you need to remember");
                    Console.WriteLine("------------------------------------------------------");

                    string? choice = Console.ReadLine();
                    
                    if(choice == "p")
                    {
                        Console.Clear();
                        MonsterActions.MonsterTakingAction(randomMonster, player);
                        
                    }



                    if (choice == "a")
                    {
                        Console.Clear();

                        player.Attack();

                        if (randomMonster != null)
                        {
                            bool didDodge = randomMonster.Dodge(randomMonster.DodgeChance);

                            if (didDodge)
                            {
                                Console.WriteLine($"{randomMonster.Name} dodged your attack!");
                                player.AttackDamage = 0;
                            }
                            //If the randomized number is lower than the dodge chance
                            //The monster will "dodge", setting the player damage to 0.
                        }

                        Console.WriteLine($"{player.Name} DEALT {player.AttackDamage} DAMAGE To {randomMonster.Name}!\n");

                        randomMonster.HitPoints -= player.AttackDamage;

                        if (randomMonster.HitPoints <= 0)//If the monsters HP reaches <=0 player gets experience and if the player reaches the threshold they level up resetting xp to 0
                        {
                            counter = 0;
                            monsterItemDrop.Drop(randomMonster, player, inventory);
                            Console.WriteLine($"{randomMonster.Name} Killed!\n");
                            player.PlayerExperienceGain(randomMonster.ExperienceDrop);

                            Thread.Sleep(1000);
                            break;

                        }

                        Thread.Sleep(1000);
                        if (randomMonster.HitPoints > 0)
                        {
                            Console.WriteLine($"{randomMonster.Name}'s Turn!");
                        }
                        Console.WriteLine("------------------------------------------------------\n");

                        Thread.Sleep(1500);
                        MonsterActions.MonsterTakingAction(randomMonster, player);
                    }

                        if (choice == "h")
                        {
                            Console.Clear();

                            if (player.HitPoints < player.maximumHitPoints / 2)
                            // Healing not allowed until the player is below half hp
                            {
                                for (int i = 1; i <= 1; i++)
                                {
                                    player.Heal = MonsterSpawner.RandomNumber(player.minimumHeal, player.maximumHeal);
                                }
                                player.HitPoints += player.Heal;
                                Console.WriteLine("Healed for: " + player.Heal + " HP" + " Current Health: " + player.HitPoints);//Player heals for an amount

                                Thread.Sleep(1000);
                                Console.WriteLine($"{randomMonster.Name}'s Turn!");
                                Console.WriteLine("------------------------------------------------------\n");
                                Thread.Sleep(1500);
                                MonsterActions.MonsterTakingAction(randomMonster, player);

                            }
                            else { Console.Clear(); Console.WriteLine("You are too healthy to heal!"); Console.WriteLine(" "); }

                        }
                    
                        if (choice == "help")
                        {
                            Console.Clear();
                            Console.WriteLine("You can only heal below half of your hp\n");
                            Console.WriteLine("Write 'inventory' to show your inventory\n");
                            Console.WriteLine("Write 'potion' to use one of your healing potions");
                            Console.WriteLine("------------------------------------------------------");
                        }

                        if (choice == "q")
                        {

                            player.HitPoints = 0;
                            Console.WriteLine("Thank you for playing!");

                        }

                        if (choice == "stats")
                        {
                            Console.Clear();
                            Console.WriteLine($"Name: {player.Name}");
                            Console.WriteLine($"Current XP: {player.Experience}");
                            Console.WriteLine($"Required XP to level up: {player.experienceRequired}");
                            Console.WriteLine($"Current Level: {player.Level}\n");
                            Console.WriteLine("STATS\n");
                            Console.WriteLine($"Your Damage: Minimum {player.minimumDamage} to Maximum {player.maximumDamage}");
                            Console.WriteLine($"Your Heal: Minimum {player.minimumHeal} to Maximum {player.maximumHeal}");
                            Console.WriteLine($"Your Maximum HP: {player.maximumHitPoints}");
                            Console.WriteLine("------------------------------------------------------");
                        }

                        if (choice == "inventory")
                        {
                            inventory.ShowInventory();
                        }

                        if (choice == "potion")
                        {
                            Items healingPotion = monsterItemDrop.GetHealingPotion();
                            player.UsePotion(healingPotion);
                            inventory.RemoveItem(healingPotion);
                        }
                    

                }
            }


        }


    }
}