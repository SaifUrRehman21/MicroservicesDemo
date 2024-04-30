using Common.Enum;

namespace Inventory.Data.Models.Entities
{
    public class StockEntity
    {
        public int Id { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public int Quantity { get; set; }

        public StockEntity(int id, ProductTypeEnum productType, int quantity)
        {
            Id = id;
            ProductType = productType;
            Quantity = quantity;
        }

        public void UpdateQunatity(int qunatity)
        {
            Quantity += qunatity;
        }
    }
}
