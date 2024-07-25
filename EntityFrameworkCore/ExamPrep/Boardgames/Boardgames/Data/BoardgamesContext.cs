﻿namespace Boardgames.Data
{
    using Microsoft.EntityFrameworkCore;

    public class BoardgamesContext : DbContext
    {
        public BoardgamesContext()
        {
        }

        public BoardgamesContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User))
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
