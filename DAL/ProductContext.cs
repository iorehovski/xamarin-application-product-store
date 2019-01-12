using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProductContext: DbContext
    {
        private readonly string _path;

        public DbSet<Product> Products { get; set; }

        public ProductContext(string path)
        {
            _path = path;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_path}");
        }
    }
}