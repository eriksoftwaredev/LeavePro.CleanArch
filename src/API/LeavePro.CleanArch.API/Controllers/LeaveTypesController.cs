using System.Net;
using LeavePro.CleanArch.Application.Features.LeaveType.Commands.CreateLeaveType;
using LeavePro.CleanArch.Application.Features.LeaveType.Commands.DeleteLeaveType;
using LeavePro.CleanArch.Application.Features.LeaveType.Commands.UpdateLeaveType;
using LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeavePro.CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypesQuery());

            return Ok(leaveTypes);
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDetailsDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));

            return Ok(leaveType);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post([FromBody] CreateLeaveTypeCommand request)
        {
            var response = await _mediator.Send(request);

            return CreatedAtAction(nameof(Get), new { id = response });

        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveTypeCommand request)
        {
            if (id != request.Id)
                return BadRequest();

            await _mediator.Send(request);

            return NoContent();
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveTypeCommand(id));

            return NoContent();
        }
    }
}
