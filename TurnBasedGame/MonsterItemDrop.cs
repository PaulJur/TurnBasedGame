using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class MonsterItemDrop
    {
        Items HealingPotion = new Items("Healing Potion", 15, "A simple Healing Potion");
        Items IronSword = new Items("Sword", "A normal sword", 3, 6);
        public void Drop(MonsterConst _monster, Player _player, Inventory _inventory) {
            int _number = MonsterSpawner.RandomNumber(1, 15);
            bool swordEquipped = false;


            switch (_number)//If a monster is killed and it fits the switch case it will either drop a certain item or nothing
            {
                case 1:
                    if (swordEquipped == false)
                    {
                        Console.WriteLine($"The monster has dropped a Sword! It adds MIN {IronSword.minAttackDamage}  MAX {IronSword.maxAttackDamage} to your attacks!");

                        _inventory.AddItem(IronSword);
                        _player.EquipSword(IronSword);
                        swordEquipped = true;
                    }
                    else { Console.WriteLine("Monster didn't drop anything\n"); break; }

                    break;

                case 2:
                    Console.WriteLine($"The monster has dropped a Healing Potion!");

                    _inventory.AddItem(HealingPotion);
                    break;
                default: Console.WriteLine("Monster didn't drop anything"); break;
            }
        }
        public Items GetHealingPotion()//returns the healing potion
        {
            return HealingPotion;
        }
        public Items GetIronSword()//returns the iron sword (no item durabilty so nothing uses this)
        {
            return IronSword;
        }
    }
}
