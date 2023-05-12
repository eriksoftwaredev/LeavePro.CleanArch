using LeavePro.CleanArch.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using LeavePro.CleanArch.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using LeavePro.CleanArch.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using LeavePro.CleanArch.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using LeavePro.CleanArch.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using LeavePro.CleanArch.Application.Features.LeaveType.Commands.CreateLeaveType;
using LeavePro.CleanArch.Application.Features.LeaveType.Commands.DeleteLeaveType;
using LeavePro.CleanArch.Application.Features.LeaveType.Commands.UpdateLeaveType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeavePro.CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveAllocationsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationsQuery());

            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDetailsDto>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationWithDetailsQuery(id));

            return Ok(leaveAllocation);
        }

        // POST api/<LeaveAllocationsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationCommand request)
        {
            var result = await _mediator.Send(request);

            return CreatedAtAction(nameof(Get), new { id = result });
        }

        // PUT api/<LeaveAllocationsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveAllocationCommand request)
        {
            if (id != request.Id)
                return BadRequest();

            await _mediator.Send(request);

            return NoContent();
        }

        // DELETE api/<LeaveAllocationsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveAllocationCommand(id));

            return NoContent();
        }
    }
}
