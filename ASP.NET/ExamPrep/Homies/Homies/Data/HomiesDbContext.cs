using Homies.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Type = Homies.Data.Models.Type;

namespace Homies.Data
{
    /// <summary>
    /// Db context
    /// </summary>
    public class HomiesDbContext : IdentityDbContext
    {
        /// <summary>
        /// Events table
        /// </summary>
        public DbSet<Event> Events { get; set; }

        /// <summary>
        /// Types table
        /// </summary>
        public DbSet<Type> Types { get; set; }

        /// <summary>
        /// Joining table for many-to-many relationship between Events and Types
        /// </summary>
        public DbSet<EventParticipant> EventsParticipants { get; set; }

        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //setting complex key for joining table
            modelBuilder.Entity<EventParticipant>()
                .HasKey(e => new { e.HelperId, e.EventId });

            //setting on delete behavior
            modelBuilder.Entity<EventParticipant>()
                .HasOne(e => e.Event)
                .WithMany(e => e.EventsParticipants)
                .HasForeignKey(e => e.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            //seeding data to Types table
            modelBuilder
                .Entity<Type>()
                .HasData(new Type()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new Type()
                {
                    Id = 2,
                    Name = "Fun"
                },
                new Type()
                {
                    Id = 3,
                    Name = "Discussion"
                },
                new Type()
                {
                    Id = 4,
                    Name = "Work"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}