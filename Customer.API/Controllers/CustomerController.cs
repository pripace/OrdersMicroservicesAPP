using Customer.Application.Features.Customers;
using Customer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerEntity>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllCustomersQuery());
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerEntity>> GetById(int id) 
    {
        var result = await _mediator.Send(new GetCustomerByIdQuery(id));
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerCommand command) 
    {
        if (id != command.Id)
            return BadRequest("El ID del cliente no coincide.");

        var result = await _mediator.Send(command);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) 
    {
        var result = await _mediator.Send(new DeleteCustomerCommand(id));
        if (!result)
            return NotFound();

        return NoContent();
    }

}

