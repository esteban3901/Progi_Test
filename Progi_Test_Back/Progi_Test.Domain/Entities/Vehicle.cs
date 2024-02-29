using Progi_Test.Domain.Enums;

namespace Progi_Test.Domain.Entities;

public class Vehicle
{
    public VehicleType Type { get; set; }
    public decimal BasePrice { get; set; }
}