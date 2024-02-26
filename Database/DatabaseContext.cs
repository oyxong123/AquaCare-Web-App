using Microsoft.EntityFrameworkCore;
using AquaCare_Web_App.Models;

namespace AquaCare_Web_App.Database
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Sensor> Sensor { get; set; }
    }
}
