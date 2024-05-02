using Inventory.API.Query;
using Inventory.Data.Models.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.API.Commands;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<StockDTO>> Get()
        {
            return await _mediator.Send(new GetStockQuery());
        }

        [HttpGet("{id}")]
        public async Task<StockDTO> Get(int id)
        {
            return await _mediator.Send(new GetStockByIdQuery(id));
        }

        [HttpPost]
        public async Task<StockDTO> Create([FromBody] StockDTO stock)
        {
            return await _mediator.Send(new CreateStockCommand(stock.ProductType, stock.Quantity));
        }

        [HttpPut("{id}")]
        public async Task<StockDTO> Update(int id, int qunatity)
        {
            return await _mediator.Send(new UpdateStockCommand(id, qunatity));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _mediator.Send(new DeleteStockCommand(id));
        }
    }
}
