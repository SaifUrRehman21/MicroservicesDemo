using Common.ErrorManagement;
using Inventory.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.API.Commands;

namespace Order.API.Handles
{
    public class DeleteStockHandles(InventoryDbContext _dbContext) : IRequestHandler<DeleteStockCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteStockCommand command, CancellationToken cancellationToken)
        {
            ServiceResult result = ServiceResult.Success();
            try
            {
                await _dbContext.Stocks.Where(x => x.Id == command.Id).ExecuteDeleteAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                result = ServiceResult.Failed(new ServiceErrors(ServiceErrorCode.BadRequest, ex.Message));
            }
            return result;
        }
    }
}
