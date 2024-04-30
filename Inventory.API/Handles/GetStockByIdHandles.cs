using Inventory.API.Exceptions;
using Inventory.API.Query;
using Inventory.Data;
using Inventory.Data.Models.DTO;
using MediatR;

namespace Inventory.API.Handles
{
    public class GetStockByIdHandles(InventoryDbContext context) : IRequestHandler<GetStockByIdQuery, StockDTO>
    {
        public async Task<StockDTO> Handle(GetStockByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await context.Stocks.FindAsync(query.id, cancellationToken);
            return result is null ? throw new StockNotFoundException(query.id) : new StockDTO(result);
        }
    }
}
