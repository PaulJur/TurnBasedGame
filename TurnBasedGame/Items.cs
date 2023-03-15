using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class Items
    {
        private string _name;
        private string _description;
        private int _minattackDamage;
        private int _maxattackDamage;
        private int _maxhealing;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }
        public int maxAttackDamage
        {
            get { return _maxattackDamage; }
            set
            {
                _maxattackDamage = value;
            }
        }
        public int minAttackDamage
        {
            get { return _minattackDamage; }
            set
            {
                _minattackDamage = value;
            }
        }
        public int maxhealing
        {
            get { return _maxhealing; }
            set
            {
                _maxhealing = value;
            }
        }


        public Items(string Name, string Description, int minAttack, int maxAttack)
        {
            _name=Name;
            _description=Description;
            _minattackDamage=minAttack;
            _maxattackDamage=maxAttack;
        }
        public Items(string Name,int maxHealing, string Description)
        {
            _name=Name;
            _description=Description;
            _maxhealing=maxhealing;
        }

        
    }


}
