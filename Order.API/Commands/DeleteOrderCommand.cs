using Common.ErrorManagement;
using MediatR;

namespace Order.API.Commands
{
    public record DeleteOrderCommand(int Id) : IRequest<ServiceResult>;
}
