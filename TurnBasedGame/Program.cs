
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
using System.Text.Json;

namespace TurnBasedCombat
{
    class MainClass
    {

        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            int Heal;

            bool orcBossKilled = false;
            var counter = 0;
            Player player = new Player("Chad", 5000, 5000, 4, 11, 200, 200, 0, 0,0,10); //4 6 attack
            

            Console.WriteLine("Game made by Paulius Jurgelis\n");
            Thread.Sleep(2000);
            Console.WriteLine("You can quit anytime if you write q, enjoy\n");
            Thread.Sleep(1500);
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Please enter your character's name: ");

            player.Name = Console.ReadLine();
            
            while (true)
            {
                
                int randomMonsterID = MonsterSpawner.RandomNumber(1, 15);
                if (player.Level == 5 && orcBossKilled == false)
                {
                    randomMonsterID = 95;
                }
                MonsterConst randomMonster = MonsterSpawner.GetMonster(randomMonsterID,player.Level);
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
                    Console.WriteLine($"Monster Ability: {randomMonster.Ability}\n");
                    Console.WriteLine("A TO ATTACK H TO HEAL          'stats' for player stats         Write 'help' if you need to remember");
                    Console.WriteLine("------------------------------------------------------");

                    string? choice = Console.ReadLine();
#if DEBUG
                    if(choice == "p")
                    {
                        Console.Clear();
                        MonsterActions.MonsterTakingAction(randomMonster, player);
                        
                    }
#endif
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

                            if(randomMonsterID == 95)
                            {
                                orcBossKilled = true;
                            }

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

                            if (player.HitPoints < player.MaximumHitPoints / 2)
                            // Healing not allowed until the player is below half hp
                            {
                                
                                Heal = MonsterSpawner.RandomNumber(player.MinimumHeal, player.MaximumHeal);
                                player.HitPoints += Heal;
                                Console.WriteLine("Healed for: " + Heal + " HP" + " Current Health: " + player.HitPoints);//Player heals for an amount

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
                            Console.WriteLine("You can type 'save' to save your game and 'load' to load your game state");
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
                            Console.WriteLine($"Current XP: {player.ExperienceAmount}");
                            Console.WriteLine($"Required XP to level up: {player.ExperienceRequired}");
                            Console.WriteLine($"Current Level: {player.Level}\n");
                            Console.WriteLine("STATS\n");
                            Console.WriteLine($"Your Damage: Minimum {player.MinimumDamage} to Maximum {player.MaximumDamage}");
                            Console.WriteLine($"Your Heal: Minimum {player.MinimumHeal} to Maximum {player.MaximumHeal}");
                            Console.WriteLine($"Your Maximum HP: {player.MaximumHitPoints}");
                            Console.WriteLine("------------------------------------------------------");
                        }
                        //Check the Player's inventory
                        if (choice == "inventory")
                        {
                            Console.Clear();
                            inventory.ShowInventory();
                        }
                        //The player uses a potion
                        if (choice == "potion")
                        {
                            Items healingPotion = monsterItemDrop.GetHealingPotion();
                            player.UsePotion(healingPotion);
                            inventory.RemoveItem(healingPotion);
                        }
                        //Save the game
                        if (choice == "save")
                        {
                            DataSaveAndLoad.SaveGame(player,randomMonster,inventory);
                            Console.WriteLine("Game saved successfully");
                            continue;
                        }
                        //Load the game
                        if (choice == "load")
                        {
                            (player, randomMonster,inventory) = DataSaveAndLoad.LoadGame();

                            if(player!= null && randomMonster != null)
                            {
                            Console.WriteLine("Game loaded successfully!");
                            }

                            else if(player == null && randomMonster == null)
                            {
                                Console.WriteLine("\nPlease enter your character's name:");
                                string nameChoice = Console.ReadLine();
                                player = new Player(nameChoice, 5000, 5000, 4, 11, 4, 6, 0, 0, 0, 10);
                                break;
                            }
                        }


                }
            }


        }


    }
}