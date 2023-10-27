using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class MonsterFactory
    {

        //Class for monsters, dodge chance will always be left as default.
        public static MonsterConst CreateGoblin(double levelMultiplier)
        {
            return new MonsterConst("Goblin", (int)(10 * levelMultiplier), (int)(5 * levelMultiplier), 
                (int)(8 * levelMultiplier), (int)(3 * levelMultiplier), (int)(3 * levelMultiplier), 
                (int)(10 * levelMultiplier), (int)(5 * levelMultiplier), 20);
        }

        public static MonsterConst CreateOrc(double levelMultiplier)
        {
            return new MonsterConst("Orc", (int)(15 * levelMultiplier), (int)(8 * levelMultiplier), 
                (int)(10 * levelMultiplier), (int)(7 * levelMultiplier), (int)(10 * levelMultiplier), 
                (int)(15 * levelMultiplier), (int)(10 * levelMultiplier), 15);
        }

        public static MonsterConst CreateTroll(double levelMultiplier)
        {
            return new MonsterConst("Troll", (int)(25 * levelMultiplier), (int)(12 * levelMultiplier),
                (int)(15 * levelMultiplier), (int)(8 * levelMultiplier), (int)(12 * levelMultiplier), 
                (int)(25 * levelMultiplier), (int)(15 * levelMultiplier), 10);
        }

        public static MonsterConst CreateFlyingEagle(double levelMultiplier)
        {
            return new MonsterConst("Giant Flying Eagle", (int)(12 * levelMultiplier), (int)(7 * levelMultiplier), 
                (int)(13 * levelMultiplier), (int)(4 * levelMultiplier), (int)(5 * levelMultiplier), 
                (int)(12 * levelMultiplier), (int)(9 * levelMultiplier), 30);
        }

        public static MonsterConst CreateOrcBoss()
        {
            return new MonsterConst("Orc Boss", 35, 12, 15, 8, 13, 35, 25, 20);
        }

    }
}
