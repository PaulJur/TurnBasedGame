using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using TurnBasedGame.Database;

namespace TurnBasedGame
{
    
    public static class DataSaveAndLoad
    {
        internal class SaveData //Player and monster constructor for save data
        {
            public Player player { get; set; }
            public MonsterConst monsterConst { get; set; }

            public List<Items> inventoryItems { get; set; }

            [JsonConstructor]
            public SaveData(Player player, MonsterConst monsterConst, List<Items> inventoryItems)
            {
                this.player = player;
                this.monsterConst = monsterConst;
                this.inventoryItems = inventoryItems;
            }
        }
        //Serializes the Player, Monster and Inventory Items and puts into a local database, will store into a json file if not found
        public static void SaveGame(Player player, MonsterConst monsterConst,Inventory inventory)
        {
            var saveData = new SaveData(player, monsterConst, inventory.Items);
            var jsonData = JsonSerializer.Serialize(saveData);


            using (var context = new GameDbContext())
            {
                var saveDataEntity = new GameSaveDBData
                {
                    JsonData = jsonData
                };

                context.GameSaveData.Add(saveDataEntity);
                context.SaveChanges();
            }

#if DEBUG
                Console.WriteLine(jsonData);
#endif

            //File.WriteAllText("PlayerSave.json", jsonData);
        }


        //Loads the saved JSON file and deserializes the data so it loads the Inventory items, player stats and monster. The way SaveData syntax is writen is very important. Player player and this.player etc.
        public static (Player,MonsterConst,Inventory) LoadGame()
        {
            //Check if the files exists in the folder, can set custom pathing.
            if (File.Exists("PlayerSave.json"))
            {
                
                string jsonData = File.ReadAllText("PlayerSave.json");

                //Savedata receives the Player and Monster 
                SaveData saveData = JsonSerializer.Deserialize<SaveData>(jsonData);

                var inventory = new Inventory();//New inventory instance
                inventory.Items = saveData.inventoryItems;


                return (saveData.player, saveData.monsterConst,inventory);
                    
                    
            }else //If no JSON file is found, a new game will be started with a fresh character.
            {
                Console.WriteLine("No save found. Starting a new game");
                return (null, null,null);
            }
        }
            
           
    }

}
 