using AutoMapper;
using LeavePro.CleanArch.Application.Contracts.Logging;
using LeavePro.CleanArch.Application.Contracts.Persistence;
using LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeavePro.CleanArch.Application.MappingProfiles;
using LeavePro.CleanArch.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace LeavePro.CleanArch.Application.UnitTests.Features.LeaveTypes.Queries;

public class GetLeaveTypesQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveTypeRepository> _leaveTypeRepository;
    private readonly Mock<IAppLogger<GetLeaveTypesQueryHandler>> _logger;
    public GetLeaveTypesQueryHandlerTests()
    {
        var mapperConfig = new MapperConfiguration(c =>
            c.AddProfile<LeaveTypeProfile>());

        _mapper = mapperConfig.CreateMapper();

        _leaveTypeRepository = MockLeaveTypeRepository.GetLeaveTypeRepository();

        _logger = new Mock<IAppLogger<GetLeaveTypesQueryHandler>>();
    }

    [Fact]
    public async Task GetLeaveTypesQuery()
    {
        var handler = new GetLeaveTypesQueryHandler(_mapper, _leaveTypeRepository.Object, _logger.Object);
        var result =await handler.Handle(new GetLeaveTypesQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<LeaveTypeDto>>();
        result.Count.ShouldBe(3);
    }
}
