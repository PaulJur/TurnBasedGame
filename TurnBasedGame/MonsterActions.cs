
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class MonsterActions
    {
        
        public static void MonsterTakingAction(MonsterConst monster, Player player)
        {
            int action = MonsterSpawner.RandomNumber(1, 3);//Picks from these numbers to choose an action for the monster
            switch (action)
            {
                case 1:
                    Attack(monster,player);
                    break;
                case 2:
                    Heal(monster,player);
                    break;
                default:
                    Console.WriteLine($"{monster.Name} decided to do nothing!");
                    break;
            }
            static void Attack(MonsterConst monster, Player player)
                {
                Console.WriteLine($"{monster.Name} Attacks!");

                int monsterDamage = MonsterSpawner.RandomNumber(monster.MinimumAttackDamage, monster.MaximumAttackDamage);
                player.HitPoints -= monsterDamage;

                Console.WriteLine($"{monster.Name} Dealt: {monsterDamage} to player");
                 }
            
            static void Heal(MonsterConst monster, Player player)
            {
                if (monster.HitPoints < monster.MaximumHealth+ 1 /2)
                {
                    Console.WriteLine($"{monster.Name} Heals!");

                    int monsterHealAmount = MonsterSpawner.RandomNumber(monster.MinimumHeal, monster.MaximumHeal);
                    monster.HitPoints += monsterHealAmount;

                    Console.WriteLine($"{monster.Name} healed for {monsterHealAmount}HP");

                    if (monster.HitPoints > monster.MaximumHealth)
                    {
                        monster.HitPoints = monster.MaximumHealth;
                    }
                }
                else
                {
                    Console.WriteLine($"{monster.Name} wanted to heal but it's too healthy so it decided to Attack!");

                    int monsterDamageOverHeal = MonsterSpawner.RandomNumber(monster.MinimumAttackDamage, monster.MaximumAttackDamage);
                    player.HitPoints -= monsterDamageOverHeal;

                    Console.WriteLine($"{monster.Name} Dealt: {monsterDamageOverHeal} to player");
                }
            }

        }
        
    }

}
