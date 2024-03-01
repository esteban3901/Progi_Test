using AutoMapper;
using Moq;
using Progi_Test.Application.Features.Fee.Vms;
using Progi_Test.Application.Features.Vehicle.Queries.GetVehicleInformation;
using Progi_Test.Application.Features.Vehicle.Vms;
using Progi_Test.Application.Interfaces;
using Progi_Test.Application.Tests.Theories;
using Progi_Test.Domain.Entities;
using Progi_Test.Domain.Enums;

namespace Progi_Test.Application.Tests.Features.Vehicle;

public class GetVehicleInformationQueryHandlerTest
{
    private readonly Mock<IFeeService> _mockFeeService = new();
    private readonly Mock<IMapper> _mockMapper = new();

    [Theory]
    [MemberData(nameof(VehicleDataTheory.GetVehicleInformationTestData), MemberType = typeof(VehicleDataTheory))]
    public async Task Handle_ReturnsCorrectVehicleInformation(VehicleType vehicleType, decimal basePrice,
        List<Fee> expectedFees, decimal expectedTotal)
    {
        var vehicle = new VehicleVm { Type = vehicleType.ToString(), BasePrice = basePrice };

        _mockFeeService.Setup(x => x.CalculateFees(It.IsAny<Domain.Entities.Vehicle>())).ReturnsAsync(expectedFees);
        _mockMapper.Setup(x => x.Map<VehicleVm>(It.IsAny<object>())).Returns(vehicle);
        _mockMapper.Setup(x => x.Map<List<FeeVm>>(It.IsAny<List<Fee>>())).Returns(expectedFees
            .Select(f => new FeeVm { FeeName = f.FeeType.ToString(), Value = f.Value }).ToList());

        var handler = new GetVehicleInformationQueryHandler(_mockFeeService.Object, _mockMapper.Object);
        var request = new GetVehicleInformationQuery { Vehicle = new() { Type = vehicleType, BasePrice = basePrice } };

        var result = await handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(vehicle.Type, result.Type);
        Assert.Equal(vehicle.BasePrice, result.BasePrice);
        Assert.Equal(expectedTotal, result.Total);
    }
}