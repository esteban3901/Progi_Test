using Progi_Test.Application.Features.Fee.Vms;
using Progi_Test.Domain.Enums;

namespace Progi_Test.Application.Features.Vehicle.Vms;

public class VehicleVm
{
    public string? Type { get; set; }
    public decimal BasePrice { get; set; }
    public decimal Total { get; set; }
    public List<FeeVm>? Fees { get; set; }
}