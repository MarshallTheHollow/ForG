using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GRate.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameReview> Review { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminLogin = "MarshallTheHollow";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Login = adminLogin, Password = adminPassword, RoleId = adminRole.Id };
    
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            
            string g = "rouge-like";
            Genre firstg = new Genre { Id = 1, Name = g };
            Game firstgame = new Game { Id = 1, GameName = "Dunno", CompanyName = "Pixel Hunting Studio", GenreId = firstg.Id, GameDiscription = "Еще нет", GameReleaseTime = new DateTime(2022, 5, 4, 0, 0, 0), };
            GameReview gr = new GameReview { Id=1, UserId = adminUser.Id, GameId = firstgame.Id, Description = "Лучшее во что я играл", Rate = 5 };
            
            modelBuilder.Entity<GameReview>().HasData(new GameReview[] {gr });
            modelBuilder.Entity<Genre>().HasData(new Genre[] { firstg });
            modelBuilder.Entity<Game>().HasData(new Game[] { firstgame });       
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
