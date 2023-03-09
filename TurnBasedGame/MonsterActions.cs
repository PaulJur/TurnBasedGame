using EntityList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class MonsterActions
    {
        
        public static void MonsterTakingAction(Monster _monster, Player player)
        {
            int _action = MonsterSpawner.RandomNumber(1, 3);
            switch (_action)
            {
                case 1:
                    Console.WriteLine($"{_monster.Name} Attacks!");
                    int _monsterDamage = MonsterSpawner.RandomNumber(_monster.MinimumAttackDamage, _monster.MaximumAttackDamage);
                    player.HitPoints -= _monsterDamage;
                    Console.WriteLine($"{_monster.Name} Dealt: {_monsterDamage} to player");
                    break;
                case 2:
                    Console.WriteLine($"{_monster.Name} Heals!");
                    int _monsterHealAmount = MonsterSpawner.RandomNumber(_monster.MinimumHeal,_monster.MaximumHeal);
                    _monster.HitPoints += _monsterHealAmount;
                    Console.WriteLine($"{_monster.Name} healed for {_monsterHealAmount}HP");
                    break;
                default:
                    Console.WriteLine($"{_monster.Name} decided to do nothing!");
                    break;
            }
                

        }



    }
}
