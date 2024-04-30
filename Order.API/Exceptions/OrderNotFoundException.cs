using Common.ErrorManagement.Exceptions;

namespace Order.API.Exceptions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(int id) : base("Order", id)
        {

        }
    }
}
