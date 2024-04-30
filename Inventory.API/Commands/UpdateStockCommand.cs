using Inventory.Data.Models.DTO;
using MediatR;

namespace Order.API.Commands
{
    public record UpdateStockCommand(int Id, int Qunatity) : IRequest<StockDTO>;
}
