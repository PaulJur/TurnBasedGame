using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TurnBasedGame
{
    //Player class for variables and their get; sets;
    public class Player
    {
        #region PlayerStatVariables
        private string name;
        private int hitPoints;
        private int attackDamage;
        private int maximumHeal;
        private int minimumHeal;
        private int maximumDamage;
        private int minimumDamage;
        private int maximumHitPoints;

        private int experience;
        private int level;

        private int experienceRequired = 10;
        #endregion

        public String Name
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
        public int MaximumHp
        {
            get { return maximumHitPoints; }
            set
            {
                maximumHitPoints = value;
            }
        }
        public int MinimumHeal
        {
            get { return minimumHeal; }
            set
            {
                minimumHeal = value;
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
        public int MinimumDamage
        {
            get { return minimumDamage; }
            set
            {
                minimumDamage = value;
            }
        }
        public int MaximumDamage
        {
            get { return maximumDamage; }
            set
            {
                maximumDamage = value;
            }

        }
        public int ExperienceAmount
        {
            get { return experience; }
            set
            {
                experience = value;
            }
        }
        public int Level
        {
            get { return level; }
            set
            {
                level = value;
            }
        }
        public int AttackDamage
        {
            get { return attackDamage; }
            set
            {
                attackDamage = value;
            }
        }
        public int ExperienceRequired
        {
            get { return experienceRequired; }
            set { experienceRequired = value; }
        }

       
        
        public Player(string name, int hitPoints,int maximumHitPoints,int minimumHeal, int maximumHeal, int minimumDamage, int maximumDamage,int experienceAmount, int level, int attackDamage,int experienceRequired)
        {
            Name = name;
            HitPoints = hitPoints;
            MaximumHp = maximumHitPoints;
            ExperienceAmount = experience;
            MinimumHeal = minimumHeal;
            MaximumHeal = maximumHeal;
            MaximumDamage = maximumDamage;
            MinimumDamage = minimumDamage;
            ExperienceAmount = experienceAmount;
            Level = level;
            AttackDamage = attackDamage;
            ExperienceRequired = experienceRequired;
        }

        public void PlayerExperienceGain(int _monsterExperienceDrop)//When monster is killed experience gets added to the player and they level up
        {
            ExperienceAmount += _monsterExperienceDrop;

            if(ExperienceAmount >= experienceRequired)
            {
                PlayerLevelUp();
            }
        }

        private void PlayerLevelUp()//Player levels up, damage, healing scales up. Experience is set to 0  then the experience to level up goes up by 50%
        {
            Level++;
            HitPoints += maximumHitPoints/3;
            maximumHitPoints += 5;
            minimumDamage = (int)Math.Round(minimumDamage * 1.1);
            maximumDamage = (int)Math.Round(maximumDamage * 1.15);
            minimumHeal = (int)Math.Round(minimumHeal * 1.1);
            maximumHeal = (int)Math.Round(maximumHeal * 1.15);
            ExperienceAmount = 0;
            experienceRequired = (int)Math.Round(experienceRequired * 1.7);
            Console.WriteLine("You have Leveled up!");
        }

        public int Attack()
        {
            int damage = MonsterSpawner.RandomNumber(minimumDamage,maximumDamage);
            AttackDamage = damage;

            return damage;
        }

        public void EquipSword(Items sword)
        {
            minimumDamage += sword.minAttackDamage;
            maximumDamage += sword.maxAttackDamage;
        }
        public void UsePotion(Items potion)
        {
            HitPoints += potion.maxhealing;
            if(HitPoints > maximumHitPoints)
            {
                HitPoints= maximumHitPoints;
            }
        }
    }

    

}
