using Microsoft.EntityFrameworkCore;
using AquaCare_Web_App.Models;

namespace AquaCare_Web_App.Database
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string debugConnectionString = "Server=DESKTOP-BU9N8KA\\SQLEXPRESS;Database=AquaCareWebApp_Database_Debug;Trusted_Connection=True;Encrypt=False;";
            optionsBuilder.UseSqlServer(debugConnectionString);
        }

        public DbSet<Sensor> Sensor { get; set; }
    }
}
