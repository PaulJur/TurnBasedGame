using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class MonsterEncounterPercnt
    {
        public int MonsterID { get; set;}
        public int encounterChance { get; set;}
        
        public MonsterEncounterPercnt(int monsterID,int chance)
        {
            MonsterID = monsterID;
            encounterChance = chance;
        }

    }
}
