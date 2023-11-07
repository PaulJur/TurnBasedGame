using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace TurnBasedGame
{
    internal class SaveData
    {
        internal Player Player { get; set; }
        internal MonsterConst MonsterConst { get; set; }

        internal SaveData(Player player, MonsterConst currentMonster) 
        {
            Player = player;
            MonsterConst = currentMonster;
        }
    }


    public static class DataSaveAndLoad
    {

        public static void SaveGame(Player player, MonsterConst currentMonster)
        {
            var saveData = new SaveData(player, currentMonster);
            string jsonData = JsonSerializer.Serialize(saveData);

            File.WriteAllText("save.json", jsonData);
        }

        public static (Player,MonsterConst) LoadGame()
        {
            if (File.Exists("save.json"))
            {
                string jsonData = File.ReadAllText("save.json");
                SaveData saveData = JsonSerializer.Deserialize<SaveData>(jsonData);

                return (saveData.Player, saveData.MonsterConst);
            }
            else
            {
                return (null, null);
            }
        }


    }
}
