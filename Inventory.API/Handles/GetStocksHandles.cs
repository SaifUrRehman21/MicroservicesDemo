using Inventory.API.Query;
using Inventory.Data;
using Inventory.Data.Models.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Handles
{
    public class GetStocksHandles(InventoryDbContext context) : IRequestHandler<GetStockQuery, IEnumerable<StockDTO>>
    {
        public async Task<IEnumerable<StockDTO>> Handle(GetStockQuery query, CancellationToken cancellationToken)
        {
            var result = await context.Stocks.ToListAsync();
            return result.Select(x => new StockDTO(x));
        }
    }
}
