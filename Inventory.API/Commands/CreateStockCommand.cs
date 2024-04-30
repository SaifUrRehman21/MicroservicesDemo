using Common.Enum;
using Inventory.Data.Models.DTO;
using MediatR;

namespace Order.API.Commands
{
    public record CreateStockCommand(ProductTypeEnum ProductType, int Quantity) : IRequest<StockDTO>;
}
