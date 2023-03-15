using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class Inventory
    {
        private List<Items> _items = new List<Items>();

        public void AddItem(Items item)
        {
            _items.Add(item);
        }

        public void ShowInventory()
        {
            foreach (Items item in _items)
            {
                Console.WriteLine(item.Name);
            }

            if(_items.Count <= 0 ) 
            {
                Console.WriteLine("No Items in Inventory!");
            }
        }

    }
}
