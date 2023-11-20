using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class MonsterAbility
    {
        private string name;
        private string description;
        private int? dodgeChance;

        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int? DodgeChance { get { return dodgeChance; } set { dodgeChance = value; } }

        public MonsterAbility(string name, string description, int? dodgeChance)
        {
            Name = name;
            Description = description;
            DodgeChance = dodgeChance;


        }


        public static List<MonsterAbility> GoblinAbilities = new List<MonsterAbility>
        {
            
        };

        public static List<MonsterAbility> OrcAbilities = new List<MonsterAbility>
        {
           

        };

        public static List<MonsterAbility> CommonAbilities = new List<MonsterAbility>
        {
            new MonsterAbility("Sharper Weapon", "Gives more damage to the monster",0),
             new MonsterAbility("Thicker Hide", "Gives 5 more HP to the Orc", 0),
            new MonsterAbility("Improved Dodge", "Increases dodge chance for the monster",5)
        };

    }
}
