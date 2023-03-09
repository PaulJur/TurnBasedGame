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
        public int AttackDamage { get; set; }
        public int Heal { get; set; }
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

        public Monster(string name, int hitPoints, int attackDamage, int heal)
        {
            Name = name;
            HitPoints = hitPoints;
            AttackDamage = attackDamage;
            Heal = heal;
            HitPoints = hitPoints;
        }
    }

}
