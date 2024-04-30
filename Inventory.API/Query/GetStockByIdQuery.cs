using Inventory.Data.Models.DTO;
using MediatR;

namespace Inventory.API.Query
{
    public record GetStockByIdQuery(int id) : IRequest<StockDTO>;
}
