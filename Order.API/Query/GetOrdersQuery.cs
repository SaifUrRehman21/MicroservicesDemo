using MediatR;
using Order.Data.Models.DTO;

namespace Order.API.Query
{
    public record GetOrdersQuery(int? PageNumber, int? PageSize) : IRequest<IEnumerable<OrderDTO>>;
}
