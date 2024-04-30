using Common.Enum;
using Order.Data.Models.Entities;

namespace Order.Data.Models.DTO
{
    public class OrderDTO
    {
        public int Id { get; init; }
        public string CustomerName { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public int Quantity { get; set; }
        public OrderStatusEnum Status { get; set; }

        public OrderDTO()
        {
            CustomerName = string.Empty;
        }

        public OrderDTO(OrderEntity entity)
        {
            Id = entity.Id;
            CustomerName = entity.CustomerName;
            ProductType = entity.ProductType;
            Quantity = entity.Quantity;
            Status = entity.Status;
        }
    }
}
