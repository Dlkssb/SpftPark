using Application.Customers.Commands;
using Application.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("~/GetCustomers")]
        public async Task<ActionResult> GetCustomers([FromQuery] GetCustomersQuerie query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("~/GetCustomer")]
        public async Task<ActionResult> GetCustomer([FromQuery] GetCustomerQuerie query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("~/AddCustomer")]
        public async Task<ActionResult> AddCustomer([FromBody] CreateCustomerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("~/EditCustomer")]
        public async Task<ActionResult> EditCustomer([FromBody] EditCustomerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("~/DeleteCustomer")]
        public async Task<ActionResult> DeleteCustomer([FromBody] DeleteCustomerCommand command)
        {
           return Ok( await _mediator.Send(command));
        }
    }
}
