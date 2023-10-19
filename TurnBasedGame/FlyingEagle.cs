using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class FlyingEagle : MonsterConst
    {
        public FlyingEagle(string name, int hitPoints, int minAttackDamage, int maxAttackDamage, int minimumHeal, int maximumHeal, int maximumHealth, int experienceDrop)
        : base(name, hitPoints, minAttackDamage, maxAttackDamage, minimumHeal, maximumHeal, maximumHealth, experienceDrop)
        {
        }

        public bool Dodge()
        {
            int dodgeChance = MonsterSpawner.RandomNumber(1, 100); 
            return dodgeChance <= 20;//This does not work, need to 
        }
    }
}
