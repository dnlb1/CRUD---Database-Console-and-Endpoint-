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
                new Game("1#Elden Ring#50#7,9#1"),
                new Game("2#Black Desert Online#30#8,7#1"),
                new Game("3#League of Legends#19#9,2#1"),
                new Game("4#Mario Kart#20#5,4#2"),
                new Game("5#Destiny 2#40#7,1#2"),
                new Game("6#God of War#77#9,2#3"),
                new Game("7#Roblox#10#3,3#4"),
                new Game("8#Minecraft#59#8,6#5"),
                new Game("9#Fortnite#23#4,6#6"),
                new Game("10#Hades#30#2,2#6"),
                new Game("11#Core Keeper#25#7,2#1"),
                new Game("12#Sudoku#2#4,2#6"),
                new Game("13#Tekken 7#30#8#3"),
                new Game("14#Rising Hell#8#5,4#4"),
                new Game("15#Blade & Sorcery#24#5,5#3"),
                new Game("16#Legendary Tales#32#5,5#5"),

         });

            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
          {
                  new Publisher("1#Kakao Games"),
                   new Publisher("2#Pearl Abys"),
                   new Publisher("3#Tencent Games"),
                   new Publisher("4#Sony Interactive Entertainment"),
                   new Publisher("5#Nintendo"),
                   new Publisher("6#Microsoft"),
                   new Publisher("7#Pankix"),
                   new Publisher("8#Riot"),
                   new Publisher("9#Ubisoft"),
                   new Publisher("10#FromSoftware Inc.")

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
            modelBuilder.Entity<Game_publisher>().HasData(new Game_publisher[]
            {
                new Game_publisher("1#1#10#2022"),
                new Game_publisher("2#1#9#2022"),
                new Game_publisher("3#2#1#2014"),
                new Game_publisher("4#2#2#2018"),
                new Game_publisher("5#3#8#2009"),
                new Game_publisher("6#4#5#1999"),
                new Game_publisher("7#4#4#2005"),
                new Game_publisher("8#4#9#2015"),
                new Game_publisher("9#5#6#2017"),
                new Game_publisher("10#6#3#2011"),
                new Game_publisher("11#7#7#2004"),
                new Game_publisher("12#7#6#2012"),
                new Game_publisher("13#8#6#2010"),
                new Game_publisher("14#8#10#2022"),
                new Game_publisher("15#9#6#2005"),
                new Game_publisher("16#9#7#2007"),
                new Game_publisher("17#9#8#2014"),
                new Game_publisher("18#10#4#2012"),
                new Game_publisher("19#10#6#2019"),
                new Game_publisher("20#11#7#2001"),
                new Game_publisher("21#11#9#2011"),
                new Game_publisher("22#12#4#2004"),
                new Game_publisher("23#13#3#2007"),
                new Game_publisher("24#14#2#2021"),
                new Game_publisher("25#15#2#2017"),
                new Game_publisher("26#15#5#2021"),
                new Game_publisher("27#16#3#2022"),
            });

        }
    }
}
