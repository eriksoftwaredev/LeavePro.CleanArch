using AutoMapper;
using LeavePro.CleanArch.Application.Contracts.Email;
using LeavePro.CleanArch.Application.Contracts.Logging;
using LeavePro.CleanArch.Application.Contracts.Persistence;
using LeavePro.CleanArch.Application.Exceptions;
using LeavePro.CleanArch.Application.Models.Email;
using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveRequest.Commands.ApproveLeaveRequest;

public class ApproveLeaveRequestCommandHandler : IRequestHandler<ApproveLeaveRequestCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly IAppLogger<ApproveLeaveRequestCommandHandler> _logger;

    public ApproveLeaveRequestCommandHandler(ILeaveTypeRepository leaveTypeRepository,
        ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper,
        IEmailSender emailSender,
        IAppLogger<ApproveLeaveRequestCommandHandler> logger)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        _emailSender = emailSender;
        _logger = logger;
    }

    public async Task<Unit> Handle(ApproveLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequestToApprove = await _leaveRequestRepository.GetByIdAsync(request.Id);

        if (leaveRequestToApprove == null)
            throw new NotFoundException(nameof(Domain.LeaveRequest), request.Id);

        await _leaveRequestRepository.Approve(leaveRequestToApprove);

        try
        {
            var email = new EmailMessage
            {
                To = string.Empty, /* Get email from employee record */
                Body = $"Your leave request for {leaveRequestToApprove.StartDate:D} to {leaveRequestToApprove.EndDate:D} has been approved.",
                Subject = "Leave Request approved"
            };
            await _emailSender.SendEmail(email);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
        }

        return Unit.Value;
    }
}