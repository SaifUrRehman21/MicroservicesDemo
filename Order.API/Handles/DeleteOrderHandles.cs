using Common.ErrorManagement;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.API.Commands;
using Order.Data;

namespace Order.API.Handles
{
    public class DeleteOrderHandles(OrderDbContext _dbContext) : IRequestHandler<DeleteOrderCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            ServiceResult result = ServiceResult.Success();
            try
            {
                await _dbContext.Orders.Where(x => x.Id == command.Id).ExecuteDeleteAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                result = ServiceResult.Failed(new ServiceErrors(ServiceErrorCode.BadRequest, ex.Message));
            }
            return result;
        }
    }
}
