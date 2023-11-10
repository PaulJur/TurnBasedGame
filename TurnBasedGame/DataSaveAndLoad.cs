using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace TurnBasedGame
{
    
    public static class DataSaveAndLoad
    {
        internal class SaveData //Player and monster constructor for save data
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
        //Serializes both the Player and the Monster into a JSON file
        public static void SaveGame(Player player, MonsterConst monsterConst)
        {
            var saveData = new SaveData(player, monsterConst);
            var jsonData = JsonSerializer.Serialize(saveData);

            Console.WriteLine(jsonData);
            File.WriteAllText("PlayerSave.json", jsonData);
        }


        //Loads the saved JSON file and deserializes the data so it loads the monster and player stats. The way SaveData syntax is writen is very important. Player player and this.player etc.
        public static (Player,MonsterConst) LoadGame()
        {
            //Check if the files exists in the folder, can set custom pathing.
            if (File.Exists("PlayerSave.json"))
            {
                
                string jsonData = File.ReadAllText("PlayerSave.json");

                //Savedata receives the Player and Monster 
                SaveData saveData = JsonSerializer.Deserialize<SaveData>(jsonData);


                return (saveData.player, saveData.monsterConst);
                    
                    
            }else //If no JSON file is found, a new game will be started with a fresh character.
            {
                Console.WriteLine("No save found. Starting a new game");
                return (null, null);
            }
        }
            
           
    }

}
