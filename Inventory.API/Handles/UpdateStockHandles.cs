using Inventory.API.Exceptions;
using Inventory.Data;
using Inventory.Data.Models.DTO;
using MediatR;
using Order.API.Commands;

namespace Order.API.Handles
{
    public class UpdateStockHandles(InventoryDbContext _dbContext) : IRequestHandler<UpdateStockCommand, StockDTO>
    {
        public async Task<StockDTO> Handle(UpdateStockCommand command, CancellationToken cancellationToken)
        {
            var stockEntity = await _dbContext.Stocks.FindAsync(command.Id, cancellationToken);
            if (stockEntity != null)
            {
                stockEntity.UpdateQunatity(command.Qunatity);

                _dbContext.Stocks.Update(stockEntity);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return stockEntity is null ? throw new StockNotFoundException(command.Id) : new StockDTO(stockEntity);
        }
    }
}
