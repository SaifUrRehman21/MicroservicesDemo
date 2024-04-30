using Common.Enum;

namespace Order.Data.Models.Entities
{
    public class OrderEntity
    {
        public int Id { get; private set; }
        public string CustomerName { get; private set; }
        public ProductTypeEnum ProductType { get; private set; }
        public int Quantity { get; private set; }
        public OrderStatusEnum Status { get; private set; }

        public OrderEntity(int id, string customerName, ProductTypeEnum productType, int qunatity, OrderStatusEnum status)
        {
            Id = id;
            CustomerName = customerName;
            ProductType = productType;
            Quantity = qunatity;
            Status = status;
        }

        public void UpdateStatus(OrderStatusEnum status)
        {
            Status = status;
        }
    }
}
