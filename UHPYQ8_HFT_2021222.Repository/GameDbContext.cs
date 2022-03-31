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
            .HasOne(Game => Game.Publisher)
            .WithMany(Publisher => Publisher.Games)
            .HasForeignKey(Game => Game.PublisherId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Game>(Game => Game
            .HasOne(Game => Game.Platform)
            .WithMany(Platform => Platform.Games)
            .HasForeignKey(Game => Game.PlatformId)
            .OnDelete(DeleteBehavior.Cascade));

        }
    }
}
