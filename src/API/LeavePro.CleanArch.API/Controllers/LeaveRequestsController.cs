using LeavePro.CleanArch.Application.Features.LeaveRequest.Commands.ApproveLeaveRequest;
using LeavePro.CleanArch.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;
using LeavePro.CleanArch.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using LeavePro.CleanArch.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;
using LeavePro.CleanArch.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using LeavePro.CleanArch.Application.Features.LeaveRequest.Queries.GetGetLeaveRequestList;
using LeavePro.CleanArch.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeavePro.CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveRequestsController>
        [HttpGet]
        public async Task<ActionResult<LeaveRequestListDto>> Get()
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestListQuery());

            return Ok(leaveRequests);
        }

        // GET api/<LeaveRequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDetailDto>> Get(int id)
        {
            var leaveRequestDetail = await _mediator.Send(new GetLeaveRequestDetailQuery(id));

            return Ok(leaveRequestDetail);
        }

        // POST api/<LeaveRequestsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestCommand request)
        {
            var response = await _mediator.Send(request);

            return CreatedAtAction(nameof(Get), new { Id = response });
        }

        // PUT api/<LeaveRequestsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestCommand request)
        {
            if (id != request.Id)
                return BadRequest();

            await _mediator.Send(request);

            return NoContent();
        }

        // DELETE api/<LeaveRequestsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveRequestCommand(id));

            return NoContent();
        }

        // PUT api/<LeaveRequestsController>/5
        [HttpPut]
        [Route("CancelRequest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CancelRequest([FromBody] CancelLeaveRequestCommand request)
        {
            await _mediator.Send(request);

            return NoContent();
        }

        // PUT api/<LeaveRequestsController>/5
        [HttpPut]
        [Route("ApproveRequest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> ApproveRequest([FromBody] ApproveLeaveRequestCommand request)
        {
            await _mediator.Send(request);

            return NoContent();
        }
    }
}
