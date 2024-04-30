using Inventory.Data.Models.DTO;
using MediatR;

namespace Inventory.API.Query
{
    public record GetStockQuery() : IRequest<IEnumerable<StockDTO>>;
}
