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
using System.Numerics;

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

            using (var context = new GameDbContext())
            {
                var existingSave = context.GameSaveData.FirstOrDefault();//grabs the first element of the database.

                if(existingSave != null)//If first element in the database does not equal null, it will overwrite the data with a new save data aka overwriting.
                {
                    Console.WriteLine("Are you sure you want to overwrite your save? Y or N");

                    string answer = Console.ReadLine();

                    if(answer == "Y")
                    {
                        var saveData = new SaveData(player, monsterConst, inventory.Items);
                        var jsonData = JsonSerializer.Serialize(saveData);

                        existingSave.JsonData = jsonData;

                        context.SaveChanges();
                        Console.WriteLine("Game overwritten successfully");
                    }
                    else
                    {
                        return;
                    }

                    
                }
                else//if no data is found in the first element, create a new save.
                {
                    var saveData = new SaveData(player, monsterConst, inventory.Items);
                    var jsonData = JsonSerializer.Serialize(saveData);

                    var saveDataEntity = new GameSaveDBData
                    {
                        JsonData = jsonData
                    };

                    context.GameSaveData.Add(saveDataEntity);
                    context.SaveChanges();

#if DEBUG
                    Console.WriteLine(jsonData);
#endif          
                }


            }

            //File.WriteAllText("PlayerSave.json", jsonData); THIS IS FOR SAVING TO JSON FILE
        }


        
        public static (Player,MonsterConst,Inventory) LoadGame() //Loads saved JSON data from first database element and returns the entities and their values.
        {
            using (var context = new GameDbContext())
            {
                var DBSavedData = context.GameSaveData.FirstOrDefault();

                if(DBSavedData != null)
                {
                   



                    var jsonData = DBSavedData.JsonData;//Grabs the JSON data from DB first element.
                    var saveData = JsonSerializer.Deserialize<SaveData>(jsonData);

                    var inventory = new Inventory();

                    Console.WriteLine("Are you sure you want to load your save? Y or N\n");

                    Console.WriteLine($"Name: {saveData.player.Name} Level: {saveData.player.Level} HP: {saveData.player.HitPoints}\n");
                    Console.WriteLine("With these items in your inventory\n");

                    if (inventory.Items.Count <= 0)//If there are no items in the list, then none will be displayed with the message.
                    {
                        Console.WriteLine("You have no items");
                    }
                    else
                    {
                        foreach (var item in inventory.Items)//This will display every item in the players inventory in the save.
                        {
                            Console.WriteLine(item.Name);
                        }
                    }

                    Console.WriteLine($"\nAgainst monster {saveData.monsterConst.Name} HP: {saveData.monsterConst.HitPoints}");

                    string answer = Console.ReadLine();

                    if( answer == "Y")
                    {
                        return (saveData.player, saveData.monsterConst, inventory);
                    }
                    else
                    {
                        return (null, null, null);
                    }

                   
                }
                else //If no JSON file is found, a new game will be started with a fresh character.
                {
                    Console.WriteLine("No save found. Starting a new game");
                    return (null, null, null);
                }
            }




        }//Loads the saved JSON file and deserializes the data so it loads the Inventory items, player stats and monster. The way SaveData syntax is writen is very important. Player player and this.player etc.

         //Check if the files exists in the folder, can set custom pathing.
        /* if (File.Exists("PlayerSave.json"))
         {

             string jsonData = File.ReadAllText("PlayerSave.json");

             //Savedata receives the Player and Monster 
             SaveData saveData = JsonSerializer.Deserialize<SaveData>(jsonData);

             var inventory = new Inventory();//New inventory instance
             inventory.Items = saveData.inventoryItems;


             return (saveData.player, saveData.monsterConst,inventory);*/

    }

}
 