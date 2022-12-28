using GeekShopping.CartAPI.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartAPI.Model.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<CartDetail> CartDetail { get; set; }
        public DbSet<CartHeader> CartHeader { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(GetConnectionString());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public string GetConnectionString()
        {
            return "Host=localhost;Port=5432;Pooling=true;Database=Geek_Shopping_Cart_API;User Id=postgres;Password=159357sa@";
        }

    }
}
