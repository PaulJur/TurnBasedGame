using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class MonsterItemDrop
    {
      

        

        
        public void Drop(Monster _monster,Player _player,Inventory _inventory) {
            int _number = MonsterSpawner.RandomNumber(1, 3);
            Items IronSword = new Items("Sword", "A normal sword", 5, 10);
            bool swordEquipped = false;
            Items HealingPotion = new Items("Healing Potion", 15, "A simple Healing Potion");

            switch (_number)
                {
                    case 1:
                        if (swordEquipped == false)
                        {
                        Console.WriteLine($"The monster has dropped a Sword!");
                        _inventory.AddItem(IronSword);
                        _player.EquipSword(IronSword);
                        swordEquipped = true;
                        }
                        else { break; }
                        
                        break;

                    case 2:
                        Console.WriteLine($"The monster has dropped a Healing Potion!");

                        _inventory.AddItem(HealingPotion);
                        break;
                    default: Console.WriteLine("Monster didn't drop anything"); break;
                }
            }
        

    }


    }
