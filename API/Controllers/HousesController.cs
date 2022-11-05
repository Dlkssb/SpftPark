using Application.Customers.Queries;
using Application.Houses.Commands;
using Application.Houses.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HousesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HousesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("~/GetHouses")]
        public async Task<ActionResult> GetHouses([FromQuery] GetHousesQuerie query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("~/GetHouse")]
        public async Task<ActionResult> GetHouse([FromQuery] GetHouseQuerie query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("~/CreateHouse")]
        public async Task<ActionResult> CreateHouse([FromBody] CreateHouseCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("EditHouse")]
        public async Task<ActionResult> EditHouse([FromBody] EditHouseCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("DeleteHouse")]
        public async Task<ActionResult> DeleteHouse([FromBody] DeleteHouseCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
