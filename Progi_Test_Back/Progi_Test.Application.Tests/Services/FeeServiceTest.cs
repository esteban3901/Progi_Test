using Progi_Test.Application.Services;
using Progi_Test.Application.Tests.Theories;
using Progi_Test.Domain.Entities;
using Progi_Test.Domain.Enums;

namespace Progi_Test.Application.Tests.Services;

public class FeeServiceTests
{
    [Theory]
    [MemberData(nameof(VehicleDataTheory.GetVehicleInformationTestData), MemberType = typeof(VehicleDataTheory))]
    public async Task CalculateFees_ReturnsExpectedValues(VehicleType vehicleType, decimal basePrice,
        List<Fee> expectedFees, decimal expectedTotal)
    {
        var feeService = new FeeService();
        var vehicle = new Vehicle { Type = vehicleType, BasePrice = basePrice };

        var fees = await feeService.CalculateFees(vehicle);

        Assert.Equal(expectedTotal, basePrice + fees.Sum(x => x.Value));
    }
}