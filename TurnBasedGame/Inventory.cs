using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class Inventory
    {
        private List<Items> Items = new List<Items>();

        public void AddItem(Items item)//Adds an item to the List
        {
            Items.Add(item);
        }

        public void RemoveItem(Items item)//Removes an item from the list
        {
            Items.Remove(item);
        }

        public void ShowInventory()//Shows all the items in the List to the player
        {
            foreach (Items item in Items)
            {
                Console.WriteLine(item.Name + ": " + item.Description);
            }

            if(Items.Count <= 0 ) 
            {
                Console.WriteLine("No Items in Inventory!\n");
            }
        }

    }
}
