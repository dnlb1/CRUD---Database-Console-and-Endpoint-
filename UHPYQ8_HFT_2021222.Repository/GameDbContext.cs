using Microsoft.EntityFrameworkCore;
using System;
using UHPYQ8_HFT_2021222.Models;

namespace UHPYQ8_HFT_2021222.Repository
{
    public class GameDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Game_publisher> Game_Publishers { get; set; }

        public GameDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("game").UseLazyLoadingProxies();
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(Game => Game
            .HasOne(Game => Game.Platform)
            .WithMany(Platform => Platform.Games)
            .HasForeignKey(Game => Game.PlatformId)
            .OnDelete(DeleteBehavior.Cascade)
            );

            modelBuilder.Entity<Publisher>()
                .HasMany(x => x.Games)
                .WithMany(x => x.Publishers)
                .UsingEntity<Game_publisher>(
                x => x.HasOne(x => x.Game)
                .WithMany()
                .HasForeignKey(x => x.GameId).OnDelete(DeleteBehavior.Cascade),
                x => x.HasOne(x => x.Publisher)
                .WithMany().HasForeignKey(x => x.PublisherId).OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Game>().HasData(new Game[]
         {
                new Game("1#Elden Ring#50#1#7,9#1"),
                new Game("2#Black Desert Online#30#2#8,7#1"),
                new Game("3#League of Legends#19#1#9,2#1"),
                new Game("4#Mario Kart#20#3#5,4#2"),
                new Game("5#Destiny 2#40#4#7,1#2"),
                new Game("6#God of War#77#5#9,2#3"),
                new Game("7#Roblox#10#6#3,3#4"),
                new Game("8#Minecraft#59#7#8,6#5"),
                new Game("9#Fortnite#23#8#4,6#6"),
                new Game("10#Hades#30#9#2,2#6"),

         });

            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
          {
                   new Publisher("1#Kakao Games"),
                   new Publisher("2#Sajobabonyi Zrt."),
                   new Publisher("3#Tencent Games"),
                   new Publisher("4#Sony Interactive Entertainment"),
                   new Publisher("5#Nintendo"),
                   new Publisher("6#Microsoft"),
                   new Publisher("7#Java"),
                   new Publisher("8#Pankix"),
                   new Publisher("9#Ubisoft"),
                   new Publisher("10#Capcorn")

          });
            modelBuilder.Entity<Platform>().HasData(new Platform[]
          {
                new Platform("1#Steam"),
                new Platform("2#Epic Launcher"),
                new Platform("3#XBOX"),
                new Platform("4#Switch"),
                new Platform("5#Mobile"),
                new Platform("6#IOS"),
          });

        }
    }
}
