using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class Player
    {
        private string _name;
        private int _hitPoints;
        private int _attackDamage;
        private int _heal;

        public String Name
        {
            get { return _name; }
            set
            {
                _name= value;
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
        public int AttackDamage
        {
            get { return _attackDamage; }
            set
            {
                _attackDamage = value;
            }
        }
        public int Heal
        {
            get { return _heal; }
            set
            {
                _heal = value;
            }
        }
    }
}
