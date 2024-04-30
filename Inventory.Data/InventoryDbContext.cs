using Common.Enum;
using Inventory.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        { }

        public DbSet<StockEntity> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockEntity>()
            .HasData(
                    new StockEntity(1, ProductTypeEnum.Engine, 5)
                );
        }
    }
}
