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
    }

    public class VehicleHistoryContextFactory : IDesignTimeDbContextFactory<VehicleHistoryContext>
    {
        const string ConnectionString = "Server=E7450;Database=VehicleHistory;Trusted_Connection=True;";
        public VehicleHistoryContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<VehicleHistoryContext>();
            builder.UseSqlServer(ConnectionString);

            return new VehicleHistoryContext(builder.Options);
        }
    }

}
