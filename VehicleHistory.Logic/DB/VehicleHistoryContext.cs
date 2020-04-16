using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Enums;

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

            modelBuilder.Entity<DictionaryItem>().HasData(
                new DictionaryItem
                {
                    Id = Guid.NewGuid(),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DictionaryType = DictionaryType.LocationTypes,
                    EnumValue = (int)LocationTypes.BodyShop,
                    StringValue = "Lakiernia",
                },
                new DictionaryItem
                {
                    Id = Guid.NewGuid(),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DictionaryType = DictionaryType.LocationTypes,
                    EnumValue = (int)LocationTypes.IndependentService,
                    StringValue = "Niezależny Serwis",
                },
                new DictionaryItem
                {
                    Id = Guid.NewGuid(),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DictionaryType = DictionaryType.LocationTypes,
                    EnumValue = (int)LocationTypes.ManufacturerAuthorizedService,
                    StringValue = "Autoryzowany Serwis Obsługi",
                },
                new DictionaryItem
                {
                    Id = Guid.NewGuid(),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DictionaryType = DictionaryType.LocationTypes,
                    EnumValue = (int)LocationTypes.TyreShop,
                    StringValue = "Wulkanizator",
                },
                new DictionaryItem
                {
                    Id = Guid.NewGuid(),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DictionaryType = DictionaryType.LocationTypes,
                    EnumValue = (int)LocationTypes.InspectionStation,
                    StringValue = "Stacja kontroli pojazdów",
                },
                new DictionaryItem
                {
                    Id = Guid.NewGuid(),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DictionaryType = DictionaryType.RecordTypes,
                    EnumValue = (int)RecordTypes.AccidentRepair,
                    StringValue = "Naprawa po kolizji",
                },
                new DictionaryItem
                {
                    Id = Guid.NewGuid(),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DictionaryType = DictionaryType.RecordTypes,
                    EnumValue = (int)RecordTypes.ElectronicsRepair,
                    StringValue = "Naprawa elektroniki",
                },
                new DictionaryItem
                {
                    Id = Guid.NewGuid(),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DictionaryType = DictionaryType.RecordTypes,
                    EnumValue = (int)RecordTypes.MechanicalRepair,
                    StringValue = "Naprawa elementów mechanicznych",
                },
                new DictionaryItem
                {
                    Id = Guid.NewGuid(),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DictionaryType = DictionaryType.RecordTypes,
                    EnumValue = (int)RecordTypes.MechanicalUpgrade,
                    StringValue = "Instalacja ulepszeń",
                },
                new DictionaryItem
                {
                    Id = Guid.NewGuid(),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DictionaryType = DictionaryType.RecordTypes,
                    EnumValue = (int)RecordTypes.ScheduledMaintenance,
                    StringValue = "Okresowy serwis",
                },
                new DictionaryItem
                {
                    Id = Guid.NewGuid(),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DictionaryType = DictionaryType.RecordTypes,
                    EnumValue = (int)RecordTypes.SoftwareUpgrade,
                    StringValue = "Aktualizacja oprogramowania",
                },
                new DictionaryItem
                {
                    Id = Guid.NewGuid(),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DictionaryType = DictionaryType.RecordTypes,
                    EnumValue = (int)RecordTypes.TyreChange,
                    StringValue = "Wymiana opon",
                },
                new DictionaryItem
                {
                    Id = Guid.NewGuid(),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DictionaryType = DictionaryType.UserGroups,
                    EnumValue = (int)UserGroups.ShopEmployee,
                    StringValue = "Pracownicy placówek",
                },
                new DictionaryItem
                {
                    Id = Guid.NewGuid(),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DictionaryType = DictionaryType.UserGroups,
                    EnumValue = (int)UserGroups.ShopOwner,
                    StringValue = "Kierownicy placówek",
                },
                new DictionaryItem
                {
                    Id = Guid.NewGuid(),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DictionaryType = DictionaryType.UserGroups,
                    EnumValue = (int)UserGroups.SysAdmin,
                    StringValue = "Administratorzy",
                }
            );

            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = Guid.Parse("a472e3e7-1db7-4c92-b686-671a04ce8f60"),
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Name = "test",
                    LocationType = LocationTypes.BodyShop,
                    Line1 = "Testowa 1",
                    Line2 = "Testowo",
                    ZipCode = "12-345"
                }
            );
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
