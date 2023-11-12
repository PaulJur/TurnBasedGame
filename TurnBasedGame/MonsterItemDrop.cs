using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class MonsterItemDrop
    {
        public static bool swordEquipped = false;

        Items HealingPotion = new Items("Healing Potion", "A simple Healing Potion",0,0,15);
        Items IronSword = new Items("Sword", "A normal sword", 3, 6);
        public void Drop(MonsterConst _monster, Player player, Inventory inventory) {
            int number = MonsterSpawner.RandomNumber(1, 15);
            


            switch (number)//If a monster is killed and it fits the switch case it will either drop a certain item or nothing
            {
                case 1:
                        if(swordEquipped == true)
                        {
                            Console.WriteLine("Monster didn't drop anything\n"); break;
                        }
                        else if (swordEquipped == false)
                        {
                             swordEquipped = true;
                             Console.WriteLine($"The monster has dropped a Sword! It adds MIN {IronSword.MinimumAttackDamage}  MAX {IronSword.MaximumAttackDamage} to your attacks!");
                             inventory.AddItem(IronSword);
                             player.EquipSword(IronSword);
                            
                        }

                    break;

                case 2:
                    Console.WriteLine($"The monster has dropped a Healing Potion!");

                    inventory.AddItem(HealingPotion);
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
