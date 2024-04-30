using MediatR;
using Order.Data.Models.DTO;

namespace Order.API.Query
{
    public record GetOrderByIdQuery(int id) : IRequest<OrderDTO>;
}
