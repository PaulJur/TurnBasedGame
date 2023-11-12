using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class Items
    {
        private string name;
        private string description;
        private int? minimumAttackDamage;
        private int? maximumAttackDamage;
        private int? maximumHealing;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
            }
        }
        public int? MaximumAttackDamage
        {
            get { return maximumAttackDamage; }
            set
            {
                maximumAttackDamage = value;
            }
        }
        public int? MinimumAttackDamage
        {
            get { return minimumAttackDamage; }
            set
            {
                minimumAttackDamage = value;
            }
        }
        public int? MaximumHealing
        {
            get { return maximumHealing; }
            set
            {
                maximumHealing = value;
            }
        }

        [JsonConstructor]
        public Items(string name, string description, int? minimumAttackDamage = null, int? maximumAttackDamage = null, int? maximumHealing = null )
        {
            Name = name;
            Description = description;
            MinimumAttackDamage = minimumAttackDamage;
            MaximumAttackDamage = maximumAttackDamage;
            MaximumHealing = maximumHealing;
        }
    }


}
