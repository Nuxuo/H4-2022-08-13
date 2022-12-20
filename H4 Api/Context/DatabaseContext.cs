using Microsoft.EntityFrameworkCore;
using Models;

namespace Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}
        public DbSet<Hub> Hub { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Building> Building { get; set; }
        public DbSet<HubSensors> HubSensors { get; set; }
        public DbSet<DataPackage> DataPackage { get; set; }
        public DbSet<Sensor> Sensor { get; set; }
        public DbSet<SensorData> SensorData { get; set; }
    }
}