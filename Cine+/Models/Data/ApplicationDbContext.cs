using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cine_.Models.Entities;
using Cine_.Models.Relations;

namespace Cine_.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Shift> Shifts { get; set; }

        public DbSet<SpecialDate> SpecialDates { get; set; }

        public DbSet<SpecialUser> SpecialUsers { get; set; }

        public DbSet<DiscountType> DiscountTypes { get; set; }

        public DbSet<Presentation> Presentations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Presentation>().HasKey(m => new { m.MovieID, m.RoomID, m.ShiftID, m.Date });

        }
    }
}
