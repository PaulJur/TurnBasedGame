
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public static class MonsterSpawner
    {
        private static readonly Random _simpleGenerator = new Random();
        public static MonsterConst GetMonster(int monsterID)//a list of monsters that have their own ID and will be generated each encounter
        {
            switch(monsterID)
            {
                case 1:
                    MonsterConst Goblin =
                        new MonsterConst("Goblin", 10, 5, 8, 3, 5,10,5);
                    return Goblin;
                case 2:
                    MonsterConst Orc =
                        new MonsterConst("Orc", 15, 8,10, 7, 10,15,10);
                    return Orc;
                case 3:
                    MonsterConst Troll =
                        new MonsterConst("Troll", 25, 12,15, 8, 12,25,15);
                    return Troll;
                case 4:
                    MonsterConst flyingEagle = new MonsterConst("Flying Eagle", 12, 7, 13, 4, 5, 12, 9);
                    return flyingEagle;
                default:
                    throw new ArgumentException(String.Format("MonsterType '{0}' does not exist", monsterID));

            }

        }
        
        public static int RandomNumber(int minimumValue, int maximumValue)//Selects a number between values randomly
        {
            return _simpleGenerator.Next(minimumValue, maximumValue + 1);
        }



    }
}
