using MediatR;
using Order.API.Commands;
using Order.API.Exceptions;
using Order.Data;
using Order.Data.Models.DTO;

namespace Order.API.Handles
{
    public class UpdateOrderHandles(OrderDbContext _dbContext) : IRequestHandler<UpdateOrderCommand, OrderDTO>
    {
        public async Task<OrderDTO> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderEntity = await _dbContext.Orders.FindAsync(command.Id, cancellationToken);
            if (orderEntity != null)
            {
                orderEntity.UpdateStatus(command.Status);

                _dbContext.Orders.Update(orderEntity);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return orderEntity is null ? throw new OrderNotFoundException(command.Id) : new OrderDTO(orderEntity);
        }
    }
}
