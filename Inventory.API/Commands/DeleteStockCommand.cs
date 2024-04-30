using Common.ErrorManagement;
using MediatR;

namespace Order.API.Commands
{
    public record DeleteStockCommand(int Id) : IRequest<ServiceResult>;
}
