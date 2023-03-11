using EntityList;
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
        public static Monster GetMonster(int monsterID)//a list of monsters that have their own ID and will be generated each encounter
        {
            switch(monsterID)
            {
                case 1:
                    Monster Goblin =
                        new Monster("Goblin", 10, 5, 8, 3, 5,10,5);
                    return Goblin;
                case 2:
                    Monster Orc =
                        new Monster("Orc", 15, 8,10, 7, 10,15,10);
                    return Orc;
                case 3:
                    Monster Troll =
                        new Monster("Troll", 25, 12,15, 8, 12,25,15);
                    return Troll;
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
