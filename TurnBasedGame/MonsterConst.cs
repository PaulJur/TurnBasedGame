using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityList
{
    //General variables for the monster class and a constructor
    public class Monster
    {
        #region Variables
        private string _name;
        private int _hitPoints;
        private int _minimumAttackDamage;
        private int _maximumAttackDamage;
        private int _minimumHeal;
        private int _maximumHeal;
        private int _maximumHealth;
        #endregion

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }

        }
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
            }
        }

        public int MinimumAttackDamage
        {
            get { return _minimumAttackDamage; }
            set
            {
                _minimumAttackDamage = value;
            }
        }

        public int MaximumAttackDamage
        {
            get { return _maximumAttackDamage; }
            set 
            { 
                _maximumAttackDamage= value;
            }
        }

        public int MinimumHeal
        {
            get { return _minimumHeal; }
            set 
            {
             _minimumHeal= value;
            }
        }

        public int MaximumHeal
        {
            get { return _maximumHeal; }
            set
            {
                _maximumHeal = value;
            }
        }

        public int MaximumHealth
        {
            get { return _maximumHealth; }
            set
            {
                _maximumHealth= value;
            }
        }

        public Monster(string name, int hitPoints, int minAttackDamage,int maxAttackDamge, int minmumheal, int maximumHeal, int maximumHealth)
        {
            Name = name;
            HitPoints = hitPoints;
            _minimumAttackDamage = minAttackDamage;
            _maximumAttackDamage = maxAttackDamge;
            _minimumHeal = minmumheal;
            _maximumHeal = maximumHeal;
            HitPoints = hitPoints;
            _maximumHealth = maximumHealth;
        }
    }

}
