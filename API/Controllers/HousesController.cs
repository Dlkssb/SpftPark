using Application.Customers.Queries;
using Application.Houses.Commands;
using Application.Houses.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HousesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<House>> GetCustomers([FromQuery] GetHousesQuerie query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        public async Task<House> GetCustomers([FromQuery] GetHouseQuerie query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task<Guid> CreateHouse(CreateHouseCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost]
        public async Task<Guid> EditHouse(EditHouseCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost]
        public async Task DeleteHouse(DeleteHouseCommand command)
        {
             await _mediator.Send(command);
        }
    }
}
