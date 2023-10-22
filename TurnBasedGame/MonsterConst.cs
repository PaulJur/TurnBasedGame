using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    //General variables for the monster class and a constructor
    public class MonsterConst
    {
        #region Variables
        private string name;
        private int hitPoints;
        private int minimumAttackDamage;
        private int maximumAttackDamage;
        private int minimumHeal;
        private int maximumHeal;
        private int maximumHealth;
        private int experienceDrop;
        private int dodgeChance;
        #endregion

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }

        }
        public int HitPoints
        {
            get { return hitPoints; }
            set
            {
                hitPoints = value;
            }
        }

        public int MinimumAttackDamage
        {
            get { return minimumAttackDamage; }
            set
            {
                minimumAttackDamage = value;
            }
        }

        public int MaximumAttackDamage
        {
            get { return maximumAttackDamage; }
            set 
            { 
                maximumAttackDamage= value;
            }
        }

        public int MinimumHeal
        {
            get { return minimumHeal; }
            set 
            {
             minimumHeal= value;
            }
        }

        public int MaximumHeal
        {
            get { return maximumHeal; }
            set
            {
                maximumHeal = value;
            }
        }

        public int MaximumHealth
        {
            get { return maximumHealth; }
            set
            {
                maximumHealth= value;
            }
        }

        public int ExperienceDrop
        {
            get { return experienceDrop; }
            set
            {
                experienceDrop= value;
            }
        }

        public int DodgeChance
        {
            get { return dodgeChance; }
            set
            {
                dodgeChance = value;
            }
        }
        public MonsterConst(string name, int hitPoints, int minAttackDamage,int maxAttackDamge, int minmumheal, int maximumHeal, int maximumHealth,int xpDrop, int dodgeChance)
        {
            this.name = name;
            this.hitPoints = hitPoints;
            this.minimumAttackDamage = minAttackDamage;
            this.maximumAttackDamage = maxAttackDamge;
            this.minimumHeal = minmumheal;
            this.maximumHeal = maximumHeal;
            this.maximumHealth = maximumHealth;
            this.experienceDrop = xpDrop;
            this.dodgeChance= dodgeChance;
        }
        public bool Dodge(int dodgeChance)
        {
            int dodgeRoll = MonsterSpawner.RandomNumber(1, 100);

            if (dodgeRoll <= dodgeChance)
            {
                return true;
            }
            return false;
        }
    }

}
