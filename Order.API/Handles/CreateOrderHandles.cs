using MediatR;
using Order.API.Commands;
using Order.Data;
using Order.Data.Models.DTO;
using Order.Data.Models.Entities;

namespace Order.API.Handles
{
    public class CreateOrderHandles(OrderDbContext _dbContext) : IRequestHandler<CreateOrderCommand, OrderDTO>
    {
        public async Task<OrderDTO> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderEntity = new OrderEntity(0, command.CustomerName, command.ProductType, command.Quantity, command.Status);
            await _dbContext.Orders.AddAsync(orderEntity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new OrderDTO(orderEntity);
        }
    }
}
