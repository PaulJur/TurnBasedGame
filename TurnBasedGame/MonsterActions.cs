
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class MonsterActions
    {
        static List<int>? tempHpList = new List<int>();
        public static void MonsterTakingAction(MonsterConst monster, Player player)
        {
            
            bool _isDefending=false;
            int action = MonsterSpawner.RandomNumber(1, 3);//Picks from these numbers to choose an action for the monster

            switch (action)
            {
                case 1:
                    _isDefending = false;
                    Defend(monster,player,_isDefending);

                    Attack(monster,player);
                    break;
                case 2:
                    _isDefending = false;
                    Defend(monster, player, _isDefending);

                    Heal(monster,player);

                    break;
                default: //!!!!!!!!!!Need to add another mechanics here where either it has some of the temp hp added to the hp pool 
                    //or another action, maybe a potential parry or attack or something.
                    _isDefending = false;
                    Defend(monster, player, _isDefending);

                    _isDefending = true;
                    Defend(monster, player, _isDefending);

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
                if (monster.HitPoints < monster.MaximumHealth+1 /2)
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

            void Defend(MonsterConst monster, Player player, bool isDefending)
            {
                _isDefending = isDefending;

                if (_isDefending)
                {
                    int currentTempHp = MonsterSpawner.RandomNumber(1, 10);

                    tempHpList.Add(currentTempHp);
                    Console.WriteLine($"{monster.Name} is defending and gained {currentTempHp} of temporary hp!");
                    monster.HitPoints += tempHpList[0];
                    isDefending = false;
                    //Randomizes temporary hp variable and adds it to a list which then adds the number to the monsters hp.

                }
                else if(_isDefending==false && tempHpList.Count > 0)
                {
                    monster.HitPoints -= tempHpList[0];
                    Console.WriteLine($"Removed {tempHpList[0]} HP from enemy monster");

                    if (monster.HitPoints == 0 || monster.HitPoints - tempHpList[0] == 0)
                    {
                        Console.WriteLine($"{monster.Name} is defending with it's last energy!");
                    }

                    tempHpList.RemoveAt(0);

                    
                    //When the monster is no longer defending and takes another action, the saved element in the list is subtracted 
                    //from the monsters hp.
                }


            }
                
        }   
        
    }

}
