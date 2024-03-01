using Progi_Test.Application.Interfaces;
using Progi_Test.Domain.Entities;
using Progi_Test.Domain.Enums;

namespace Progi_Test.Application.Services;

public class FeeService : IFeeService
{
    public async Task<List<Fee>> CalculateFees(Vehicle vehicle)
    {
        var fees = new List<Fee>();

        foreach (FeeType feeType in Enum.GetValues(typeof(FeeType)))
        {
            var fee = feeType switch
            {
                FeeType.Basic => await CalculateBasicFee(vehicle.Type, vehicle.BasePrice),
                FeeType.Special => await CalculateSpecialFee(vehicle.Type, vehicle.BasePrice),
                FeeType.Association => await CalculateAssociationFee(vehicle.BasePrice),
                FeeType.Storage => new Fee { FeeType = FeeType.Storage, Value = 100 }
            };
            fees.Add(fee!);
        }

        return fees;
    }

    private static Task<Fee> CalculateBasicFee(VehicleType type, decimal basePrice)
    {
        decimal minFee = 0, maxFee = 0;

        (minFee, maxFee) = type switch
        {
            VehicleType.Common => (10, 50),
            VehicleType.Luxury => (25, 200)
        };

        var feeValue = basePrice * 10 / 100;
        var basicFee = feeValue < minFee ? minFee : feeValue > maxFee ? maxFee : feeValue;

        return Task.FromResult(new Fee { FeeType = FeeType.Basic, Value = basicFee });
    }

    private static Task<Fee> CalculateSpecialFee(VehicleType type, decimal basePrice)
    {
        var specialFee = type switch
        {
            VehicleType.Common => basePrice * 2 / 100,
            VehicleType.Luxury => basePrice * 4 / 100
        };
        return Task.FromResult(new Fee { FeeType = FeeType.Special, Value = specialFee });
    }

    private static Task<Fee> CalculateAssociationFee(decimal basePrice)
    {
        var associationFee = basePrice switch
        {
            > 3000 => 20,
            > 1000 and <= 3000 => 15,
            > 500 and <= 1000 => 10,
            <= 500 => 5
        };
        return Task.FromResult(new Fee { FeeType = FeeType.Association, Value = associationFee });
    }
}