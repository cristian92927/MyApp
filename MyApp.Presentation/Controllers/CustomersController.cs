using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Customers.Commands.CreateCustomer;
using MyApp.Application.Customers.Queries.GetCustomerById;
using MyApp.Application.Orders.Commands.CreateOrder;

namespace MyApp.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomersController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand cmd)
    {
        var id = await _mediator.Send(cmd);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var dto = await _mediator.Send(new GetCustomerByIdQuery(id));
        if (dto == null) return NotFound();
        return Ok(dto);
    }

    [HttpPost("{id:guid}/orders")]
    public async Task<IActionResult> CreateOrder(Guid id, [FromBody] CreateOrderCommand cmd)
    {
        var command = cmd with { CustomerId = id };
        var orderId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, new { orderId });
    }
}