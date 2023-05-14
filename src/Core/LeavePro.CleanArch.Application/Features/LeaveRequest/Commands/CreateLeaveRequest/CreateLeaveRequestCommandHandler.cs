using AutoMapper;
using LeavePro.CleanArch.Application.Contracts.Email;
using LeavePro.CleanArch.Application.Contracts.Logging;
using LeavePro.CleanArch.Application.Contracts.Persistence;
using LeavePro.CleanArch.Application.Exceptions;
using LeavePro.CleanArch.Application.Models.Email;
using LeavePro.CleanArch.Domain;
using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly IAppLogger<CreateLeaveRequestCommandHandler> _logger;

    public CreateLeaveRequestCommandHandler(ILeaveTypeRepository leaveTypeRepository,
        ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper,
        IEmailSender emailSender,
        IAppLogger<CreateLeaveRequestCommandHandler> logger)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        _emailSender = emailSender;
        _logger = logger;
    }

    public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveRequestCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Leave Request", validationResult);

        var leaveRequestToCreate = _mapper.Map<Domain.LeaveRequest>(request);

        leaveRequestToCreate.RequestDate = DateTime.UtcNow;

        await _leaveRequestRepository.CreateAsync(leaveRequestToCreate);

        try
        {
            var email = new EmailMessage
            {
                To = string.Empty, /* Get email from employee record */
                Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
                       $"has been submitted successfully.",
                Subject = "Leave Request Submitted"
            };

            await _emailSender.SendEmail(email);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
        }

        return leaveRequestToCreate.Id;
    }
}