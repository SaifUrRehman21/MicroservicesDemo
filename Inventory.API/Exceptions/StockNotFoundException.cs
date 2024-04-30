using Common.ErrorManagement.Exceptions;

namespace Inventory.API.Exceptions
{
    public class StockNotFoundException : NotFoundException
    {
        public StockNotFoundException(int id) : base("Stock", id)
        { }
    }
}
