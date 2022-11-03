using Application.Customers.Commands;
using Application.Customers.Queries;
using Application.Houses.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Customer>> GetCustomers([FromQuery] GetCustomersQuerie query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        public async Task<Customer> GetCustomer([FromQuery] GetCustomerQuerie query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task<Guid> AddCustomer([FromBody] CreateCustomerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<Guid> EditCustomer([FromBody] EditCustomerCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost]
        public async Task DeleteCustomer(DeleteCustomerCommand command)
        {
            await _mediator.Send(command);
        }
    }
}
