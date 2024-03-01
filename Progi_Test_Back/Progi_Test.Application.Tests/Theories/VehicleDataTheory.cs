using Progi_Test.Domain.Entities;
using Progi_Test.Domain.Enums;

namespace Progi_Test.Application.Tests.Theories;

public class VehicleDataTheory
{
    public static IEnumerable<object[]> GetVehicleInformationTestData =>
        new List<object[]>
        {
            new object[]
            {
                VehicleType.Common,
                398,
                550.76
            },
            new object[]
            {
                VehicleType.Common,
                501,
                new List<Fee>
                {
                    new Fee { FeeType = FeeType.Basic, Value = 50m },
                    new Fee { FeeType = FeeType.Special, Value = 10.02m },
                    new Fee { FeeType = FeeType.Association, Value = 10m },
                    new Fee { FeeType = FeeType.Storage, Value = 100m }
                },
                671.02
            },
            new object[]
            {
                VehicleType.Common,
                57,
                new List<Fee>
                {
                    new Fee { FeeType = FeeType.Basic, Value = 10m },
                    new Fee { FeeType = FeeType.Special, Value = 1.14m },
                    new Fee { FeeType = FeeType.Association, Value = 5m },
                    new Fee { FeeType = FeeType.Storage, Value = 100m }
                },
                173.14
            },
            new object[]
            {
                VehicleType.Luxury,
                1800,
                new List<Fee>
                {
                    new Fee { FeeType = FeeType.Basic, Value = 180m },
                    new Fee { FeeType = FeeType.Special, Value = 72m },
                    new Fee { FeeType = FeeType.Association, Value = 15m },
                    new Fee { FeeType = FeeType.Storage, Value = 100m }
                },
                2167
            },
            new object[]
            {
                VehicleType.Common,
                1100,
                new List<Fee>
                {
                    new Fee { FeeType = FeeType.Basic, Value = 50m },
                    new Fee { FeeType = FeeType.Special, Value = 22m },
                    new Fee { FeeType = FeeType.Association, Value = 15m },
                    new Fee { FeeType = FeeType.Storage, Value = 100m }
                },
                1287
            },
            new object[]
            {
                VehicleType.Luxury,
                1000000,
                new List<Fee>
                {
                    new Fee { FeeType = FeeType.Basic, Value = 200m },
                    new Fee { FeeType = FeeType.Special, Value = 40000m },
                    new Fee { FeeType = FeeType.Association, Value = 20m },
                    new Fee { FeeType = FeeType.Storage, Value = 100m }
                },
                1040320
            }
        };
}