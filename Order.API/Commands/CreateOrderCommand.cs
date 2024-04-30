using Common.Enum;
using MediatR;
using Order.Data.Models.DTO;

namespace Order.API.Commands
{
    public record CreateOrderCommand(string CustomerName, ProductTypeEnum ProductType, int Quantity, OrderStatusEnum Status) : IRequest<OrderDTO>;
}
