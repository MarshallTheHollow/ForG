using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GRate.Models
{
    public class AppGamesContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public AppGamesContext(DbContextOptions<AppGamesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string g = "rouge-like";
            Genre firstg = new Genre { Id = 1, Name = g };
            Game firstgame = new Game { Id = 1, GameName = "Dunno", CompanyName = "Pixel Hunting Studio", GenreId = firstg.Id, GameDiscription = "Еще нет", GameReleaseTime = new DateTime(2022, 5, 4, 0, 0, 0), Image = "default" };
            modelBuilder.Entity<Genre>().HasData(new Genre[] { firstg});
            modelBuilder.Entity<Game>().HasData(new Game[] { firstgame });
            base.OnModelCreating(modelBuilder);
        }
    }
}
