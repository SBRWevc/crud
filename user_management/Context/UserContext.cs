using Microsoft.EntityFrameworkCore;

using user_management.Models;

namespace user_management.Context
{
    public class UserContext : DbContext
    {
        public DbSet<UserViewModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=users.db");
        }
    }
}
