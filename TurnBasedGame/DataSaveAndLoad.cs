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
            public Player Player { get; set; }
            public MonsterConst MonsterConst { get; set; }

            [JsonConstructor]
            public SaveData(Player player, MonsterConst currentMonster)
            {
                Player = player;
                MonsterConst = currentMonster;
            }
        }

        public static void SaveGame(Player currentPlayer, MonsterConst currentMonster)
        {
            var saveData = new SaveData(currentPlayer, currentMonster);
            var options = new JsonSerializerOptions { IncludeFields = true };
            var jsonData = JsonSerializer.Serialize(saveData,options);
            Console.WriteLine(jsonData);

            File.WriteAllText("save.json", jsonData);
        }

        public static (Player,MonsterConst) LoadGame()
        {
            if (File.Exists("save.json"))
            {
                string jsonData = File.ReadAllText("save.json");
                var options = new JsonSerializerOptions { IncludeFields = true };
                SaveData saveData = JsonSerializer.Deserialize<SaveData>(jsonData,options);

                return (saveData.Player, saveData.MonsterConst);
            }
            else
            {
                return (null, null);
            }
        }


    }
}
