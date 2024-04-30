using Common.Enum;
using MediatR;
using Order.Data.Models.DTO;

namespace Order.API.Commands
{
    public record UpdateOrderCommand(int Id, OrderStatusEnum Status) : IRequest<OrderDTO>;
}
