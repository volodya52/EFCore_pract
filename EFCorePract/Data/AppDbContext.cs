using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCorePract.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCorePract.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Users>Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<InterestGroup> InterestGroups { get; set; }
        public DbSet<UserInterestGroup> UsersInterestGroups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sql.ects;Database=Users4;User Id=student_05;Password=student_05;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>( )
                .HasOne(s => s.UserProfile)
                .WithOne(ps => ps.User)
                .HasForeignKey<UserProfile>(ps => ps.UserId);

            modelBuilder.Entity<Role>( )
                .HasMany(r => r.Users)
                .WithOne(s => s.Role)
                .HasForeignKey(s => s.RoleId);

            modelBuilder.Entity<UserInterestGroup>( )
                .HasKey(ui => new { ui.UserId, ui.InterestGroupId });

            modelBuilder.Entity<UserInterestGroup>( )
                .HasOne(ui => ui.User)
                .WithMany(u => u.UserInterestGroups)
                .HasForeignKey(ui => ui.UserId);

            modelBuilder.Entity<UserInterestGroup>( )
                .HasOne(ui => ui.InterestGroup)
                .WithMany(i => i.UserInterestGroups)
                .HasForeignKey(ui => ui.InterestGroupId);

        }
    }
}
