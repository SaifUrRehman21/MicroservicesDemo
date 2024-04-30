using Common.Enum;
using Microsoft.EntityFrameworkCore;
using Order.Data.Models.Entities;

namespace Order.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        { }

        public DbSet<OrderEntity> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>()
            .HasData(
                    new OrderEntity(1, "Customer Name", ProductTypeEnum.Engine, 1, OrderStatusEnum.New),
                    new OrderEntity(2, "Customer Name", ProductTypeEnum.Engine, 3, OrderStatusEnum.New),
                    new OrderEntity(3, "Customer Name", ProductTypeEnum.Chassis, 5, OrderStatusEnum.New),
                    new OrderEntity(4, "Customer Name", ProductTypeEnum.Chassis, 4, OrderStatusEnum.New)
                );
        }
    }
}
