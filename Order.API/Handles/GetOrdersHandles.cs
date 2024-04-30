using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.API.Query;
using Order.Data;
using Order.Data.Models.DTO;

namespace Order.API.Handles
{
    public class GetOrdersHandles(OrderDbContext context) : IRequestHandler<GetOrdersQuery, IEnumerable<OrderDTO>>
    {
        public async Task<IEnumerable<OrderDTO>> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            var result = await context.Orders.ToListAsync();
            return result.Select(x => new OrderDTO(x));
        }
    }
}
