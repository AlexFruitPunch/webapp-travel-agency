using Microsoft.EntityFrameworkCore;
using Travel_Agency.Models;

namespace Travel_Agency.Database
{
    public class TravelAgencyContext : DbContext
    {
        public DbSet<PacchettoViaggio>? Pizze { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=Travel_Agency;Integrated Security=True");
        }
    }
}
