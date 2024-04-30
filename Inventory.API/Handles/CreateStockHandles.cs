using Inventory.Data;
using Inventory.Data.Models.DTO;
using Inventory.Data.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.API.Commands;

namespace Order.API.Handles
{
    public class CreateStockHandles(InventoryDbContext _dbContext) : IRequestHandler<CreateStockCommand, StockDTO>
    {
        public async Task<StockDTO> Handle(CreateStockCommand command, CancellationToken cancellationToken)
        {
            StockEntity entity;
            if (!await _dbContext.Stocks.AnyAsync(x => x.ProductType == command.ProductType, cancellationToken))
            {
                entity = new StockEntity(0, command.ProductType, command.Quantity);
                await _dbContext.Stocks.AddAsync(entity, cancellationToken);
            }
            else
            {
                entity = await _dbContext.Stocks.SingleAsync(x => x.ProductType == command.ProductType, cancellationToken);
                entity.UpdateQunatity(command.Quantity);
                _dbContext.Update(entity);
            }
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new StockDTO(entity);
        }
    }
}
