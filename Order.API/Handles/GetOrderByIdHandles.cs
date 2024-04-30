using MediatR;
using Order.API.Exceptions;
using Order.API.Query;
using Order.Data;
using Order.Data.Models.DTO;

namespace Order.API.Handles
{
    public class GetOrderByIdHandles(OrderDbContext context) : IRequestHandler<GetOrderByIdQuery, OrderDTO>
    {
        public async Task<OrderDTO> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await context.Orders.FindAsync(query.id, cancellationToken);
            return result is null ? throw new OrderNotFoundException(query.id) : new OrderDTO(result);
        }
    }
}
