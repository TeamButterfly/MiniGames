using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BuisnessLogic
{
    public class DatabaseContext : DbContext
    {
        private static readonly string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=Minigame;Trusted_Connection=True;";

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.Username })
                .IsUnique(true);

            modelBuilder.Entity<Account>()
                .HasIndex(a => new { a.UserId })
                .IsUnique(true);
        }
    }
}
