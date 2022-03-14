using ControllerRestDemo.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ControllerRestDemo.DAL
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-94UMSFPO;Database=UserDb;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
