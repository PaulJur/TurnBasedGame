﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public static class MonsterActions
    {
        
        public static void MonsterTakingAction(MonsterConst _monster, Player player)
        {
            int _action = MonsterSpawner.RandomNumber(1, 3);//Picks from these numbers to choose an action for the monster
            switch (_action)
            {
                case 1:
                    Attack(_monster,player);
                    break;
                case 2:
                    Heal(_monster,player);
                    break;
                default:
                    Console.WriteLine($"{_monster.Name} decided to do nothing!");
                    break;
            }
            static void Attack(MonsterConst _monster, Player player)
            {
                Console.WriteLine($"{_monster.Name} Attacks!");

                int _monsterDamage = MonsterSpawner.RandomNumber(_monster.MinimumAttackDamage, _monster.MaximumAttackDamage);
                player.HitPoints -= _monsterDamage;

                Console.WriteLine($"{_monster.Name} Dealt: {_monsterDamage} to player");
            }
            
            static void Heal(MonsterConst _monster, Player player)
            {
                if (_monster.HitPoints < _monster.MaximumHealth + 1)
                {
                    Console.WriteLine($"{_monster.Name} Heals!");

                    int _monsterHealAmount = MonsterSpawner.RandomNumber(_monster.MinimumHeal, _monster.MaximumHeal);
                    _monster.HitPoints += _monsterHealAmount;

                    Console.WriteLine($"{_monster.Name} healed for {_monsterHealAmount}HP");

                    if (_monster.HitPoints > _monster.MaximumHealth)
                    {
                        _monster.HitPoints = _monster.MaximumHealth;
                    }
                }
                else
                {
                    Console.WriteLine($"{_monster.Name} wanted to heal but it's too healthy so it decided to Attack!");

                    int _monsterDamageOverHeal = MonsterSpawner.RandomNumber(_monster.MinimumAttackDamage, _monster.MaximumAttackDamage);
                    player.HitPoints -= _monsterDamageOverHeal;

                    Console.WriteLine($"{_monster.Name} Dealt: {_monsterDamageOverHeal} to player");
                }
            }
        }
        
    }

}
