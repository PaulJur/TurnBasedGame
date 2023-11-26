using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame.Database
{
    public class GameDbContext : DbContext
    {
        public DbSet<GameSaveDBData> GameSaveData{  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=RPGDatabase;Trusted_Connection=true");
        }

    }

    public class GameSaveDBData
    {
        [Key]
        public int Id { get; set; }
        public string JsonData { get; set; }
    }


}
