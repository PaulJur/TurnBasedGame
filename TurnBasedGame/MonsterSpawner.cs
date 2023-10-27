
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
        public static MonsterConst GetMonster(int monsterID, int playerLevel)//a list of monsters that have their own ID and will be generated each encounter
        {
            double levelMultiplier = CalculateLevelMultiplier(playerLevel);

            switch (monsterID)
            {

                case 1:
                    return MonsterFactory.CreateGoblin(levelMultiplier);
                case 2:
                    return MonsterFactory.CreateOrc(levelMultiplier);
                case 3:
                    return MonsterFactory.CreateTroll(levelMultiplier);
                case 4:
                    return MonsterFactory.CreateFlyingEagle(levelMultiplier);
                case 95:
                    return MonsterFactory.CreateOrcBoss();
                default:
                    return MonsterFactory.CreateGoblin(levelMultiplier);

            }

        }
        
        public static int RandomNumber(int minimumValue, int maximumValue)//Selects a number between values randomly
        {
            return _simpleGenerator.Next(minimumValue, maximumValue + 1);
        }

        private static double CalculateLevelMultiplier(int playerLevel)
        {

            int levelReached = (playerLevel - 1) / 5;
            double levelMultiplier = 0.3;

            double totalMultiplier =  Math.Pow(1 + levelMultiplier,levelReached); //every 5 levels, to the power of 1.2^0.2 

            return totalMultiplier;
        }

    }
}
