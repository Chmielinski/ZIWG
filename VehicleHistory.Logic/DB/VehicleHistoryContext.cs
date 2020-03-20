using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VehicleHistory.Logic.Models.Database;

namespace VehicleHistory.Logic.DB
{
    public class VehicleHistoryContext : DbContext
    {

        public VehicleHistoryContext(DbContextOptions options) : base(options)
        {
        }

        protected VehicleHistoryContext()
        {
        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VehicleRecord> VehicleRecords { get; set; }
        public DbSet<DictionaryItem> DictionaryItems { get; set; }
        public DbSet<LocationApplication> LocationApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Id).IsUnique();
        }
    }

    public class VehicleHistoryContextFactory : IDesignTimeDbContextFactory<VehicleHistoryContext>
    {
        string connectionString = $"Server={Environment.MachineName};Database=ZIWG;Trusted_Connection=True;";
        public VehicleHistoryContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<VehicleHistoryContext>();
            builder.UseSqlServer(connectionString);

            return new VehicleHistoryContext(builder.Options);
        }
    }

}
