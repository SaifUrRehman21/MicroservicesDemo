using Common.Enum;
using Inventory.Data.Models.Entities;

namespace Inventory.Data.Models.DTO
{
    public class StockDTO
    {
        public int Id { get; init; }
        public ProductTypeEnum ProductType { get; set; }
        public int Quantity { get; set; }

        public StockDTO(StockEntity entity)
        {
            Id = entity.Id;
            ProductType = entity.ProductType;
            Quantity = entity.Quantity;
        }
    }
}
