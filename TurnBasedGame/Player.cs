using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TurnBasedGame
{
    //Player class for variables and their get; sets;
    public class Player
    {
        private string _name;
        private int _hitPoints;
        private int _attackDamage;
        private int _heal;
        private int _maximumHeal;
        private int _minimumHeal;
        private int _maximumDamage;
        private int _minimumDamage;
        private int _maximumHitPoints;

        private int _experience;
        private int _level;

        public Player(string name, int hitPoints,int maximumHitPoints,int minimumHeal, int maximumHeal, int minimumDamage, int maximumDamage,int experience, int level)
        {
            _name = name;
            _hitPoints = hitPoints;
            _maximumHitPoints = maximumHitPoints;
            _maximumHeal = maximumHeal;
            _minimumHeal = minimumHeal;
            _maximumDamage = maximumDamage;
            _minimumDamage = minimumDamage;
            _experience = experience;
            _level = level;
        }

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
        public int Experience
        {
            get { return _experience; }
            set
            {
                _experience = value;
            }
        }
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
            }
        }
        public int maximumHeal
        {
            get { return _maximumHeal; }
            set
            {
                _maximumHeal = value;
            }
        }
        public int minimumHeal
        {
            get { return _minimumHeal; }
            set
            {
                _minimumHeal = value;
            }
        }
        public int maximumDamage
        {
            get { return _maximumDamage; }
            set
            {
                _maximumDamage = value;
            }

        }
        public int minimumDamage
        {
            get { return _minimumDamage; }
            set
            {
                _minimumDamage = value;
            }
        }
        public int maximumHitPoints
        {
            get { return _maximumHitPoints; }
            set
            {
                _maximumHitPoints = value;
            }
        }
    }
}
