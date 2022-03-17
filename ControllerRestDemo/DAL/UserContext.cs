using ControllerRestDemo.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ControllerRestDemo.DAL
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
