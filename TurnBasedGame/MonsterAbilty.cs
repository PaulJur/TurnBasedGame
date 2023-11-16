using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class MonsterAbilty
    {
        private string name;
        private string description;

        public string Name { get  { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }

        public MonsterAbilty(string name, string description) 
        {   
            Name = name;
            Description = description;
        
        }
    }
}
