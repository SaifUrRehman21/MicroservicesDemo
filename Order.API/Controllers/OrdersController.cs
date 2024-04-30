using Common.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.API.Commands;
using Order.API.Query;
using Order.Data.Models.DTO;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> Get(int pageNumber = 1, int pageSize = 10)
        {
            return await _mediator.Send(new GetOrdersQuery(pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<OrderDTO> Get(int id)
        {
            return await _mediator.Send(new GetOrderByIdQuery(id));
        }

        [HttpPost]
        public async Task<OrderDTO> Create(OrderDTO order)
        {
            return await _mediator.Send(new CreateOrderCommand(order.CustomerName, order.ProductType, order.Quantity, order.Status));
        }

        [HttpPut("{id}")]
        public async Task<OrderDTO> Update(int id, OrderStatusEnum Status)
        {
            return await _mediator.Send(new UpdateOrderCommand(id, Status));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _mediator.Send(new DeleteOrderCommand(id));
        }
    }
}
