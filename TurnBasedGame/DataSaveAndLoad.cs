using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TurnBasedGame
{
    
    public static class DataSaveAndLoad
    {
        internal class SaveData
        {
            public Player player { get; set; }
            public MonsterConst monsterConst { get; set; }

            [JsonConstructor]
            public SaveData(Player player, MonsterConst monsterConst)
            {
                this.player = player;
                this.monsterConst = monsterConst;
            }
        }

        public static void SaveGame(Player player, MonsterConst monsterConst)
        {
            var saveData = new SaveData(player, monsterConst);
            var jsonData = JsonSerializer.Serialize(saveData);
            Console.WriteLine(jsonData);

            File.WriteAllText("save.json", jsonData);
        }

        public static (Player,MonsterConst) LoadGame()
        {
            if (File.Exists("save.json"))
            {
                string jsonData = File.ReadAllText("save.json");
                SaveData saveData = JsonSerializer.Deserialize<SaveData>(jsonData);

                return (saveData.player, saveData.monsterConst);
            }
            else
            {
                return (null, null);
            }
        }


    }
}
