using Microsoft.EntityFrameworkCore;
using test2.Models;

namespace HW9.DataAcses
{
    public class AppDbContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=. ;Initial Catalog=test2; Integrated Security =true");
        }


        public DbSet<Product> products { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<Category> categories { get; set; }

    }
}
