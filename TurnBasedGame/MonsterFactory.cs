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
            List<MonsterAbility> commonAbilities = MonsterAbility.CommonAbilities.ToList();
            MonsterAbility ability = GetMonsterAbility(commonAbilities);

            return new MonsterConst("Goblin", (int)(10 * levelMultiplier), (int)(5 * levelMultiplier),
                (int)(8 * levelMultiplier), (int)(3 * levelMultiplier), (int)(3 * levelMultiplier),
                (int)(10 * levelMultiplier), (int)(5 * levelMultiplier), 20, ability);
        }

        public static MonsterConst CreateOrc(double levelMultiplier)
        {
            List<MonsterAbility> commonAbilities = MonsterAbility.CommonAbilities.ToList();
            MonsterAbility ability = GetMonsterAbility(commonAbilities);

            return new MonsterConst("Orc", (int)(15 * levelMultiplier), (int)(8 * levelMultiplier),
                (int)(10 * levelMultiplier), (int)(7 * levelMultiplier), (int)(10 * levelMultiplier),
                (int)(15 * levelMultiplier), (int)(10 * levelMultiplier), 15, ability);
        }

        public static MonsterConst CreateTroll(double levelMultiplier)
        {
            List<MonsterAbility> commonAbilities = MonsterAbility.CommonAbilities.ToList();
            MonsterAbility ability = GetMonsterAbility(commonAbilities);

            return new MonsterConst("Troll", (int)(25 * levelMultiplier), (int)(12 * levelMultiplier),
                (int)(15 * levelMultiplier), (int)(8 * levelMultiplier), (int)(12 * levelMultiplier),
                (int)(25 * levelMultiplier), (int)(15 * levelMultiplier), 10, ability);
        }

        public static MonsterConst CreateFlyingEagle(double levelMultiplier)
        {
            List<MonsterAbility> commonAbilities = MonsterAbility.CommonAbilities.ToList();
            MonsterAbility ability = GetMonsterAbility(commonAbilities);

            return new MonsterConst("Giant Flying Eagle", (int)(12 * levelMultiplier), (int)(7 * levelMultiplier),
                (int)(13 * levelMultiplier), (int)(4 * levelMultiplier), (int)(5 * levelMultiplier),
                (int)(12 * levelMultiplier), (int)(9 * levelMultiplier), 30, ability);
        }

        public static MonsterConst CreateOrcBoss()
        {
            return new MonsterConst("Orc Boss", 35, 12, 15, 8, 13, 35, 25, 20,null);
        }

        private static MonsterAbility GetMonsterAbility(List<MonsterAbility> commonAbilities)
        {
            List<MonsterAbility> monsterAbilityPool = new List<MonsterAbility>(commonAbilities);

            MonsterAbility randomAbility = RandomMonsterAbility(monsterAbilityPool);

            return randomAbility;

        }

        // Fisher-Yates shuffle algorithm
        private static MonsterAbility RandomMonsterAbility(List<MonsterAbility> abilities)
        {
            int randomIndex = MonsterSpawner.RandomNumber(0, abilities.Count);

            if (randomIndex >= 0 && randomIndex < abilities.Count)
            {
                MonsterAbility randomAbility = abilities[randomIndex];
                return randomAbility;
            }
            else
            {
                Console.WriteLine("Invalid index generated.");
                return null;
            }

        }

    }
}
